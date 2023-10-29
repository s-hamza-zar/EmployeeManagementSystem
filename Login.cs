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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (UsernameTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Please Fill all the Feilds...");
            }
            else if (UsernameTb.Text == "admin" && PasswordTb.Text == "admin") 
                {
                    Employees Obj = new Employees();
                    Obj.Show();
                    this.Hide();
                }
            else
            {
                MessageBox.Show("Please enter correct username/password...");
                UsernameTb.Text = "";
                PasswordTb.Text = "";

            }



        }

        private void label2_Click_2(object sender, EventArgs e)
        {

        }

        private void Label2_Click_3(object sender, EventArgs e)
        {
            UsernameTb.Text = "";
            PasswordTb.Text = "";
        }
    }
}
