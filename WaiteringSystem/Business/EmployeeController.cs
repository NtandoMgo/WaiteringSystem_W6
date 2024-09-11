using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaiteringSystem.Data;

namespace WaiteringSystem.Business
{
    
    public class EmployeeController
    {
        #region Data Members
        EmployeeDB employeeDB;
        Collection<Employee> employees;
        #endregion

        #region Properties
        public Collection<Employee> AllEmployees
        {
            get
            {
                return employees;
            }
        }
        #endregion

        #region Constructor
        public EmployeeController()
        {
            //***instantiate the EmployeeDB object to communicate with the database
            employeeDB = new EmployeeDB();
            employees = employeeDB.AllEmployees;
        }
        #endregion

        #region Database Communication.
        public void DataMaintenance(Employee anEmp)
        {
            //perform a given database operation to the dataset in meory; 
            employeeDB.DataSetChange(anEmp);
            employees.Add(anEmp);
        }

        //***Commit the changes to the database
        public bool FinalizeChanges(Employee employee)
        {
            //***call the EmployeeDB method that will commit the changes to the database
            return employeeDB.UpdateDataSource(employee);
        }
        #endregion



        public Collection<Employee> FindByRole(Collection<Employee> emps, Role.RoleType roleVal)
        {
            Collection<Employee> matches = new Collection<Employee>();
            foreach (Employee emp in emps)
            {
                if(emp.role.getRoleValue == roleVal)
                {
                    matches.Add(emp); 
                }
            }
            return matches;
        }



        }
}
