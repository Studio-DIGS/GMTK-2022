using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    //Player Components
    public CharacterController controller;

    //Player States
    PlayerBaseState currentState;
    public PlayerIdleState IdleState = new PlayerIdleState();
    public PlayerMoveState MoveState = new PlayerMoveState();
    public PlayerJumpState JumpState = new PlayerJumpState();
    public PlayerFallState FallState = new PlayerFallState();

    //Player Stats
    public float maxSpeed = 18f;
    public float jumpHeight = 30f;
    public float gravity = 1.5f;
    public float groundAcceleration = 10f;
    public float airAcceleration =7f;
    public float terminalVelocity = 45f;

    //Player Movement
    [HideInInspector]
    public float horizontalInput;
    public float orientation = 1f;
    public float verticalMovement;
    public float playerAcceleration;
    public Vector3 horizontalMovement;
    public Vector3 direction;
    public Vector3 playerVelocity;


    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Start()
    {
        currentState = MoveState;

        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(PlayerBaseState _player)
    {
        currentState = _player;
        _player.EnterState(this);
    }

    public void UpdateMovement(PlayerBaseState _player)
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        orientation = Mathf.Clamp(orientation + (horizontalInput * 2), -1, 1);

        direction = (transform.forward * horizontalInput);
        if (controller.isGrounded)
        {
            verticalMovement = -0.5f;
            playerAcceleration = groundAcceleration;

            if (Input.GetButton("Jump"))
            {
                verticalMovement = jumpHeight;
                playerAcceleration = airAcceleration;
            }
        }

        horizontalMovement = Vector3.Lerp(horizontalMovement, direction * maxSpeed, playerAcceleration * Time.deltaTime);
        verticalMovement = Mathf.Lerp(verticalMovement, -1 * terminalVelocity, gravity * Time.deltaTime);

        playerVelocity = new Vector3(horizontalMovement.x, verticalMovement, horizontalMovement.z);

        controller.Move(playerVelocity * Time.deltaTime);

    }

    //Getter Functions
    public PlayerBaseState GetCurrentState() { return currentState; }
    public Vector3 GetPlayerVelocity() {return playerVelocity; }
    public Vector3 GetHorizontalMovement() { return horizontalMovement; }
    public float GetVerticalMovement() { return verticalMovement; }
}
