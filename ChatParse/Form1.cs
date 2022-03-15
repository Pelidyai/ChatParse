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
using System.Text.RegularExpressions;
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
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            //AllocConsole();
            Boolean is_init = false;
            using (StreamReader reader = new StreamReader("init.conf"))
            {
                string text = reader.ReadToEnd();
                if(text=="")
                {
                   
                    ProcessStartInfo startInfo = new ProcessStartInfo("cmd");

                    string script1 = "python -m pip install --upgrade pip";
                    string script2 = "pip3 install telethon";

                    startInfo.UseShellExecute = false;
                    startInfo.CreateNoWindow = false;
                    startInfo.RedirectStandardError = true;
                    startInfo.RedirectStandardInput = true;
                    startInfo.RedirectStandardOutput = false;

                    using (var process = Process.Start(startInfo))
                    {
                        process.StandardInput.WriteLine(script1);
                        process.StandardInput.WriteLine(script2);
                        process.StandardInput.Close();
                    }
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
            UrlTextBox.Text = "https://t.me/chat_reference";
            UrlTextBox.ForeColor = Color.Gray;
            CollectData.WorkerReportsProgress = true;
            StatusChange.WorkerReportsProgress = true;
            CollectData.WorkerSupportsCancellation = true;
            StatusChange.WorkerSupportsCancellation = true;
        }
        Boolean is_work = false;
        String url = "";
        String errors = "";
        Boolean is_tel = false;
        String outp = "";


        String Mes = "";
        String File = "";
        String Im = "";
        String Vid = "";

        public delegate void MyDelegate(Label myControl);
        private void button1_Click(object sender, EventArgs e)
        {
            //Console.WriteLine("butt");
            url  = UrlTextBox.Text;
            is_tel = checkBox1.Checked;
            StatusChange.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker2_ProgressChanged);
            if (CollectData.IsBusy != true)
            {
                CollectData.RunWorkerAsync();
            }
            is_work = true;
            GetDataButton.Enabled = false;
            if (StatusChange.IsBusy != true)
            {
                StatusLabel.ForeColor = Color.Red;
                StatusChange.RunWorkerAsync();
            }
            if (StatusChange.WorkerSupportsCancellation == true)
            {
                StatusChange.CancelAsync();
            }
            if (CollectData.WorkerSupportsCancellation == true)
            {
                CollectData.CancelAsync();
            }
            //if (errors.Contains("FileNotFoundError"))
            //    errors = "";

            //Console.WriteLine("tik");
        }

        public void DelegateMethod(Label label)
        {
            GetDataButton.Enabled = true;
            SendButton.Enabled = true;
            ErrorLabel.Text = errors;
            StatusLabel.ForeColor = Color.Green;
            StatusLabel.Text = "Выполнено";
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {            
            //Console.WriteLine("work");
            ProcessStartInfo startInfo = new ProcessStartInfo("python");

            string dir = System.IO.Directory.GetCurrentDirectory();
            string script = "Parser.py " + url + " " + is_tel;
            //Console.WriteLine(dir);
            //Console.WriteLine(script);
            startInfo.WorkingDirectory = dir;
            startInfo.Arguments = script;
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

        private void textBox1_Enter_1(object sender, EventArgs e)
        {
            UrlTextBox.Text = null;
            UrlTextBox.ForeColor = Color.Black;
        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int i = e.ProgressPercentage;
            //Console.WriteLine("pr" + i);
            if (i > 3) i = 0;
            String[] work = { "Обработка", "Обработка.", "Обработка..", "Обработка..." };
            StatusLabel.Text = work[i];
            //label3.Refresh();
            Refresh();
            //Console.WriteLine("loop");
            
        }

        private void SendMessage_DoWork(object sender, DoWorkEventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo("cmd");

            string dir = System.IO.Directory.GetCurrentDirectory();
           // string dir = "D:\\PickAim\\Projects\\ChatParser\\";
            string script = "python " + dir + "\\Sender.py -f \"" + File + "\" -m \"" + Mes + "\" -p \"" + Im + "\" -v \"" + Vid + "\"";
            startInfo.WorkingDirectory = dir;
            //startInfo.Arguments = script;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardError = true;
            startInfo.RedirectStandardOutput = true;

            //Console.WriteLine(script);
            using (var process = Process.Start(startInfo))
            {
                process.StandardInput.WriteLine(script);
                process.StandardInput.Close();
                //Console.WriteLine("start2");
                errors = process.StandardError.ReadToEnd();
                outp = process.StandardOutput.ReadToEnd();
            }
            //Console.WriteLine(outp);
            Mes = "";
            File = "";
            Im = "";
            Vid = "";
            is_work = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Таблица csv|*.csv";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                DocTextBox.Text = openFileDialog1.FileName;
            }
        }

        private void ImButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Изображение|*.jpg; *.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ImageTextBox.Text = openFileDialog1.FileName;
            }
        }

        private void VidButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Видео|*.mp4; *.avi; *mkv";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                VidTextBox.Text = openFileDialog1.FileName;
            }
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            Mes = MessageTextBox.Text;
            Mes = Regex.Replace(Mes, @"\r?\n", " ");
            //Mes.Replace(Environment.NewLine, );
            File = DocTextBox.Text;
            Im = ImageTextBox.Text;
            Vid = VidTextBox.Text;
            //Console.WriteLine(Mes);
            //Console.WriteLine(File);
            //Console.WriteLine(Im);
            //Console.WriteLine(Vid);
            if (SendMessage.IsBusy != true)
            {
                SendMessage.RunWorkerAsync();
            }
            is_work = true;
            SendButton.Enabled = false;
            if (StatusChange.IsBusy != true)
            {
                StatusLabel.ForeColor = Color.Red;
                StatusChange.RunWorkerAsync();
            }
            if (StatusChange.WorkerSupportsCancellation == true)
            {
                StatusChange.CancelAsync();
            }
            if (SendMessage.WorkerSupportsCancellation == true)
            {
                SendMessage.CancelAsync();
            }
        }

        private void StatusChange_DoWork(object sender, DoWorkEventArgs e)
        {
            String[] work = { "Обработка", "Обработка.", "Обработка..", "Обработка..." };
            int i = 0;
            while (is_work)
            {
                if (i > 3) i = 0;
                //Console.WriteLine("work2");
                StatusChange.ReportProgress(i);
                i++;
                Thread.Sleep(500);
            }
            object[] myArray = new object[1];
            myArray[0] = StatusLabel;
            StatusLabel.BeginInvoke(new MyDelegate(DelegateMethod), myArray);
        }
    }
}
