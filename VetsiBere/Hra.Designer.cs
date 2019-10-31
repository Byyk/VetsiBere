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
      this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
      this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
      this.SuspendLayout();
      // 
      // flowLayoutPanel1
      // 
      this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
      this.flowLayoutPanel1.Name = "flowLayoutPanel1";
      this.flowLayoutPanel1.Size = new System.Drawing.Size(776, 270);
      this.flowLayoutPanel1.TabIndex = 0;
      // 
      // flowLayoutPanel2
      // 
      this.flowLayoutPanel2.Location = new System.Drawing.Point(12, 288);
      this.flowLayoutPanel2.Name = "flowLayoutPanel2";
      this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(3);
      this.flowLayoutPanel2.Size = new System.Drawing.Size(776, 150);
      this.flowLayoutPanel2.TabIndex = 1;
      // 
      // Hra
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Bisque;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.flowLayoutPanel2);
      this.Controls.Add(this.flowLayoutPanel1);
      this.Name = "Hra";
      this.Text = "Hra";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Hra_FormClosing);
      this.Load += new System.EventHandler(this.Hra_Load);
      this.Shown += new System.EventHandler(this.Hra_Shown);
      this.Click += new System.EventHandler(this.Hra_Click);
      this.ResumeLayout(false);

        }

    #endregion

    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
  }
}