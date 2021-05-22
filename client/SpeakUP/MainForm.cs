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
        public string OnServer= String.Empty;
        public MainForm(string[] Channels, string usrName)
        {
            InitializeComponent();
            ChannelBox.Items.Clear();
            ChannelBox.Items.AddRange(Channels);
            UserLabel.Text = usrName;
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
            result = result.Skip(1).ToArray();
            ChannelBox.Items.Clear();
            ChannelBox.Items.AddRange(result);

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChannelForm chan = new ChannelForm(ChannelBox.Items.OfType<string>().ToArray(), UserLabel.Text);
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

        private void ChannelBox_DoubleClick(object sender, EventArgs e)
        {
            if(ChannelBox.SelectedItem != null)
            {
                string answ = Client.send("JON$$" + ChannelBox.SelectedItem.ToString() + "$$" + UserLabel.Text);
                string[] result = answ.Split(new string[] { "$$" }, StringSplitOptions.None);
                if(result[0] == "OK")
                {
                    DisconnectButton.Enabled = true;
                    OnServer = ChannelBox.SelectedItem.ToString();
                    if(!UsersBox.Items.Contains(UserLabel.Text))
                        UsersBox.Items.Add(UserLabel.Text);
                }
            }

        }

        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(OnServer))
            {
                string answ = Client.send("DSC$$" + ChannelBox.SelectedItem.ToString() + "$$" + UserLabel.Text);
                string[] result = answ.Split(new string[] { "$$" }, StringSplitOptions.None);
                if (result[0] == "OK")
                {
                    OnServer = String.Empty;
                    UsersBox.Items.RemoveAt(UsersBox.Items.IndexOf(UserLabel.Text));
                    DisconnectButton.Enabled = false;
                }
            }
        }
    }
}
