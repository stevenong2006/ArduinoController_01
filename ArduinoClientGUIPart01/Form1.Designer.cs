namespace ArduinoControllerPart01
{
    partial class ArduinoController
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
            this.LogDisplay = new System.Windows.Forms.RichTextBox();
            this.BinaryControl = new System.Windows.Forms.CheckBox();
            this.QueryButton = new System.Windows.Forms.Button();
            this.QuitButton = new System.Windows.Forms.Button();
            this.AnalogControl = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.AnalogControl)).BeginInit();
            this.SuspendLayout();
            // 
            // LogDisplay
            // 
            this.LogDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.LogDisplay.Location = new System.Drawing.Point(13, 13);
            this.LogDisplay.Name = "LogDisplay";
            this.LogDisplay.Size = new System.Drawing.Size(609, 318);
            this.LogDisplay.TabIndex = 0;
            this.LogDisplay.Text = "";
            // 
            // BinaryControl
            // 
            this.BinaryControl.Appearance = System.Windows.Forms.Appearance.Button;
            this.BinaryControl.Location = new System.Drawing.Point(13, 338);
            this.BinaryControl.Name = "BinaryControl";
            this.BinaryControl.Size = new System.Drawing.Size(112, 32);
            this.BinaryControl.TabIndex = 1;
            this.BinaryControl.Text = "Off";
            this.BinaryControl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BinaryControl.UseVisualStyleBackColor = true;
            this.BinaryControl.CheckedChanged += new System.EventHandler(this.BinaryControl_CheckedChanged);
            // 
            // QueryButton
            // 
            this.QueryButton.Location = new System.Drawing.Point(135, 338);
            this.QueryButton.Name = "QueryButton";
            this.QueryButton.Size = new System.Drawing.Size(113, 31);
            this.QueryButton.TabIndex = 2;
            this.QueryButton.Text = "Query";
            this.QueryButton.UseVisualStyleBackColor = true;
            this.QueryButton.Click += new System.EventHandler(this.QueryButton_Click);
            // 
            // QuitButton
            // 
            this.QuitButton.Location = new System.Drawing.Point(553, 337);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(69, 31);
            this.QuitButton.TabIndex = 3;
            this.QuitButton.Text = "Quit";
            this.QuitButton.UseVisualStyleBackColor = true;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // AnalogControl
            // 
            this.AnalogControl.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.AnalogControl.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.AnalogControl.Location = new System.Drawing.Point(13, 377);
            this.AnalogControl.Maximum = 5;
            this.AnalogControl.Name = "AnalogControl";
            this.AnalogControl.Size = new System.Drawing.Size(235, 45);
            this.AnalogControl.TabIndex = 4;
            this.AnalogControl.Scroll += new System.EventHandler(this.AnalogControl_Scroll);
            // 
            // ArduinoController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 452);
            this.Controls.Add(this.AnalogControl);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.QueryButton);
            this.Controls.Add(this.BinaryControl);
            this.Controls.Add(this.LogDisplay);
            this.Name = "ArduinoController";
            this.Text = "Arduino Controller";
            ((System.ComponentModel.ISupportInitialize)(this.AnalogControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox LogDisplay;
        private System.Windows.Forms.CheckBox BinaryControl;
        private System.Windows.Forms.Button QueryButton;
        private System.Windows.Forms.Button QuitButton;
        private System.Windows.Forms.TrackBar AnalogControl;
    }
}

