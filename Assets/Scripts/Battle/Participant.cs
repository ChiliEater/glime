using UnityEngine;

namespace CodeBrewery.Glime.Battle
{
    /// <summary>
    /// Provides the capability to participate at a battle.
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    public class Participant : MonoBehaviour
    {
        /// <summary>
        /// The hit points of the participant.
        /// </summary>
        [SerializeField]
        private int hitPoints = 1;

        /// <summary>
        /// The attack of the participant.
        /// </summary>
        [SerializeField]
        private int attack = 1;

        /// <summary>
        /// Gets or sets the hit points of the participant.
        /// </summary>
        public int HitPoints
        {
            get => hitPoints;
            set => hitPoints = value;
        }

        /// <summary>
        /// Gets or sets the attack of the participant.
        /// </summary>
        public int Attack
        {
            get => attack;
            set => attack = value;
        }

        /// <summary>
        /// Gets the rigidbody of the participant.
        /// </summary>
        protected Rigidbody2D Rigidbody2D { get; private set; }

        /// <summary>
        /// Initializes the participant.
        /// </summary>
        public virtual void Start()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
        }
    }
}
