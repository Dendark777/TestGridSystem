using Assets.Scripts.Constants;
using Assets.Scripts.EventsBus.UIEvents;
using Assets.Scripts.Helpers.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class TileChipManager : TileBaseManager<ChipInfoePrepareForGame>
    {
        private void OnEnable()
        {
            base.Start();
            SetMaxCountTile(LevelConstants.MaxCountChip);
        }

        public override void AddTile()
        {
            EventBus.Instance.Publish<StartSelectCharacter>(null);
            EventBus.Instance.SubscribeOnce<SelectedCharacter>(AddTile);
        }

        private void AddTile(object eventData)
        {
            var parameters = eventData as BaseParameters;
            base.AddTile();
            _tiles[_tiles.Count - 1].SetParameters(parameters);
            PlayerConstants.AddChip();
        }
    }
}
