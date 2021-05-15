using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_1
{
    public partial class CalculatorInterface : Form
    {
        public Calculator calculator { get; set; } = new();

        public CalculatorInterface()
        {
            InitializeComponent();
            //resultOutput.DataBindings.Add("Text", this, "calculator.CurrentValue");
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            calculator.AddElement((sender as Button).Text);
            resultOutput.Text = calculator.CurrentValue;
            if (calculator.Operation != null)
            {
                expression.Text = $"{calculator.FirstNumber:G29} {calculator.Operation} {calculator.SecondNumber:G29}";
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
