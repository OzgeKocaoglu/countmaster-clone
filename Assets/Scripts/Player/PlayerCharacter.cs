using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private void Update()
    {
        if (transform.position.y < 0)
        {
            FindObjectOfType<StackManager>().NumberOfStackCount--;
            ObjectManager.Instance.DestoryFromPool(Constants.Character, this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == Constants.Enemy)
        {
            Debug.Log("Here");
            
        }
    }
}
