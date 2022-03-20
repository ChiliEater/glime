using CodeBrewery.Glime.Battle.Potions;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CodeBrewery.Glime.Battle
{
    /// <summary>
    /// Represents an encounter.
    /// </summary>
    public class EncounterManager : MonoBehaviour
    {
        /// <summary>
        /// Gets or sets the instance of the player.
        /// </summary>
        Participant Player { get; set; }

        /// <summary>
        /// Gets the enemies participating in the encounter.
        /// </summary>
        public Enemy[] Enemies { get; private set; }

        /// <summary>
        /// The enemies which are pending to finish their turn.
        /// </summary>
        private List<Enemy> enemiesCurrentlyInTurn = new List<Enemy>();

        /// <summary>
        /// Gets a value indicating whether the battle is ongoing.
        /// </summary>
        public bool BattleOngoing { get; private set; }


        public Transform Transform;
        /// <summary>
        /// Gets or sets the target of the enemies.
        /// </summary>
        public Vector3 EnemyTarget => Transform.position;

        /// <summary>
        /// Gets or sets the number of enemies.
        /// </summary>
        public int EnemyCount { get; set; }

        /// <summary>
        /// Occurs when a turn stopped.
        /// </summary>
        public UnityEvent OnTurnStoppedEvent;

        /// <summary>
        /// Gets the time which passed during the battle.
        /// </summary>
        public TimeSpan BattleTime { get; private set; }

        public UnityEvent<int, List<Potion>> OnTurnStartEvent;

        /// <summary>
        /// Gets the number of minutes which passed during the battle.
        /// </summary>
        public int BattleTimeMinutes => Mathf.FloorToInt(BattleTime.Minutes);

        /// <summary>
        /// Gets the number of seconds in the current minute which passed during the battle.
        /// </summary>
        public int BattleTimeSeconds => Mathf.FloorToInt(BattleTime.Seconds);

        public int TurnCount {get; private set;} = 1;

        /// <summary>
        /// Handles the initialization.
        /// </summary>
        public void Start()
        {
            Enemies = GetComponentsInChildren<Enemy>();
        }

        /// <summary>
        /// Handles updates prior to each frame.
        /// </summary>
        void Update()
        {
            if (BattleOngoing)
            {
                BattleTime +=  TimeSpan.FromSeconds(Time.deltaTime);
            }
        }

        public void StartTurn(List<Potion> potions )
        {
            OnTurnStartEvent.Invoke(TurnCount, potions);
            BattleOngoing = true;
            enemiesCurrentlyInTurn.Clear();
            enemiesCurrentlyInTurn.AddRange(Enemies);
            foreach (var enemy in Enemies)
            {
                enemy.TurnStarts(this);
                enemy.gameObject.SetActive(true);
            }
        }

        public void StopTurn(Enemy enemy)
        {
            Debug.Log("remeoved enemy: " + enemiesCurrentlyInTurn.Remove(enemy));
            Debug.Log("missing end turns from " + enemiesCurrentlyInTurn.Count);
            if(enemiesCurrentlyInTurn.Count == 0)
            {
                TurnCount++;
                BattleOngoing = false;
                OnTurnStoppedEvent.Invoke();
            }
        }
    }
}
