using SimpleTCP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace First
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SimpleTcpClient client;

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new SimpleTcpClient();
            client.StringEncoder = Encoding.UTF8;
            client.Connect("127.0.0.1", 8910);

            

        }



        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            client.Disconnect();
        }

        private void visibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            visibleToolStripMenuItem.Checked = visibleToolStripMenuItem.Checked == false ? true : false;
            client.WriteLineAndGetReply("1", TimeSpan.FromMilliseconds(1));
        }

        private void exitF10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            client.WriteLineAndGetReply("7", TimeSpan.FromMilliseconds(1));
            this.Close();
        }

        private void labelTextМіткаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            client.WriteLineAndGetReply("6", TimeSpan.FromMilliseconds(1));
        }

        private void clBthFaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clBthFaceToolStripMenuItem.Checked = true;
            clRedToolStripMenuItem.Checked = false;
            clBlueToolStripMenuItem.Checked=false;
            clYellowToolStripMenuItem.Checked= false;

            client.WriteLineAndGetReply("2", TimeSpan.FromMilliseconds(1));
        }

        private void clRedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clBthFaceToolStripMenuItem.Checked = false;
            clRedToolStripMenuItem.Checked = true;
            clBlueToolStripMenuItem.Checked = false;
            clYellowToolStripMenuItem.Checked = false;
            client.WriteLineAndGetReply("4", TimeSpan.FromMilliseconds(1));
        }

        private void clBlueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clBthFaceToolStripMenuItem.Checked = false;
            clRedToolStripMenuItem.Checked = false;
            clBlueToolStripMenuItem.Checked = true;
            clYellowToolStripMenuItem.Checked = false;
            client.WriteLineAndGetReply("3", TimeSpan.FromMilliseconds(1));
        }

        private void clYellowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clBthFaceToolStripMenuItem.Checked = false;
            clRedToolStripMenuItem.Checked = false;
            clBlueToolStripMenuItem.Checked = false;
            clYellowToolStripMenuItem.Checked = true;
            client.WriteLineAndGetReply("5", TimeSpan.FromMilliseconds(1));
        }
    }
}
