using Assets.Scripts.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Helpers.Parameters
{
    public class HumanParameters : BaseParameters
    {
        public HumanParameters() : base(HumanConstans.MaxHealth,
                                        HumanConstans.CountMaxActions,
                                        HumanConstans.CountCellPerAction,
                                        HumanConstans.AnimatorPath)
        {
        }
    }
}
