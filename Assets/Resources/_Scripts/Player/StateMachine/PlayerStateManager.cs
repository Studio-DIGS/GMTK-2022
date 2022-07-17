using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    //Player Components
    public Camera playerCamera;
    public Animator animator;
    [HideInInspector]
    public CharacterController controller;
    public DrawTrajectory drawTrajectory;
    public SpriteRenderer sprite;
    public Score score = new Score();

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
    private bool facingRight = false;

    //Player Throw Stats
    public float initialChargeScale = 1f;
    public float initialForce = 150f;
    public float maxChargeTime = 1.5f;
    public float maxChargeScale = 2.5f;
    public float maxMouseMagnitude = 5f;
    
    //Player Throw Vars
    [HideInInspector]
    public GameObject coinPrefab;
    [HideInInspector]
    public bool hasCoin = true;
    [HideInInspector]
    public float chargeScale = 1f;

    // Player Particles
    public ParticleSystem dustTrail;
    public void CreateDustTrail()
    {
        dustTrail.Play();
    }
    public void DestroyDustTrail()
    {
        dustTrail.Stop();
    }

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        drawTrajectory = GetComponent<DrawTrajectory>();
        coinPrefab = (GameObject) Resources.Load("Prefabs/Coin");
    }

    void Start()
    {
        currentState = MoveState;

        currentState.EnterState(this);
        drawTrajectory.HideLine();
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
        currentState.ExitState(this);
        currentState = _player;
        _player.EnterState(this);
    }

    private void OnTriggerEnter(Collider other) 
    {
        Debug.Log(score.GetPoints());
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

        if(horizontalInput == -1 && facingRight) {
            FlipPlayer();
        }
        if(horizontalInput == 1 && !facingRight) {
            FlipPlayer();
        }

        horizontalMovement = Vector3.Lerp(horizontalMovement, direction * maxSpeed, playerAcceleration * Time.deltaTime);
        verticalMovement = Mathf.Lerp(verticalMovement, -1 * terminalVelocity, gravity * Time.deltaTime);
        
        playerVelocity = new Vector3(0, verticalMovement, horizontalMovement.z);
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

    private void FlipPlayer()
    {
        Vector3 currScale = sprite.transform.localScale;
        currScale.x *= -1;
        sprite.transform.localScale = currScale;

        facingRight = !facingRight;
    }

    public void FireCoin()
    {
        if (coinPrefab != null)
        {
            Vector3 mouseToPlayer = (playerCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, playerCamera.transform.position.x))
                                    - transform.position);
            mouseToPlayer.y = Mathf.Clamp(mouseToPlayer.y, 0f, 5f);
            if (mouseToPlayer.magnitude >= maxMouseMagnitude)
            {
            mouseToPlayer *= maxMouseMagnitude / mouseToPlayer.magnitude;
            }

            Vector3 displacement = new Vector3(0, 1, Mathf.Sign(mouseToPlayer.z));
            GameObject coin = (GameObject) Instantiate(coinPrefab, this.transform.position + displacement, coinPrefab.transform.rotation);
            Vector3 shootDirection = new Vector3(0, mouseToPlayer.y, mouseToPlayer.z).normalized;
            coin.GetComponent<Rigidbody>().AddForce(new Vector3(0, (1/maxChargeScale) * chargeScale * mouseToPlayer.y, mouseToPlayer.z) * initialForce);
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
    public float GetOrientation() { return orientation; }
}
