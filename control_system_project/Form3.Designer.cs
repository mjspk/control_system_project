namespace control_system_project
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.login_bt = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.username_tb = new System.Windows.Forms.TextBox();
            this.password_tb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.close_bt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // login_bt
            // 
            this.login_bt.BackColor = System.Drawing.Color.Transparent;
            this.login_bt.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.login_bt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.login_bt.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_bt.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.login_bt.Location = new System.Drawing.Point(369, 365);
            this.login_bt.Name = "login_bt";
            this.login_bt.Size = new System.Drawing.Size(124, 41);
            this.login_bt.TabIndex = 1;
            this.login_bt.Text = "Log IN";
            this.login_bt.UseVisualStyleBackColor = false;
            this.login_bt.Visible = false;
            this.login_bt.Click += new System.EventHandler(this.button2_Click);
            this.login_bt.MouseHover += new System.EventHandler(this.button2_MouseHover);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(237, 280);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "UserName";
            this.label2.Visible = false;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(237, 307);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "PassWorad";
            this.label3.Visible = false;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // username_tb
            // 
            this.username_tb.Location = new System.Drawing.Point(334, 279);
            this.username_tb.Name = "username_tb";
            this.username_tb.Size = new System.Drawing.Size(159, 20);
            this.username_tb.TabIndex = 0;
            this.username_tb.Visible = false;
            // 
            // password_tb
            // 
            this.password_tb.Location = new System.Drawing.Point(334, 307);
            this.password_tb.Name = "password_tb";
            this.password_tb.Size = new System.Drawing.Size(159, 20);
            this.password_tb.TabIndex = 1;
            this.password_tb.Visible = false;
            this.password_tb.TextChanged += new System.EventHandler(this.password_tb_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.OrangeRed;
            this.label4.Location = new System.Drawing.Point(256, 331);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 18);
            this.label4.TabIndex = 7;
            this.label4.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button3.Location = new System.Drawing.Point(151, 365);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(194, 41);
            this.button3.TabIndex = 8;
            this.button3.Text = "Sign In";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // close_bt
            // 
            this.close_bt.BackColor = System.Drawing.Color.Transparent;
            this.close_bt.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.close_bt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.close_bt.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close_bt.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.close_bt.Location = new System.Drawing.Point(228, 365);
            this.close_bt.Name = "close_bt";
            this.close_bt.Size = new System.Drawing.Size(124, 41);
            this.close_bt.TabIndex = 9;
            this.close_bt.Text = "Close";
            this.close_bt.UseVisualStyleBackColor = false;
            this.close_bt.Visible = false;
            this.close_bt.Click += new System.EventHandler(this.close_bt_Click);
            // 
            // Form3
            // 
            this.AcceptButton = this.button3;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::control_system_project.Properties.Resources.PhototasticCollage_2016_03_02_16_42_31;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.close_bt;
            this.ClientSize = new System.Drawing.Size(503, 412);
            this.ControlBox = false;
            this.Controls.Add(this.close_bt);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.password_tb);
            this.Controls.Add(this.username_tb);
            this.Controls.Add(this.login_bt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form3";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sign in";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form3_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form3_FormClosed);
            this.Load += new System.EventHandler(this.Form3_Load);
            this.Enter += new System.EventHandler(this.Form3_Enter);
            this.MouseLeave += new System.EventHandler(this.Form3_MouseLeave);
            this.MouseHover += new System.EventHandler(this.Form3_MouseHover);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button login_bt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox username_tb;
        public System.Windows.Forms.TextBox password_tb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button close_bt;
    }
}