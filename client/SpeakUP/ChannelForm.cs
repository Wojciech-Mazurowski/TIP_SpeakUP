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
        string temp;
        public ChannelForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Client.send("ADD$$" + NameBox.Text);
            string answ = Client.listen();
            string[] result = answ.Split(new string[] { "$$" }, StringSplitOptions.None);
            if(result[0] == "OK")
            {
                result = result.Skip(1).ToArray();
                this.Close();
            }

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
