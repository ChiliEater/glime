using System;
using System.Collections.Concurrent;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

namespace CodeBrewery.Glime
{
    /// <summary>
    /// Provides the functionality to handle the movement of the player.
    /// </summary>
    public class PlayerMovement : MonoBehaviour
    {
        /// <summary>
        /// A component for controlling the player.
        /// </summary>
        [SerializeField]
        private PlayerController controller;

        /// <summary>
        /// An action for moving the player.
        /// </summary>
        [SerializeField]
        private InputAction moveAction;

        /// <summary>
        /// An action for making the player jump.
        /// </summary>
        [SerializeField]
        public InputAction jumpAction;

        /// <summary>
        /// The speed of the player while running.
        /// </summary>
        [SerializeField]
        private float runSpeed = 40f;

        /// <summary>
        /// The horizontal speed of the player while running.
        /// </summary>
        [SerializeField]
        private float horizontalMove = 0f;

        /// <summary>
        /// A value indicating whether the player is able to jump.
        /// </summary>
        [SerializeField]
        bool canJump = true;

        /// <summary>
        /// A value indicating whether the player is jumping.
        /// </summary>
        [SerializeField]
        private bool isJump = false;

        /// <summary>
        /// A value indicating whether a button is pressed.
        /// </summary>
        [SerializeField]
        private bool buttonPressed;

        /// <summary>
        /// A queue containing user input.
        /// </summary>
        private ConcurrentStack<Input> inputBuffer;

        /// <summary>
        /// A component for presenting debug messages.
        /// </summary>
        [Header("Debug")]
        [Space]
        [SerializeField]
        private GameObject DebugUI;

        /// <summary>
        /// Gets a component for writing debug messages to.
        /// </summary>
        private TextMeshProUGUI DebugText => DebugUI.GetComponent<TextMeshProUGUI>();


        // Start is called before the first frame update
        public void Start()
        {
            inputBuffer = new ConcurrentStack<Input>();
            moveAction.Enable();
            jumpAction.Enable();
        }

        /// <summary>
        /// Handles updates on each frame.
        /// </summary>
        public void Update()
        {
            // Poll movement inputs
            horizontalMove = (float)(Math.Round(moveAction.ReadValue<Vector2>()[0]) * runSpeed);

            // Poll jump input
            buttonPressed = Convert.ToBoolean(jumpAction.ReadValue<float>());

            if (canJump && buttonPressed)
            {
                isJump = true;
            }
            else if (!buttonPressed)
            {
                canJump = true;
            }

            // Debug
            DebugText.text = "Jump Action: " + isJump;
        }

        /// <summary>
        /// Handles updates on each tick.
        /// </summary>
        public void FixedUpdate()
        {
            controller.Move(horizontalMove * Time.fixedDeltaTime, false, isJump, inputBuffer);
        }
    }
}
