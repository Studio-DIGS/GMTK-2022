using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChargeState : PlayerBaseState
{
    private  float currentChargeTime = 0.0f;

    public override void EnterState(PlayerStateManager _player)
    {
        //Debug.Log("Charge State Entered");
        _player.animator.SetBool("isCharging", true);
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
        
        Vector3 mouseToPlayer = (_player.playerCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _player.playerCamera.transform.position.x))
                                 - _player.transform.position);
        mouseToPlayer.y = Mathf.Clamp(mouseToPlayer.y, 0f, _player.maxMouseMagnitude);
        mouseToPlayer.x = 0f;
        if (mouseToPlayer.magnitude >= _player.maxMouseMagnitude)
        {
            mouseToPlayer *= _player.maxMouseMagnitude / mouseToPlayer.magnitude;
        }

        currentChargeTime += Time.deltaTime;
        _player.chargeScale = Mathf.Lerp(_player.initialChargeScale, _player.maxChargeScale, Mathf.Clamp(currentChargeTime, 0.0f, _player.maxChargeTime));

        Vector3 expectedForce = new Vector3(0, (1/_player.maxChargeScale) * _player.chargeScale * mouseToPlayer.y, mouseToPlayer.z) * _player.initialForce;
        Vector3 expectedDisplacement = new Vector3(0, 0.5f, Mathf.Sign(mouseToPlayer.z) * 0.5f);

        _player.drawTrajectory.UpdateTrajectory(expectedForce, _player.coinPrefab.GetComponent<Rigidbody>(), expectedDisplacement);

    }

    public override void LateUpdateState(PlayerStateManager _player)
    {
        if (!Input.GetButton("Fire1"))
        {
            _player.SwitchState(_player.ThrowState);
        }
    }

    public override void ExitState(PlayerStateManager _player)
    {
        _player.animator.SetBool("isCharging", false);
    }
}
