using Assets.Scripts.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Helpers.Parameters
{
    public class ZombieParameters : BaseParameters
    {
        public ZombieParameters(string name, string logo) : base(ZombieConstans.MaxHealth,
                                                                 ZombieConstans.CountMaxActions,
                                                                 ZombieConstans.CountCellPerAction,
                                                                 name,
                                                                 ZombieConstans.AnimatorPath,
                                                                 $"{ZombieConstans.LogoPath}/{logo}")
        {
        }
    }
}
