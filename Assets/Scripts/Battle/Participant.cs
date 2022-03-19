using UnityEngine;

namespace CodeBrewery.Glime.Battle
{
    /// <summary>
    /// Provides the capability to participate at a battle.
    /// </summary>
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
    }
}
