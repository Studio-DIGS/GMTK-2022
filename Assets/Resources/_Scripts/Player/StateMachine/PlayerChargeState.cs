using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChargeState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager _player)
    {
        Debug.Log("Charge State Entered");

        return;
    }

    public override void UpdateState(PlayerStateManager _player)
    {
        _player.UpdateMovement(false);
    }

    public override void LateUpdateState(PlayerStateManager _player)
    {
        if (!Input.GetButton("Fire1"))
        {
            _player.SwitchState(_player.ThrowState);
        }
    }
}
