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
        public void DataMaintenance(Employee anEmp, DB.DBOperation dBOperation)
        {
            switch (dBOperation)
            {
                case DB.DBOperation.add:
                    employees.Add(anEmp);
                    employeeDB.DataSetChange(anEmp, dBOperation);
                    break;

                case DB.DBOperation.edit:
                    int index = FindIndex(anEmp);
                    if (index >= 0)
                    {
                        employees[index] = anEmp;
                        employeeDB.DataSetChange(anEmp, dBOperation);
                    }
                    break;

                case DB.DBOperation.delete:
                    index = FindIndex(anEmp);
                    if (index >= 0)
                    {
                        employees.RemoveAt(index);
                        employeeDB.DataSetChange(anEmp, dBOperation);
                    }
                    break;
            }
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

        #region Find & Search methods
        public Employee Find(string ID)
        {
            int index = 0;
            bool found = employees[index].ID == ID;
            int count = employees.Count;

            while (!(found) && (index < count - 1))
            {
                index++;
                found = employees[index].ID == ID;
            }

           // return employees[index];    // say index is > count, we exit the loop but haven't found the
                                        // employee, we still gonna return the first employee which is
                                        // not what we looking for
            if (found)
            {
                return employees[index];
            }
            else
            {
                return null; // Employee not found
            }
        }

        public int FindIndex(Employee anEmp)
        {
            //Employee employee = anEmp;
            int counter = 0, count = employees.Count;

            bool found = false;
            found = (anEmp.ID == employees[counter].ID);
            while (!found && counter < count) {

                counter++;
                found = (anEmp.ID == employees[counter].ID);
            }
            if (found)
            {
                return counter;
            }
            else
            {
                return -1;
            }
        }
        #endregion

    }
}
