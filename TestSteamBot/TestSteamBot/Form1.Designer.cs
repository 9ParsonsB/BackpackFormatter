namespace TestSteamBot
{
    partial class Form1
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
            this.btnLoadtxt = new System.Windows.Forms.Button();
            this.lstItems = new System.Windows.Forms.ListView();
            this.txtKeyValue = new System.Windows.Forms.TextBox();
            this.lblkeyPrice = new System.Windows.Forms.Label();
            this.lblDev = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLoadtxt
            // 
            this.btnLoadtxt.Location = new System.Drawing.Point(12, 12);
            this.btnLoadtxt.Name = "btnLoadtxt";
            this.btnLoadtxt.Size = new System.Drawing.Size(165, 51);
            this.btnLoadtxt.TabIndex = 2;
            this.btnLoadtxt.Text = "Browse";
            this.btnLoadtxt.UseVisualStyleBackColor = true;
            this.btnLoadtxt.Click += new System.EventHandler(this.btnLoadtxt_Click);
            // 
            // lstItems
            // 
            this.lstItems.GridLines = true;
            this.lstItems.Location = new System.Drawing.Point(12, 69);
            this.lstItems.Name = "lstItems";
            this.lstItems.Size = new System.Drawing.Size(923, 469);
            this.lstItems.TabIndex = 5;
            this.lstItems.UseCompatibleStateImageBehavior = false;
            this.lstItems.View = System.Windows.Forms.View.Details;
            // 
            // txtKeyValue
            // 
            this.txtKeyValue.Location = new System.Drawing.Point(219, 43);
            this.txtKeyValue.Name = "txtKeyValue";
            this.txtKeyValue.Size = new System.Drawing.Size(100, 20);
            this.txtKeyValue.TabIndex = 6;
            this.txtKeyValue.Text = "12.66";
            this.txtKeyValue.TextChanged += new System.EventHandler(this.txtKeyValue_TextChanged);
            // 
            // lblkeyPrice
            // 
            this.lblkeyPrice.AutoSize = true;
            this.lblkeyPrice.Location = new System.Drawing.Point(216, 27);
            this.lblkeyPrice.Name = "lblkeyPrice";
            this.lblkeyPrice.Size = new System.Drawing.Size(92, 13);
            this.lblkeyPrice.TabIndex = 7;
            this.lblkeyPrice.Text = "Price of key in ref:";
            // 
            // lblDev
            // 
            this.lblDev.AutoSize = true;
            this.lblDev.Location = new System.Drawing.Point(326, 50);
            this.lblDev.Name = "lblDev";
            this.lblDev.Size = new System.Drawing.Size(51, 13);
            this.lblDev.TabIndex = 8;
            this.lblDev.Text = "Decimal: ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(818, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 51);
            this.button1.TabIndex = 9;
            this.button1.Text = "Output to .txt";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 550);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblDev);
            this.Controls.Add(this.lblkeyPrice);
            this.Controls.Add(this.txtKeyValue);
            this.Controls.Add(this.lstItems);
            this.Controls.Add(this.btnLoadtxt);
            this.Name = "Form1";
            this.Text = "TF2 Backpack Formatter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadtxt;
        private System.Windows.Forms.ListView lstItems;
        private System.Windows.Forms.TextBox txtKeyValue;
        private System.Windows.Forms.Label lblkeyPrice;
        private System.Windows.Forms.Label lblDev;
        private System.Windows.Forms.Button button1;
    }
}

