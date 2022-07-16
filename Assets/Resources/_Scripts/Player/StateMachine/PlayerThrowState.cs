using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrowState : PlayerBaseState
{
    private float animationTimer = 0.5f;
    public override void EnterState(PlayerStateManager _player)
    {
        //Debug.Log("Throw State Entered");

        return;
    }

    public override void UpdateState(PlayerStateManager _player)
    {
        if(_player.hasCoin)
        {
            _player.FireCoin();
        }
        _player.hasCoin = false;
    }

    public override void LateUpdateState(PlayerStateManager _player)
    {
        if (animationTimer <= 0f) 
        {
            _player.SwitchState(_player.MoveState);
            animationTimer = 0.5f;
        }
        else
        {
            animationTimer -= Time.deltaTime;
        }
    }
}
