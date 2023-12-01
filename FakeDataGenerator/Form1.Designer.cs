namespace FakeDataGenerator
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
            register = new Button();
            randomTransaction = new Button();
            splitContainer1 = new SplitContainer();
            label2 = new Label();
            recommend = new TextBox();
            label1 = new Label();
            registerName = new TextBox();
            transactionRecord = new ListBox();
            login = new Button();
            label5 = new Label();
            recommenderLabel = new Label();
            loginName = new TextBox();
            codeLabel = new Label();
            randomUser = new Button();
            randomRecommender = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // register
            // 
            register.Location = new Point(4, 69);
            register.Name = "register";
            register.Size = new Size(300, 32);
            register.TabIndex = 0;
            register.Text = "註冊";
            register.UseVisualStyleBackColor = true;
            register.Click += register_Click;
            // 
            // randomTransaction
            // 
            randomTransaction.Location = new Point(648, 262);
            randomTransaction.Name = "randomTransaction";
            randomTransaction.Size = new Size(145, 85);
            randomTransaction.TabIndex = 1;
            randomTransaction.Text = "隨機產生交易";
            randomTransaction.UseVisualStyleBackColor = true;
            randomTransaction.Click += randomTransaction_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(12, 12);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(label2);
            splitContainer1.Panel1.Controls.Add(recommend);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(registerName);
            splitContainer1.Panel1.Controls.Add(register);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(login);
            splitContainer1.Panel2.Controls.Add(label5);
            splitContainer1.Panel2.Controls.Add(loginName);
            splitContainer1.Size = new Size(630, 114);
            splitContainer1.SplitterDistance = 317;
            splitContainer1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(4, 39);
            label2.Name = "label2";
            label2.Size = new Size(105, 19);
            label2.TabIndex = 4;
            label2.Text = "Recommend :";
            // 
            // recommend
            // 
            recommend.Location = new Point(115, 36);
            recommend.Name = "recommend";
            recommend.Size = new Size(188, 27);
            recommend.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(4, 6);
            label1.Name = "label1";
            label1.Size = new Size(87, 19);
            label1.TabIndex = 2;
            label1.Text = "Username :";
            // 
            // registerName
            // 
            registerName.Location = new Point(97, 3);
            registerName.Name = "registerName";
            registerName.Size = new Size(206, 27);
            registerName.TabIndex = 1;
            // 
            // transactionRecord
            // 
            transactionRecord.FormattingEnabled = true;
            transactionRecord.ItemHeight = 19;
            transactionRecord.Location = new Point(12, 235);
            transactionRecord.Name = "transactionRecord";
            transactionRecord.Size = new Size(623, 194);
            transactionRecord.TabIndex = 7;
            // 
            // login
            // 
            login.Location = new Point(3, 36);
            login.Name = "login";
            login.Size = new Size(300, 32);
            login.TabIndex = 5;
            login.Text = "登入";
            login.UseVisualStyleBackColor = true;
            login.Click += login_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 6);
            label5.Name = "label5";
            label5.Size = new Size(87, 19);
            label5.TabIndex = 6;
            label5.Text = "Username :";
            // 
            // recommenderLabel
            // 
            recommenderLabel.AutoSize = true;
            recommenderLabel.BackColor = SystemColors.Control;
            recommenderLabel.Location = new Point(12, 203);
            recommenderLabel.Name = "recommenderLabel";
            recommenderLabel.Size = new Size(156, 19);
            recommenderLabel.TabIndex = 6;
            recommenderLabel.Text = "Your recommender : ";
            // 
            // loginName
            // 
            loginName.Location = new Point(96, 3);
            loginName.Name = "loginName";
            loginName.Size = new Size(206, 27);
            loginName.TabIndex = 5;
            // 
            // codeLabel
            // 
            codeLabel.AutoSize = true;
            codeLabel.Location = new Point(12, 171);
            codeLabel.Name = "codeLabel";
            codeLabel.Size = new Size(160, 19);
            codeLabel.TabIndex = 5;
            codeLabel.Text = "Your invitation code : ";
            // 
            // randomUser
            // 
            randomUser.Location = new Point(648, 353);
            randomUser.Name = "randomUser";
            randomUser.Size = new Size(145, 85);
            randomUser.TabIndex = 3;
            randomUser.Text = "隨機產生用戶";
            randomUser.UseVisualStyleBackColor = true;
            randomUser.Click += randomUser_Click;
            // 
            // randomRecommender
            // 
            randomRecommender.Location = new Point(648, 171);
            randomRecommender.Name = "randomRecommender";
            randomRecommender.Size = new Size(145, 85);
            randomRecommender.TabIndex = 4;
            randomRecommender.Text = "隨機產生推薦人";
            randomRecommender.UseVisualStyleBackColor = true;
            randomRecommender.Click += randomRecommender_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(transactionRecord);
            Controls.Add(randomRecommender);
            Controls.Add(recommenderLabel);
            Controls.Add(randomUser);
            Controls.Add(codeLabel);
            Controls.Add(splitContainer1);
            Controls.Add(randomTransaction);
            Name = "Form1";
            Text = "Form1";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button register;
        private Button randomTransaction;
        private SplitContainer splitContainer1;
        private Label label1;
        private TextBox registerName;
        private Button randomUser;
        private Label label2;
        private TextBox recommend;
        private Label codeLabel;
        private Label recommenderLabel;
        private Button randomRecommender;
        private Button login;
        private Label label5;
        private TextBox loginName;
        private ListBox transactionRecord;
    }
}
