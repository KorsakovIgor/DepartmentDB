using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class EmployeeForm : Form
    {
        CompaniesContext db;
        List<Department> DepartmentsList;
        decimal id;
        Empoyee empoyee;

        public EmployeeForm(CompaniesContext db, decimal id)
        {
            InitializeComponent();

            this.db = db;
            this.id = id;
            DepartmentsList = new List<Department>();

            this.empoyee = db.Empoyee.Find(id);
            this.Text = empoyee.SurName + " " + empoyee.FirstName;
            FirstName.Text = empoyee.FirstName;
            SurName.Text = empoyee.SurName;
            Patronymic.Text = empoyee.Patronymic;
            DateOfBirth.Value = empoyee.DateOfBirth;
            DocSeries.Text = empoyee.DocSeries;
            DocNumber.Text = empoyee.DocNumber;
            Position.Text = empoyee.Position;

            foreach (Department departments in db.Department)
            {

                DepartmentComboBox.Items.Add(departments.Name);
                DepartmentsList.Add(departments);
                

                if(departments.ID==empoyee.DepartmentID)
                {
                    
                    DepartmentComboBox.SelectedIndex = DepartmentComboBox.Items.Count - 1;
                }
            }

            var today = DateTime.Today;
            var age = today.Year - empoyee.DateOfBirth.Year;
            if (empoyee.DateOfBirth > today.AddYears(-age)) age--;
            Age.Text = age.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = "";
            try
            {
                empoyee.FirstName = FirstName.Text.ToString();
                empoyee.SurName = SurName.Text.ToString();
                empoyee.Patronymic = Patronymic.Text.ToString();
                empoyee.DateOfBirth = DateOfBirth.Value;
                empoyee.Department = DepartmentsList[DepartmentComboBox.SelectedIndex];
                empoyee.DocNumber = DocNumber.Text.ToString();
                empoyee.DocSeries = DocSeries.Text.ToString();
                empoyee.Position = Position.Text.ToString();
                empoyee.DepartmentID = DepartmentsList[DepartmentComboBox.SelectedIndex].ID;

                db.SaveChanges();

                MessageBox.Show("Успешно отредактировано", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
