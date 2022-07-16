using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager _player)
    {
        Debug.Log("Fall State Entered");

        return;
    }
    public override void UpdateState(PlayerStateManager _player)
    {
        _player.UpdateMovement(1);
    }
    
    public override void LateUpdateState(PlayerStateManager _player)
    {
        //Switching State Logic
        if (_player.controller.isGrounded)
        {
            _player.SwitchState(_player.MoveState);
        }
    }
}
