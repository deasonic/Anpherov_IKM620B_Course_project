namespace Anpherov_IKM_Course_project
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            tbInput = new TextBox();
            label1 = new Label();
            bStart = new Button();
            tClock = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // tbInput
            // 
            tbInput.Enabled = false;
            tbInput.Location = new Point(330, 150);
            tbInput.Name = "tbInput";
            tbInput.Size = new Size(100, 23);
            tbInput.TabIndex = 0;
            tbInput.KeyPress += tbInput_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(363, 119);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 1;
            label1.Text = "label1";
            // 
            // bStart
            // 
            bStart.Location = new Point(339, 254);
            bStart.Name = "bStart";
            bStart.Size = new Size(75, 23);
            bStart.TabIndex = 2;
            bStart.Text = "Пуск";
            bStart.UseVisualStyleBackColor = true;
            bStart.Click += bStart_Click;
            // 
            // tClock
            // 
            tClock.Interval = 25000;
            tClock.Tick += tClock_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(813, 432);
            Controls.Add(bStart);
            Controls.Add(label1);
            Controls.Add(tbInput);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbInput;
        private Label label1;
        private Button bStart;
        private System.Windows.Forms.Timer tClock;
    }
}