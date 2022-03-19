using System;
using UnityEngine;

namespace CodeBrewery.Glime.Battle
{
    /// <summary>
    /// Represents an encounter.
    /// </summary>
    public class EncounterManager : MonoBehaviour
    {
        Participant Player { get; set; }
        Enemy[] Enemies { get; set; }

        public Vector3 EnemyTarget;

        public int EnemyCount;

        public void StartTurn()
        {
            foreach (var enemy in Enemies)
            {
                enemy.TurnStarts(this);
            }
        }

        public void SpawnEnemies()
        {
        }
    }
}
