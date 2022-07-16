using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager _player)
    {
        //Debug.Log("Idle State Entered");
        _player.animator.SetBool("isIdle", true);

        // destroys any dust trail from previous states
        _player.DestroyDustTrail();

        return;
    }

    public override void UpdateState(PlayerStateManager _player)
    {
        _player.UpdateMovement(false);
    }
    
    public override void LateUpdateState(PlayerStateManager _player) 
    {
        if (Input.GetButtonDown("Fire1") && _player.hasCoin)
        {
            _player.SwitchState(_player.ChargeState);
        }
        
        if (Input.GetAxisRaw("Horizontal") != 0f || Input.GetButton("Jump"))
        {
            _player.SwitchState(_player.MoveState);
        }
    }

    public override void ExitState(PlayerStateManager _player)
    {
        _player.animator.SetBool("isIdle", false);
    }
}
