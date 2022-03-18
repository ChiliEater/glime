using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public PlayerController controller;
    public InputAction moveAction;
    public InputAction jumpAction;
    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool canJump = true;
    bool isJump = false;

    private bool buttonPressed;
    private ConcurrentStack<Input> inputBuffer;

    [Header("Debug")]
    [Space]

    [SerializeField] private GameObject DebugUI;
    private TextMeshProUGUI DebugText;


    // Start is called before the first frame update
    void Start()
    {
        inputBuffer = new ConcurrentStack<Input>();
        controller.GetComponent<PlayerController>();
        DebugText = DebugUI.GetComponent<TextMeshProUGUI>();
        moveAction.Enable();
        jumpAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        // Poll movement inputs
        horizontalMove = (float)(Math.Round(moveAction.ReadValue<Vector2>()[0]) * runSpeed);

        // Poll jump input
        buttonPressed = Convert.ToBoolean(jumpAction.ReadValue<float>());

        if (canJump && buttonPressed)
        {
            isJump = true;
        } else if (!buttonPressed) {
            canJump = true;
        }

        // Debug
        DebugText.text = "Jump Action: " + isJump;
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, isJump, inputBuffer);
    }
}
