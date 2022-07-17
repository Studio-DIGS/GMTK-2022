using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager _player)
    {
        //Debug.Log("Jump State Entered");
        _player.animator.SetBool("isJumping", true);

        return;
    }
    public override void UpdateState(PlayerStateManager _player)
    {
        _player.UpdateMovement(true);

    }

    public override void LateUpdateState(PlayerStateManager _player) 
    {
        //Switching State Logic
        if (_player.controller.isGrounded)
        {
            _player.SwitchState(_player.MoveState);
        }
        if (_player.controller.velocity.y <= 0f)
        {
            _player.SwitchState(_player.FallState);
        }
        if (Input.GetButtonDown("Fire1")  &&
            _player.hasCoin)
        {
            _player.SwitchState(_player.ChargeState);
        }
    }

    public override void ExitState(PlayerStateManager _player)
    {
        _player.animator.SetBool("isJumping", false);
    }
}
