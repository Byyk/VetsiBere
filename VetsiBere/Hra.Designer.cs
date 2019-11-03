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
      this.components = new System.ComponentModel.Container();
      this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
      this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
      this.button1 = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.SuspendLayout();
      // 
      // flowLayoutPanel1
      // 
      this.flowLayoutPanel1.AutoScroll = true;
      this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
      this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
      this.flowLayoutPanel1.Name = "flowLayoutPanel1";
      this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
      this.flowLayoutPanel1.Size = new System.Drawing.Size(776, 285);
      this.flowLayoutPanel1.TabIndex = 0;
      this.flowLayoutPanel1.Click += new System.EventHandler(this.Hra_Click);
      // 
      // flowLayoutPanel2
      // 
      this.flowLayoutPanel2.AutoScroll = true;
      this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
      this.flowLayoutPanel2.Location = new System.Drawing.Point(12, 303);
      this.flowLayoutPanel2.Name = "flowLayoutPanel2";
      this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(3);
      this.flowLayoutPanel2.Size = new System.Drawing.Size(776, 165);
      this.flowLayoutPanel2.TabIndex = 1;
      // 
      // button1
      // 
      this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.button1.Location = new System.Drawing.Point(794, 12);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(50, 50);
      this.button1.TabIndex = 2;
      this.button1.Text = "||";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.Button1_Click);
      // 
      // button2
      // 
      this.button2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button2.Location = new System.Drawing.Point(794, 68);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(50, 50);
      this.button2.TabIndex = 3;
      this.button2.Text = "|>";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.Button2_Click);
      // 
      // timer1
      // 
      this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
      // 
      // Hra
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Bisque;
      this.ClientSize = new System.Drawing.Size(854, 480);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.button1);
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
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Timer timer1;
  }
}