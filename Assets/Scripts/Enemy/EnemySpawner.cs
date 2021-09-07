using UnityEngine;
using DG.Tweening;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int enemyNumber;
    [SerializeField] private GameObject circle;
    [SerializeField] private Transform _stackPivot;
    private int currentEnemyNumber;



    private void Start()
    {
        currentEnemyNumber = 0;
        if (enemyNumber != 0)
        {
            CreateEnemies();
        }
    }


    private void CreateEnemies()
    {
        while(currentEnemyNumber != enemyNumber)
        {
            var spawned = ObjectManager.Instance.SpawnFromPool("Enemy", _stackPivot.transform.position, Quaternion.identity);
            spawned.transform.parent = _stackPivot;
            spawned.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * 3);
            circle.transform.DOScale(circle.transform.localScale + Vector3.one * 1.35f, 1);
            currentEnemyNumber++;
        }

    }
}
