using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
        /// The last position of the enemy.
        /// </summary>
        private Vector3 lastPosition;

        /// <summary>
        /// Gets the type of the enemy.
        /// </summary>
        public List<EnemyType> Type { get; } = new List<EnemyType>();


        /// <summary>
        /// Gets the position of the target the enemy should be moving to.
        /// </summary>
        private Vector3 target;

        /// <summary>
        /// Gets or sets the speed of the enemy.
        /// </summary>
        public float Speed;

        /// <summary>
        /// Gets or sets the maximum of the distance the enemy is allowed to go.
        /// </summary>
        public float MaxDistance;

        /// <summary>
        /// Gets the current distance the enemy walked so far.
        /// </summary>
        public float CurrentDistance { get; private set; }

        private bool walking = false;
        private Rigidbody2D rb;

        private EncounterManager encounterManager;

        /// <summary>
        /// Initializes the enemy.
        /// </summary>
        public override void Start()
        {
            base.Start();
            Type.AddRange(type);
            lastPosition = transform.position;
            rb = GetComponent<Rigidbody2D>();
        }

        /// <summary>
        /// Handles updates before each frame.
        /// </summary>
        void Update()
        {
            if (walking)
            {
                Debug.Log("walking");
                lastPosition = transform.position;
                rb.MovePosition(Vector3.MoveTowards(transform.position, target, Speed*Time.deltaTime));
                CurrentDistance += Mathf.Abs(Vector3.Distance(lastPosition, transform.position));
                Debug.Log($"CurrentDistance: {CurrentDistance}, maxDistance: {MaxDistance}");
                if (CurrentDistance > MaxDistance)
                {
                    encounterManager.StopTurn(this);
                    walking = false;
                }
            }
        }

        /// <summary>
        /// Starts a turn.
        /// </summary>
        /// <param name="encounterManager">A component for managing the encounter.</param>
        public void TurnStarts(EncounterManager encounterManager)
        {
            this.encounterManager = encounterManager;
            CurrentDistance = 0;
            lastPosition = transform.position;
            target = encounterManager.EnemyTarget;
            walking = true;
        }
    }
}
