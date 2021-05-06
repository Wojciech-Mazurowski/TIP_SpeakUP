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
    public partial class ChannelForm : Form
    {
        string[] Backup;
        public ChannelForm(string[] channels)
        {
            InitializeComponent();
            Backup = channels;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string answ = Client.send("ADD$$" + NameBox.Text);
            string[] result = answ.Split(new string[] { "$$" }, StringSplitOptions.None);
            if(result[0] == "OK")
            {
                result = result.Skip(1).ToArray();
                this.Hide();
                MainForm Main = new MainForm(result);
                Main.Show();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm Main = new MainForm(Backup);
            Main.Show();
        }
    }
}
