using CodeBrewery.Glime.Battle.Potions;
using CodeBrewery.Glime.UI.Element;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBrewery.Glime.UI.Manager {
    public class CombatUIManager : UIBehaviour
    {
        private List<Potion> potions = new List<Potion>();
        void Start()
        {
            MainUIManager.EncounterManager.OnTurnStartEvent.AddListener(TurnStartHandler);
        }

        private void TurnStartHandler(int turnCount, List<Potion> potions)
        {
            potions.Clear();
            potions.AddRange(potions);
        }

        public void PotionSelectHandler(TabGroup tabGroup)
        {

        }

    }
}
