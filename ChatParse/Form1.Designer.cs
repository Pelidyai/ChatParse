
namespace ChatParse
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GetDataButton = new System.Windows.Forms.Button();
            this.ChanelUrl = new System.Windows.Forms.Label();
            this.UrlTextBox = new System.Windows.Forms.TextBox();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.CollectData = new System.ComponentModel.BackgroundWorker();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.StatusChange = new System.ComponentModel.BackgroundWorker();
            this.FileButton = new System.Windows.Forms.Button();
            this.DocLabel = new System.Windows.Forms.Label();
            this.DocTextBox = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.MessageTextBox = new System.Windows.Forms.RichTextBox();
            this.Message = new System.Windows.Forms.Label();
            this.ImageTextBox = new System.Windows.Forms.TextBox();
            this.ImageLabel = new System.Windows.Forms.Label();
            this.ImButton = new System.Windows.Forms.Button();
            this.VidTextBox = new System.Windows.Forms.TextBox();
            this.VidLabel = new System.Windows.Forms.Label();
            this.VidButton = new System.Windows.Forms.Button();
            this.SendButton = new System.Windows.Forms.Button();
            this.SendMessage = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // GetDataButton
            // 
            this.GetDataButton.Location = new System.Drawing.Point(295, 32);
            this.GetDataButton.Name = "GetDataButton";
            this.GetDataButton.Size = new System.Drawing.Size(151, 29);
            this.GetDataButton.TabIndex = 0;
            this.GetDataButton.Text = "Получить данные";
            this.GetDataButton.UseVisualStyleBackColor = true;
            this.GetDataButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // ChanelUrl
            // 
            this.ChanelUrl.AutoSize = true;
            this.ChanelUrl.Location = new System.Drawing.Point(13, 10);
            this.ChanelUrl.Name = "ChanelUrl";
            this.ChanelUrl.Size = new System.Drawing.Size(59, 20);
            this.ChanelUrl.TabIndex = 1;
            this.ChanelUrl.Text = "Ссылка";
            // 
            // UrlTextBox
            // 
            this.UrlTextBox.Location = new System.Drawing.Point(13, 33);
            this.UrlTextBox.Name = "UrlTextBox";
            this.UrlTextBox.Size = new System.Drawing.Size(267, 27);
            this.UrlTextBox.TabIndex = 2;
            this.UrlTextBox.Enter += new System.EventHandler(this.textBox1_Enter_1);
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.Location = new System.Drawing.Point(12, 552);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(0, 20);
            this.ErrorLabel.TabIndex = 3;
            // 
            // CollectData
            // 
            this.CollectData.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(295, 9);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(0, 20);
            this.StatusLabel.TabIndex = 4;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(13, 67);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(455, 24);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "Считывать только пользователей с указанными телефонами";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // StatusChange
            // 
            this.StatusChange.DoWork += new System.ComponentModel.DoWorkEventHandler(this.StatusChange_DoWork);
            this.StatusChange.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker2_ProgressChanged);
            // 
            // FileButton
            // 
            this.FileButton.Location = new System.Drawing.Point(295, 132);
            this.FileButton.Name = "FileButton";
            this.FileButton.Size = new System.Drawing.Size(151, 29);
            this.FileButton.TabIndex = 6;
            this.FileButton.Text = "Обзор...";
            this.FileButton.UseVisualStyleBackColor = true;
            this.FileButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // DocLabel
            // 
            this.DocLabel.AutoSize = true;
            this.DocLabel.Location = new System.Drawing.Point(13, 109);
            this.DocLabel.Name = "DocLabel";
            this.DocLabel.Size = new System.Drawing.Size(313, 20);
            this.DocLabel.TabIndex = 7;
            this.DocLabel.Text = "Выберите документ с базой пользователей";
            // 
            // DocTextBox
            // 
            this.DocTextBox.BackColor = System.Drawing.Color.White;
            this.DocTextBox.Location = new System.Drawing.Point(13, 134);
            this.DocTextBox.Name = "DocTextBox";
            this.DocTextBox.Size = new System.Drawing.Size(267, 27);
            this.DocTextBox.TabIndex = 8;
            // 
            // MessageTextBox
            // 
            this.MessageTextBox.Location = new System.Drawing.Point(13, 195);
            this.MessageTextBox.Name = "MessageTextBox";
            this.MessageTextBox.Size = new System.Drawing.Size(433, 175);
            this.MessageTextBox.TabIndex = 9;
            this.MessageTextBox.Text = "";
            // 
            // Message
            // 
            this.Message.AutoSize = true;
            this.Message.Location = new System.Drawing.Point(13, 172);
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(205, 20);
            this.Message.TabIndex = 10;
            this.Message.Text = "Сообщение пользователям:";
            // 
            // ImageTextBox
            // 
            this.ImageTextBox.BackColor = System.Drawing.Color.White;
            this.ImageTextBox.Location = new System.Drawing.Point(13, 405);
            this.ImageTextBox.Name = "ImageTextBox";
            this.ImageTextBox.Size = new System.Drawing.Size(267, 27);
            this.ImageTextBox.TabIndex = 13;
            // 
            // ImageLabel
            // 
            this.ImageLabel.AutoSize = true;
            this.ImageLabel.Location = new System.Drawing.Point(13, 380);
            this.ImageLabel.Name = "ImageLabel";
            this.ImageLabel.Size = new System.Drawing.Size(178, 20);
            this.ImageLabel.TabIndex = 12;
            this.ImageLabel.Text = "Выберите изображение";
            // 
            // ImButton
            // 
            this.ImButton.Location = new System.Drawing.Point(295, 403);
            this.ImButton.Name = "ImButton";
            this.ImButton.Size = new System.Drawing.Size(151, 29);
            this.ImButton.TabIndex = 11;
            this.ImButton.Text = "Обзор...";
            this.ImButton.UseVisualStyleBackColor = true;
            this.ImButton.Click += new System.EventHandler(this.ImButton_Click);
            // 
            // VidTextBox
            // 
            this.VidTextBox.BackColor = System.Drawing.Color.White;
            this.VidTextBox.Location = new System.Drawing.Point(13, 466);
            this.VidTextBox.Name = "VidTextBox";
            this.VidTextBox.Size = new System.Drawing.Size(267, 27);
            this.VidTextBox.TabIndex = 16;
            // 
            // VidLabel
            // 
            this.VidLabel.AutoSize = true;
            this.VidLabel.Location = new System.Drawing.Point(13, 441);
            this.VidLabel.Name = "VidLabel";
            this.VidLabel.Size = new System.Drawing.Size(124, 20);
            this.VidLabel.TabIndex = 15;
            this.VidLabel.Text = "Выберите видео";
            // 
            // VidButton
            // 
            this.VidButton.Location = new System.Drawing.Point(295, 464);
            this.VidButton.Name = "VidButton";
            this.VidButton.Size = new System.Drawing.Size(151, 29);
            this.VidButton.TabIndex = 14;
            this.VidButton.Text = "Обзор...";
            this.VidButton.UseVisualStyleBackColor = true;
            this.VidButton.Click += new System.EventHandler(this.VidButton_Click);
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(13, 505);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(433, 29);
            this.SendButton.TabIndex = 17;
            this.SendButton.Text = "Отправить сообщение";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // SendMessage
            // 
            this.SendMessage.DoWork += new System.ComponentModel.DoWorkEventHandler(this.SendMessage_DoWork);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 581);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.VidTextBox);
            this.Controls.Add(this.VidLabel);
            this.Controls.Add(this.VidButton);
            this.Controls.Add(this.ImageTextBox);
            this.Controls.Add(this.ImageLabel);
            this.Controls.Add(this.ImButton);
            this.Controls.Add(this.Message);
            this.Controls.Add(this.MessageTextBox);
            this.Controls.Add(this.DocTextBox);
            this.Controls.Add(this.DocLabel);
            this.Controls.Add(this.FileButton);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.UrlTextBox);
            this.Controls.Add(this.ChanelUrl);
            this.Controls.Add(this.GetDataButton);
            this.Name = "Form1";
            this.Text = "ChatParser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GetDataButton;
        private System.Windows.Forms.Label ChanelUrl;
        private System.Windows.Forms.TextBox UrlTextBox;
        private System.Windows.Forms.Label ErrorLabel;
        private System.ComponentModel.BackgroundWorker CollectData;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.ComponentModel.BackgroundWorker StatusChange;
        private System.Windows.Forms.Button FileButton;
        private System.Windows.Forms.Label DocLabel;
        private System.Windows.Forms.TextBox DocTextBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.RichTextBox MessageTextBox;
        private System.Windows.Forms.Label Message;
        private System.Windows.Forms.TextBox ImageTextBox;
        private System.Windows.Forms.Label ImageLabel;
        private System.Windows.Forms.Button ImButton;
        private System.Windows.Forms.TextBox VidTextBox;
        private System.Windows.Forms.Label VidLabel;
        private System.Windows.Forms.Button VidButton;
        private System.Windows.Forms.Button SendButton;
        private System.ComponentModel.BackgroundWorker SendMessage;
    }
}

