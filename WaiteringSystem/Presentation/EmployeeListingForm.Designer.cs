
namespace WaiteringSystem.Presentation
{
    partial class EmployeeListingForm
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
            this.listLabel = new System.Windows.Forms.Label();
            this.employeeListView = new System.Windows.Forms.ListView();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.submit_btn = new System.Windows.Forms.Button();
            this.id_lbl = new System.Windows.Forms.Label();
            this.emp_id_lbl = new System.Windows.Forms.Label();
            this.name_lbl = new System.Windows.Forms.Label();
            this.phone_lbl = new System.Windows.Forms.Label();
            this.pay_lbl = new System.Windows.Forms.Label();
            this.shifts_lbl = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.name_txt = new System.Windows.Forms.TextBox();
            this.phone_txt = new System.Windows.Forms.TextBox();
            this.pay_txt = new System.Windows.Forms.TextBox();
            this.shifts_txt = new System.Windows.Forms.TextBox();
            this.delete = new System.Windows.Forms.Button();
            this.edit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listLabel
            // 
            this.listLabel.AutoSize = true;
            this.listLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listLabel.Location = new System.Drawing.Point(12, 5);
            this.listLabel.Name = "listLabel";
            this.listLabel.Size = new System.Drawing.Size(179, 17);
            this.listLabel.TabIndex = 0;
            this.listLabel.Text = "Listing of all employees";
            // 
            // employeeListView
            // 
            this.employeeListView.HideSelection = false;
            this.employeeListView.Location = new System.Drawing.Point(12, 25);
            this.employeeListView.Name = "employeeListView";
            this.employeeListView.Size = new System.Drawing.Size(693, 226);
            this.employeeListView.TabIndex = 1;
            this.employeeListView.UseCompatibleStateImageBehavior = false;
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(505, 412);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(75, 23);
            this.cancel_btn.TabIndex = 2;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.UseVisualStyleBackColor = true;
            // 
            // submit_btn
            // 
            this.submit_btn.Location = new System.Drawing.Point(615, 412);
            this.submit_btn.Name = "submit_btn";
            this.submit_btn.Size = new System.Drawing.Size(75, 23);
            this.submit_btn.TabIndex = 3;
            this.submit_btn.Text = "Submit";
            this.submit_btn.UseVisualStyleBackColor = true;
            // 
            // id_lbl
            // 
            this.id_lbl.AutoSize = true;
            this.id_lbl.Location = new System.Drawing.Point(36, 271);
            this.id_lbl.Name = "id_lbl";
            this.id_lbl.Size = new System.Drawing.Size(18, 13);
            this.id_lbl.TabIndex = 4;
            this.id_lbl.Text = "ID";
            // 
            // emp_id_lbl
            // 
            this.emp_id_lbl.AutoSize = true;
            this.emp_id_lbl.Location = new System.Drawing.Point(246, 274);
            this.emp_id_lbl.Name = "emp_id_lbl";
            this.emp_id_lbl.Size = new System.Drawing.Size(67, 13);
            this.emp_id_lbl.TabIndex = 5;
            this.emp_id_lbl.Text = "Employee ID";
            // 
            // name_lbl
            // 
            this.name_lbl.AutoSize = true;
            this.name_lbl.Location = new System.Drawing.Point(36, 309);
            this.name_lbl.Name = "name_lbl";
            this.name_lbl.Size = new System.Drawing.Size(35, 13);
            this.name_lbl.TabIndex = 6;
            this.name_lbl.Text = "Name";
            // 
            // phone_lbl
            // 
            this.phone_lbl.AutoSize = true;
            this.phone_lbl.Location = new System.Drawing.Point(36, 348);
            this.phone_lbl.Name = "phone_lbl";
            this.phone_lbl.Size = new System.Drawing.Size(38, 13);
            this.phone_lbl.TabIndex = 7;
            this.phone_lbl.Text = "Phone";
            // 
            // pay_lbl
            // 
            this.pay_lbl.AutoSize = true;
            this.pay_lbl.Location = new System.Drawing.Point(36, 379);
            this.pay_lbl.Name = "pay_lbl";
            this.pay_lbl.Size = new System.Drawing.Size(48, 13);
            this.pay_lbl.TabIndex = 8;
            this.pay_lbl.Text = "Payment";
            // 
            // shifts_lbl
            // 
            this.shifts_lbl.AutoSize = true;
            this.shifts_lbl.Location = new System.Drawing.Point(36, 417);
            this.shifts_lbl.Name = "shifts_lbl";
            this.shifts_lbl.Size = new System.Drawing.Size(85, 13);
            this.shifts_lbl.TabIndex = 9;
            this.shifts_lbl.Text = "Number of Shifts";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(137, 271);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(67, 20);
            this.textBox1.TabIndex = 10;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(338, 271);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(80, 20);
            this.textBox2.TabIndex = 11;
            // 
            // name_txt
            // 
            this.name_txt.Location = new System.Drawing.Point(137, 306);
            this.name_txt.Name = "name_txt";
            this.name_txt.Size = new System.Drawing.Size(281, 20);
            this.name_txt.TabIndex = 12;
            // 
            // phone_txt
            // 
            this.phone_txt.Location = new System.Drawing.Point(137, 341);
            this.phone_txt.Name = "phone_txt";
            this.phone_txt.Size = new System.Drawing.Size(100, 20);
            this.phone_txt.TabIndex = 13;
            // 
            // pay_txt
            // 
            this.pay_txt.Location = new System.Drawing.Point(137, 372);
            this.pay_txt.Name = "pay_txt";
            this.pay_txt.Size = new System.Drawing.Size(100, 20);
            this.pay_txt.TabIndex = 14;
            // 
            // shifts_txt
            // 
            this.shifts_txt.Location = new System.Drawing.Point(137, 410);
            this.shifts_txt.Name = "shifts_txt";
            this.shifts_txt.Size = new System.Drawing.Size(100, 20);
            this.shifts_txt.TabIndex = 15;
            // 
            // delete
            // 
            this.delete.BackgroundImage = global::WaiteringSystem.Properties.Resources.delete;
            this.delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.delete.Location = new System.Drawing.Point(615, 266);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(52, 43);
            this.delete.TabIndex = 17;
            this.delete.UseVisualStyleBackColor = true;
            // 
            // edit
            // 
            this.edit.BackgroundImage = global::WaiteringSystem.Properties.Resources.edit;
            this.edit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.edit.Location = new System.Drawing.Point(522, 266);
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(58, 43);
            this.edit.TabIndex = 16;
            this.edit.UseVisualStyleBackColor = true;
            // 
            // EmployeeListingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 450);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.edit);
            this.Controls.Add(this.shifts_txt);
            this.Controls.Add(this.pay_txt);
            this.Controls.Add(this.phone_txt);
            this.Controls.Add(this.name_txt);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.shifts_lbl);
            this.Controls.Add(this.pay_lbl);
            this.Controls.Add(this.phone_lbl);
            this.Controls.Add(this.name_lbl);
            this.Controls.Add(this.emp_id_lbl);
            this.Controls.Add(this.id_lbl);
            this.Controls.Add(this.submit_btn);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.employeeListView);
            this.Controls.Add(this.listLabel);
            this.Name = "EmployeeListingForm";
            this.Text = "Employee Listing";
            this.Activated += new System.EventHandler(this.EmployeeListingForm_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EmployeeListingForm_FormClosed);
            this.Load += new System.EventHandler(this.EmployeeListingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label listLabel;
        private System.Windows.Forms.ListView employeeListView;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.Button submit_btn;
        private System.Windows.Forms.Label id_lbl;
        private System.Windows.Forms.Label emp_id_lbl;
        private System.Windows.Forms.Label name_lbl;
        private System.Windows.Forms.Label phone_lbl;
        private System.Windows.Forms.Label pay_lbl;
        private System.Windows.Forms.Label shifts_lbl;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox name_txt;
        private System.Windows.Forms.TextBox phone_txt;
        private System.Windows.Forms.TextBox pay_txt;
        private System.Windows.Forms.TextBox shifts_txt;
        private System.Windows.Forms.Button edit;
        private System.Windows.Forms.Button delete;
    }
}