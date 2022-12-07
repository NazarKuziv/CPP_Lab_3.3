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

namespace Second
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SimpleTcpServer server;

        private void Form1_Load(object sender, EventArgs e)
        {
            server = new SimpleTcpServer();
            server.StringEncoder = Encoding.UTF8;
            server.DataReceived += Server_DataRecieved;
            System.Net.IPAddress ip = System.Net.IPAddress.Parse("127.0.0.1");
            server.Start(ip, 8910);

        }

        private void Server_DataRecieved(object sender, SimpleTCP.Message e)
        {

            int acrion = Convert.ToInt32(e.MessageString.Trim(''));

            switch (acrion)
            {
                case 1:
                    {
                        button.Visible = button.Visible == true ? false : true;
                        break;
                    }
                case 2:
                    {
                        label.Invoke((MethodInvoker)delegate ()
                        {
                            label.BackColor = Color.White;
                        });

                        break;
                    }
                case 3:
                    {
                        label.Invoke((MethodInvoker)delegate ()
                        {
                            label.BackColor = Color.Blue;
                        });

                        break;
                    }
                case 4:
                    {

                        label.Invoke((MethodInvoker)delegate ()
                        {
                            label.BackColor = Color.Red;
                        });

                        break;
                    }
                case 5:
                    {
                        label.Invoke((MethodInvoker)delegate ()
                        {
                            label.BackColor = Color.Yellow;
                        });

                        break;
                    }
                case 6:
                    {
                        label.Invoke((MethodInvoker)delegate ()
                        {
                            label.Text = "Мітка";
                        });

                        break;
                    }
                case 7:
                    {
                        this.Invoke((MethodInvoker)delegate ()
                        {
                            this.Close();
                        });

                        break;
                    }
                default: break;
            }

        }



        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            server.Stop();
        }
    }
}
