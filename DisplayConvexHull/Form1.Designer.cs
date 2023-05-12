using System;
using ConvexHull;

namespace DisplayConvexHull
{
    partial class ConvexHullForm
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
            this.MenuGroup = new System.Windows.Forms.GroupBox();
            this.algorithmComboBox = new System.Windows.Forms.ComboBox();
            this.algorithmLabel = new System.Windows.Forms.Label();
            this.HullPointsLabel = new System.Windows.Forms.Label();
            this.NrPointsLabel = new System.Windows.Forms.Label();
            this.ImportButton = new System.Windows.Forms.Button();
            this.ExportButton = new System.Windows.Forms.Button();
            this.Type = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.GenerateButton = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.MenuGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            //
            // MenuGroup
            //
            this.MenuGroup.Controls.Add(this.algorithmComboBox);
            this.MenuGroup.Controls.Add(this.algorithmLabel);
            this.MenuGroup.Controls.Add(this.HullPointsLabel);
            this.MenuGroup.Controls.Add(this.NrPointsLabel);
            this.MenuGroup.Controls.Add(this.ImportButton);
            this.MenuGroup.Controls.Add(this.ExportButton);
            this.MenuGroup.Controls.Add(this.Type);
            this.MenuGroup.Controls.Add(this.comboBox1);
            this.MenuGroup.Controls.Add(this.label1);
            this.MenuGroup.Controls.Add(this.numericUpDown1);
            this.MenuGroup.Controls.Add(this.GenerateButton);
            this.MenuGroup.Dock = System.Windows.Forms.DockStyle.Left;
            this.MenuGroup.Location = new System.Drawing.Point(0, 0);
            this.MenuGroup.Name = "MenuGroup";
            this.MenuGroup.Size = new System.Drawing.Size(91, 457);
            this.MenuGroup.TabIndex = 1;
            this.MenuGroup.TabStop = false;
            this.MenuGroup.Text = "Menu";
            //
            // algorithmComboBox
            //
            this.algorithmComboBox.FormattingEnabled = true;
            this.algorithmComboBox.Items.AddRange(new object[] {
            "GrahamScan",
            "JarvisMarch",
            "Quickhull"});
            this.algorithmComboBox.Location = new System.Drawing.Point(7, 33);
            this.algorithmComboBox.Name = "algorithmComboBox";
            this.algorithmComboBox.Size = new System.Drawing.Size(75, 21);
            this.algorithmComboBox.TabIndex = 10;
            //
            // algorithmLabel
            //
            this.algorithmLabel.AutoSize = true;
            this.algorithmLabel.Location = new System.Drawing.Point(8, 17);
            this.algorithmLabel.Name = "algorithmLabel";
            this.algorithmLabel.Size = new System.Drawing.Size(50, 13);
            this.algorithmLabel.TabIndex = 9;
            this.algorithmLabel.Text = "Algorithm";
            //
            // HullPointsLabel
            //
            this.HullPointsLabel.AutoSize = true;
            this.HullPointsLabel.Location = new System.Drawing.Point(7, 379);
            this.HullPointsLabel.Name = "HullPointsLabel";
            this.HullPointsLabel.Size = new System.Drawing.Size(57, 13);
            this.HullPointsLabel.TabIndex = 8;
            this.HullPointsLabel.Text = "HullPoints:";
            //
            // NrPointsLabel
            //
            this.NrPointsLabel.AutoSize = true;
            this.NrPointsLabel.Location = new System.Drawing.Point(8, 360);
            this.NrPointsLabel.Name = "NrPointsLabel";
            this.NrPointsLabel.Size = new System.Drawing.Size(50, 13);
            this.NrPointsLabel.TabIndex = 7;
            this.NrPointsLabel.Text = "NrPoints:";
            //
            // ImportButton
            //
            this.ImportButton.Location = new System.Drawing.Point(6, 399);
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.Size = new System.Drawing.Size(75, 23);
            this.ImportButton.TabIndex = 6;
            this.ImportButton.Text = "Import";
            this.ImportButton.UseVisualStyleBackColor = true;
            this.ImportButton.Click += new System.EventHandler(this.ImportButton_Click);
            //
            // ExportButton
            //
            this.ExportButton.Location = new System.Drawing.Point(6, 428);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(75, 23);
            this.ExportButton.TabIndex = 5;
            this.ExportButton.Text = "Export";
            this.ExportButton.UseVisualStyleBackColor = true;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            //
            // Type
            //
            this.Type.AutoSize = true;
            this.Type.Location = new System.Drawing.Point(3, 96);
            this.Type.Name = "Type";
            this.Type.Size = new System.Drawing.Size(86, 13);
            this.Type.TabIndex = 4;
            this.Type.Text = "Generation Type";
            //
            // comboBox1
            //
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(7, 112);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(75, 21);
            this.comboBox1.TabIndex = 3;
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Number points";
            //
            // numericUpDown1
            //
            this.numericUpDown1.Increment = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(7, 73);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(75, 20);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            //
            // GenerateButton
            //
            this.GenerateButton.Location = new System.Drawing.Point(6, 139);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(75, 23);
            this.GenerateButton.TabIndex = 0;
            this.GenerateButton.Text = "Generate";
            this.GenerateButton.UseVisualStyleBackColor = true;
            this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            //
            // pictureBox
            //
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(91, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(583, 457);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox.Resize += new System.EventHandler(this.pictureBox_Resize);
            //
            // ConvexHullForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 457);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.MenuGroup);
            this.Name = "ConvexHullForm";
            this.Text = "ConvexHullForm";
            this.MenuGroup.ResumeLayout(false);
            this.MenuGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox MenuGroup;
        private System.Windows.Forms.Button GenerateButton;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;

        private void pictureBox_Resize(object sender, EventArgs e)
        {
            pictureBox.Invalidate();
        }

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label Type;
        private System.Windows.Forms.Label HullPointsLabel;
        private System.Windows.Forms.Label NrPointsLabel;
        private System.Windows.Forms.Button ImportButton;
        private System.Windows.Forms.Button ExportButton;
        private System.Windows.Forms.Label algorithmLabel;
        private System.Windows.Forms.ComboBox algorithmComboBox;
    }
}
