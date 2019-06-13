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
    public partial class Form1 : Form
    {
        CompaniesContext db;
        public Form1()
        {
            InitializeComponent();
            db = new CompaniesContext();
            TreeNode tree = new TreeNode("Фирмы");
            tree.Name = "root";
            treeView1.Nodes.Add(tree);
            IQueryable<Department> roots = db.Department.Where(x => x.ParentDepartmentID == null);
            foreach(Department u in roots)
            {
                ViewTree(u, tree);
            }
            
        }

        private void insertEmployeeButton_Click(object sender, EventArgs e)
        {
            Insert();
        }


        public void Insert()
        {
            InsertForm insert = new InsertForm(db);
            insert.Show();
        }

        public void EmployeeInDepartment(Guid id)
        {
            ListOfEmployees listOfEmployees = new ListOfEmployees(db, id);
            listOfEmployees.Show();
        }
            
        public void ViewTree (Department department, TreeNode treeNode)
        {
            TreeNode newNode = new TreeNode();
            newNode.Name = department.ID.ToString();
            newNode.Text = department.Name;
            treeNode.Nodes.Add(newNode);
            foreach (Department u in department.Department1)
            {
                ViewTree(u, newNode);
            }
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Name != "root")
            {
                ListOfEmployees listOfEmployees = new ListOfEmployees(db, new Guid(treeView1.SelectedNode.Name));
                listOfEmployees.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Для вывода всех работников отдела используйте двойной щелчок мыши\nДля вывода информации о работнике также используется двойной щелчок мыши", "Справка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
