using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrowState : PlayerBaseState
{
    private float animationTimer = 0.2f;
    public override void EnterState(PlayerStateManager _player)
    {
        //Debug.Log("Throw State Entered");
        _player.animator.SetBool("isThrowing", true);
        _player.drawTrajectory.HideLine();
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

    public override void ExitState(PlayerStateManager _player)
    {
        _player.animator.SetBool("isThrowing", false);
    }
}
