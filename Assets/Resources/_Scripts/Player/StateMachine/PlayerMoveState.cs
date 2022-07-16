using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager _player)
    {
        //Debug.Log("Move State Entered");
        _player.animator.SetBool("isRunning", true);

        // creates dust trail upon entering state
        _player.CreateDustTrail();

        return;
    }

    public override void UpdateState(PlayerStateManager _player)
    {
        _player.UpdateMovement(true);
    }

    public override void LateUpdateState(PlayerStateManager _player) 
    {
        //Switching States Logic
        if (_player.controller.velocity == Vector3.zero && _player.controller.isGrounded)
        {
            _player.SwitchState(_player.IdleState);
        }
        if (Input.GetButton("Jump"))
        {
            _player.SwitchState(_player.JumpState);
        }
        if (Input.GetButtonDown("Fire1") &&
            _player.controller.isGrounded &&
            _player.hasCoin)
        {
            _player.SwitchState(_player.ChargeState);
        }
        if (_player.controller.velocity.y <= -1f)
        {
            _player.SwitchState(_player.FallState);
        }
        
        return;
    }

    public override void ExitState(PlayerStateManager _player)
    {
        _player.animator.SetBool("isRunning", false);
    }
}
