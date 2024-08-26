using Assets.Scripts.Constants;
using Assets.Scripts.Players.Chip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Helpers.Parameters
{
    public class BaseParameters
    {
        public int MaxHealth { get; private set; }
        public int CountMaxActions { get; private set; }
        public int CountCellPerAction { get; private set; }
        public string Name { get; private set; }
        public string AnimatorPath { get; private set; }
        public Inventory Inventory { get; private set; }
        public string LogoPath {  get; private set; }
        public BaseParameters(int maxHealth, int countMaxActions, int countCellPerAction,string name, string animatorPath, string logoPath)
        {
            MaxHealth = maxHealth;
            CountMaxActions = countMaxActions;
            CountCellPerAction = countCellPerAction;
            AnimatorPath = animatorPath;
            Name = name;
            Inventory = new Inventory();
            LogoPath = logoPath;
        }
    }
}
