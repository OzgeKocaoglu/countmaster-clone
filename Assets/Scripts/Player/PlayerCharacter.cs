using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{

    private void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == Constants.Enemy)
        {
            StackManager.On_RemovingStack?.Invoke();
            Debug.Log("Here");
        }
    }
}
