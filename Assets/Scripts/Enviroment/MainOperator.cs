using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainOperator : MonoBehaviour
{
    public delegate void MainOperatorHandler(int id);
    public static MainOperatorHandler On_OperatorTriggered;
    public BoxCollider[] colliders;
    public int id;

    private void Awake()
    {
        On_OperatorTriggered += DestoryOperatorColliders;
        colliders = GetComponentsInChildren<BoxCollider>();
    }

    private void OnDestroy()
    {
        On_OperatorTriggered -= DestoryOperatorColliders;
    }

    private void DestoryOperatorColliders(int id)
    {
        if(id == this.id)
        {
            foreach (var collider in colliders)
            {
                collider.enabled = false;
            }
        }
    }
}
