using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager _player)
    {
        return;
    }
    public override void UpdateState(PlayerStateManager _player)
    {
        //Switching State Logic
        if (_player.controller.isGrounded)
        {
            _player.SwitchState(_player.MoveState);
        }
    }
}
