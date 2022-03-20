using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBrewery.Glime.Battle
{
    /// <summary>
    /// Represents an enemy.
    /// </summary>
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Enemy : Participant
    {
        /// <summary>
        /// The type of the enemy.
        /// </summary>
        [SerializeField]
        private EnemyType[] type;

        /// <summary>
        /// The last position of the enemy.
        /// </summary>
        private Vector3 lastPosition;

        /// <summary>
        /// Gets the type of the enemy.
        /// </summary>
        public List<EnemyType> Type { get; } = new List<EnemyType>();

        /// <summary>
        /// Gets or sets a component for determining the movement path of the enemy.
        /// </summary>
        private NavMeshAgent NavMeshAgent { get; set; }

        /// <summary>
        /// Gets the position of the target the enemy should be moving to.
        /// </summary>
        public Vector3 Target { get; private set; }

        /// <summary>
        /// Gets or sets the speed of the enemy.
        /// </summary>
        public float Speed { get; set; }

        /// <summary>
        /// Gets or sets the maximum of the distance the enemy is allowed to go.
        /// </summary>
        public float MaxDistance { get; set; }

        /// <summary>
        /// Gets the current distance the enemy walked so far.
        /// </summary>
        public float CurrentDistance { get; private set; }

        /// <summary>
        /// Gets the rigidbody of the enemy.
        /// </summary>
        protected Rigidbody2D Rigidbody2D { get; private set; }

        /// <summary>
        /// Initializes the enemy.
        /// </summary>
        public void Start()
        {
            Type.AddRange(type);
            NavMeshAgent = GetComponent<NavMeshAgent>();
            Rigidbody2D = GetComponent<Rigidbody2D>();
            lastPosition = transform.position;
        }

        /// <summary>
        /// Handles updates before each frame.
        /// </summary>
        void Update()
        {
            if (NavMeshAgent.isOnNavMesh && !NavMeshAgent.isStopped)
            {
                CurrentDistance += Vector3.Distance(lastPosition, transform.position);
                lastPosition = transform.position;
                if (CurrentDistance > MaxDistance)
                {
                    NavMeshAgent.isStopped = true;
                }
            }
        }

        /// <summary>
        /// Starts a turn.
        /// </summary>
        /// <param name="encounterManager">A component for managing the encounter.</param>
        public void TurnStarts(EncounterManager encounterManager)
        {
            CurrentDistance = 0;
            lastPosition = transform.position;
            Target = encounterManager.EnemyTarget;
            NavMeshAgent.isStopped = false;
        }
    }
}
