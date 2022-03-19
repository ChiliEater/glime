using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBrewery.Glime
{
    /// <summary>
    /// Provides the functionality to handle debug output.
    /// </summary>
    public class DebugOutput : MonoBehaviour
    {
        /// <summary>
        /// The player to get the debug information from.
        /// </summary>
        [SerializeField]
        private GameObject player = null;

        /// <summary>
        /// Gets the text object to print the debug text to.
        /// </summary>
        protected Text DebugText
        {
            get
            {
                return GetComponent<Text>();
            }
        }

        /// <summary>
        /// Gets or sets the player to get the debug information from.
        /// </summary>
        public GameObject Player => player;

        /// <summary>
        /// Gets the movement of the player to get debug information from.
        /// </summary>
        protected PlayerMovement Movement
        {
            get
            {
                return Player.GetComponent<PlayerMovement>();
            }
        }

        /// <summary>
        /// Gets the controller of the player to get debug information from.
        /// </summary>
        protected PlayerController Controller
        {
            get
            {
                return Player.GetComponent<PlayerController>();
            }
        }

        /// <summary>
        /// Gets the rigidbody of the player to get debug information from.
        /// </summary>
        protected Rigidbody2D Rigidbody
        {
            get
            {
                return Player.GetComponent<Rigidbody2D>();
            }
        }

        /// <summary>
        /// Gets or sets the elapsed time.
        /// </summary>
        protected float ElapsedTime { get; set; }

        /// <summary>
        /// Gets or sets the state of the jump action.
        /// </summary>
        protected string JumpState { get; set; }

        // Start is called before the first frame update
        void Start()
        {
            Movement.jumpAction.performed +=
                context =>
                {
                    JumpState = context.phase.ToString();
                };
        }

        // Update is called once per frame
        void Update()
        {
            ElapsedTime += Time.deltaTime;
            DebugText.text = "";
            DebugText.text += "Grounded: " + Controller.Grounded.ToString();
            DebugText.text += "\nJump: " + JumpState;
            DebugText.text += "\nTime: " + ElapsedTime.ToString();
            DebugText.text += "\nH-Spd: " + Rigidbody.velocity.x;
            DebugText.text += "\nV-Spd: " + Rigidbody.velocity.y;
        }
    }
}
