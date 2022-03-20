using System.Collections;
using System.Collections.Generic;
using CodeBrewery.Glime.Battle;
using TMPro;
using UnityEngine;

namespace CodeBrewery.Glime.UI.Manager
{
    public class TimeRoundManager : UIBehaviour
    {
    
        public TextMeshProUGUI TurnCountLabel;
        public TextMeshProUGUI MinuteLabel;
        public TextMeshProUGUI SecondLabel;
        private EncounterManager encounterManager => MainUIManager.EncounterManager;

        void Start()
        {
            encounterManager.OnTurnStoppedEvent.AddListener(UpdateTurnCounter);
            UpdateTime();
            UpdateTurnCounter();
        }

        private void OnEnable()
        {
            UpdateTime();
            UpdateTurnCounter();
        }

        void Update()
        {
            UpdateTime();
        }

        private void UpdateTime() {
            if(encounterManager.BattleOngoing) {
                MinuteLabel.text = encounterManager.BattleTimeMinutes.ToString("00");
                SecondLabel.text = encounterManager.BattleTimeSeconds.ToString("00");
            }
        }

        private void UpdateTurnCounter() {
            TurnCountLabel.text = encounterManager.TurnCount.ToString("00");
        }
    }

}