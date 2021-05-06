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
    public partial class MainForm : Form
    {       
        public MainForm(string[] Channels)
        {
            InitializeComponent();
            ChannelBox.Items.Clear();
            ChannelBox.Items.AddRange(Channels);
        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
            Client.close();
            this.Hide();
            LoginForm Login = new LoginForm();
            Login.FormClosed += (s, args) => this.Close();
            Login.Show();
        }

        private void RefButton_Click(object sender, EventArgs e)
        {
            string answ = Client.send("REF");
            string[] result = answ.Split(new string[] { "$$" }, StringSplitOptions.None);
            ChannelBox.Items.Clear();
            ChannelBox.Items.AddRange(result);

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChannelForm chan = new ChannelForm(ChannelBox.Items.OfType<string>().ToArray());
            chan.FormClosed += (s, args) => this.Close();
            chan.Show();
        }

        private void ChannelBox_Click(object sender, EventArgs e)
        {
            if (ChannelBox.SelectedItem != null)
            {
                string answ = Client.send("SHW$$" + ChannelBox.SelectedItem.ToString());
                string[] result = answ.Split(new string[] { "$$" }, StringSplitOptions.None);
                if(result[0] == "OK")
                {
                    result = result.Skip(1).ToArray();
                    UsersBox.Items.Clear();
                    UsersBox.Items.AddRange(result);
                }
            }
        }
    }
}
