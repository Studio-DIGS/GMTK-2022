using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager _player)
    {
        Debug.Log("Move State Entered");

        return;
    }

    public override void UpdateState(PlayerStateManager _player)
    {
        _player.horizontalInput = Input.GetAxisRaw("Horizontal");
        _player.orientation = Mathf.Clamp(_player.orientation + (_player.horizontalInput * 2), -1, 1);

        _player.direction = (_player.transform.forward * _player.horizontalInput);
        if (_player.controller.isGrounded)
        {
            _player.verticalMovement = -0.5f;
            _player.playerAcceleration = _player.groundAcceleration;

            if (Input.GetButton("Jump"))
            {
                _player.verticalMovement = _player.jumpHeight;
                _player.playerAcceleration = _player.airAcceleration;
            }
        }

        _player.horizontalMovement = Vector3.Lerp(_player.horizontalMovement, _player.direction * _player.maxSpeed, _player.playerAcceleration * Time.deltaTime);
        _player.verticalMovement = Mathf.Lerp(_player.verticalMovement, -1 * _player.terminalVelocity, _player.gravity * Time.deltaTime);

        _player.playerVelocity = new Vector3(_player.horizontalMovement.x, _player.verticalMovement, _player.horizontalMovement.z);

        _player.controller.Move(_player.playerVelocity * Time.deltaTime);

        //Switching States Logic
        if (_player.controller.velocity == Vector3.zero &&
            _player.controller.isGrounded)
        {
            _player.SwitchState(_player.IdleState);
        }

    }
}
