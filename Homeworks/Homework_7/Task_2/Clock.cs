using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Task_2
{
    /// <summary>
    /// Clock form class.
    /// </summary>
    public partial class Clock : Form
    {
        /// <summary>
        /// Creates a new clock form.
        /// </summary>
        public Clock()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constants that determine the length of the hands relative to the form size.
        /// </summary>
        private const float secondHandRelativeLength = 0.4f;
        private const float minuteHandRelativeLength = 0.3f;
        private const float hourHandRelativeLength = 0.2f;

        /// <summary>
        /// Constants that determine the width of the hands relative to the form size.
        /// </summary>
        private const float secondHandRelativeWidth = 0.005f;
        private const float minuteHandRelativeWidth = 0.01f;
        private const float hourHandRelativeWidth = 0.02f;

        /// <summary>
        /// Сonstant that determines the width of the clock face relative to the form size.
        /// </summary>
        private const float clockFaceRelativeWidth = 0.01f;

        /// <summary>
        /// Сonstant that determines the width of the clock face font relative to the form size.
        /// </summary>
        private const float fontRelativeSize = 0.0035f;

        private Matrix RotateAroundPoint(float angle, PointF center)
        {
            var result = new Matrix();
            result.RotateAt(angle, center);
            return result;
        }

        private void DrawHand(Graphics graphics, Color color, float angle, float relativeLength, float relativeWidth)
        {
            var size = Math.Min(pictureBox.Height, pictureBox.Width);
            var pen = new Pen(color, relativeWidth * size);
            PointF center = new(pictureBox.Width / 2f, pictureBox.Height / 2f);
            var length = size * relativeLength;

            graphics.Transform = RotateAroundPoint(angle, center);
            PointF newPoint = new(pictureBox.Width / 2f, pictureBox.Height / 2f - length);
            graphics.DrawLine(pen, center, newPoint);
        }

        private void DrawClockFace(Graphics graphics, Color color, float clockFaceRelativeWidth, float fontRelativeSize)
        {
            var size = Math.Min(pictureBox.Height, pictureBox.Width) * 0.95f;
            var pen = new Pen(color, clockFaceRelativeWidth * size);
            PointF center = new(pictureBox.Width / 2f, pictureBox.Height / 2f);

            graphics.DrawEllipse(pen, center.X - size / 2f, center.Y - size / 2f, size, size);

            for (int i = 1; i <= 12; ++i)
            {
                graphics.Transform = RotateAroundPoint(30 * i, center);
                PointF newPoint = new(center.X, center.Y - size * 0.9f / 2f);
                graphics.TranslateTransform(newPoint.X, newPoint.Y);
                graphics.RotateTransform(-30 * i);
                var format = new StringFormat();
                format.LineAlignment = StringAlignment.Center;
                format.Alignment = StringAlignment.Center;
                graphics.DrawString($"{i}", new Font("Arial", 12 * size * fontRelativeSize), Brushes.Black, 0, 0, format);
            }
        }

        private void DrawClock(Graphics graphics)
        {
            DrawClockFace(graphics, Color.Black, clockFaceRelativeWidth, fontRelativeSize);
            DrawHand(graphics, Color.Red, 6f * DateTime.Now.Second, secondHandRelativeLength, secondHandRelativeWidth);
            DrawHand(graphics, Color.Black, 6f * (DateTime.Now.Minute + DateTime.Now.Second / 60f), minuteHandRelativeLength, minuteHandRelativeWidth);
            DrawHand(graphics, Color.Black, 30f * (DateTime.Now.Hour + DateTime.Now.Minute / 60f + DateTime.Now.Second / 3600f), hourHandRelativeLength, hourHandRelativeWidth);
        }

        private void pictureBoxPaint(object sender, PaintEventArgs e)
        {
            DrawClock(e.Graphics);
        }

        private void timerTick(object sender, EventArgs e)
        {
            pictureBox.Invalidate();
        }
    }
}