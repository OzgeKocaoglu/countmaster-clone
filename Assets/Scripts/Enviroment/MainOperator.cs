using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainOperator : MonoBehaviour
{
    public delegate void MainOperatorHandler();
    public static MainOperatorHandler On_OperatorTriggered;
    public BoxCollider[] colliders;

    private void Awake()
    {
        On_OperatorTriggered += DestoryOperatorColliders;
        colliders = GetComponentsInChildren<BoxCollider>();
    }

    private void OnDestroy()
    {
        On_OperatorTriggered -= DestoryOperatorColliders;
    }

    private void DestoryOperatorColliders()
    {
        foreach(var collider in colliders)
        {
            collider.enabled = false;
        }
    }
}
