using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class ListOfEmployees : Form
    {
        CompaniesContext db;
        List<decimal> employersIndexes;
        public ListOfEmployees(CompaniesContext db, Guid id)
        {
            InitializeComponent();
            employersIndexes = new List<decimal>();
            this.db = db;
            Department department = db.Department.Find(id);

            this.Text = department.Name;
            AllEmployee(department);
        }

        public void AllEmployee(Department department)
        {
            IQueryable<Empoyee> empoyees = db.Empoyee.Where(x => x.DepartmentID == department.ID);

            foreach (Empoyee u in empoyees)
            {
                listOfEmployee.Items.Add(u.FirstName+" "+u.SurName+" "+u.Patronymic+"           Должность: "+u.Position);
                employersIndexes.Add(u.ID);
            }

            foreach (Department u in department.Department1)
            {
                AllEmployee(u);
            }
        }

        private void listOfEmployee_DoubleClick(object sender, EventArgs e)
        {
            if (listOfEmployee.SelectedIndex >=0)
            {
                Update(employersIndexes[listOfEmployee.SelectedIndex]);
            }
        }

        public void Update(decimal id)
        {
            EmployeeForm emp = new EmployeeForm(db, id);
            emp.Show();
        }
    }
}
