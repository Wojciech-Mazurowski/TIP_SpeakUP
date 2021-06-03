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
    public partial class MainForm : Form
    {
        public string OnServer= String.Empty;
        List<string> OnCall = new List<string>();
        public MainForm(string[] Channels, string usrName)
        {
            InitializeComponent();
            ChannelBox.Items.Clear();
            ChannelBox.Items.AddRange(Channels);
            UserLabel.Text = usrName;
            DisconnectButton.Enabled = false;
            Task.Run(() => TraffickHandler());
        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
            Client.close();
            this.Close();
        }

        private void RefButton_Click(object sender, EventArgs e)
        {
            Client.send("REF");
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChannelForm chan = new ChannelForm();
            chan.FormClosed += (s, args) => this.Show();
            chan.Show();
        }

        private void ChannelBox_Click(object sender, EventArgs e)
        {
            if (ChannelBox.SelectedItem != null)
            {
                Client.send("SHW$$" + ChannelBox.SelectedItem.ToString());
            }
        }

        private void ChannelBox_DoubleClick(object sender, EventArgs e)
        {
            if(ChannelBox.SelectedItem != null)
            {
                Client.send("JON$$" + ChannelBox.SelectedItem.ToString() + "$$" + UserLabel.Text);
            }

        }

        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(OnServer))
            {
                Client.send("DSC$$" + ChannelBox.SelectedItem.ToString() + "$$" + UserLabel.Text);
            }
        }

        private void TraffickHandler()
        {
            while (true)
            {
                string answ = Client.listen();
                string[] result = answ.Split(new string[] { "$$" }, StringSplitOptions.None);

                switch (result[0])
                {
                    case "DSC":
                        OnServer = String.Empty;
                        UsersBox.Items.RemoveAt(UsersBox.Items.IndexOf(UserLabel.Text));
                        DisconnectButton.Enabled = false;
                        break;
                    case "JON":
                        DisconnectButton.Enabled = true;
                        result = result.Skip(1).ToArray();
                        OnCall.AddRange(result);
                        OnServer = ChannelBox.SelectedItem.ToString();
                        if (!UsersBox.Items.Contains(UserLabel.Text))
                            UsersBox.Items.Add(UserLabel.Text);
                        break;
                    case "SHW":
                        result = result.Skip(1).ToArray();
                        UsersBox.Items.Clear();
                        UsersBox.Items.AddRange(result);
                        break;
                    case "REF":
                        result = result.Skip(1).ToArray();
                        ChannelBox.Items.Clear();
                        ChannelBox.Items.AddRange(result);
                        break;
                    case "ADD":
                        result = result.Skip(1).ToArray();
                        ChannelBox.Items.Clear();
                        ChannelBox.Items.AddRange(result);
                        break;
                    case "CAL":
                        OnCall.Add(result[1]);
                        break;
                    case "ERR":
                        MessageBox.Show(result[1]);
                        break;

                }
            }
        }
    }
}
