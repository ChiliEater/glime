using System.Collections.Generic;
using UnityEngine;

namespace CodeBrewery.Glime.Battle
{
    /// <summary>
    /// Represents an enemy.
    /// </summary>
    public class Enemy : Participant
    {
        /// <summary>
        /// The type of the enemy.
        /// </summary>
        [SerializeField]
        private EnemyType[] type;

        /// <summary>
        /// Gets the type of the enemy.
        /// </summary>
        public List<EnemyType> Type { get; } = new List<EnemyType>();

        /// <summary>
        /// Initializes the enemy.
        /// </summary>
        public void Start()
        {
            Type.AddRange(type);
        }
    }
}
