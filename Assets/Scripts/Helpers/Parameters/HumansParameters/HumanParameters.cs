using Assets.Scripts.Constants;
using Assets.Scripts.Items.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Helpers.Parameters
{
    public class HumanParameters : BaseParameters
    {
        public HumanParameters(string name, string logo) : base(HumanConstans.MaxHealth,
                                                                HumanConstans.CountMaxActions,
                                                                HumanConstans.CountCellPerAction,
                                                                name,
                                                                HumanConstans.AnimatorPath,
                                                                $"{HumanConstans.LogoPath}/{logo}")
        {
            Inventory.AddWeapon(new Hands());
        }
    }
}
