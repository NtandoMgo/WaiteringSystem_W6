using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaiteringSystem.Business;
using static WaiteringSystem.Data.DB;

namespace WaiteringSystem.Data
{
   public class EmployeeDB:DB
    {
        #region  Data members        
        private string table1 = "HeadWaiter";
        private string sqlLocal1 = "SELECT * FROM HeadWaiter";
        private string table2 = "Waiter";
        private string sqlLocal2 = "SELECT * FROM Waiter";
        private string table3 = "Runner";
        private string sqlLocal3 = "SELECT * FROM Runner";
        private Collection<Employee> employees;

        #endregion

        #region Property Method: Collection
        public Collection<Employee> AllEmployees
        {
            get
            {
                return employees;
            }
        }
        #endregion

        #region Constructor
        public EmployeeDB() : base()
        {
            employees = new Collection<Employee>();
            FillDataSet(sqlLocal1, table1);
            Add2Collection(table1);
            FillDataSet(sqlLocal2, table2);
            Add2Collection(table2);
            FillDataSet(sqlLocal3, table3);
            Add2Collection(table3);
        }
        #endregion

        #region Utility Methods
        public DataSet GetDataSet()
        {
            return dsMain;
        }
        private void Add2Collection(string table)
        {
            //Declare references to a myRow object and an Employee object
            DataRow myRow = null;
            Employee anEmp;
            HeadWaiter headw;
            Waiter waiter;
            Runner runner;
            Role.RoleType roleValue = Role.RoleType.NoRole;  //Declare roleValue and initialise
            switch (table)
            {
                case "HeadWaiter":
                    roleValue = Role.RoleType.Headwaiter;
                    break;
                case "Waiter":
                    roleValue = Role.RoleType.Waiter;
                    break;
                case "Runner":
                    roleValue = Role.RoleType.Runner;
                    break;
            }
            //READ from the table  
            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    //Instantiate a new Employee object
                    anEmp = new Employee(roleValue);
                    //Obtain each employee attribute from the specific field in the row in the table
                    anEmp.ID = Convert.ToString(myRow["ID"]).TrimEnd();
                    //Do the same for all other attributes
                    anEmp.EmployeeID = Convert.ToString(myRow["EmpID"]).TrimEnd();
                    anEmp.Name = Convert.ToString(myRow["Name"]).TrimEnd();
                    anEmp.Telephone = Convert.ToString(myRow["Phone"]).TrimEnd();
                    anEmp.role.getRoleValue = (Role.RoleType)Convert.ToByte(myRow["Role"]);
                    //Depending on Role read more Values
                    switch (anEmp.role.getRoleValue)
                    {
                        case Role.RoleType.Headwaiter:
                            headw = (HeadWaiter)anEmp.role;
                            headw.SalaryAmount = Convert.ToDecimal(myRow["Salary"]);
                            break;
                        case Role.RoleType.Waiter:
                            waiter = (Waiter)anEmp.role;
                            waiter.getRate = Convert.ToDecimal(myRow["DayRate"]);
                            waiter.getShifts = Convert.ToInt32(myRow["NoOfShifts"]);
                            //was not included so added myslef
                            waiter.getTips = Convert.ToDecimal(myRow["Tips"]);
                            break;
                        case Role.RoleType.Runner:
                            runner = (Runner)anEmp.role;
                            runner.getRate = Convert.ToDecimal(myRow["DayRate"]);
                            runner.getShifts = Convert.ToInt32(myRow["NoOfShifts"]);
                            // was not included so added myslef
                            runner.getTips = Convert.ToDecimal(myRow["Tips"]);
                            break;
                    }
                    employees.Add(anEmp);
                }
            }
        }
        private void FillRow(DataRow aRow, Employee anEmp, DB.DBOperation dBOperation)
        {
            HeadWaiter headwaiter;
            Runner runner;
            Waiter waiter;
                aRow["ID"] = anEmp.ID;  //NOTE square brackets to indicate index of collections of fields in row.
                aRow["EmpID"] = anEmp.EmployeeID;
                aRow["Name"] = anEmp.Name;
                aRow["Phone"] = anEmp.Telephone;
                aRow["Role"] = (byte)anEmp.role.getRoleValue;
            //*** For each role add the specific data variables

            if(dBOperation == DB.DBOperation.add) {
                aRow["ID"] = anEmp.ID;
                aRow["EmpID"] = anEmp.EmployeeID;
            }

            switch (anEmp.role.getRoleValue)
            {
                case Role.RoleType.Headwaiter:
                    headwaiter = (HeadWaiter)anEmp.role;
                    aRow["Salary"] = headwaiter.SalaryAmount;
                    break;
                case Role.RoleType.Waiter:
                    waiter = (Waiter)anEmp.role;
                    aRow["DayRate"] = waiter.getRate;
                    aRow["NoOfShifts"] = waiter.getShifts;
                    aRow["Tips"] = waiter.getTips;
                    break;
                case Role.RoleType.Runner:
                    runner = (Runner)anEmp.role;
                    aRow["DayRate"] = runner.getRate;
                    aRow["NoOfShifts"] = runner.getShifts;
                    aRow["Tips"] = runner.getTips;
                    break;
            }
        }

        private int FindRow(Employee anEmp, string table)
        {
            int rowIndex = 0;
            DataRow myRow;
            int returnValue = -1;

            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                if (myRow.RowState != DataRowState.Deleted)
                {
                    if (anEmp.ID == Convert.ToString(dsMain.Tables[table].Rows[rowIndex]["ID"]))
                    {
                        //2.3.7 assign rowIndex to returnValue
                        returnValue = rowIndex;
                    }
                    rowIndex++;
                }
            }
            return returnValue;
        }
        #endregion

        #region Database Operations CRUD
        public void DataSetChange(Employee anEmp, DB.DBOperation dBOperation)
        {
            DataRow aRow = null;
            string dataTable = table1;
            switch (anEmp.role.getRoleValue)
            {
                case Role.RoleType.Headwaiter:
                    dataTable = table1;
                   // aRow = dsMain.Tables[dataTable].NewRow();
                   // FillRow(aRow, anEmp);
                   // //Add to the dataset
                   //dsMain.Tables[dataTable].Rows.Add(aRow);
                    break;
                case Role.RoleType.Waiter:
                    dataTable = table2;
                    break;
                case Role.RoleType.Runner:
                    dataTable = table3;
                    break;
            }
            switch (dBOperation)
            {
                case DB.DBOperation.add:
                    aRow = dsMain.Tables[dataTable].NewRow();
                    FillRow(aRow, anEmp, dBOperation);
                    dsMain.Tables[dataTable].Rows.Add(aRow); //Add to the dataset
                    break;
                case DB.DBOperation.edit:
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(anEmp, dataTable)];

                    FillRow(aRow, anEmp, dBOperation);
                    break;
                case DB.DBOperation.delete:
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(anEmp, dataTable)];
                    dsMain.Tables[dataTable].Rows.Remove(aRow);
                    break;
            }
            aRow = dsMain.Tables[dataTable].NewRow();
            FillRow(aRow, anEmp, dBOperation);
            //Add to the dataset
            dsMain.Tables[dataTable].Rows.Add(aRow);
        }
        #endregion

        #region Build Parameters, Create Commands & Update database
        private void Build_INSERT_Parameters(Employee anEmp)
        {
            //Create Parameters to communicate with SQL INSERT...add the input parameter and set its properties.
            SqlParameter param = default(SqlParameter);
            param = new SqlParameter("@ID", SqlDbType.NVarChar, 15, "ID");
            daMain.InsertCommand.Parameters.Add(param);//Add the parameter to the Parameters collection.

            param = new SqlParameter("@EMPID", SqlDbType.NVarChar, 10, "EMPID");
            daMain.InsertCommand.Parameters.Add(param);

            //Do the same for Description & answer -ensure that you choose the right size
            param = new SqlParameter("@Name", SqlDbType.NVarChar, 100, "Name");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Phone", SqlDbType.NVarChar, 15, "Phone");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Role", SqlDbType.TinyInt, 1, "Role");
            daMain.InsertCommand.Parameters.Add(param);
            switch (anEmp.role.getRoleValue)
            {
                case Role.RoleType.Headwaiter:
                    param = new SqlParameter("@Salary", SqlDbType.Money, 8, "Salary");
                    daMain.InsertCommand.Parameters.Add(param);
                    break;
                case Role.RoleType.Waiter:
                    param = new SqlParameter("@Tips", SqlDbType.Money, 8, "Tips");
                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter("@DayRate", SqlDbType.Money, 8, "DayRate");
                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter("@NoOfShifts", SqlDbType.SmallInt, 4, "NoOfShifts");
                    daMain.InsertCommand.Parameters.Add(param);
                    break;
                case Role.RoleType.Runner:
                    param = new SqlParameter("@DayRate", SqlDbType.Money, 8, "DayRate");
                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter("@NoOfShifts", SqlDbType.SmallInt, 4, "NoOfShifts");
                    daMain.InsertCommand.Parameters.Add(param);
                    break;
            }
            //***https://msdn.microsoft.com/en-za/library/ms179882.aspx
        }

        private void Create_INSERT_Command(Employee anEmp)
        {
            //Create the command that must be used to insert values into the Books table..
            switch (anEmp.role.getRoleValue)
            {
                case Role.RoleType.Headwaiter:
                    daMain.InsertCommand = new SqlCommand("INSERT into HeadWaiter (ID, EMPID, Name, Phone, Role, Salary) VALUES (@ID, @EmpID, @Name, @Phone, @Role, @Salary)", cnMain);
                    break;
                case Role.RoleType.Waiter:
                    daMain.InsertCommand = new SqlCommand("INSERT into Waiter (ID, EMPID, Name, Phone, Role, Tips, DayRate, NoOfShifts) VALUES (@ID, @EmpID, @Name, @Phone, @Role, @Tips, @DayRate, @NoOfShifts)", cnMain);
                    break;
                case Role.RoleType.Runner:
                    daMain.InsertCommand = new SqlCommand("INSERT into Runner (ID, EMPID, Name, Phone, Role, DayRate, NoOfShifts) VALUES (@ID, @EmpID, @Name, @Phone, @Role, @DayRate, @NoOfShifts)", cnMain);
                    break;
            }
            Build_INSERT_Parameters(anEmp);
        }

        public bool UpdateDataSource(Employee anEmp)
        {
            bool success = true;
            Create_INSERT_Command(anEmp);
            switch (anEmp.role.getRoleValue)
            {
                case Role.RoleType.Headwaiter:
                    success = UpdateDataSource(sqlLocal1, table1);
                    break;
                case Role.RoleType.Waiter:
                    success = UpdateDataSource(sqlLocal2, table2);
                    break;
                case Role.RoleType.Runner:
                    success = UpdateDataSource(sqlLocal3, table3);
                    break;
            }
            return success;
        }

        private void Build_UPDATE_Parameters(Employee anEmp)
        {
            SqlParameter param = default(SqlParameter);
            param = new SqlParameter("@Name", SqlDbType.NVarChar, 100, "Name");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);
            // 2.5.1 TO DO: -: Do for all fields other than ID and EMPID as for the Build Insert parameters.
           // Ofcourse, depending on the role. The code is similar to the Build_INSERT_Parameters that you created
            param = new SqlParameter("@Original_ID", SqlDbType.NVarChar, 15, "ID");
            param.SourceVersion = DataRowVersion.Original;
            daMain.UpdateCommand.Parameters.Add(param);
        }

        #endregion
    }


}
