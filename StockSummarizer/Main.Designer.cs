﻿namespace StockSummarizer
{
    partial class Main
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.monthlyProfit = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.mappingMonthSelector = new System.Windows.Forms.DateTimePicker();
            this.mappingGrid = new System.Windows.Forms.DataGridView();
            this.stockRecordPage = new System.Windows.Forms.TabPage();
            this.monthSelector = new System.Windows.Forms.DateTimePicker();
            this.recordView = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.action = new System.Windows.Forms.ComboBox();
            this.amount = new System.Windows.Forms.NumericUpDown();
            this.price = new System.Windows.Forms.NumericUpDown();
            this.stockTime = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.symbol = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.recordDeleteButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mappingGrid)).BeginInit();
            this.stockRecordPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recordView)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.amount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.price)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.stockRecordPage);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1238, 697);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.monthlyProfit);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.mappingMonthSelector);
            this.tabPage1.Controls.Add(this.mappingGrid);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1230, 668);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "總覽";
            // 
            // monthlyProfit
            // 
            this.monthlyProfit.AutoSize = true;
            this.monthlyProfit.Font = new System.Drawing.Font("微軟正黑體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.monthlyProfit.Location = new System.Drawing.Point(64, 598);
            this.monthlyProfit.Name = "monthlyProfit";
            this.monthlyProfit.Size = new System.Drawing.Size(31, 34);
            this.monthlyProfit.TabIndex = 18;
            this.monthlyProfit.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(30, 549);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(204, 34);
            this.label5.TabIndex = 17;
            this.label5.Text = "本月累計總額：";
            // 
            // mappingMonthSelector
            // 
            this.mappingMonthSelector.CustomFormat = "yyyy/MM";
            this.mappingMonthSelector.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.mappingMonthSelector.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.mappingMonthSelector.Location = new System.Drawing.Point(20, 21);
            this.mappingMonthSelector.Name = "mappingMonthSelector";
            this.mappingMonthSelector.Size = new System.Drawing.Size(105, 31);
            this.mappingMonthSelector.TabIndex = 16;
            this.mappingMonthSelector.ValueChanged += new System.EventHandler(this.mappingMonthSelector_ValueChanged);
            // 
            // mappingGrid
            // 
            this.mappingGrid.AllowUserToAddRows = false;
            this.mappingGrid.AllowUserToDeleteRows = false;
            this.mappingGrid.AllowUserToOrderColumns = true;
            this.mappingGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mappingGrid.Location = new System.Drawing.Point(20, 74);
            this.mappingGrid.Name = "mappingGrid";
            this.mappingGrid.ReadOnly = true;
            this.mappingGrid.RowTemplate.Height = 27;
            this.mappingGrid.Size = new System.Drawing.Size(1188, 450);
            this.mappingGrid.TabIndex = 3;
            // 
            // stockRecordPage
            // 
            this.stockRecordPage.BackColor = System.Drawing.SystemColors.Control;
            this.stockRecordPage.Controls.Add(this.recordDeleteButton);
            this.stockRecordPage.Controls.Add(this.monthSelector);
            this.stockRecordPage.Controls.Add(this.recordView);
            this.stockRecordPage.Controls.Add(this.groupBox1);
            this.stockRecordPage.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.stockRecordPage.Location = new System.Drawing.Point(4, 25);
            this.stockRecordPage.Name = "stockRecordPage";
            this.stockRecordPage.Padding = new System.Windows.Forms.Padding(3);
            this.stockRecordPage.Size = new System.Drawing.Size(1230, 668);
            this.stockRecordPage.TabIndex = 1;
            this.stockRecordPage.Text = "股票進出紀錄";
            // 
            // monthSelector
            // 
            this.monthSelector.CustomFormat = "yyyy/MM";
            this.monthSelector.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.monthSelector.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.monthSelector.Location = new System.Drawing.Point(20, 21);
            this.monthSelector.Name = "monthSelector";
            this.monthSelector.Size = new System.Drawing.Size(105, 31);
            this.monthSelector.TabIndex = 15;
            this.monthSelector.ValueChanged += new System.EventHandler(this.monthSelector_ValueChanged);
            // 
            // recordView
            // 
            this.recordView.AllowUserToAddRows = false;
            this.recordView.AllowUserToDeleteRows = false;
            this.recordView.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.recordView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.recordView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.recordView.DefaultCellStyle = dataGridViewCellStyle5;
            this.recordView.Location = new System.Drawing.Point(20, 74);
            this.recordView.Name = "recordView";
            this.recordView.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.recordView.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.recordView.RowTemplate.Height = 27;
            this.recordView.Size = new System.Drawing.Size(1188, 450);
            this.recordView.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.action);
            this.groupBox1.Controls.Add(this.amount);
            this.groupBox1.Controls.Add(this.price);
            this.groupBox1.Controls.Add(this.stockTime);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.symbol);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Font = new System.Drawing.Font("微軟正黑體 Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox1.Location = new System.Drawing.Point(378, 541);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(846, 121);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "加入交易紀錄";
            // 
            // action
            // 
            this.action.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.action.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.action.FormattingEnabled = true;
            this.action.Location = new System.Drawing.Point(531, 64);
            this.action.Name = "action";
            this.action.Size = new System.Drawing.Size(121, 33);
            this.action.TabIndex = 5;
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
            this.amount.Enter += new System.EventHandler(this.clear_when_enter);
            // 
            // price
            // 
            this.price.DecimalPlaces = 2;
            this.price.Location = new System.Drawing.Point(301, 65);
            this.price.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(117, 34);
            this.price.TabIndex = 3;
            this.price.Enter += new System.EventHandler(this.clear_when_enter);
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
            this.label4.Size = new System.Drawing.Size(69, 34);
            this.label4.TabIndex = 8;
            this.label4.Text = "動作";
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
            this.label2.Size = new System.Drawing.Size(69, 34);
            this.label2.TabIndex = 6;
            this.label2.Text = "價格";
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
            this.symbol.Enter += new System.EventHandler(this.clear_when_enter);
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
            this.button1.Click += new System.EventHandler(this.click_add_button);
            // 
            // recordDeleteButton
            // 
            this.recordDeleteButton.Font = new System.Drawing.Font("微軟正黑體", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.recordDeleteButton.Location = new System.Drawing.Point(20, 534);
            this.recordDeleteButton.Name = "recordDeleteButton";
            this.recordDeleteButton.Size = new System.Drawing.Size(212, 47);
            this.recordDeleteButton.TabIndex = 9;
            this.recordDeleteButton.Text = "刪除選取紀錄";
            this.recordDeleteButton.UseVisualStyleBackColor = true;
            this.recordDeleteButton.Click += new System.EventHandler(this.recordDeleteButton_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 721);
            this.Controls.Add(this.tabControl1);
            this.Name = "Main";
            this.Text = "股票工具";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mappingGrid)).EndInit();
            this.stockRecordPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.recordView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.amount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.price)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage stockRecordPage;
        private System.Windows.Forms.DateTimePicker monthSelector;
        private System.Windows.Forms.DataGridView recordView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown amount;
        private System.Windows.Forms.NumericUpDown price;
        private System.Windows.Forms.DateTimePicker stockTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox symbol;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox action;
        private System.Windows.Forms.DataGridView mappingGrid;
        private System.Windows.Forms.DateTimePicker mappingMonthSelector;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label monthlyProfit;
        private System.Windows.Forms.Button recordDeleteButton;
    }
}