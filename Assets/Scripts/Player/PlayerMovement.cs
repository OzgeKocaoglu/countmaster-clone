using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _forwardSpeed;
    [SerializeField] private float _swerveSpeed;
    [SerializeField] private DynamicJoystick joystick;
    private bool isPlayerMovementFreeze;
    private float _minHorizontalMovementBorder = -3.45f;
    private float _maxHorizontalMovementBorder = 3.45f;

    public delegate void PlayerMovementHandler(bool isPlayerMovementFreezed);
    public static PlayerMovementHandler On_PlayerMovementFreezed;

    private void Awake()
    {
        On_PlayerMovementFreezed += FreezeMovementSwicth;
    }

    private void OnDestroy()
    {
        On_PlayerMovementFreezed -= FreezeMovementSwicth;
    }


    private void Update()
    {
        if (!isPlayerMovementFreeze)
        {
            ForwardMove();
            SwerveMove();
        }
        else
        {
            FreezedMovement();
        }
    }

    private void ForwardMove()
    {
        transform.Translate(transform.forward * Time.deltaTime * _forwardSpeed);
    }
    private void SwerveMove()
    {
        float clampedHorizontal = Mathf.Clamp(transform.position.x + joystick.Horizontal * _swerveSpeed * Time.deltaTime, _minHorizontalMovementBorder, _maxHorizontalMovementBorder);
        Vector3 direction = new Vector3(clampedHorizontal, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, direction, 1);
    }
    private void FreezedMovement()
    {
        transform.Translate(transform.forward * Time.deltaTime * _forwardSpeed * 0.1f);
    }
    private void FreezeMovementSwicth(bool val)
    {
        if(val != isPlayerMovementFreeze)
        {
            isPlayerMovementFreeze = val;
        }
    }

}
