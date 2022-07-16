using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    //Player Components
    [HideInInspector]
    public CharacterController controller;

    //Player States
    [HideInInspector]
    private PlayerBaseState currentState;
    public PlayerIdleState IdleState = new PlayerIdleState();
    public PlayerMoveState MoveState = new PlayerMoveState();
    public PlayerJumpState JumpState = new PlayerJumpState();
    public PlayerFallState FallState = new PlayerFallState();
    public PlayerChargeState ChargeState = new PlayerChargeState();
    public PlayerThrowState ThrowState = new PlayerThrowState();

    //Player Movement Stats
    public float maxSpeed = 18f;
    public float jumpHeight = 30f;
    public float gravity = 1.5f;
    public float groundAcceleration = 10f;
    public float airAcceleration =7f;
    public float terminalVelocity = 45f;

    //Player Movement Vars
    private float horizontalInput;
    private float orientation = 1f;
    private float verticalMovement;
    private float playerAcceleration;
    private Vector3 horizontalMovement;
    private Vector3 direction;
    private Vector3 playerVelocity;

    //Player Throw Stats
    public float initialChargeScale = 1f;
    public float initialForce = 150f;
    public float maxChargeTime = 1.5f;
    public float maxChargeScale = 2.5f;
    
    //Player Throw Vars
    [HideInInspector]
    public GameObject coinPrefab;
    [HideInInspector]
    public bool hasCoin = true;
    [HideInInspector]
    public float chargeScale = 1f;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        coinPrefab = (GameObject) Resources.Load("Prefabs/Coin");
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

    private void OnTriggerEnter(Collider other) 
    {
        currentState.OnTriggerEnterState(this, other);
    }

    public void UpdateMovement(bool _canInput)
    {
        if (_canInput)
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

    public void FireCoin()
    {
        if (coinPrefab != null)
        {
            Debug.Log(orientation);
            GameObject coin = (GameObject) Instantiate(coinPrefab, this.transform.position + new Vector3(0, 1, orientation), this.transform.rotation);
            coin.GetComponent<Rigidbody>().AddForce(new Vector3(0, 1/chargeScale * chargeScale, orientation) * initialForce);
        } 
        else
        {
            Debug.LogError("Coin Not Instantiated");
        }
    }

    public void GetCoin(GameObject coin)
    {
        Destroy(coin);
    }

    //Getter Functions
    public PlayerBaseState GetCurrentState() { return currentState; }
    public Vector3 GetPlayerVelocity() { return playerVelocity; }
    public Vector3 GetHorizontalMovement() { return horizontalMovement; }
    public float GetVerticalMovement() { return verticalMovement; }
}
