using Assets.Scripts.EventsBus.PlayersEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.UI
{
    internal class NextPlayerButton : MonoBehaviour
    {
        public void NextPlayer()
        {
            EventBus.Instance.Publish<NextPlayer>(null);
        }
    }
}
