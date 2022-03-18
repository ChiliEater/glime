using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{   
    // Amount of force added when the player jumps.
    [SerializeField] private float m_JumpForce = 400f;
    // How many ticks a jump can last. Physics run at 50 TPS
    [SerializeField] private int m_MaxJumpDuration;
    // Amount of maxSpeed applied to crouching movement. 1 = 100%
    [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;
    // How much to smooth out the movement
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
    // Whether or not a player can steer while jumping
    [SerializeField] private bool m_AirControl = true;
    // A mask determining what is ground to the character
    [SerializeField] private LayerMask m_WhatIsGround;
    // A position marking where to check if the player is grounded.
    [SerializeField] private Transform m_GroundCheck;
    // A position marking where to check for ceilings
    [SerializeField] private Transform m_CeilingCheck;
    // A collider that will be disabled when crouching
    [SerializeField] private Collider2D m_CrouchDisableCollider;

    // Radius of the overlap circle to determine if grounded
    const float k_GroundedRadius = 6f;
    // Whether or not the player is grounded.
    public bool m_Grounded;
    // Radius of the overlap circle to determine if the player can stand up
    const float k_CeilingRadius = .2f;
    private Rigidbody2D m_Rigidbody2D;
    // For determining which way the player is currently facing.
    private bool m_FacingRight = true;
    private Vector3 m_Velocity = Vector3.zero;
    //
    private int m_CurrentJumpDuration = 1;
    // Lock for preventing auto-jump
    private bool JumpLocked = false;

    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    public BoolEvent OnCrouchEvent;
    private bool m_wasCrouching = false;

    [Header("Debug")]
    [Space]

    [SerializeField] private GameObject DebugUI;
    private TextMeshProUGUI DebugText;
    private float AerialTime;
    

    void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

        // Setup debug variable
        DebugText = DebugUI.GetComponent<TextMeshProUGUI>();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();

        if (OnCrouchEvent == null)
            OnCrouchEvent = new BoolEvent();

    }

    void FixedUpdate()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            m_Grounded = true;
            m_CurrentJumpDuration = 1;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            m_Grounded = false;
            // Reset Debug output
            AerialTime = 0.0f;
        }
    }

    public void Move(float move, bool crouch, bool jump, ConcurrentStack<Input> inputBuffer)
    {
        // If crouching, check to see if the character can stand up
        if (!crouch)
        {
            // If the character has a ceiling preventing them from standing up, keep them crouching
            if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
            {
                crouch = true;
            }
        }

        // only control the player if grounded or airControl is turned on
        if (m_Grounded || m_AirControl)
        {
            // If crouching
            if (crouch)
            {
                if (!m_wasCrouching)
                {
                    m_wasCrouching = true;
                    OnCrouchEvent.Invoke(true);
                }

                // Reduce the speed by the crouchSpeed multiplier
                move *= m_CrouchSpeed;

                // Disable one of the colliders when crouching
                if (m_CrouchDisableCollider != null)
                    m_CrouchDisableCollider.enabled = false;
            } else
            {
                // Enable the collider when not crouching
                if (m_CrouchDisableCollider != null)
                    m_CrouchDisableCollider.enabled = true;

                if (m_wasCrouching)
                {
                    m_wasCrouching = false;
                    OnCrouchEvent.Invoke(false);
                }
            }

            // Move the character by finding the target velocity
            Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
            // And then smoothing it out and applying it to the character
            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

            // If the input is moving the player right and the player is facing left...
            if (move > 0 && !m_FacingRight)
            {
                // ...flip the player.
                Flip();
            }
            // Otherwise if the input is moving the player left and the player is facing right...
            else if (move < 0 && m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }

            if (!m_Grounded)
            {
                AerialTime += Time.fixedDeltaTime;
                DebugText.text = "Airtime: " + AerialTime.ToString();
                DebugText.text += "\nCurrent Jump: " + m_CurrentJumpDuration;
                DebugText.text += "\n" + (m_JumpForce / m_CurrentJumpDuration).ToString();
            }
                
        }
        // If the player should jump...
        if (jump && m_MaxJumpDuration >= m_CurrentJumpDuration)
        {
            if (!jump && !m_Grounded)
            {
                m_CurrentJumpDuration = m_MaxJumpDuration;
                return;
            }
            // Add a vertical force to the player.
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce / m_CurrentJumpDuration));
            m_CurrentJumpDuration++;
        }
    }

    public void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
