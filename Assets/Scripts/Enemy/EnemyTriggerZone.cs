using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTriggerZone : MonoBehaviour
{
    public delegate void EnemyTriggerHandler();
    public static EnemyTriggerHandler On_EnemyFinish;

    private void Awake()
    {
        On_EnemyFinish += EnemyFinish;
    }

    private void OnDestroy()
    {
        On_EnemyFinish -= EnemyFinish;
    }

    private void EnemyFinish()
    {
        this.gameObject.transform.parent.gameObject.SetActive(false);
        //gameObject.transform.parent.parent.GetChild(2).gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == Constants.Character)
        {
            Debug.Log("Player here");
            PlayerMovement.On_PlayerMovementFreezed?.Invoke(true);
            Character.On_CharacterAttackToPlayer?.Invoke(true);
        }
    }
}
