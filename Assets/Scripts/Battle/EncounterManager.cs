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
        Participant Player { get; set; }
        public Enemy[] Enemies { get; private set; }

        private List<Enemy> enemiesCurrentlyInTurn = new List<Enemy>();

        public Boolean BattleOngoing { get; private set; }

        public Vector3 EnemyTarget;

        public int EnemyCount;

        public UnityEvent OnTurnStoppedEvent;

        public float battleTime;

        public int BattleTimeMinute => Mathf.FloorToInt(battleTime / 60);
        public int BattleTimeSeconds => Mathf.FloorToInt(battleTime % 60);

        public void Start()
        {
            Enemies = GetComponentsInChildren<Enemy>();
        }

        void Update()
        {
            if (BattleOngoing)
            {
                battleTime += Time.deltaTime;
            }
        }

        public void StartTurn()
        {
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
            enemiesCurrentlyInTurn.Remove(enemy);
            if(enemiesCurrentlyInTurn.Count == 0)
            {
                BattleOngoing = false;
                OnTurnStoppedEvent.Invoke();
            }
        }
    }
}
