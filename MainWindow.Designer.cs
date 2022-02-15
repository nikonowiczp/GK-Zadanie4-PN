
namespace GK_Zadanie4_PN
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.camera3Button = new System.Windows.Forms.Button();
            this.camera2Button = new System.Windows.Forms.Button();
            this.camera1Button = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Phong = new System.Windows.Forms.Button();
            this.gouraudaLightingButton = new System.Windows.Forms.Button();
            this.staticLightingButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.fogButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 244F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(951, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(701, 444);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Controls.Add(this.groupBox2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(710, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(238, 444);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.camera3Button);
            this.groupBox1.Controls.Add(this.camera2Button);
            this.groupBox1.Controls.Add(this.camera1Button);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(226, 125);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cameras";
            // 
            // camera3Button
            // 
            this.camera3Button.Location = new System.Drawing.Point(6, 61);
            this.camera3Button.Name = "camera3Button";
            this.camera3Button.Size = new System.Drawing.Size(94, 29);
            this.camera3Button.TabIndex = 2;
            this.camera3Button.Text = "Camera3";
            this.camera3Button.UseVisualStyleBackColor = true;
            this.camera3Button.Click += new System.EventHandler(this.camera3Button_Click);
            // 
            // camera2Button
            // 
            this.camera2Button.Location = new System.Drawing.Point(106, 26);
            this.camera2Button.Name = "camera2Button";
            this.camera2Button.Size = new System.Drawing.Size(94, 29);
            this.camera2Button.TabIndex = 1;
            this.camera2Button.Text = "Camera2";
            this.camera2Button.UseVisualStyleBackColor = true;
            this.camera2Button.Click += new System.EventHandler(this.camera2Button_Click);
            // 
            // camera1Button
            // 
            this.camera1Button.Location = new System.Drawing.Point(6, 26);
            this.camera1Button.Name = "camera1Button";
            this.camera1Button.Size = new System.Drawing.Size(94, 29);
            this.camera1Button.TabIndex = 0;
            this.camera1Button.Text = "Camera1";
            this.camera1Button.UseVisualStyleBackColor = true;
            this.camera1Button.Click += new System.EventHandler(this.camera1Button_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.fogButton);
            this.groupBox2.Controls.Add(this.Phong);
            this.groupBox2.Controls.Add(this.gouraudaLightingButton);
            this.groupBox2.Controls.Add(this.staticLightingButton);
            this.groupBox2.Location = new System.Drawing.Point(3, 134);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(238, 125);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lighting";
            // 
            // Phong
            // 
            this.Phong.Location = new System.Drawing.Point(6, 61);
            this.Phong.Name = "Phong";
            this.Phong.Size = new System.Drawing.Size(94, 29);
            this.Phong.TabIndex = 2;
            this.Phong.Text = "Phong";
            this.Phong.UseVisualStyleBackColor = true;
            this.Phong.Click += new System.EventHandler(this.Phong_Click);
            // 
            // gouraudaLightingButton
            // 
            this.gouraudaLightingButton.Location = new System.Drawing.Point(106, 26);
            this.gouraudaLightingButton.Name = "gouraudaLightingButton";
            this.gouraudaLightingButton.Size = new System.Drawing.Size(94, 29);
            this.gouraudaLightingButton.TabIndex = 1;
            this.gouraudaLightingButton.Text = "Gouraud";
            this.gouraudaLightingButton.UseVisualStyleBackColor = true;
            this.gouraudaLightingButton.Click += new System.EventHandler(this.gouraudaLightingButton_Click);
            // 
            // staticLightingButton
            // 
            this.staticLightingButton.Location = new System.Drawing.Point(6, 26);
            this.staticLightingButton.Name = "staticLightingButton";
            this.staticLightingButton.Size = new System.Drawing.Size(94, 29);
            this.staticLightingButton.TabIndex = 0;
            this.staticLightingButton.Text = "Static";
            this.staticLightingButton.UseVisualStyleBackColor = true;
            this.staticLightingButton.Click += new System.EventHandler(this.staticLightingButton_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 150;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // fogButton
            // 
            this.fogButton.Location = new System.Drawing.Point(106, 61);
            this.fogButton.Name = "fogButton";
            this.fogButton.Size = new System.Drawing.Size(94, 29);
            this.fogButton.TabIndex = 3;
            this.fogButton.Text = "Fog";
            this.fogButton.UseVisualStyleBackColor = true;
            this.fogButton.Click += new System.EventHandler(this.fogButton_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button camera3Button;
        private System.Windows.Forms.Button camera2Button;
        private System.Windows.Forms.Button camera1Button;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Phong;
        private System.Windows.Forms.Button gouraudaLightingButton;
        private System.Windows.Forms.Button staticLightingButton;
        private System.Windows.Forms.Button fogButton;
    }
}

