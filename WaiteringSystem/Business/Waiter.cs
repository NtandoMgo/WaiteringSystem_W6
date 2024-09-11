using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaiteringSystem.Business
{
    public class Waiter:Role
    {
        #region Data Member
        //encapsulation
        private decimal tips, rate;
        private int NumberOfShifts;
        #endregion

        #region Property Methods
        public decimal getTips
        {
            get { return tips; }
            set { tips = value; }
        }

        public decimal getRate
        {
            get { return rate; }
            set { rate = value; }

        }
        public int getShifts
        {
            get { return NumberOfShifts; }
            set { NumberOfShifts = value; }
        }
        #endregion

        #region Constructors
        public Waiter() : base()
        {
            getRoleValue = RoleType.Waiter;
            description = "Waiter";
            getShifts = 0;
            rate = 0;
        }
        #endregion

        #region Methods
        public override decimal Payment()
        {
            //Will be calculated when shifts are available
            return rate * getShifts + tips;
        }

        #endregion
    }
}

