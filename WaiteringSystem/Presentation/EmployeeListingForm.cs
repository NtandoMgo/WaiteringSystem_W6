using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using WaiteringSystem.Business;
using WaiteringSystem.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WaiteringSystem.Presentation
{


    public partial class EmployeeListingForm : Form
    {

        #region Variables
        public bool listFormClosed;//= true;
        private Collection<Employee> employees;
        private Role.RoleType roleValue;
        private EmployeeController employeeController;

        private FormStates state;
        public enum FormStates
        {
            view=0,
            add=1,
            edit=2,
            delete=3
        }
        #endregion

        #region property methods

        public Role.RoleType RoleValue
        {

            set { roleValue = value; }

        }

        #endregion

        #region Utility methods
        private void ShowAll(bool value, FormStates state, Role.RoleType roleType)
        {
            id_lbl.Visible = value;
            emp_id_lbl.Visible = value;
            name_lbl.Visible = value;
            phone_lbl.Visible = value;
            pay_lbl.Visible = value;

            textBox1.Visible = value;
            textBox2.Visible = value;
            name_txt.Visible = value;
            phone_txt.Visible = value;
            pay_txt.Visible = value;

            submit_btn.Visible = value;
            cancel_btn.Visible = value;

            if (state == FormStates.view)
            {
                submit_btn.Visible = false;
                edit.Visible = false;
            }

            if ((roleType == Role.RoleType.Waiter) || (roleType == Role.RoleType.Runner) && value)
            {
               shifts_lbl.Visible = value;
               shifts_txt.Visible = value;
            }
            else
            {
                shifts_lbl.Visible = false;
                shifts_txt.Visible = false;
            }
        }

        private void ClearAll()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            name_txt.Text = "";
            phone_txt.Text = "";
            pay_txt.Text = "";
            shifts_txt.Text = "";
        }

        private void EnableEntries(bool value)
        {
            if(state == FormStates.edit && value)
            {
                textBox1.Enabled = !value;
                textBox2.Enabled = !value;
            }else
            {
                textBox1.Enabled = value;
                textBox2.Enabled = value;
            }

            name_txt.Enabled = value;
            phone_txt.Enabled = value;
            pay_txt.Enabled = value;
            shifts_txt.Enabled = value;

            if (state == FormStates.delete)
            {
                cancel_btn.Enabled = !value;
                submit_btn.Enabled = !value;
            }
            else
            {
                cancel_btn.Enabled = value;
                submit_btn.Enabled = value;
            }
        }

        private void PopulateTextBoxes(Employee employee)
        {
            HeadWaiter headW;
            Waiter waiter;
            Runner runner;

            textBox1.Text = employee.ID;
            textBox2.Text = employee.EmployeeID;
            name_txt.Text= employee.Name;
            phone_txt.Text = employee.Telephone;

            switch (employee.role.getRoleValue)
            {
                case Role.RoleType.Headwaiter:
                    headW = (HeadWaiter)employee.role;
                    pay_txt.Text = Convert.ToString(headW.SalaryAmount);
                    break;
                case Role.RoleType.Waiter:
                    waiter = (Waiter)employee.role;
                    pay_txt.Text = Convert.ToString(waiter.getTips);
                    pay_lbl.Text = "Tips";
                    shifts_txt.Text = Convert.ToString(waiter.getShifts);
                    break;
                case Role.RoleType.Runner:
                    runner = (Runner)employee.role;
                    pay_lbl.Text = "Tips";
                    pay_txt.Text = Convert.ToString(runner.getTips);
                    shifts_txt.Text = Convert.ToString(runner.getShifts);
                    break;
            }
        }
        #endregion

        #region Constructor
        public EmployeeListingForm()
        {
            InitializeComponent();
            this.Load += EmployeeListingForm_Load;
            this.Activated += EmployeeListingForm_Activated;

            state = FormStates.view;
        }



        public EmployeeListingForm(EmployeeController empController)
        {

            InitializeComponent();
            employeeController = empController;
            this.Load += EmployeeListingForm_Load;
            this.Activated += EmployeeListingForm_Activated;

        }
        #endregion

        #region Events
        private void EmployeeListingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            listFormClosed = true;
        }
        
        private void EmployeeListingForm_Load(object sender, EventArgs e)
        {
            employeeListView.View = View.Details;
        }

        private void EmployeeListingForm_Activated(object sender, EventArgs e)
        {
            employeeListView.View = View.Details;
        }
        #endregion

        #region ListView set up
        public void setUpEmployeeListView()
        {
            ListViewItem employeeDetails;
            HeadWaiter headW;
            Waiter waiter;
            Runner runner;
            employees = null;
            employeeListView.Clear();

            employeeListView.Columns.Insert(0, "ID", 120, HorizontalAlignment.Left);
            employeeListView.Columns.Insert(1, "EMPID", 120, HorizontalAlignment.Left);
            employeeListView.Columns.Insert(2, "Name", 120, HorizontalAlignment.Left);
            employeeListView.Columns.Insert(3, "Phone", 120, HorizontalAlignment.Left);


            switch (roleValue)
            {
                case Role.RoleType.NoRole:
                    employees = employeeController.AllEmployees; listLabel.Text = "Listing of all employees";
                    employeeListView.Columns.Insert(4, "Payment", 100, HorizontalAlignment.Center);
                    break;
                case Role.RoleType.Headwaiter:
                    //Add a FindByRole method to the EmployeeController
                    employees = employeeController.FindByRole(employeeController.AllEmployees, Role.RoleType.Headwaiter);
                    listLabel.Text = "Listing of all Headwaiters";
                    //Set Up Columns of List View
                    employeeListView.Columns.Insert(4, "Salary", 100, HorizontalAlignment.Center);
                    break;
                case Role.RoleType.Waiter:
                    //Add a FindByRole method to the EmployeeController
                    employees = employeeController.FindByRole(employeeController.AllEmployees, Role.RoleType.Waiter);
                    listLabel.Text = "Listing of all Waiters";
                    //Set Up Columns of List View
                    employeeListView.Columns.Insert(4, "DayRate", 100, HorizontalAlignment.Center);
                    employeeListView.Columns.Insert(5, "NoOfShifts", 100, HorizontalAlignment.Center);
                    employeeListView.Columns.Insert(6, "Tips", 100, HorizontalAlignment.Center);
                    break;

                case Role.RoleType.Runner:
                    //Add a FindByRole method to the EmployeeController
                    employees = employeeController.FindByRole(employeeController.AllEmployees, Role.RoleType.Runner);
                    listLabel.Text = "Listing of all Runners";
                    //Set Up Columns of List View
                    employeeListView.Columns.Insert(4, "DayRate", 100, HorizontalAlignment.Center);
                    employeeListView.Columns.Insert(5, "NoOfShifts", 100, HorizontalAlignment.Center);
                    employeeListView.Columns.Insert(6, "Tips", 100, HorizontalAlignment.Center);
                    break;
            }




            foreach (Employee employee in employees)
            {
                employeeDetails = new ListViewItem();
                employeeDetails.Text = employee.ID.ToString();
                employeeDetails.SubItems.Add(employee.EmployeeID.ToString());
                employeeDetails.SubItems.Add(employee.Name.ToString());
                employeeDetails.SubItems.Add(employee.Telephone.ToString());
                // Do the same for EmpID, Name and Phone
                switch (employee.role.getRoleValue)
                {
                    case Role.RoleType.Headwaiter:
                        headW = (HeadWaiter)employee.role;
                        employeeDetails.SubItems.Add(headW.SalaryAmount.ToString());
                        break;
                    case Role.RoleType.Waiter:
                        waiter = (Waiter)employee.role;
                        employeeDetails.SubItems.Add(waiter.getRate.ToString());
                        employeeDetails.SubItems.Add(waiter.getShifts.ToString());
                        employeeDetails.SubItems.Add(waiter.getTips.ToString());
                        break;
                    case Role.RoleType.Runner:
                        runner = (Runner)employee.role;
                        employeeDetails.SubItems.Add(runner.getRate.ToString());
                        employeeDetails.SubItems.Add(runner.getShifts.ToString());
                        employeeDetails.SubItems.Add(runner.getTips.ToString());
                        break;

                }

                employeeListView.Items.Add(employeeDetails);


            }

            employeeListView.Refresh();
            employeeListView.GridLines = true;
        }
        #endregion

        private void employeeListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            ShowAll(true, state, roleValue);       // form state was initiated as view initially
            state = FormStates.view;
            EnableEntries(false);

            if (employeeListView.SelectedItems.Count > 0) // if you selected an item
            {
                MessageBox.Show("Employee selected");       // debugging
                Employee employee =
                employeeController.Find(employeeListView.SelectedItems[0].Text);
                
                PopulateTextBoxes(employee);
            }
        }
    }
}
