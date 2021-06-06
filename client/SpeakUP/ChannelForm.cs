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
        public ChannelForm()
        {
            InitializeComponent();
        }


        private void Confirm_Click(object sender, EventArgs e)
        {
            Client.send("ADD$$" + NameBox.Text);
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
