using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaiteringSystem.Business
{
    public class Role
    {
        /*The Role class will have a role description(description) and the role ID(roleval) 
            * which can either be: runner, headwaitron, waitron or simply no role.
            * These data members could be reused by the child classes, 
            * so be mindful of the protection rights you give them.
            */

        #region Data Member
        public enum RoleType
        {
            /*The role ID will be stored as an enumeration type. 
             So an employee can either have no role, that is, not yet assigned (0), be a Headwaiter (1), a Waiter (2) 
             or a Runner (3). Once you declare the role type as an enumeration type, make sure the role ID (roleval) 
             is of this type (RoleType).  */
            NoRole = 0,
            Headwaiter = 1,
            Waiter = 2,
            Runner = 3
        }
        protected RoleType roleVal;
        protected string description;

        #endregion

        #region Property Methods
        /*Declare properties for the Role class	*/
        public RoleType getRoleValue
        {
            get { return roleVal; }
            set { roleVal = value; }
        }
        public string getDescription
        {
            get { return description; }
            set { description = value; }
        }
        #endregion

        #region Constructor
        /*Include a default constructor to initialise the values: 
         * Initialise the role ID (roleval) and the role description to no role. 
         * We assume until a role is assigned to an employee, they have no role
         */

        public Role()
        {
            roleVal = Role.RoleType.NoRole;
            description = "No role";
        }
        #endregion

        #region Methods

        public virtual decimal Payment()
        {
            /*Include an overridable method Payment() which is to return the salary.
            * For now the method will return 0;       */
            return 0;
        }

        public virtual decimal Payment(decimal percentage)
        {
            /*Include another overridable method Payment() which takes in an argument
             and returns the salary. */
            return 0;
        }

        #endregion
    }
}
