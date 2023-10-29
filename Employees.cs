using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeManagementSystem
{
    public partial class Employees : Form
    {
        Functions Con;
        public Employees()
        {
            InitializeComponent();
            Con = new Functions();
            ShowEmployee();
            GetDepartment();
        }
        private void ShowEmployee()
        {
            string Query = "Select * from EmployeeTbl";
            EmployeeList.DataSource = Con.GetData(Query);
        }
        private void GetDepartment()
        {
            string Query = "SELECT * FROM DepartmentTbl";
            DepCb.DisplayMember = Con.GetData(Query).Columns["DepName"].ToString();
            DepCb.ValueMember = Con.GetData(Query).Columns["DepId"].ToString();
            DepCb.DataSource = Con.GetData(Query);
        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (EmpNameTb.Text == "" || GenCb.SelectedIndex==-1 || DepCb.SelectedIndex==-1 || DailySalTb.Text=="")
                {
                    MessageBox.Show("Missing Data...");
                }
                else
                {
                    string Name = EmpNameTb.Text;
                    string Gender = GenCb.SelectedItem.ToString();
                    string Department;
                    if (DepCb.SelectedItem != null)
                    {
                        DataRowView selectedRow = (DataRowView)DepCb.SelectedItem;
                        Department = selectedRow["DepId"].ToString();
                        // Now 'department' contains the department name.
                    }
                    else
                    {
                        MessageBox.Show("Invalid Department value");
                        Department = "";
                    }
                    string DOB = DOBTb.Value.ToString();
                    string JoinDate = JDate.Value.ToString();
                    int  Salary = Convert.ToInt32(DailySalTb.Text);
                    string Query = "INSERT INTO EmployeeTbl values('{0}','{1}','{2}','{3}','{4}',{5})";
                    Query = string.Format(Query, Name, Gender, Department, DOB, JoinDate, Salary);
                    Con.SetData(Query);
                    ShowEmployee();
                    MessageBox.Show("Employee Added Sucessfully...");
                    EmpNameTb.Text = "";
                    GenCb.SelectedIndex = -1;
                    DepCb.SelectedIndex = -1;
                    DailySalTb.Text = "";

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        private void Employees_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (EmpNameTb.Text == "" || GenCb.SelectedIndex == -1 || DepCb.SelectedIndex == -1 || DailySalTb.Text == "")
                {
                    MessageBox.Show("Missing Data...");
                }
                else
                {
                    string Name = EmpNameTb.Text;
                    string Gender = GenCb.SelectedItem.ToString();
                    string Department;
                    if (DepCb.SelectedItem != null)
                    {
                        DataRowView selectedRow = (DataRowView)DepCb.SelectedItem;
                        Department = selectedRow["DepId"].ToString();
                        // Now 'department' contains the department name.
                    }
                    else
                    {
                        MessageBox.Show("Invalid Department value");
                        Department = "";
                    }
                    string DOB = DOBTb.Value.ToString();
                    string JoinDate = JDate.Value.ToString();
                    int Salary = Convert.ToInt32(DailySalTb.Text);
                    string Query = "UPDATE EmployeeTbl SET EmpName='{0}',EmpGen='{1}',EmpDep='{2}',EmpDOB='{3}',EmpJDate='{4}',EmpSal={5} WHERE EmpId={6}";
                    Query = string.Format(Query, Name, Gender, Department, DOB, JoinDate, Salary,key);
                    Con.SetData(Query);
                    ShowEmployee();
                    MessageBox.Show("Employee Updated Sucessfully...");
                    EmpNameTb.Text = "";
                    GenCb.SelectedIndex = -1;
                    DepCb.SelectedIndex = -1;
                    DailySalTb.Text = "";

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void DepartmentLbl_Click(object sender, EventArgs e)
        {
            Departments Obj = new Departments();
            Obj.Show();
            this.Hide();
        }

        private void SalaryLbl_Click(object sender, EventArgs e)
        {
            Salaries Obj = new Salaries();
            Obj.Show();
            this.Hide();
        }

        private void LogoutLbl_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }
        int key = 0;
        private void EmployeeList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EmpNameTb.Text = EmployeeList.SelectedRows[0].Cells[1].Value.ToString();
            GenCb.Text = EmployeeList.SelectedRows[0].Cells[2].Value.ToString();
            DepCb.SelectedValue = EmployeeList.SelectedRows[0].Cells[3].Value.ToString();
            DOBTb.Text = EmployeeList.SelectedRows[0].Cells[4].Value.ToString();
            JDate.Text = EmployeeList.SelectedRows[0].Cells[5].Value.ToString();
            DailySalTb.Text = EmployeeList.SelectedRows[0].Cells[6].Value.ToString();


            if (EmpNameTb.Text == "" )
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(EmployeeList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (key==0)
                {
                    MessageBox.Show("Missing Data...");
                }
                else
                {
                    string QueryTwo = "DELETE FROM SalaryTbl WHERE Employee={0}";
                    QueryTwo = string.Format(QueryTwo, key);
                    Con.SetData(QueryTwo);
                    string Query = "DELETE FROM EmployeeTbl WHERE EmpId={0}";
                    Query = string.Format(Query,key);
                    Con.SetData(Query);
                    ShowEmployee();
                    MessageBox.Show("Employee Deleted Sucessfully...");
                    EmpNameTb.Text = "";
                    GenCb.SelectedIndex = -1;
                    DepCb.SelectedIndex = -1;
                    DailySalTb.Text = "";

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
    }
}
