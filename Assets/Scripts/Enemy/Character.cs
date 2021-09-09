using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Character : MonoBehaviour
{
    public delegate void CharacterHandler(bool isAttack);
    public static CharacterHandler On_CharacterAttackToPlayer;
    GameObject closestCharacter;
    StackManager stackManager;
    private bool isAttacking;

    private void Awake()
    {
        On_CharacterAttackToPlayer += AttackSwitch;
        stackManager = FindObjectOfType<StackManager>();
    }

    private void OnDestroy()
    {
        On_CharacterAttackToPlayer -= AttackSwitch;
    }

    private void Update()
    {
        if (isAttacking)
        {
            Attack();
        }
    }
    private void AttackSwitch(bool isAttacking)
    {
        if(isAttacking != this.isAttacking)
        {
            this.isAttacking = isAttacking;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == Constants.Character)
        {
            EnemySpawner.On_EnemyDestoryChange?.Invoke(this.gameObject);
            ObjectManager.Instance.DestoryFromPool(Constants.Character, collision.gameObject);
        }
    }

    private void Attack()
    {
        PlayerCharacter[] obj = FindObjectsOfType<PlayerCharacter>();
        float minDistance = 100;

        foreach(var character in obj){
            float distance = Vector3.Distance(character.gameObject.transform.position, this.transform.position);
            if(distance < minDistance)
            {
                minDistance = distance;
                closestCharacter = character.gameObject;
            }
        }
        if(closestCharacter != null)
        {
            this.transform.DOMove(closestCharacter.transform.position, 2);
        }

    }
}
