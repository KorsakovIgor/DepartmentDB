using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity.Validation;

namespace Test
{
    public partial class InsertForm : Form
    {
        CompaniesContext db;
        List<Department> DepartmentsList;

        public InsertForm(CompaniesContext db)
        {
            InitializeComponent();
            this.db = db;
            DepartmentsList = new List<Department>();
            foreach (Department departments in db.Department)
            {
                //if (departments.Department1.Count==0)
               // {
                    DepartmentComboBox.Items.Add(departments.Name);
                    DepartmentsList.Add(departments);
               // }
            }
        }

        string message = "";

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                db.Empoyee.Add(new Empoyee
                {
                    FirstName = FirstName.Text.ToString(),
                    SurName = SurName.Text.ToString(),
                    Patronymic = Patronymic.Text.ToString(),
                    DateOfBirth = DateOfBirth.Value,
                    Department = DepartmentsList[DepartmentComboBox.SelectedIndex],
                    DocNumber = DocNumber.Text.ToString(),
                    DocSeries = DocSeries.Text.ToString(),
                    Position = Position.Text.ToString(),
                    DepartmentID = DepartmentsList[DepartmentComboBox.SelectedIndex].ID
                });

                db.SaveChanges();
                MessageBox.Show("Успешно добавлено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    message = "Object: " + validationError.Entry.Entity.ToString();

                    foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        message = message + err.ErrorMessage + "";
                    }
                }
                MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Поле не заполнено", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    
    }
}
