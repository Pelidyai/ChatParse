using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ChatParse
{
    public partial class Form1 : Form
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool FreeConsole();
       
    
        public Form1()
        {
           //AllocConsole();
            Boolean is_init = false;
            using (StreamReader reader = new StreamReader("init.conf"))
            {
                string text = reader.ReadToEnd();
                if(text=="")
                {
                    //ProcessStartInfo psi;
                    //psi = new ProcessStartInfo("cmd", "pip3 install telethon");
                    //Process.Start(psi);
                    ////Console.WriteLine()
                    

                    ProcessStartInfo startInfo = new ProcessStartInfo("cmd");

                    
                    //dir = "D:/PickAim/Projects/ChatParser/";
                    string script = "pip3 install telethon";
                    //Console.WriteLine(dir);
                    //Console.WriteLine(script);
                    startInfo.Arguments = script/*$"\"{script}\"\"{url}\""*/;
                    startInfo.UseShellExecute = false;
                    startInfo.CreateNoWindow = false;
                    startInfo.RedirectStandardError = true;
                    startInfo.RedirectStandardInput = true;
                    startInfo.RedirectStandardOutput = true;

                    //Console.WriteLine("start1");
                    string er;
                    using (var process = Process.Start(startInfo))
                    {
                        
                        //Console.WriteLine("start2");
                        process.StandardInput.WriteLine(script);
                        process.StandardInput.Close();
                        er = process.StandardOutput.ReadToEnd();
                    }
                    //Console.WriteLine(er);
                    is_init = true;
                }
            }
            if(is_init)
            {
                using (StreamWriter writer = new StreamWriter("init.conf", false))
                {
                    writer.Write("1");
                }
            }
            InitializeComponent();
            textBox1.Text = "https://t.me/chat_reference";
            textBox1.ForeColor = Color.Gray;
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
        }
        Boolean is_work = false;
        String url = "";
        String errors = "";
        Boolean is_tel = false;
        String outp = "";

        public delegate void MyDelegate(Label myControl, String[] myArg2);
        private void button1_Click(object sender, EventArgs e)
        {
            //Console.WriteLine("butt");

            url  = textBox1.Text;
            is_tel = checkBox1.Checked;
           
            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync();
            }           
            is_work = true;
            object[] myArray = new object[2];
            String[] work = { "Обработка", "Обработка.", "Обработка..", "Обработка..." };
            myArray[0] = label3;
            myArray[1] = work;
            label3.BeginInvoke(new MyDelegate(DelegateMethod), myArray);

            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
                backgroundWorker1.CancelAsync();
            }
            //label3.EndInvoke();
            //if (errors.Contains("FileNotFoundError"))
            //    errors = "";
            
            //Console.WriteLine("tik");
        }

        public void DelegateMethod(Label label, String[] work)
        {
            int i = 0;
            while (is_work)
            {
                if (i > 3) i = 0;
                label3.Text = work[i];
                label3.Refresh();
                //Console.WriteLine("loop");
                Thread.Sleep(500);
                i++;
            }
            //Console.WriteLine(outp);
            label2.Text = errors;
            label3.Text = "Выполнено";
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            
            //Console.WriteLine("work");
            ProcessStartInfo startInfo = new ProcessStartInfo("python");

            string dir = System.IO.Directory.GetCurrentDirectory();
            //dir = "D:/PickAim/Projects/ChatParser/";
            string script = "main.py " + url + " " +is_tel;
            //Console.WriteLine(dir);
            //Console.WriteLine(script);
            startInfo.WorkingDirectory = dir;
            startInfo.Arguments = script/*$"\"{script}\"\"{url}\""*/;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            startInfo.RedirectStandardError = true;
            startInfo.RedirectStandardOutput = true;            

            //Console.WriteLine("start1");
            using (var process = Process.Start(startInfo))
            {
                //Console.WriteLine("start2");
                errors = process.StandardError.ReadToEnd();
                outp = process.StandardOutput.ReadToEnd();
            }            
            is_work = false;
            //Console.WriteLine("end");
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                label3.Text = "Canceled!";
            }
            else if (e.Error != null)
            {
                label3.Text = "Error: " + e.Error.Message;
            }
            else
            {
                label3.Text = "Done!";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_Enter_1(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox1.ForeColor = Color.Black;
        }
    }
}
