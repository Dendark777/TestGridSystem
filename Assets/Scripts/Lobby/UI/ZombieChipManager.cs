using Assets.Scripts.Constants;
using Assets.Scripts.EventsBus.ChipEvents;
using Assets.Scripts.Helpers.Parameters;
using Assets.Scripts.Helpers.Parameters.ZimbiesParameters;
using Assets.Scripts.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.PrepareForGame.UI
{
    public class ZombieChipManager : TileBaseManager<ChipInfoePrepareForGame>
    {
        private void OnEnable()
        {
            _tiles = new List<ChipInfoePrepareForGame>();
            EventBus.Instance.Subscribe<ChipAddEvent>(AddTile);
            EventBus.Instance.Subscribe<ChipRemoveEvent>(RemoveTile);
            for (int i = 0; i < ZombieConstans.MaxCountZombie; i++)
            {
                AddTile(new NormalZombieParameters());
            }
        }

        private void AddTile(object eventData)
        {
            SetMaxCountTile(ZombieConstans.MaxCountZombie);
            for (int i = _tiles.Count; i < ZombieConstans.MaxCountZombie; i++)
            {
                base.AddTile();
                _tiles[i].SetParameters(new NormalZombieParameters());
            }
        }
        private void RemoveTile(object eventData)
        {
            base.RemoveTile();
        }

        private void OnDestroy()
        {
            OnDisable();
        }
        private void OnDisable()
        {
            EventBus.Instance.Unsubscribe<ChipAddEvent>(AddTile);
            EventBus.Instance.Unsubscribe<ChipRemoveEvent>(RemoveTile);
        }

    }
}
