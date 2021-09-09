using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovingPlatform : Obstacle
{

    public override void ExecuteObstacle()
    {
        
    }

    public override void ExecuteTriggerObstacle(GameObject obj)
    {
        Rigidbody characterRigidbody = obj.GetComponent<Rigidbody>();
        characterRigidbody.constraints = RigidbodyConstraints.None;
        characterRigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        characterRigidbody.angularDrag = 0;
        characterRigidbody.drag = 0;
        if(obj.transform.position.y < -2)
        {
            obj.SetActive(false);
        }
    }

    public override void ExitedTriggerObstacle(GameObject obj)
    {
        Rigidbody characterRigidbody = obj.GetComponent<Rigidbody>();
        characterRigidbody.constraints = RigidbodyConstraints.FreezePositionY;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == Constants.Character)
        {
            ExecuteTriggerObstacle(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == Constants.Character)
        {
            ExecuteTriggerObstacle(other.gameObject);
        }
    }
}
