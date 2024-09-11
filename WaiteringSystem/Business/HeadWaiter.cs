using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaiteringSystem.Business
{
    public class HeadWaiter:Role
    {
        #region Data Member
        //encapsulation
        private decimal salary;
        #endregion

        #region Property Methods
        public decimal SalaryAmount
        {
            get { return salary; }
            set { salary = value; }
        }
        #endregion

        #region Constructor
        public HeadWaiter() : base()
        {
            getRoleValue = RoleType.Headwaiter;
            description = "Headwaiter";
            salary = 0;
        }
        #endregion

        #region Methods
        public override decimal Payment()
        {
            //Will be calculated when shifts are available
            return salary;
        }
        #endregion
    }
}
