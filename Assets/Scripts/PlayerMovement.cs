using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float swerveSpeed;
    [SerializeField] private DynamicJoystick joystick;

    private void Update()
    {
        ForwardMove();
        SwerveMove();
    }

    private void ForwardMove()
    {
        transform.Translate(transform.forward * Time.deltaTime * forwardSpeed);
    }

    private void SwerveMove()
    {
        float clampedHorizontal = Mathf.Clamp(transform.position.x + joystick.Horizontal * swerveSpeed * Time.deltaTime, -3.45F, 3.45F);
        Vector3 direction = new Vector3(clampedHorizontal, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, direction, 1);
    }
}
