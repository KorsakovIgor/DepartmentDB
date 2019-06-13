namespace Test
{
    partial class ListOfEmployees
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
            this.listOfEmployee = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listOfEmployee
            // 
            this.listOfEmployee.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listOfEmployee.FormattingEnabled = true;
            this.listOfEmployee.HorizontalScrollbar = true;
            this.listOfEmployee.ItemHeight = 16;
            this.listOfEmployee.Location = new System.Drawing.Point(12, 12);
            this.listOfEmployee.Name = "listOfEmployee";
            this.listOfEmployee.Size = new System.Drawing.Size(637, 388);
            this.listOfEmployee.TabIndex = 0;
            this.listOfEmployee.DoubleClick += new System.EventHandler(this.listOfEmployee_DoubleClick);
            // 
            // ListOfEmployees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 416);
            this.Controls.Add(this.listOfEmployee);
            this.Name = "ListOfEmployees";
            this.Text = "ListOfEmployees";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listOfEmployee;
    }
}