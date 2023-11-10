namespace PtintBook
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btncountstr = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbstr = new System.Windows.Forms.TextBox();
            this.dgw1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgw2 = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.lbstr = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgw1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgw2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(209, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Количество страниц:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(122, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(556, 33);
            this.label2.TabIndex = 1;
            this.label2.Text = "Количество листов, необходимое для печати: ";
            // 
            // btncountstr
            // 
            this.btncountstr.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btncountstr.Location = new System.Drawing.Point(183, 159);
            this.btncountstr.Name = "btncountstr";
            this.btncountstr.Size = new System.Drawing.Size(529, 40);
            this.btncountstr.TabIndex = 2;
            this.btncountstr.Text = "Рассчитать последовательность страниц";
            this.btncountstr.UseVisualStyleBackColor = true;
            this.btncountstr.Click += new System.EventHandler(this.btncountstr_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 239);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(436, 32);
            this.label3.TabIndex = 3;
            this.label3.Text = "Первый проход (первая сторона) ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(500, 239);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(419, 32);
            this.label4.TabIndex = 4;
            this.label4.Text = "Второй проход (вторая сторона)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(42, 303);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(389, 66);
            this.label5.TabIndex = 5;
            this.label5.Text = "Печать осуществляетс в два прохода\r\n(с двух сторон листа) с настройкой:\r\n2 страни" +
    "цы на лист (порядок: нормальный).";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(543, 303);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(353, 66);
            this.label6.TabIndex = 6;
            this.label6.Text = "Необходимо перевернуть напечатанные \r\nстраницы относительно ороткого края. \r\nНаст" +
    "ройки прежние.";
            // 
            // tbstr
            // 
            this.tbstr.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbstr.Location = new System.Drawing.Point(488, 8);
            this.tbstr.Name = "tbstr";
            this.tbstr.Size = new System.Drawing.Size(53, 39);
            this.tbstr.TabIndex = 7;
            // 
            // dgw1
            // 
            this.dgw1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgw1.Location = new System.Drawing.Point(29, 409);
            this.dgw1.Name = "dgw1";
            this.dgw1.RowHeadersWidth = 51;
            this.dgw1.RowTemplate.Height = 24;
            this.dgw1.Size = new System.Drawing.Size(402, 150);
            this.dgw1.TabIndex = 8;
            this.dgw1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgw1_CellMouseDoubleClick1);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Тетрадь";
            this.Column1.MinimumWidth = 150;
            this.Column1.Name = "Column1";
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Первый проход";
            this.Column2.MinimumWidth = 250;
            this.Column2.Name = "Column2";
            this.Column2.Width = 250;
            // 
            // dgw2
            // 
            this.dgw2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column4});
            this.dgw2.Location = new System.Drawing.Point(527, 409);
            this.dgw2.Name = "dgw2";
            this.dgw2.RowHeadersWidth = 51;
            this.dgw2.RowTemplate.Height = 24;
            this.dgw2.Size = new System.Drawing.Size(392, 150);
            this.dgw2.TabIndex = 9;
            this.dgw2.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgw2_CellMouseDoubleClick);
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Тетрадь";
            this.Column3.MinimumWidth = 150;
            this.Column3.Name = "Column3";
            this.Column3.Width = 150;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Второй проход";
            this.Column4.MinimumWidth = 250;
            this.Column4.Name = "Column4";
            this.Column4.Width = 250;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(196, 579);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(593, 22);
            this.label7.TabIndex = 10;
            this.label7.Text = "Двойной клик по строке - скопировать последовательность страниц";
            // 
            // lbstr
            // 
            this.lbstr.AutoSize = true;
            this.lbstr.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbstr.Location = new System.Drawing.Point(706, 86);
            this.lbstr.Name = "lbstr";
            this.lbstr.Size = new System.Drawing.Size(0, 33);
            this.lbstr.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(949, 616);
            this.Controls.Add(this.lbstr);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgw2);
            this.Controls.Add(this.dgw1);
            this.Controls.Add(this.tbstr);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btncountstr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Печать книг в Word";
            ((System.ComponentModel.ISupportInitialize)(this.dgw1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgw2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btncountstr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbstr;
        private System.Windows.Forms.DataGridView dgw1;
        private System.Windows.Forms.DataGridView dgw2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbstr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}

