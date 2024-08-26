using Assets.Scripts.EventsBus.ChipEvents;
using Assets.Scripts.Helpers.Parameters;
using Assets.Scripts.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Constants
{
    public static class PlayerConstants
    {
        public static int CurrentCountPlayers { get; private set; } = 0;
        public static int CountAllChip {  get; private set; } = 0;
        public static Dictionary<string, BaseParameters> ListPersons { get; private set; } = new Dictionary<string, BaseParameters>
        {
            {"Командос", new CommandoParameters() },
            {"Инструктор по стрельбе", new ShootingInstructorParameters() },
        };

        public static void AddPlayer()
        {
            CurrentCountPlayers++;
        }
        public static void AddChip()
        {
            CountAllChip++;
            EventBus.Instance.Publish<ChipAddEvent>(1);
        }
        public static void RemoveChip()
        {
            CountAllChip--;
            EventBus.Instance.Publish<ChipRemoveEvent>(-1);
        }
    }
}
