using CodeBrewery.Glime.Battle;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CodeBrewery.Glime.UI.Manager {
    public class CraftingUIManager : UIBehaviour
    {
        private EncounterManager encounterManager;

        public TextMeshProUGUI MinuteLabel;
        public TextMeshProUGUI SecondLabel;
        // Start is called before the first frame update
        void Start()
        {
            encounterManager = mainUIManager.EncounterManager;
            UpdateBattleTime();
        }

        private void UpdateBattleTime()
        {
            MinuteLabel.text = encounterManager.BattleTimeMinute.ToString("00");
            SecondLabel.text = encounterManager.BattleTimeMinute.ToString("00");
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
