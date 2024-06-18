namespace SnakeFarm
{
    partial class ShopScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.swordPower1 = new System.Windows.Forms.Button();
            this.buckshotButton = new System.Windows.Forms.Button();
            this.hoeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // swordPower1
            // 
            this.swordPower1.Location = new System.Drawing.Point(780, 131);
            this.swordPower1.Name = "swordPower1";
            this.swordPower1.Size = new System.Drawing.Size(163, 107);
            this.swordPower1.TabIndex = 0;
            this.swordPower1.Text = "sword";
            this.swordPower1.UseVisualStyleBackColor = true;
            this.swordPower1.Click += new System.EventHandler(this.swordPower1_Click);
            // 
            // buckshotButton
            // 
            this.buckshotButton.Location = new System.Drawing.Point(564, 131);
            this.buckshotButton.Name = "buckshotButton";
            this.buckshotButton.Size = new System.Drawing.Size(163, 107);
            this.buckshotButton.TabIndex = 1;
            this.buckshotButton.Text = "buckshot";
            this.buckshotButton.UseVisualStyleBackColor = true;
            // 
            // hoeButton
            // 
            this.hoeButton.Location = new System.Drawing.Point(1008, 131);
            this.hoeButton.Name = "hoeButton";
            this.hoeButton.Size = new System.Drawing.Size(163, 107);
            this.hoeButton.TabIndex = 2;
            this.hoeButton.Text = "Hoe";
            this.hoeButton.UseVisualStyleBackColor = true;
            // 
            // ShopScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.hoeButton);
            this.Controls.Add(this.buckshotButton);
            this.Controls.Add(this.swordPower1);
            this.Name = "ShopScreen";
            this.Size = new System.Drawing.Size(1366, 768);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button swordPower1;
        private System.Windows.Forms.Button buckshotButton;
        private System.Windows.Forms.Button hoeButton;
    }
}
