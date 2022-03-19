using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBrewery.Glime.Battle
{
    /// <summary>
    /// Represents an enemy.
    /// </summary>
    [RequireComponent(typeof(NavMeshAgent))]
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

        private NavMeshAgent NavMeshAgent { get; set; }

        public Vector3 Target { get; private set; }

        public float Speed { get; set; }

        public float MaxDistance { get; set; }

        public float CurrentDistance { get; private set; }

        private Vector3 lastPosition;


        /// <summary>
        /// Initializes the enemy.
        /// </summary>
        public void Start()
        {
            Type.AddRange(type);
            NavMeshAgent = GetComponent<NavMeshAgent>();
            lastPosition = transform.position;
        }

        void Update()
        {
            if (!NavMeshAgent.isStopped)
            {
                CurrentDistance += Vector3.Distance(lastPosition, transform.position);
                lastPosition = transform.position;
                if (CurrentDistance > MaxDistance)
                {
                    NavMeshAgent.isStopped = true;
                }
            }
        }

        public void TurnStarts(EncounterManager encounterManager)
        {
            CurrentDistance = 0;
            lastPosition = transform.position;
            Target = encounterManager.EnemyTarget;
            NavMeshAgent.isStopped = false;
        }
    }
}
