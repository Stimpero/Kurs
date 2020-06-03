using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Temperature
{
    public partial class Form1 : Form
    {

        public Process progid;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //How to start another application from the current application
            Process runProg = new Process();
            runProg.StartInfo.FileName = "wscript.exe"; //the path of the application
            runProg.StartInfo.Arguments = "hide.vbs rtl.bat"; //скрытый запуск 
            runProg.StartInfo.CreateNoWindow = true;
            runProg.Start();
        }


        static string textload()
        {
            string path = "temp.txt";
            string text_temp="";

            if (path.Length!=0)
            {   
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    string line;
                    for (int i = 0; i < 4; i++)
                    {
                        line =  sr.ReadLine();
                        text_temp = line;

                    }
                    return text_temp.Substring(14);
                }
            }
            else return text_temp.Substring(14);

        }


        private void timer1_Tick(object sender, EventArgs e)
        {

            label1.Text = "T = "+textload();
            notifyIcon1.Text = "T = " + textload();

            //How to start another application from the current application
            Process runProg = new Process();
            runProg.StartInfo.FileName = "wscript.exe"; //the path of the application
            runProg.StartInfo.Arguments = "hide.vbs rtl.bat";
            runProg.StartInfo.CreateNoWindow = true;
            runProg.Start();
        }

        //Minimazing in tray icon
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
            }
        }

        //Restore form
        private void Form1_Deactivate(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
            }
        }

    }
}