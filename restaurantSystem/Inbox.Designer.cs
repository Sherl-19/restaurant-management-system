namespace restaurantSystem
{
    partial class Inbox
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
            this.back_btn = new System.Windows.Forms.Button();
            this.inbox_table = new System.Windows.Forms.DataGridView();
            this.complete_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.inbox_table)).BeginInit();
            this.SuspendLayout();
            // 
            // back_btn
            // 
            this.back_btn.Location = new System.Drawing.Point(96, 367);
            this.back_btn.Name = "back_btn";
            this.back_btn.Size = new System.Drawing.Size(75, 23);
            this.back_btn.TabIndex = 1;
            this.back_btn.Text = "Back";
            this.back_btn.UseVisualStyleBackColor = true;
            this.back_btn.Click += new System.EventHandler(this.back_btn_Click);
            // 
            // inbox_table
            // 
            this.inbox_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.inbox_table.Location = new System.Drawing.Point(12, 47);
            this.inbox_table.Name = "inbox_table";
            this.inbox_table.Size = new System.Drawing.Size(779, 300);
            this.inbox_table.TabIndex = 2;
            this.inbox_table.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.inbox_table_CellContentClick);
            // 
            // complete_btn
            // 
            this.complete_btn.Location = new System.Drawing.Point(651, 354);
            this.complete_btn.Name = "complete_btn";
            this.complete_btn.Size = new System.Drawing.Size(75, 23);
            this.complete_btn.TabIndex = 3;
            this.complete_btn.Text = "Complete";
            this.complete_btn.UseVisualStyleBackColor = true;
            this.complete_btn.Click += new System.EventHandler(this.complete_btn_Click);
            // 
            // Inbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::restaurantSystem.Properties.Resources.a;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(814, 556);
            this.Controls.Add(this.complete_btn);
            this.Controls.Add(this.inbox_table);
            this.Controls.Add(this.back_btn);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Inbox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inbox";
            this.Load += new System.EventHandler(this.Inbox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.inbox_table)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button back_btn;
        private System.Windows.Forms.DataGridView inbox_table;
        private System.Windows.Forms.Button complete_btn;
    }
}