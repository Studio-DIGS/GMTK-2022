using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrowState : PlayerBaseState
{
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
        return;
    }
}
