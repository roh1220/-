
namespace 미니프로젝트_2._0__칼라영상처리_
{
    partial class subForm2
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
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.num_UD2 = new System.Windows.Forms.NumericUpDown();
            this.num_UD1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.num_UD2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_UD1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(255, 189);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(80, 28);
            this.btn_cancel.TabIndex = 11;
            this.btn_cancel.Text = "취소";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(51, 189);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(80, 28);
            this.btn_OK.TabIndex = 10;
            this.btn_OK.Text = "확인";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // num_UD2
            // 
            this.num_UD2.Font = new System.Drawing.Font("굴림", 12F);
            this.num_UD2.Location = new System.Drawing.Point(215, 114);
            this.num_UD2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.num_UD2.Name = "num_UD2";
            this.num_UD2.Size = new System.Drawing.Size(120, 30);
            this.num_UD2.TabIndex = 9;
            // 
            // num_UD1
            // 
            this.num_UD1.Font = new System.Drawing.Font("굴림", 12F);
            this.num_UD1.Location = new System.Drawing.Point(215, 52);
            this.num_UD1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.num_UD1.Name = "num_UD1";
            this.num_UD1.Size = new System.Drawing.Size(120, 30);
            this.num_UD1.TabIndex = 8;
            this.num_UD1.ValueChanged += new System.EventHandler(this.num_UD1_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 18F);
            this.label2.Location = new System.Drawing.Point(46, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 30);
            this.label2.TabIndex = 7;
            this.label2.Text = "세로이동 : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 18F);
            this.label1.Location = new System.Drawing.Point(46, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 30);
            this.label1.TabIndex = 6;
            this.label1.Text = "가로이동 : ";
            // 
            // subForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 256);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.num_UD2);
            this.Controls.Add(this.num_UD1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "subForm2";
            this.Text = "subForm2";
            ((System.ComponentModel.ISupportInitialize)(this.num_UD2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_UD1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_OK;
        public System.Windows.Forms.NumericUpDown num_UD2;
        public System.Windows.Forms.NumericUpDown num_UD1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}