
namespace Paint
{
    partial class Form1
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
            panel1 = new Panel();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            numericUpDown1 = new NumericUpDown();
            button1 = new Button();
            panel2 = new Panel();

            panel1.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)
                (numericUpDown1)).BeginInit();

            SuspendLayout();

            // panel1
            panel1.Controls.Add(button6);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(numericUpDown1);
            panel1.Controls.Add(button1);

            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 47);
            panel1.TabIndex = 0;

            // button6 - SAVE
            button6.Location = new Point(488, 12);
            button6.Name = "button6";
            button6.Size = new Size(75, 23);
            button6.TabIndex = 6;
            button6.Text = "Save";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;

            // button5 - CLEAR
            button5.Location = new Point(407, 12);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 5;
            button5.Text = "Clear";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;

            // button4 - ERASER
            button4.Location = new Point(326, 12);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 4;
            button4.Text = "Eraser";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;

            // button3 - CIRCLE
            button3.Location = new Point(245, 12);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 3;
            button3.Text = "Circle";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;

            // button2 - RECTANGLE
            button2.Location = new Point(162, 12);
            button2.Name = "button2";
            button2.Size = new Size(77, 23);
            button2.TabIndex = 2;
            button2.Text = "Rectangle";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;

            // numericUpDown1
            numericUpDown1.Location = new Point(95, 12);
            numericUpDown1.Maximum = new decimal(
                new int[] { 100, 0, 0, 0 });

            numericUpDown1.Minimum = new decimal(
                new int[] { 1, 0, 0, 0 });

            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(52, 23);
            numericUpDown1.TabIndex = 1;
            numericUpDown1.Value = new decimal(
                new int[] { 5, 0, 0, 0 });

            numericUpDown1.ValueChanged +=
                numericUpDown1_ValueChanged;

            // button1 - COLOR
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(59, 23);
            button1.TabIndex = 0;
            button1.Text = "Color";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;

            // panel2 - DRAWING AREA
            panel2.BackColor = Color.White;
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 47);
            panel2.Name = "panel2";
            panel2.Size = new Size(800, 403);
            panel2.TabIndex = 1;

            panel2.Paint += panel2_Paint;
            panel2.MouseDown += panel2_MouseDown;
            panel2.MouseMove += panel2_MouseMove;
            panel2.MouseUp += panel2_MouseUp;

            // Form1
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;

            ClientSize = new Size(800, 450);

            Controls.Add(panel2);
            Controls.Add(panel1);

            Name = "Form1";
            Text = "My Paint";

            panel1.ResumeLayout(false);

            ((System.ComponentModel.ISupportInitialize)
                (numericUpDown1)).EndInit();

            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private NumericUpDown numericUpDown1;
        private Button button1;
        private Panel panel2;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
    }
}
