
namespace Task_1
{
    partial class CalculatorInterface
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.buttonComma = new System.Windows.Forms.Button();
            this.buttonPlusMinus = new System.Windows.Forms.Button();
            this.buttonBackspace = new System.Windows.Forms.Button();
            this.buttonClearEntry = new System.Windows.Forms.Button();
            this.number7 = new System.Windows.Forms.Button();
            this.number8 = new System.Windows.Forms.Button();
            this.number9 = new System.Windows.Forms.Button();
            this.buttonSum = new System.Windows.Forms.Button();
            this.number4 = new System.Windows.Forms.Button();
            this.number5 = new System.Windows.Forms.Button();
            this.number6 = new System.Windows.Forms.Button();
            this.buttonSubtraction = new System.Windows.Forms.Button();
            this.number1 = new System.Windows.Forms.Button();
            this.number2 = new System.Windows.Forms.Button();
            this.number3 = new System.Windows.Forms.Button();
            this.buttonMultiplication = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.number0 = new System.Windows.Forms.Button();
            this.buttonEqual = new System.Windows.Forms.Button();
            this.buttonDivision = new System.Windows.Forms.Button();
            this.expressionLabel = new System.Windows.Forms.Label();
            this.resultLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel.ColumnCount = 4;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.Controls.Add(this.buttonComma, 2, 6);
            this.tableLayoutPanel.Controls.Add(this.buttonPlusMinus, 0, 6);
            this.tableLayoutPanel.Controls.Add(this.buttonBackspace, 2, 2);
            this.tableLayoutPanel.Controls.Add(this.buttonClearEntry, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.number7, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.number8, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.number9, 2, 3);
            this.tableLayoutPanel.Controls.Add(this.buttonSum, 3, 2);
            this.tableLayoutPanel.Controls.Add(this.number4, 0, 4);
            this.tableLayoutPanel.Controls.Add(this.number5, 1, 4);
            this.tableLayoutPanel.Controls.Add(this.number6, 2, 4);
            this.tableLayoutPanel.Controls.Add(this.buttonSubtraction, 3, 3);
            this.tableLayoutPanel.Controls.Add(this.number1, 0, 5);
            this.tableLayoutPanel.Controls.Add(this.number2, 1, 5);
            this.tableLayoutPanel.Controls.Add(this.number3, 2, 5);
            this.tableLayoutPanel.Controls.Add(this.buttonMultiplication, 3, 4);
            this.tableLayoutPanel.Controls.Add(this.buttonClear, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.number0, 1, 6);
            this.tableLayoutPanel.Controls.Add(this.buttonEqual, 3, 6);
            this.tableLayoutPanel.Controls.Add(this.buttonDivision, 3, 5);
            this.tableLayoutPanel.Controls.Add(this.expressionLabel, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.resultLabel, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 7;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.5694F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.660378F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.15405F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.15405F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.15405F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.15405F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.15405F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(382, 553);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // buttonComma
            // 
            this.buttonComma.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonComma.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonComma.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonComma.Location = new System.Drawing.Point(193, 465);
            this.buttonComma.Name = "buttonComma";
            this.buttonComma.Size = new System.Drawing.Size(89, 85);
            this.buttonComma.TabIndex = 20;
            this.buttonComma.Text = ",";
            this.buttonComma.UseVisualStyleBackColor = false;
            this.buttonComma.Click += new System.EventHandler(this.OnButtonClick);
            this.buttonComma.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseDown);
            this.buttonComma.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.buttonComma.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            this.buttonComma.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseUp);
            // 
            // buttonPlusMinus
            // 
            this.buttonPlusMinus.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonPlusMinus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPlusMinus.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonPlusMinus.Location = new System.Drawing.Point(3, 465);
            this.buttonPlusMinus.Name = "buttonPlusMinus";
            this.buttonPlusMinus.Size = new System.Drawing.Size(89, 85);
            this.buttonPlusMinus.TabIndex = 19;
            this.buttonPlusMinus.Text = "±";
            this.buttonPlusMinus.UseVisualStyleBackColor = false;
            this.buttonPlusMinus.Click += new System.EventHandler(this.OnButtonClick);
            this.buttonPlusMinus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseDown);
            this.buttonPlusMinus.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.buttonPlusMinus.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            this.buttonPlusMinus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseUp);
            // 
            // buttonBackspace
            // 
            this.buttonBackspace.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonBackspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonBackspace.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonBackspace.Location = new System.Drawing.Point(193, 109);
            this.buttonBackspace.Name = "buttonBackspace";
            this.buttonBackspace.Size = new System.Drawing.Size(89, 83);
            this.buttonBackspace.TabIndex = 18;
            this.buttonBackspace.Text = "⌫";
            this.buttonBackspace.UseVisualStyleBackColor = false;
            this.buttonBackspace.Click += new System.EventHandler(this.OnButtonClick);
            this.buttonBackspace.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseDown);
            this.buttonBackspace.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.buttonBackspace.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            this.buttonBackspace.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseUp);
            // 
            // buttonClearEntry
            // 
            this.buttonClearEntry.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonClearEntry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonClearEntry.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonClearEntry.Location = new System.Drawing.Point(3, 109);
            this.buttonClearEntry.Name = "buttonClearEntry";
            this.buttonClearEntry.Size = new System.Drawing.Size(89, 83);
            this.buttonClearEntry.TabIndex = 17;
            this.buttonClearEntry.Text = "CE";
            this.buttonClearEntry.UseVisualStyleBackColor = false;
            this.buttonClearEntry.Click += new System.EventHandler(this.OnButtonClick);
            this.buttonClearEntry.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseDown);
            this.buttonClearEntry.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.buttonClearEntry.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            this.buttonClearEntry.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseUp);
            // 
            // number7
            // 
            this.number7.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.number7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.number7.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.number7.Location = new System.Drawing.Point(3, 198);
            this.number7.Name = "number7";
            this.number7.Size = new System.Drawing.Size(89, 83);
            this.number7.TabIndex = 0;
            this.number7.Text = "7";
            this.number7.UseVisualStyleBackColor = false;
            this.number7.Click += new System.EventHandler(this.OnButtonClick);
            this.number7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseDown);
            this.number7.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.number7.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            this.number7.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseUp);
            // 
            // number8
            // 
            this.number8.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.number8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.number8.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.number8.Location = new System.Drawing.Point(98, 198);
            this.number8.Name = "number8";
            this.number8.Size = new System.Drawing.Size(89, 83);
            this.number8.TabIndex = 1;
            this.number8.Text = "8";
            this.number8.UseVisualStyleBackColor = false;
            this.number8.Click += new System.EventHandler(this.OnButtonClick);
            this.number8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseDown);
            this.number8.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.number8.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            this.number8.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseUp);
            // 
            // number9
            // 
            this.number9.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.number9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.number9.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.number9.Location = new System.Drawing.Point(193, 198);
            this.number9.Name = "number9";
            this.number9.Size = new System.Drawing.Size(89, 83);
            this.number9.TabIndex = 2;
            this.number9.Text = "9";
            this.number9.UseVisualStyleBackColor = false;
            this.number9.Click += new System.EventHandler(this.OnButtonClick);
            this.number9.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseDown);
            this.number9.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.number9.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            this.number9.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseUp);
            // 
            // buttonSum
            // 
            this.buttonSum.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonSum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSum.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonSum.Location = new System.Drawing.Point(288, 109);
            this.buttonSum.Name = "buttonSum";
            this.buttonSum.Size = new System.Drawing.Size(91, 83);
            this.buttonSum.TabIndex = 3;
            this.buttonSum.Text = "+";
            this.buttonSum.UseVisualStyleBackColor = false;
            this.buttonSum.Click += new System.EventHandler(this.OnButtonClick);
            this.buttonSum.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseDown);
            this.buttonSum.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.buttonSum.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            this.buttonSum.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseUp);
            // 
            // number4
            // 
            this.number4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.number4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.number4.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.number4.Location = new System.Drawing.Point(3, 287);
            this.number4.Name = "number4";
            this.number4.Size = new System.Drawing.Size(89, 83);
            this.number4.TabIndex = 4;
            this.number4.Text = "4";
            this.number4.UseVisualStyleBackColor = false;
            this.number4.Click += new System.EventHandler(this.OnButtonClick);
            this.number4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseDown);
            this.number4.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.number4.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            this.number4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseUp);
            // 
            // number5
            // 
            this.number5.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.number5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.number5.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.number5.Location = new System.Drawing.Point(98, 287);
            this.number5.Name = "number5";
            this.number5.Size = new System.Drawing.Size(89, 83);
            this.number5.TabIndex = 5;
            this.number5.Text = "5";
            this.number5.UseVisualStyleBackColor = false;
            this.number5.Click += new System.EventHandler(this.OnButtonClick);
            this.number5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseDown);
            this.number5.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.number5.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            this.number5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseUp);
            // 
            // number6
            // 
            this.number6.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.number6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.number6.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.number6.Location = new System.Drawing.Point(193, 287);
            this.number6.Name = "number6";
            this.number6.Size = new System.Drawing.Size(89, 83);
            this.number6.TabIndex = 6;
            this.number6.Text = "6";
            this.number6.UseVisualStyleBackColor = false;
            this.number6.Click += new System.EventHandler(this.OnButtonClick);
            this.number6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseDown);
            this.number6.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.number6.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            this.number6.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseUp);
            // 
            // buttonSubtraction
            // 
            this.buttonSubtraction.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonSubtraction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSubtraction.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonSubtraction.Location = new System.Drawing.Point(288, 198);
            this.buttonSubtraction.Name = "buttonSubtraction";
            this.buttonSubtraction.Size = new System.Drawing.Size(91, 83);
            this.buttonSubtraction.TabIndex = 7;
            this.buttonSubtraction.Text = "-";
            this.buttonSubtraction.UseVisualStyleBackColor = false;
            this.buttonSubtraction.Click += new System.EventHandler(this.OnButtonClick);
            this.buttonSubtraction.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseDown);
            this.buttonSubtraction.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.buttonSubtraction.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            this.buttonSubtraction.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseUp);
            // 
            // number1
            // 
            this.number1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.number1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.number1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.number1.Location = new System.Drawing.Point(3, 376);
            this.number1.Name = "number1";
            this.number1.Size = new System.Drawing.Size(89, 83);
            this.number1.TabIndex = 8;
            this.number1.Text = "1";
            this.number1.UseVisualStyleBackColor = false;
            this.number1.Click += new System.EventHandler(this.OnButtonClick);
            this.number1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseDown);
            this.number1.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.number1.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            this.number1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseUp);
            // 
            // number2
            // 
            this.number2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.number2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.number2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.number2.Location = new System.Drawing.Point(98, 376);
            this.number2.Name = "number2";
            this.number2.Size = new System.Drawing.Size(89, 83);
            this.number2.TabIndex = 9;
            this.number2.Text = "2";
            this.number2.UseVisualStyleBackColor = false;
            this.number2.Click += new System.EventHandler(this.OnButtonClick);
            this.number2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseDown);
            this.number2.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.number2.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            this.number2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseUp);
            // 
            // number3
            // 
            this.number3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.number3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.number3.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.number3.Location = new System.Drawing.Point(193, 376);
            this.number3.Name = "number3";
            this.number3.Size = new System.Drawing.Size(89, 83);
            this.number3.TabIndex = 10;
            this.number3.Text = "3";
            this.number3.UseVisualStyleBackColor = false;
            this.number3.Click += new System.EventHandler(this.OnButtonClick);
            this.number3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseDown);
            this.number3.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.number3.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            this.number3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseUp);
            // 
            // buttonMultiplication
            // 
            this.buttonMultiplication.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonMultiplication.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMultiplication.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonMultiplication.Location = new System.Drawing.Point(288, 287);
            this.buttonMultiplication.Name = "buttonMultiplication";
            this.buttonMultiplication.Size = new System.Drawing.Size(91, 83);
            this.buttonMultiplication.TabIndex = 11;
            this.buttonMultiplication.Text = "*";
            this.buttonMultiplication.UseVisualStyleBackColor = false;
            this.buttonMultiplication.Click += new System.EventHandler(this.OnButtonClick);
            this.buttonMultiplication.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseDown);
            this.buttonMultiplication.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.buttonMultiplication.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            this.buttonMultiplication.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseUp);
            // 
            // buttonClear
            // 
            this.buttonClear.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonClear.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonClear.Location = new System.Drawing.Point(98, 109);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(89, 83);
            this.buttonClear.TabIndex = 12;
            this.buttonClear.Text = "C";
            this.buttonClear.UseVisualStyleBackColor = false;
            this.buttonClear.Click += new System.EventHandler(this.OnButtonClick);
            this.buttonClear.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseDown);
            this.buttonClear.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.buttonClear.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            this.buttonClear.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseUp);
            // 
            // number0
            // 
            this.number0.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.number0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.number0.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.number0.Location = new System.Drawing.Point(98, 465);
            this.number0.Name = "number0";
            this.number0.Size = new System.Drawing.Size(89, 85);
            this.number0.TabIndex = 13;
            this.number0.Text = "0";
            this.number0.UseVisualStyleBackColor = false;
            this.number0.Click += new System.EventHandler(this.OnButtonClick);
            this.number0.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseDown);
            this.number0.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.number0.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            this.number0.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseUp);
            // 
            // buttonEqual
            // 
            this.buttonEqual.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonEqual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonEqual.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonEqual.Location = new System.Drawing.Point(288, 465);
            this.buttonEqual.Name = "buttonEqual";
            this.buttonEqual.Size = new System.Drawing.Size(91, 85);
            this.buttonEqual.TabIndex = 14;
            this.buttonEqual.Text = "=";
            this.buttonEqual.UseVisualStyleBackColor = false;
            this.buttonEqual.Click += new System.EventHandler(this.OnButtonClick);
            this.buttonEqual.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseDown);
            this.buttonEqual.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.buttonEqual.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            this.buttonEqual.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseUp);
            // 
            // buttonDivision
            // 
            this.buttonDivision.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonDivision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDivision.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonDivision.Location = new System.Drawing.Point(288, 376);
            this.buttonDivision.Name = "buttonDivision";
            this.buttonDivision.Size = new System.Drawing.Size(91, 83);
            this.buttonDivision.TabIndex = 15;
            this.buttonDivision.Text = "/";
            this.buttonDivision.UseVisualStyleBackColor = false;
            this.buttonDivision.Click += new System.EventHandler(this.OnButtonClick);
            this.buttonDivision.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseDown);
            this.buttonDivision.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.buttonDivision.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            this.buttonDivision.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseUp);
            // 
            // expressionLabel
            // 
            this.expressionLabel.AutoSize = true;
            this.tableLayoutPanel.SetColumnSpan(this.expressionLabel, 4);
            this.expressionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expressionLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.expressionLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.expressionLabel.Location = new System.Drawing.Point(3, 75);
            this.expressionLabel.Name = "expressionLabel";
            this.expressionLabel.Size = new System.Drawing.Size(376, 31);
            this.expressionLabel.TabIndex = 21;
            this.expressionLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.tableLayoutPanel.SetColumnSpan(this.resultLabel, 4);
            this.resultLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultLabel.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.resultLabel.Location = new System.Drawing.Point(3, 0);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(376, 75);
            this.resultLabel.TabIndex = 22;
            this.resultLabel.Text = "0";
            this.resultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CalculatorInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(382, 553);
            this.Controls.Add(this.tableLayoutPanel);
            this.MinimumSize = new System.Drawing.Size(385, 400);
            this.Name = "CalculatorInterface";
            this.Opacity = 0.95D;
            this.Text = "Calculator";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Button number7;
        private System.Windows.Forms.Button number8;
        private System.Windows.Forms.Button number9;
        private System.Windows.Forms.Button buttonSum;
        private System.Windows.Forms.Button number4;
        private System.Windows.Forms.Button number5;
        private System.Windows.Forms.Button number6;
        private System.Windows.Forms.Button buttonSubtraction;
        private System.Windows.Forms.Button number1;
        private System.Windows.Forms.Button number2;
        private System.Windows.Forms.Button number3;
        private System.Windows.Forms.Button buttonMultiplication;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button number0;
        private System.Windows.Forms.Button buttonEqual;
        private System.Windows.Forms.Button buttonDivision;
        private System.Windows.Forms.Button buttonComma;
        private System.Windows.Forms.Button buttonPlusMinus;
        private System.Windows.Forms.Button buttonBackspace;
        private System.Windows.Forms.Button buttonClearEntry;
        private System.Windows.Forms.Label expressionLabel;
        private System.Windows.Forms.Label result;
        private System.Windows.Forms.Label resultLabel;
    }
}