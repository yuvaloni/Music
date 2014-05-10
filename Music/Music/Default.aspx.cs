using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Sockets;
using System.IO;
namespace Music
{
    public partial class Default : System.Web.UI.Page
    {
        int id = 0;
        static Socket s;
        static Socket c;
        string play;
        protected void Page_Load(object sender, EventArgs e)
        {
            IPHostEntry host;
            string localIP = "?";
            host = Dns.GetHostEntry(Dns.GetHostName());
            s = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();
                    break;
                }
            }
            TextBox1.Text = localIP +":1234";
            TextBox2.Text = "no";
        }
        public bool isConnected = false;
        public void Listen()
        {
            s.Bind(new IPEndPoint(IPAddress.Any, 1234));
            s.Listen(1);
            c = s.Accept();
            TextBox2.Text = "yes";
            isConnected = true;


            
        }
        public void UploadFile()
        {
            string p = Path.Combine(Server.MapPath("~"), id + ".mp3");
            id++;
            File.WriteAllBytes(p, FileUpload1.FileBytes);
            ListBox1.Items.Add(p);


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Play();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            UploadFile();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Listen();
        }
        public void Play()
        {

                     while(ListBox1.Items.Count>0)
                     {
                         c.SendFile(ListBox1.Items[0].ToString());
                         ListBox1.Items.RemoveAt(0);
                         c.Receive(new byte[1]);

                     }
        }

    }
}