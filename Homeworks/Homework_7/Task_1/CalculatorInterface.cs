using System;
using System.Windows.Forms;

namespace Task_1
{
    public partial class CalculatorInterface : Form
    {
        private Calculator calculator;

        public CalculatorInterface()
        {
            InitializeComponent();
            calculator = new();
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            calculator.AddElement((sender as Button).Text);
            resultLabel.Text = calculator.CurrentValue;
            if (calculator.Operation != null)
            {
                expressionLabel.Text = $"{calculator.FirstNumber:G29} {calculator.Operation} {calculator.SecondNumber:G29}";
            }
            else
            {
                expressionLabel.Text = "";
            }
        }

        private void ButtonMouseEnter(object sender, EventArgs e)
        {
            (sender as Button).BackColor = System.Drawing.SystemColors.ButtonShadow;
        }

        private void ButtonMouseLeave(object sender, EventArgs e)
        {
            (sender as Button).BackColor = System.Drawing.SystemColors.ButtonFace;
        }

        private void ButtonMouseDown(object sender, MouseEventArgs e)
        {
            (sender as Button).BackColor = System.Drawing.SystemColors.ButtonHighlight;
        }

        private void ButtonMouseUp(object sender, MouseEventArgs e)
        {
            (sender as Button).BackColor = System.Drawing.SystemColors.ButtonShadow;
        }
    }
}