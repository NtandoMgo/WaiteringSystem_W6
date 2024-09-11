using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaiteringSystem.Business
{
  public  class Employee:Person
    {
        #region Info
        /*Create the derived class Employee from the Person class. 
          An employee has an employee number/ID and a role at the restaurant. 
          Since there are different types of employees with different ROLES in a restaurant, 
          we will create a Role class. Three derived classes (headwaiter, waiter and runner) 
          that inherit the role class will be created first 
          (We can say that a waiter IS A specific role an employee might have in the restaurant, etc.).
          The headwaiter has only salary as a data member. The runner and the waiter have the following attributes: 
          tips, rate and noOfShifts. For now do not include the constructor for these classes. 
          Implement the classes, observing OOP principles. Include encapsulation principles.   */
        #endregion

        #region Data Members
        //encapsulation
        private string empId;
        //need to define a role here - Question 3-Make sure the role data member of this class is of class type Role.
        public Role role;
        #endregion

        #region Property methods
        public string EmployeeID
        {
            get { return empId; }
            set { empId = value; }
        }
        #endregion

        #region Constructor
        /*
         * Include the constructor of the class. 							
            The constructor should have one argument roleValue of type Role. 
            This is because upon the invocation of this class, the role of the employee should be determined.
            Use a switch statement to find the specific role as follows (for more on switch statements):
            If there is no role yet, then:                  role = new Role ();
            If the role is Headwaiter, then:	    	role = new HeadWaiter ();

         */

        public Employee(Role.RoleType roleValue)
        {
            switch (roleValue)
            {
                case Role.RoleType.NoRole:
                    role = new Role();
                    break;
                case Role.RoleType.Headwaiter:
                    role = new HeadWaiter();
                    break;
                case Role.RoleType.Waiter:
                    role = new Waiter();
                    break;
                case Role.RoleType.Runner:
                    role = new Runner();
                    break;
            }
        }
        #endregion

    }
}
