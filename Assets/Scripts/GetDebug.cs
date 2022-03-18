using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetDebug : MonoBehaviour
{
    private Text DebugText;
    [SerializeField] private GameObject player;
    private PlayerMovement movement;
    private PlayerController controller;
    private Rigidbody2D rb;
    float time;
    string JumpTime;

    // Start is called before the first frame update
    void Start()
    {
        DebugText = GetComponent<Text>();
        movement = player.GetComponent<PlayerMovement>();
        controller = player.GetComponent<PlayerController>();
        rb = player.GetComponent<Rigidbody2D>();

        movement.jumpAction.performed +=
            context =>
            {
                JumpTime = context.phase.ToString();
            };

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        DebugText.text = "";
        DebugText.text += "Grounded: " + controller.m_Grounded.ToString();
        DebugText.text += "\nJump: " + JumpTime;
        DebugText.text += "\nTime: " + time.ToString();
        DebugText.text += "\nH-Spd: " + rb.velocity.x;
        DebugText.text += "\nV-Spd: " + rb.velocity.y;
    }
}
