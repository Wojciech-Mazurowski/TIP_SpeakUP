using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpeakUP
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            Client.runclient();
            string answ = Client.send("LOG$$"+ LoginBox.Text + "$$" + PasswordBox.Text);
            if(answ == "OK")
            {
                this.Hide();
                MainForm Main = new MainForm();
                Main.Show();
            }
        }

        private void RegButton_Click(object sender, EventArgs e)
        {
            Client.runclient();
            string answ = Client.send("REG$$" + LoginBox.Text + "$$" + PasswordBox.Text);
            if (answ == "OK")
            {
                MessageBox.Show("Registration succesful!");
            }
            else MessageBox.Show("Registration failed!");
        }
    }
}
