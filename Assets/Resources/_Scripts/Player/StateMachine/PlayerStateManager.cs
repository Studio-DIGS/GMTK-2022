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
    public PlayerChargeState ChargeState = new PlayerChargeState();
    public PlayerThrowState ThrowState = new PlayerThrowState();

    //Player Stats
    public float maxSpeed = 18f;
    public float jumpHeight = 30f;
    public float gravity = 1.5f;
    public float groundAcceleration = 10f;
    public float airAcceleration =7f;
    public float terminalVelocity = 45f;

    //Player Movement
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

    void Update()
    {
        currentState.UpdateState(this);
    }

    private void LateUpdate() 
    {
        currentState.LateUpdateState(this);
    }

    public void SwitchState(PlayerBaseState _player)
    {
        currentState = _player;
        _player.EnterState(this);
    }

    public void UpdateMovement(bool modInput)
    {
        if (modInput)
        {
            UpdateInput();
        }
        else
        {
            horizontalInput = 0f;
        }

        direction = (transform.forward * horizontalInput);

        horizontalMovement = Vector3.Lerp(horizontalMovement, direction * maxSpeed, playerAcceleration * Time.deltaTime);
        verticalMovement = Mathf.Lerp(verticalMovement, -1 * terminalVelocity, gravity * Time.deltaTime);

        playerVelocity = new Vector3(horizontalMovement.x, verticalMovement, horizontalMovement.z);
        controller.Move(playerVelocity * Time.deltaTime);
        return;
    }

    public void UpdateInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        orientation = Mathf.Clamp(orientation + (horizontalInput * 2), -1, 1);

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
    }



    //Getter Functions
    public PlayerBaseState GetCurrentState() { return currentState; }
    public Vector3 GetPlayerVelocity() { return playerVelocity; }
    public Vector3 GetHorizontalMovement() { return horizontalMovement; }
    public float GetVerticalMovement() { return verticalMovement; }
}
