using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _forwardSpeed;
    [SerializeField] private float _swerveSpeed;
    [SerializeField] private float _minHorizontalMovementBorder;
    [SerializeField] private float _maxHorizontalMovementBorder;
    [SerializeField] private DynamicJoystick joystick;

    private void Update()
    {
        ForwardMove();
        SwerveMove();
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
}
