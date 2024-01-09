namespace LG.Pages
{
    partial class edit_product
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(edit_product));
            this.label1 = new System.Windows.Forms.Label();
            this.txtid = new System.Windows.Forms.NumericUpDown();
            this.txtname = new System.Windows.Forms.TextBox();
            this.combotype = new System.Windows.Forms.ComboBox();
            this.combosize = new System.Windows.Forms.ComboBox();
            this.combocolor = new System.Windows.Forms.ComboBox();
            this.txtprice = new System.Windows.Forms.TextBox();
            this.txtpower = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtnumber = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.txtdes = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnsave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txtid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtnumber)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Yekan", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(370, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "ویرایش کالا";
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(273, 89);
            this.txtid.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(167, 20);
            this.txtid.TabIndex = 1;
            this.txtid.ValueChanged += new System.EventHandler(this.txtid_ValueChanged);
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(273, 115);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(167, 20);
            this.txtname.TabIndex = 2;
            // 
            // combotype
            // 
            this.combotype.FormattingEnabled = true;
            this.combotype.Location = new System.Drawing.Point(25, 89);
            this.combotype.Name = "combotype";
            this.combotype.Size = new System.Drawing.Size(167, 21);
            this.combotype.TabIndex = 3;
            this.combotype.SelectedIndexChanged += new System.EventHandler(this.combotype_SelectedIndexChanged);
            // 
            // combosize
            // 
            this.combosize.FormattingEnabled = true;
            this.combosize.Location = new System.Drawing.Point(25, 116);
            this.combosize.Name = "combosize";
            this.combosize.Size = new System.Drawing.Size(167, 21);
            this.combosize.TabIndex = 4;
            // 
            // combocolor
            // 
            this.combocolor.FormattingEnabled = true;
            this.combocolor.Location = new System.Drawing.Point(25, 143);
            this.combocolor.Name = "combocolor";
            this.combocolor.Size = new System.Drawing.Size(167, 21);
            this.combocolor.TabIndex = 5;
            // 
            // txtprice
            // 
            this.txtprice.Location = new System.Drawing.Point(25, 170);
            this.txtprice.Name = "txtprice";
            this.txtprice.Size = new System.Drawing.Size(167, 20);
            this.txtprice.TabIndex = 6;
            // 
            // txtpower
            // 
            this.txtpower.Location = new System.Drawing.Point(273, 143);
            this.txtpower.Name = "txtpower";
            this.txtpower.Size = new System.Drawing.Size(167, 20);
            this.txtpower.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Yekan", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(446, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "شناسه کالا";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("B Yekan", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(446, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "نام کالا";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("B Yekan", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(446, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "قدرت / توان";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("B Yekan", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.Location = new System.Drawing.Point(198, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "نوع کالا";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("B Yekan", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label6.Location = new System.Drawing.Point(198, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "سایز";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("B Yekan", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label7.Location = new System.Drawing.Point(198, 147);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "رنگ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("B Yekan", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label8.Location = new System.Drawing.Point(198, 173);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 17);
            this.label8.TabIndex = 15;
            this.label8.Text = "قیمت";
            // 
            // txtnumber
            // 
            this.txtnumber.Location = new System.Drawing.Point(273, 170);
            this.txtnumber.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtnumber.Name = "txtnumber";
            this.txtnumber.Size = new System.Drawing.Size(167, 20);
            this.txtnumber.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("B Yekan", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label9.Location = new System.Drawing.Point(446, 172);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 17);
            this.label9.TabIndex = 17;
            this.label9.Text = "تعداد";
            // 
            // txtdes
            // 
            this.txtdes.Location = new System.Drawing.Point(25, 196);
            this.txtdes.Name = "txtdes";
            this.txtdes.Size = new System.Drawing.Size(415, 20);
            this.txtdes.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("B Yekan", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label10.Location = new System.Drawing.Point(446, 199);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 17);
            this.label10.TabIndex = 19;
            this.label10.Text = "توضیحات";
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(25, 222);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 23);
            this.btnsave.TabIndex = 20;
            this.btnsave.Text = "ثبت";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // edit_product
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(526, 255);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtdes);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtnumber);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtpower);
            this.Controls.Add(this.txtprice);
            this.Controls.Add(this.combocolor);
            this.Controls.Add(this.combosize);
            this.Controls.Add(this.combotype);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "edit_product";
            this.Text = "بروزرسانی";
            this.Load += new System.EventHandler(this.edit_product_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtnumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown txtid;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.ComboBox combotype;
        private System.Windows.Forms.ComboBox combosize;
        private System.Windows.Forms.ComboBox combocolor;
        private System.Windows.Forms.TextBox txtprice;
        private System.Windows.Forms.TextBox txtpower;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown txtnumber;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtdes;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnsave;
    }
}