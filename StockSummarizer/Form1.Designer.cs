namespace StockSummarizer
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buyPrice = new System.Windows.Forms.NumericUpDown();
            this.amount = new System.Windows.Forms.NumericUpDown();
            this.sellPrice = new System.Windows.Forms.NumericUpDown();
            this.stockTime = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.symbol = new System.Windows.Forms.TextBox();
            this.gridView = new System.Windows.Forms.DataGridView();
            this.monthSelector = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.monthlyTotal = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buyPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.amount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sellPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(666, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 94);
            this.button1.TabIndex = 6;
            this.button1.Text = "加入";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buyPrice);
            this.groupBox1.Controls.Add(this.amount);
            this.groupBox1.Controls.Add(this.sellPrice);
            this.groupBox1.Controls.Add(this.stockTime);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.symbol);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Font = new System.Drawing.Font("微軟正黑體 Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox1.Location = new System.Drawing.Point(290, 376);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(846, 121);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "加入交易紀錄";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // buyPrice
            // 
            this.buyPrice.DecimalPlaces = 2;
            this.buyPrice.Location = new System.Drawing.Point(531, 65);
            this.buyPrice.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.buyPrice.Name = "buyPrice";
            this.buyPrice.Size = new System.Drawing.Size(117, 34);
            this.buyPrice.TabIndex = 5;
            this.buyPrice.Enter += new System.EventHandler(this.numeric_enter);
            // 
            // amount
            // 
            this.amount.Location = new System.Drawing.Point(431, 64);
            this.amount.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.amount.Name = "amount";
            this.amount.Size = new System.Drawing.Size(88, 34);
            this.amount.TabIndex = 4;
            this.amount.Enter += new System.EventHandler(this.numeric_enter);
            // 
            // sellPrice
            // 
            this.sellPrice.DecimalPlaces = 2;
            this.sellPrice.Location = new System.Drawing.Point(301, 65);
            this.sellPrice.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.sellPrice.Name = "sellPrice";
            this.sellPrice.Size = new System.Drawing.Size(117, 34);
            this.sellPrice.TabIndex = 3;
            this.sellPrice.Enter += new System.EventHandler(this.numeric_enter);
            // 
            // stockTime
            // 
            this.stockTime.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.stockTime.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.stockTime.Location = new System.Drawing.Point(17, 65);
            this.stockTime.Name = "stockTime";
            this.stockTime.Size = new System.Drawing.Size(136, 31);
            this.stockTime.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(525, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 34);
            this.label4.TabIndex = 8;
            this.label4.Text = "買進價格";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(436, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 34);
            this.label3.TabIndex = 7;
            this.label3.Text = "數量";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(295, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 34);
            this.label2.TabIndex = 6;
            this.label2.Text = "賣出價格";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(164, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 34);
            this.label1.TabIndex = 5;
            this.label1.Text = "股票代碼";
            // 
            // symbol
            // 
            this.symbol.Location = new System.Drawing.Point(169, 65);
            this.symbol.Name = "symbol";
            this.symbol.Size = new System.Drawing.Size(115, 34);
            this.symbol.TabIndex = 2;
            // 
            // gridView
            // 
            this.gridView.AllowUserToAddRows = false;
            this.gridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridView.Location = new System.Drawing.Point(12, 13);
            this.gridView.Name = "gridView";
            this.gridView.RowTemplate.Height = 27;
            this.gridView.Size = new System.Drawing.Size(1124, 357);
            this.gridView.TabIndex = 2;
            // 
            // monthSelector
            // 
            this.monthSelector.CustomFormat = "yyyy/MM";
            this.monthSelector.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.monthSelector.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.monthSelector.Location = new System.Drawing.Point(12, 376);
            this.monthSelector.Name = "monthSelector";
            this.monthSelector.Size = new System.Drawing.Size(110, 31);
            this.monthSelector.TabIndex = 12;
            this.monthSelector.ValueChanged += new System.EventHandler(this.monthSelector_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(12, 420);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(204, 34);
            this.label5.TabIndex = 14;
            this.label5.Text = "本月累計總額：";
            // 
            // monthlyTotal
            // 
            this.monthlyTotal.AutoSize = true;
            this.monthlyTotal.Font = new System.Drawing.Font("微軟正黑體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.monthlyTotal.Location = new System.Drawing.Point(31, 459);
            this.monthlyTotal.Name = "monthlyTotal";
            this.monthlyTotal.Size = new System.Drawing.Size(0, 34);
            this.monthlyTotal.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 509);
            this.Controls.Add(this.monthlyTotal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.monthSelector);
            this.Controls.Add(this.gridView);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "股票交易總覽";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buyPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.amount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sellPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox symbol;
        private System.Windows.Forms.DateTimePicker stockTime;
        private System.Windows.Forms.NumericUpDown buyPrice;
        private System.Windows.Forms.NumericUpDown amount;
        private System.Windows.Forms.NumericUpDown sellPrice;
        private System.Windows.Forms.DataGridView gridView;
        private System.Windows.Forms.DateTimePicker monthSelector;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label monthlyTotal;
    }
}

