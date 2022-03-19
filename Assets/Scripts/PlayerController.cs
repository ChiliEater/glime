using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CodeBrewery.Glime
{
    /// <summary>
    /// Provides the functionality to control the player.
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        /// <summary>
        /// The radius of the overlap circle to determine if grounded.
        /// </summary>
        private static readonly float groundedRadius = 6f;

        /// <summary>
        /// The radius of the overlap circle to determine if the player can stand up.
        /// </summary>
        private static readonly float ceilingRadius = 0.2f;

        /// <summary>
        /// The amount of force added when the player jumps.
        /// </summary>
        [SerializeField]
        private float jumpForce = 400f;

        /// <summary>
        /// <para>The number of ticks a jump can last.</para>
        /// <para>Physics run at 50 TPS.</para>
        /// </summary>
        [SerializeField]
        private int maxJumpDuration;

        /// <summary>
        /// The percentage of the speed that can be applied while crouching.
        /// </summary>
        [Range(0, 1)]
        [SerializeField]
        private float crouchSpeed = 0.36f;

        /// <summary>
        /// How much to smooth out the movement.
        /// </summary>
        [Range(0, .3f)]
        [SerializeField]
        private float movementSmoothing = 0.05f;

        /// <summary>
        /// A value indicating whether a player can steer while jumping.
        /// </summary>
        [SerializeField]
        private bool airControlEnabled = true;

        /// <summary>
        /// A <see cref="LayerMask"/> for determining what's indicated as ground.
        /// </summary>
        [SerializeField]
        private LayerMask groundIndicator;

        /// <summary>
        /// A position marking where to check if the player is grounded.
        /// </summary>
        [SerializeField]
        private Transform groundCheck;

        /// <summary>
        /// A position marking where to check for ceilings.
        /// </summary>
        [SerializeField]
        private Transform ceilingCheck;

        /// <summary>
        /// A collider that will be disabled when crouching.
        /// </summary>
        [SerializeField]
        private Collider2D crouchDisableCollider;

        /// <summary>
        /// A value indicating whether the player is facing to the right.
        /// </summary>
        private bool facingRight = true;

        /// <summary>
        /// The velocity of the player.
        /// </summary>
        private Vector3 velocity = Vector3.zero;

        /// <summary>
        /// The duration of the current jump.
        /// </summary>
        private int currentJumpDuration = 1;

        /// <summary>
        /// A value indicating whether auto-jumping is locked.
        /// </summary>
        private bool jumpLocked = false;

        /// <summary>
        /// A value indicating whether the player has been crouching.
        /// </summary>
        private bool wasCrouching = false;

        /// <summary>
        /// The time the player has spent in the air.
        /// </summary>
        private float aerialTime;

        /// <summary>
        /// A <see cref="GameObject"/> for printing debug information.
        /// </summary>
        [Header("Debug")]
        [Space]
        [SerializeField]
        private GameObject DebugUI;

        /// <summary>
        /// Gets a value indicating whether the player is grounded.
        /// </summary>
        public bool Grounded { get; private set; }

        /// <summary>
        /// Gets a text-field for displaying debug information.
        /// </summary>
        public TextMeshProUGUI DebugText => DebugUI.GetComponent<TextMeshProUGUI>();

        /// <summary>
        /// Gets the <see cref="Rigidbody2D"/> that is attached to this component's <see cref="GameObject"/>.
        /// </summary>
        protected Rigidbody2D Rigidbody2D => GetComponent<Rigidbody2D>();

        /// <summary>
        /// An event which is triggered on load.
        /// </summary>
        [Header("Events")]
        [Space]
        public UnityEvent OnLandEvent;

        /// <summary>
        /// An event which is triggered when the player crouches.
        /// </summary>
        public UnityEvent<bool> OnCrouchEvent;

        /// <summary>
        /// Initializes the component.
        /// </summary>
        void Awake()
        {
            if (OnLandEvent == null)
                OnLandEvent = new UnityEvent();

            if (OnCrouchEvent == null)
                OnCrouchEvent = new UnityEvent<bool>();
        }

        /// <summary>
        /// Handles updates on each frame.
        /// </summary>
        void FixedUpdate()
        {
        }

        /// <summary>
        /// Handles collisions.
        /// </summary>
        /// <param name="collision">An object containing information about the collision.</param>
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                Grounded = true;
                currentJumpDuration = 1;
            }
        }

        /// <summary>
        /// Handles the ending of a collision.
        /// </summary>
        /// <param name="collision">An object containing information about the collision.</param>
        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                Grounded = false;
                // Reset Debug output
                aerialTime = 0.0f;
            }
        }

        /// <summary>
        /// Moves the player.
        /// </summary>
        /// <param name="move">The velocity of the player.</param>
        /// <param name="crouch">A value indicating whether the player is crouching.</param>
        /// <param name="jump">A value indicating whether the player is jumping.</param>
        /// <param name="inputBuffer">The pending user inputs.</param>
        public void Move(float move, bool crouch, bool jump, ConcurrentStack<Input> inputBuffer)
        {
            // If crouching, check to see if the character can stand up
            if (!crouch)
            {
                // If the character has a ceiling preventing them from standing up, keep them crouching
                if (Physics2D.OverlapCircle(ceilingCheck.position, ceilingRadius, groundIndicator))
                {
                    crouch = true;
                }
            }

            // only control the player if grounded or airControl is turned on
            if (Grounded || airControlEnabled)
            {
                // If crouching
                if (crouch)
                {
                    if (!wasCrouching)
                    {
                        wasCrouching = true;
                        OnCrouchEvent.Invoke(true);
                    }

                    // Reduce the speed by the crouchSpeed multiplier
                    move *= crouchSpeed;

                    // Disable one of the colliders when crouching
                    if (crouchDisableCollider != null)
                        crouchDisableCollider.enabled = false;
                }
                else
                {
                    // Enable the collider when not crouching
                    if (crouchDisableCollider != null)
                        crouchDisableCollider.enabled = true;

                    if (wasCrouching)
                    {
                        wasCrouching = false;
                        OnCrouchEvent.Invoke(false);
                    }
                }

                // Move the character by finding the target velocity
                Vector3 targetVelocity = new Vector2(move * 10f, Rigidbody2D.velocity.y);
                // And then smoothing it out and applying it to the character
                Rigidbody2D.velocity = Vector3.SmoothDamp(Rigidbody2D.velocity, targetVelocity, ref velocity, movementSmoothing);

                // If the input is moving the player right and the player is facing left...
                if (move > 0 && !facingRight)
                {
                    // ...flip the player.
                    Flip();
                }
                // Otherwise if the input is moving the player left and the player is facing right...
                else if (move < 0 && facingRight)
                {
                    // ... flip the player.
                    Flip();
                }

                if (!Grounded)
                {
                    aerialTime += Time.fixedDeltaTime;
                    DebugText.text = "Airtime: " + aerialTime.ToString();
                    DebugText.text += "\nCurrent Jump: " + currentJumpDuration;
                    DebugText.text += "\n" + (jumpForce / currentJumpDuration).ToString();
                }

            }
            // If the player should jump...
            if (jump && maxJumpDuration >= currentJumpDuration)
            {
                if (!jump && !Grounded)
                {
                    currentJumpDuration = maxJumpDuration;
                    return;
                }
                // Add a vertical force to the player.
                Rigidbody2D.AddForce(new Vector2(0f, jumpForce / currentJumpDuration));
                currentJumpDuration++;
            }
        }

        public void Flip()
        {
            // Switch the way the player is labelled as facing.
            facingRight = !facingRight;

            // Multiply the player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}
