using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WaiteringSystem.Business;

namespace WaiteringSystem.Presentation
{
    public partial class EmployeesMDIParent : Form
    {
        #region Variable declaration
        private int childFormNumber = 0;
        EmployeeForm employeeForm;
        EmployeeListingForm employeeListForm;
        EmployeeController employeeController;

        #endregion

        #region Constructor
        public EmployeesMDIParent()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            employeeController = new EmployeeController();
        }

        #endregion

        #region ToolstripMenus
        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
        #endregion

        #region ToolstripMenus Employees
        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void listAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (employeeListForm == null)
            {
                CreateNewEmployeeListForm();
            }
            if (employeeListForm.listFormClosed)
            {
                CreateNewEmployeeListForm();
            }
            employeeListForm.RoleValue = Role.RoleType.NoRole;
            //7.3 write the code to call the setUpEmployeeListView method
            employeeListForm.setUpEmployeeListView();
            //7.4 write the code to show the employeeListForm form
            employeeListForm.Show();
        }

        private void listHeadWaitersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (employeeListForm == null)
            {
                CreateNewEmployeeListForm();
            }
            if (employeeListForm.listFormClosed)
            {
                CreateNewEmployeeListForm();
            }
            employeeListForm.RoleValue = Role.RoleType.Headwaiter;
            //7.3 write the code to call the setUpEmployeeListView method
            employeeListForm.setUpEmployeeListView();
            //7.4 write the code to show the employeeListForm form
            employeeListForm.Show();
        }

        private void listWaitersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (employeeListForm == null)
            {
                //CreateNewEmployeeForm();
                CreateNewEmployeeListForm();
            }
            if (employeeListForm.listFormClosed)// == false)
            {
                CreateNewEmployeeListForm();
            }
            employeeListForm.RoleValue = Role.RoleType.Waiter;
            //7.3 write the code to call the setUpEmployeeListView method
            employeeListForm.setUpEmployeeListView();
            //7.4 write the code to show the employeeListForm form
            employeeListForm.Show();
        }

        private void listRunnersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (employeeListForm == null)
            {
                //CreateNewEmployeeForm();
                CreateNewEmployeeListForm();
            }
            if (employeeListForm.listFormClosed)// == false)
            {
                CreateNewEmployeeListForm();
            }
            employeeListForm.RoleValue = Role.RoleType.Runner;
            //7.3 write the code to call the setUpEmployeeListView method
            employeeListForm.setUpEmployeeListView();
            //7.4 write the code to show the employeeListForm form
            employeeListForm.Show();
        }

        #endregion

        #region Create a New ChildForm  

        private void CreateNewEmployeeForm()
        {
             employeeForm = new EmployeeForm(employeeController);
             employeeForm.MdiParent = this;
            employeeForm.StartPosition = FormStartPosition.CenterParent;
        }

        private void CreateNewEmployeeListForm()
        {

            employeeListForm = new EmployeeListingForm(employeeController);
            employeeListForm.MdiParent = this;
            employeeListForm.StartPosition = FormStartPosition.CenterParent;
        }


        #endregion
    }
}
