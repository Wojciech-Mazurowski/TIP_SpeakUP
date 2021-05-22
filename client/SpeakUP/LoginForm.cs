﻿using System;
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
            string[] result = answ.Split(new string[] {"$$"},StringSplitOptions.None);
            if (result[0] == "OK")
            {
                result = result.Skip(1).ToArray();
                this.Hide();
                MainForm Main = new MainForm(result, LoginBox.Text);
                Main.FormClosed += (s, args) => this.Close();
                Main.Show();
            }
            else {
                Client.close();
                MessageBox.Show(result[1]); 
            }
        }

        private void RegButton_Click(object sender, EventArgs e)
        {
            Client.runclient();
            string answ = Client.send("REG$$" + LoginBox.Text + "$$" + PasswordBox.Text);
            string[] result = answ.Split(new string[] { "$$" }, StringSplitOptions.None);
            if (result[0] == "OK")
            {
                MessageBox.Show("Registration succesful!");
                result = result.Skip(1).ToArray();
                this.Hide();
                MainForm Main = new MainForm(result, LoginBox.Text);
                Main.FormClosed += (s, args) => this.Close();
                Main.Show();
            }
            else {
                Client.close();
                MessageBox.Show(result[1]);

            }
        }
    }
}
