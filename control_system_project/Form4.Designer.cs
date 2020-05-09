namespace control_system_project
{
    partial class Form4
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
            this.ed_username_tb = new System.Windows.Forms.TextBox();
            this.new_password_tb = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.old_password_tb = new System.Windows.Forms.MaskedTextBox();
            this.password_tb = new System.Windows.Forms.MaskedTextBox();
            this.old_username = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ed_username_tb
            // 
            this.ed_username_tb.Location = new System.Drawing.Point(206, 186);
            this.ed_username_tb.Name = "ed_username_tb";
            this.ed_username_tb.Size = new System.Drawing.Size(159, 20);
            this.ed_username_tb.TabIndex = 9;
            // 
            // new_password_tb
            // 
            this.new_password_tb.AutoSize = true;
            this.new_password_tb.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.new_password_tb.Location = new System.Drawing.Point(73, 224);
            this.new_password_tb.Name = "new_password_tb";
            this.new_password_tb.Size = new System.Drawing.Size(127, 19);
            this.new_password_tb.TabIndex = 8;
            this.new_password_tb.Text = " New PassWorad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(73, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "Edite Username";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(84, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 19);
            this.label1.TabIndex = 11;
            this.label1.Text = "Old PassWorad";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(328, 331);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(124, 41);
            this.button2.TabIndex = 14;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(187, 331);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 41);
            this.button1.TabIndex = 13;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // old_password_tb
            // 
            this.old_password_tb.Location = new System.Drawing.Point(206, 132);
            this.old_password_tb.Name = "old_password_tb";
            this.old_password_tb.Size = new System.Drawing.Size(159, 20);
            this.old_password_tb.TabIndex = 16;
            // 
            // password_tb
            // 
            this.password_tb.Location = new System.Drawing.Point(206, 222);
            this.password_tb.Name = "password_tb";
            this.password_tb.Size = new System.Drawing.Size(159, 20);
            this.password_tb.TabIndex = 17;
            // 
            // old_username
            // 
            this.old_username.Location = new System.Drawing.Point(206, 96);
            this.old_username.Name = "old_username";
            this.old_username.Size = new System.Drawing.Size(159, 20);
            this.old_username.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(73, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 19);
            this.label3.TabIndex = 18;
            this.label3.Text = "Old Username";
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 384);
            this.Controls.Add(this.old_username);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.password_tb);
            this.Controls.Add(this.old_password_tb);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ed_username_tb);
            this.Controls.Add(this.new_password_tb);
            this.Controls.Add(this.label2);
            this.Name = "Form4";
            this.ShowIcon = false;
            this.Text = " Username and Password Setting";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox ed_username_tb;
        private System.Windows.Forms.Label new_password_tb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MaskedTextBox old_password_tb;
        private System.Windows.Forms.MaskedTextBox password_tb;
        private System.Windows.Forms.TextBox old_username;
        private System.Windows.Forms.Label label3;
    }
}