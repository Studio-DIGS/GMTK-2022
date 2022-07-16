using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrowState : PlayerBaseState
{
    private float animationTimer = 1f;
    public override void EnterState(PlayerStateManager _player)
    {
        Debug.Log("Throw State Entered");

        return;
    }

    public override void UpdateState(PlayerStateManager _player)
    {
        return;
    }

    public override void LateUpdateState(PlayerStateManager _player)
    {
        if (animationTimer <= 0f) 
        {
            _player.SwitchState(_player.MoveState);
            animationTimer = 1f;
        }
        else
        {
            animationTimer -= Time.deltaTime;
        }
    }
}
