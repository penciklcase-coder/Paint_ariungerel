
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.IO;

namespace Paint
{
    public partial class Form1 : Form
    {
        bool isDrawing = false;

        Point startPoint;
        Point currentPoint;

        Color currentColor = Color.Black;
        float brushSize = 5f;

        string currentTool = "Pen";

        Bitmap canvas;

        public Form1()
        {
            InitializeComponent();

            canvas = new Bitmap(panel2.Width, panel2.Height);

            using (Graphics g = Graphics.FromImage(canvas))
            {
                g.Clear(Color.White);
            }

            panel2.BackColor = Color.White;
            numericUpDown1.Value = 5;
        }

        // COLOR
        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();

            if (cd.ShowDialog() == DialogResult.OK)
            {
                currentColor = cd.Color;
                button1.BackColor = cd.Color;
                currentTool = "Pen";
            }
        }

        // RECTANGLE
        private void button2_Click(object sender, EventArgs e)
        {
            currentTool = "Rectangle";
        }

        // CIRCLE
        private void button3_Click(object sender, EventArgs e)
        {
            currentTool = "Circle";
        }

        // ERASER
        private void button4_Click(object sender, EventArgs e)
        {
            currentTool = "Eraser";
        }

        // CLEAR
        private void button5_Click(object sender, EventArgs e)
        {
            using (Graphics g = Graphics.FromImage(canvas))
            {
                g.Clear(Color.White);
            }

            panel2.Invalidate();
        }

        // SAVE
        private void button6_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter =
                    "PNG Image (*.png)|*.png|JPG Image (*.jpg)|*.jpg";

                sfd.Title = "Save Drawing";
                sfd.FileName = "MyDrawing";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string extension =
                        Path.GetExtension(sfd.FileName).ToLower();

                    if (extension == ".jpg" || extension == ".jpeg")
                    {
                        canvas.Save(sfd.FileName, ImageFormat.Jpeg);
                    }
                    else
                    {
                        canvas.Save(sfd.FileName, ImageFormat.Png);
                    }

                    MessageBox.Show(
                        "Зураг амжилттай хадгалагдлаа!",
                        "Save",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }

        // BRUSH SIZE
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            brushSize = (float)numericUpDown1.Value;
        }

        // MOUSE DOWN
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            isDrawing = true;

            startPoint = e.Location;
            currentPoint = e.Location;
        }

        // MOUSE MOVE
        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDrawing)
                return;

            currentPoint = e.Location;

            if (currentTool == "Pen" || currentTool == "Eraser")
            {
                using (Graphics g = Graphics.FromImage(canvas))
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;

                    using (Pen pen = new Pen(
                        currentTool == "Eraser"
                        ? Color.White
                        : currentColor,
                        currentTool == "Eraser"
                        ? brushSize * 3
                        : brushSize))
                    {
                        pen.StartCap = LineCap.Round;
                        pen.EndCap = LineCap.Round;

                        g.DrawLine(pen, startPoint, currentPoint);
                    }
                }

                startPoint = currentPoint;
            }

            panel2.Invalidate();
        }

        // MOUSE UP
        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            if (!isDrawing)
                return;

            currentPoint = e.Location;

            if (currentTool == "Rectangle" ||
                currentTool == "Circle")
            {
                using (Graphics g = Graphics.FromImage(canvas))
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    DrawShape(g);
                }
            }

            isDrawing = false;

            panel2.Invalidate();
        }

        // DRAW SHAPE
        private void DrawShape(Graphics g)
        {
            int x = Math.Min(startPoint.X, currentPoint.X);
            int y = Math.Min(startPoint.Y, currentPoint.Y);

            int width = Math.Abs(currentPoint.X - startPoint.X);
            int height = Math.Abs(currentPoint.Y - startPoint.Y);

            using (Pen pen = new Pen(currentColor, brushSize))
            {
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;

                if (currentTool == "Rectangle")
                {
                    g.DrawRectangle(pen, x, y, width, height);
                }
                else if (currentTool == "Circle")
                {
                    g.DrawEllipse(pen, x, y, width, height);
                }
            }
        }

        // PAINT AND PREVIEW
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImageUnscaled(canvas, 0, 0);

            if (isDrawing &&
                (currentTool == "Rectangle" ||
                 currentTool == "Circle"))
            {
                int x = Math.Min(startPoint.X, currentPoint.X);
                int y = Math.Min(startPoint.Y, currentPoint.Y);

                int width = Math.Abs(currentPoint.X - startPoint.X);
                int height = Math.Abs(currentPoint.Y - startPoint.Y);

                using (Pen pen = new Pen(currentColor, brushSize))
                {
                    pen.DashStyle = DashStyle.Dash;

                    if (currentTool == "Rectangle")
                    {
                        e.Graphics.DrawRectangle(
                            pen, x, y, width, height);
                    }
                    else
                    {
                        e.Graphics.DrawEllipse(
                            pen, x, y, width, height);
                    }
                }
            }
        }

        // FORM CLOSE
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            canvas.Dispose();
            base.OnFormClosed(e);
        }
    }
}
