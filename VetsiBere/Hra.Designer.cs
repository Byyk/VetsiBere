namespace VetsiBere
{
    partial class Hra
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
            this.myPictureBox1 = new VetsiBere.Model.Overwrites.MyPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.myPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // myPictureBox1
            // 
            this.myPictureBox1.BackColor = System.Drawing.Color.Bisque;
            this.myPictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myPictureBox1.Location = new System.Drawing.Point(0, 0);
            this.myPictureBox1.Name = "myPictureBox1";
            this.myPictureBox1.Size = new System.Drawing.Size(800, 450);
            this.myPictureBox1.TabIndex = 0;
            this.myPictureBox1.TabStop = false;
            this.myPictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.MyPictureBox1_Paint);
            // 
            // Hra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.myPictureBox1);
            this.Name = "Hra";
            this.Text = "Hra";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Hra_FormClosing);
            this.Load += new System.EventHandler(this.Hra_Load);
            this.Shown += new System.EventHandler(this.Hra_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.myPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Model.Overwrites.MyPictureBox myPictureBox1;
    }
}