namespace DoAnLTWindow
{
    partial class frmcustomerMoney
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
            label1 = new System.Windows.Forms.Label();
            txtCustomerMoney = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            button1 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            button3 = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(101, 35);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(190, 22);
            label1.TabIndex = 0;
            label1.Text = "Số Tiền Khách Đưa";
            // 
            // txtCustomerMoney
            // 
            txtCustomerMoney.Location = new System.Drawing.Point(55, 93);
            txtCustomerMoney.Name = "txtCustomerMoney";
            txtCustomerMoney.Size = new System.Drawing.Size(169, 23);
            txtCustomerMoney.TabIndex = 1;
            txtCustomerMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(241, 94);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(65, 22);
            label2.TabIndex = 2;
            label2.Text = ".000 đ";
            // 
            // button1
            // 
            button1.BackColor = System.Drawing.Color.SandyBrown;
            button1.Location = new System.Drawing.Point(155, 170);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(88, 51);
            button1.TabIndex = 3;
            button1.Text = "Xác Nhận";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = System.Drawing.Color.SandyBrown;
            button2.Location = new System.Drawing.Point(278, 170);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(88, 51);
            button2.TabIndex = 4;
            button2.Text = "Huỷ";
            button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = System.Drawing.Color.SandyBrown;
            button3.Location = new System.Drawing.Point(24, 170);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(88, 51);
            button3.TabIndex = 5;
            button3.Text = ".000";
            button3.UseVisualStyleBackColor = false;
            // 
            // frmcustomerMoney
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Bisque;
            ClientSize = new System.Drawing.Size(406, 257);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(txtCustomerMoney);
            Controls.Add(label1);
            Name = "frmcustomerMoney";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Tiền Khách Đưa";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCustomerMoney;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}