using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChargeState : PlayerBaseState
{
    private  float currentChargeTime = 0.0f;

    public override void EnterState(PlayerStateManager _player)
    {
        //Debug.Log("Charge State Entered");
        _player.chargeScale = _player.initialChargeScale;
        currentChargeTime = 0.0f;
        _player.drawTrajectory.ShowLine();

        return;
    }

    public override void UpdateState(PlayerStateManager _player)
    {
        if (_player.controller.velocity != Vector3.zero)
        {
            _player.UpdateMovement(false);
        }
        currentChargeTime += Time.deltaTime;
        _player.chargeScale = Mathf.Lerp(_player.initialChargeScale, _player.maxChargeScale, Mathf.Clamp(currentChargeTime, 0.0f, _player.maxChargeTime));

        // Vector3 expectedForce = new Vector3(0, (1/_player.maxChargeScale) * _player.chargeScale, _player.GetOrientation()) * _player.initialForce;
        // Vector3 expectedDisplacement = new Vector3(0, 1, _player.GetOrientation());

        // _player.drawTrajectory.UpdateTrajectory(expectedForce, _player.coinPrefab.GetComponent<Rigidbody>(), _player.transform.position + expectedDisplacement);

    }

    public override void LateUpdateState(PlayerStateManager _player)
    {
        if (!Input.GetButton("Fire1"))
        {
            _player.SwitchState(_player.ThrowState);
        }
    }

}
