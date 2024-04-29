namespace CalculatorApp
{
    partial class Calculator
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutWithButtons = new TableLayoutPanel();
            Number1 = new Button();
            Number2 = new Button();
            Number3 = new Button();
            Number4 = new Button();
            Number5 = new Button();
            Number6 = new Button();
            Number7 = new Button();
            Number8 = new Button();
            Number9 = new Button();
            Number0 = new Button();
            MultiplicationSign = new Button();
            PlusSign = new Button();
            DivisionSign = new Button();
            ClearDisplay = new Button();
            EqualSign = new Button();
            MinusSign = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            displayWithOperations = new Label();
            displayWithResult = new Label();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutWithButtons.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = SystemColors.GradientInactiveCaption;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(tableLayoutWithButtons, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 75F));
            tableLayoutPanel1.Size = new Size(709, 449);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutWithButtons
            // 
            tableLayoutWithButtons.BackColor = SystemColors.GradientActiveCaption;
            tableLayoutWithButtons.ColumnCount = 4;
            tableLayoutWithButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutWithButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutWithButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutWithButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutWithButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutWithButtons.Controls.Add(Number1, 0, 2);
            tableLayoutWithButtons.Controls.Add(Number2, 1, 2);
            tableLayoutWithButtons.Controls.Add(Number3, 2, 2);
            tableLayoutWithButtons.Controls.Add(Number4, 0, 1);
            tableLayoutWithButtons.Controls.Add(Number5, 1, 1);
            tableLayoutWithButtons.Controls.Add(Number6, 2, 1);
            tableLayoutWithButtons.Controls.Add(Number7, 0, 0);
            tableLayoutWithButtons.Controls.Add(Number8, 1, 0);
            tableLayoutWithButtons.Controls.Add(Number9, 2, 0);
            tableLayoutWithButtons.Controls.Add(Number0, 0, 3);
            tableLayoutWithButtons.Controls.Add(MultiplicationSign, 3, 2);
            tableLayoutWithButtons.Controls.Add(PlusSign, 2, 3);
            tableLayoutWithButtons.Controls.Add(DivisionSign, 3, 1);
            tableLayoutWithButtons.Controls.Add(ClearDisplay, 3, 0);
            tableLayoutWithButtons.Controls.Add(EqualSign, 3, 3);
            tableLayoutWithButtons.Controls.Add(MinusSign, 1, 3);
            tableLayoutWithButtons.Dock = DockStyle.Fill;
            tableLayoutWithButtons.Location = new Point(3, 115);
            tableLayoutWithButtons.Name = "tableLayoutWithButtons";
            tableLayoutWithButtons.RowCount = 4;
            tableLayoutWithButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutWithButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutWithButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutWithButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutWithButtons.Size = new Size(703, 331);
            tableLayoutWithButtons.TabIndex = 0;
            // 
            // Number1
            // 
            Number1.BackColor = SystemColors.GradientActiveCaption;
            Number1.Dock = DockStyle.Fill;
            Number1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Number1.ForeColor = SystemColors.ActiveCaptionText;
            Number1.Location = new Point(3, 167);
            Number1.Name = "Number1";
            Number1.Size = new Size(169, 76);
            Number1.TabIndex = 1;
            Number1.Text = "1";
            Number1.UseVisualStyleBackColor = false;
            // 
            // Number2
            // 
            Number2.BackColor = SystemColors.GradientActiveCaption;
            Number2.Dock = DockStyle.Fill;
            Number2.Font = new Font("Segoe UI", 20F);
            Number2.Location = new Point(178, 167);
            Number2.Name = "Number2";
            Number2.Size = new Size(169, 76);
            Number2.TabIndex = 2;
            Number2.Text = "2";
            Number2.UseVisualStyleBackColor = false;
            // 
            // Number3
            // 
            Number3.BackColor = SystemColors.GradientActiveCaption;
            Number3.Dock = DockStyle.Fill;
            Number3.Font = new Font("Segoe UI", 20F);
            Number3.Location = new Point(353, 167);
            Number3.Name = "Number3";
            Number3.Size = new Size(169, 76);
            Number3.TabIndex = 3;
            Number3.Text = "3";
            Number3.UseVisualStyleBackColor = false;
            // 
            // Number4
            // 
            Number4.BackColor = SystemColors.GradientActiveCaption;
            Number4.Dock = DockStyle.Fill;
            Number4.Font = new Font("Segoe UI", 20F);
            Number4.Location = new Point(3, 85);
            Number4.Name = "Number4";
            Number4.Size = new Size(169, 76);
            Number4.TabIndex = 4;
            Number4.Text = "4";
            Number4.UseVisualStyleBackColor = false;
            // 
            // Number5
            // 
            Number5.BackColor = SystemColors.GradientActiveCaption;
            Number5.Dock = DockStyle.Fill;
            Number5.Font = new Font("Segoe UI", 20F);
            Number5.Location = new Point(178, 85);
            Number5.Name = "Number5";
            Number5.Size = new Size(169, 76);
            Number5.TabIndex = 5;
            Number5.Text = "5";
            Number5.UseVisualStyleBackColor = false;
            // 
            // Number6
            // 
            Number6.BackColor = SystemColors.GradientActiveCaption;
            Number6.Dock = DockStyle.Fill;
            Number6.Font = new Font("Segoe UI", 20F);
            Number6.Location = new Point(353, 85);
            Number6.Name = "Number6";
            Number6.Size = new Size(169, 76);
            Number6.TabIndex = 6;
            Number6.Text = "6";
            Number6.UseVisualStyleBackColor = false;
            // 
            // Number7
            // 
            Number7.BackColor = SystemColors.GradientActiveCaption;
            Number7.Dock = DockStyle.Fill;
            Number7.Font = new Font("Segoe UI", 20F);
            Number7.Location = new Point(3, 3);
            Number7.Name = "Number7";
            Number7.Size = new Size(169, 76);
            Number7.TabIndex = 7;
            Number7.Text = "7";
            Number7.UseVisualStyleBackColor = false;
            // 
            // Number8
            // 
            Number8.BackColor = SystemColors.GradientActiveCaption;
            Number8.Dock = DockStyle.Fill;
            Number8.Font = new Font("Segoe UI", 20F);
            Number8.Location = new Point(178, 3);
            Number8.Name = "Number8";
            Number8.Size = new Size(169, 76);
            Number8.TabIndex = 8;
            Number8.Text = "8";
            Number8.UseVisualStyleBackColor = false;
            // 
            // Number9
            // 
            Number9.BackColor = SystemColors.GradientActiveCaption;
            Number9.Dock = DockStyle.Fill;
            Number9.Font = new Font("Segoe UI", 20F);
            Number9.Location = new Point(353, 3);
            Number9.Name = "Number9";
            Number9.Size = new Size(169, 76);
            Number9.TabIndex = 9;
            Number9.Text = "9";
            Number9.UseVisualStyleBackColor = false;
            // 
            // Number0
            // 
            Number0.BackColor = SystemColors.GradientActiveCaption;
            Number0.Dock = DockStyle.Fill;
            Number0.Font = new Font("Segoe UI", 20F);
            Number0.Location = new Point(3, 249);
            Number0.Name = "Number0";
            Number0.Size = new Size(169, 79);
            Number0.TabIndex = 0;
            Number0.Text = "0";
            Number0.UseVisualStyleBackColor = false;
            // 
            // MultiplicationSign
            // 
            MultiplicationSign.BackColor = SystemColors.GradientActiveCaption;
            MultiplicationSign.Dock = DockStyle.Fill;
            MultiplicationSign.Font = new Font("Segoe UI", 20F);
            MultiplicationSign.Location = new Point(528, 167);
            MultiplicationSign.Name = "MultiplicationSign";
            MultiplicationSign.Size = new Size(172, 76);
            MultiplicationSign.TabIndex = 13;
            MultiplicationSign.Text = "×";
            MultiplicationSign.UseVisualStyleBackColor = false;
            // 
            // PlusSign
            // 
            PlusSign.BackColor = SystemColors.GradientActiveCaption;
            PlusSign.Dock = DockStyle.Fill;
            PlusSign.Font = new Font("Segoe UI", 20F);
            PlusSign.Location = new Point(353, 249);
            PlusSign.Name = "PlusSign";
            PlusSign.Size = new Size(169, 79);
            PlusSign.TabIndex = 12;
            PlusSign.Text = "+";
            PlusSign.UseVisualStyleBackColor = false;
            // 
            // DivisionSign
            // 
            DivisionSign.BackColor = SystemColors.GradientActiveCaption;
            DivisionSign.Dock = DockStyle.Fill;
            DivisionSign.Font = new Font("Segoe UI", 20F);
            DivisionSign.Location = new Point(528, 85);
            DivisionSign.Name = "DivisionSign";
            DivisionSign.Size = new Size(172, 76);
            DivisionSign.TabIndex = 14;
            DivisionSign.Text = "÷";
            DivisionSign.UseVisualStyleBackColor = false;
            // 
            // ClearDisplay
            // 
            ClearDisplay.BackColor = SystemColors.GradientActiveCaption;
            ClearDisplay.Dock = DockStyle.Fill;
            ClearDisplay.Font = new Font("Segoe UI", 20F);
            ClearDisplay.Location = new Point(528, 3);
            ClearDisplay.Name = "ClearDisplay";
            ClearDisplay.Size = new Size(172, 76);
            ClearDisplay.TabIndex = 15;
            ClearDisplay.Text = "C";
            ClearDisplay.UseVisualStyleBackColor = false;
            ClearDisplay.Click += Clear_Click;
            // 
            // EqualSign
            // 
            EqualSign.BackColor = SystemColors.GradientActiveCaption;
            EqualSign.Dock = DockStyle.Fill;
            EqualSign.Font = new Font("Segoe UI", 20F);
            EqualSign.Location = new Point(528, 249);
            EqualSign.Name = "EqualSign";
            EqualSign.Size = new Size(172, 79);
            EqualSign.TabIndex = 10;
            EqualSign.Text = "=";
            EqualSign.UseVisualStyleBackColor = false;
            // 
            // MinusSign
            // 
            MinusSign.BackColor = SystemColors.GradientActiveCaption;
            MinusSign.Dock = DockStyle.Fill;
            MinusSign.Font = new Font("Segoe UI", 20F);
            MinusSign.Location = new Point(178, 249);
            MinusSign.Name = "MinusSign";
            MinusSign.Size = new Size(169, 79);
            MinusSign.TabIndex = 11;
            MinusSign.Text = "-";
            MinusSign.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = SystemColors.GradientInactiveCaption;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(displayWithOperations, 0, 0);
            tableLayoutPanel2.Controls.Add(displayWithResult, 0, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            tableLayoutPanel2.Size = new Size(703, 106);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // displayWithOperations
            // 
            displayWithOperations.AutoSize = true;
            displayWithOperations.Dock = DockStyle.Fill;
            displayWithOperations.Font = new Font("Segoe UI", 14F);
            displayWithOperations.ForeColor = SystemColors.ControlDarkDark;
            displayWithOperations.Location = new Point(3, 0);
            displayWithOperations.Name = "displayWithOperations";
            displayWithOperations.Size = new Size(697, 31);
            displayWithOperations.TabIndex = 0;
            displayWithOperations.Text = "operations";
            displayWithOperations.TextAlign = ContentAlignment.BottomRight;
            // 
            // displayWithResult
            // 
            displayWithResult.AutoSize = true;
            displayWithResult.Dock = DockStyle.Fill;
            displayWithResult.Font = new Font("Segoe UI", 35F);
            displayWithResult.Location = new Point(3, 31);
            displayWithResult.Name = "displayWithResult";
            displayWithResult.Size = new Size(697, 75);
            displayWithResult.TabIndex = 1;
            displayWithResult.Text = "Result";
            displayWithResult.TextAlign = ContentAlignment.BottomRight;

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(709, 449);
            Controls.Add(tableLayoutPanel1);
            MinimumSize = new Size(500, 342);
            Name = "Calculator";
            Text = "Calculator";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutWithButtons.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutWithButtons;
        private Button Number1;
        private Button Number2;
        private Button Number3;
        private Button Number4;
        private Button Number5;
        private Button Number6;
        private Button Number7;
        private Button Number8;
        private Button Number9;
        private Button Number0;
        private Button MultiplicationSign;
        private Button PlusSign;
        private Button DivisionSign;
        private Button ClearDisplay;
        private Button EqualSign;
        private Button MinusSign;
        private TableLayoutPanel tableLayoutPanel2;
        private Label displayWithOperations;
        private Label displayWithResult;
    }
}