
namespace ScreenReader
{
    partial class ControlPanel
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
        /// 
        private KeyHandler ghk;
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlPanel));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.bttCaptureArea = new System.Windows.Forms.Button();
            this.InstructionsLabel = new System.Windows.Forms.Label();
            this.AudioButton = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.AudioButton)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "Double Click to open";
            this.notifyIcon1.BalloonTipTitle = "Screen Reader";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick_1);
            // 
            // bttCaptureArea
            // 
            this.bttCaptureArea.Location = new System.Drawing.Point(55, 177);
            this.bttCaptureArea.Name = "bttCaptureArea";
            this.bttCaptureArea.Size = new System.Drawing.Size(159, 31);
            this.bttCaptureArea.TabIndex = 0;
            this.bttCaptureArea.Text = "Make Selection";
            this.bttCaptureArea.UseVisualStyleBackColor = true;
            this.bttCaptureArea.Click += new System.EventHandler(this.bttCaptureArea_Click);
            // 
            // InstructionsLabel
            // 
            this.InstructionsLabel.AutoSize = true;
            this.InstructionsLabel.Location = new System.Drawing.Point(23, 9);
            this.InstructionsLabel.Name = "InstructionsLabel";
            this.InstructionsLabel.Size = new System.Drawing.Size(247, 117);
            this.InstructionsLabel.TabIndex = 1;
            this.InstructionsLabel.Text = resources.GetString("InstructionsLabel.Text");
            this.InstructionsLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // AudioButton
            // 
            this.AudioButton.Image = global::ScreenReader.Properties.Resources.SpeakerIcon;
            this.AudioButton.Location = new System.Drawing.Point(223, 117);
            this.AudioButton.Name = "AudioButton";
            this.AudioButton.Size = new System.Drawing.Size(35, 35);
            this.AudioButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AudioButton.TabIndex = 2;
            this.AudioButton.TabStop = false;
            this.AudioButton.Click += new System.EventHandler(this.AudioButton_Click);
            // 
            // ControlPanel
            // 
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(284, 220);
            this.Controls.Add(this.AudioButton);
            this.Controls.Add(this.InstructionsLabel);
            this.Controls.Add(this.bttCaptureArea);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "ControlPanel";
            this.ShowIcon = false;
            this.Text = "Reader";
            this.TopMost = true;
            this.Resize += new System.EventHandler(this.ControlPanel_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.AudioButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button bttCaptureArea;
        private System.Windows.Forms.Label InstructionsLabel;
        private System.Windows.Forms.PictureBox AudioButton;
    }
}

