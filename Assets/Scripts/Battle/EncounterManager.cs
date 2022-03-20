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

        public Vector3 EnemyTarget;

        public int EnemyCount;

        public UnityEvent OnTurnStoppedEvent;

        public void Start()
        {
            Enemies = GetComponentsInChildren<Enemy>();
        }

        public void StartTurn()
        {
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
                OnTurnStoppedEvent.Invoke();
            }
        }
    }
}
