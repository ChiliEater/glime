using UnityEngine;

namespace CodeBrewery.Glime
{
    /// <summary>
    /// Provides the functionality to let a target follow the player.
    /// </summary>
    public class FollowPlayer : MonoBehaviour
    {
        /// summary>
        /// Gets or sets the transformation target.
        /// </summary>
        [SerializeField]
        public Transform Target { get; set; }

        /// summary>
        /// Gets or sets the speed of the target.
        /// </summary>
        [SerializeField]
        public float SmoothSpeed { get; set; }

        /// <summary>
        /// Gets or sets the offset of the target in relation to the player.
        /// </summary>
        [SerializeField]
        public Vector3 Offset { get; set; }

        /// <summary>
        /// Handles updates on each frame. 
        /// </summary>
        void FixedUpdate()
        {
            Vector3 desiredPosition = Target.position + Offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, SmoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
