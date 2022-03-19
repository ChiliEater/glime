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
        public Enemy[] Enemies { get; private set; }

        public Vector3 EnemyTarget;

        public int EnemyCount;

        public void Start()
        {
            Enemies = GetComponentsInChildren<Enemy>();
        }

        public void StartTurn()
        {
            foreach (var enemy in Enemies)
            {
                enemy.TurnStarts(this);
            }
        }
    }
}
