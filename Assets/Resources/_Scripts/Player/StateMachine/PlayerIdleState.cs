using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager _player)
    {
        Debug.Log("Idle State Entered");

        return;
    }

    public override void UpdateState(PlayerStateManager _player)
    {
        if (Input.GetAxisRaw("Horizontal") != 0f || Input.GetButton("Jump"))
        {
            _player.UpdateMovement();
        }
    }
    
    public override void LateUpdateState(PlayerStateManager _player) 
    {
        if (Input.GetAxisRaw("Horizontal") != 0f || Input.GetButton("Jump"))
        {
            _player.SwitchState(_player.MoveState);
        }
    }
}
