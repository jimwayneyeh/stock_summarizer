namespace StockSummarizer
{
    partial class TransactionMappingForm
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
            this.gridView = new System.Windows.Forms.DataGridView();
            this.chooseButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.remainValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView
            // 
            this.gridView.AllowUserToAddRows = false;
            this.gridView.AllowUserToDeleteRows = false;
            this.gridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridView.Location = new System.Drawing.Point(12, 12);
            this.gridView.MultiSelect = false;
            this.gridView.Name = "gridView";
            this.gridView.RowTemplate.Height = 27;
            this.gridView.Size = new System.Drawing.Size(688, 279);
            this.gridView.TabIndex = 0;
            // 
            // chooseButton
            // 
            this.chooseButton.Font = new System.Drawing.Font("微軟正黑體", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.chooseButton.Location = new System.Drawing.Point(550, 302);
            this.chooseButton.Name = "chooseButton";
            this.chooseButton.Size = new System.Drawing.Size(150, 94);
            this.chooseButton.TabIndex = 7;
            this.chooseButton.Text = "選擇";
            this.chooseButton.UseVisualStyleBackColor = true;
            this.chooseButton.Click += new System.EventHandler(this.chooseButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(12, 302);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 35);
            this.label1.TabIndex = 8;
            this.label1.Text = "未對應張數";
            // 
            // remainValue
            // 
            this.remainValue.AutoSize = true;
            this.remainValue.Font = new System.Drawing.Font("微軟正黑體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.remainValue.Location = new System.Drawing.Point(39, 347);
            this.remainValue.Name = "remainValue";
            this.remainValue.Size = new System.Drawing.Size(0, 35);
            this.remainValue.TabIndex = 9;
            // 
            // TransactionMappingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 408);
            this.Controls.Add(this.remainValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chooseButton);
            this.Controls.Add(this.gridView);
            this.Name = "TransactionMappingForm";
            this.Text = "TransactionMappingForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TransactionMappingForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridView;
        private System.Windows.Forms.Button chooseButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label remainValue;
    }
}