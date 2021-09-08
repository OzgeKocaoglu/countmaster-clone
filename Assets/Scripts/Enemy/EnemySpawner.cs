using UnityEngine;
using DG.Tweening;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int enemyNumber;
    [SerializeField] private GameObject circle;
    [SerializeField] private Transform _stackPivot;
    private int currentEnemyNumber;

    public delegate void EnemySpawnerHandler(int value);
    public delegate void EnemyDestoryHandler(GameObject obj);
    public static EnemySpawnerHandler On_EnemySpawnerCountChange;
    public static EnemyDestoryHandler On_EnemyDestoryChange;

    public int CurrentEnemyNumber
    {
        get
        {
            return currentEnemyNumber;
        }
        set
        {
            if (value > 0)
            {
                currentEnemyNumber = value;
                On_EnemySpawnerCountChange?.Invoke(value);
                Debug.Log("ENEMY SPAWNER COUNT:: " + currentEnemyNumber);
            }
            else
            {
                EnemyTriggerZone.On_EnemyFinish?.Invoke();
                PlayerMovement.On_PlayerMovementFreezed?.Invoke(false);
                EnemyUI.On_Closed?.Invoke();
            }
        }
    }
    private void Awake()
    {
        On_EnemyDestoryChange += DestoryEnemy;
    }

    private void OnDestroy()
    {
        On_EnemyDestoryChange += DestoryEnemy;
    }
    private void Start()
    {
        if (enemyNumber != 0)
        {
            CreateEnemies();
        }
        //circle.SetActive(false);
    }
    private void CreateEnemies()
    {
        while(currentEnemyNumber != enemyNumber)
        {
            var spawned = ObjectManager.Instance.SpawnFromPool(Constants.Enemy, _stackPivot.transform.position, Quaternion.identity);
            spawned.transform.parent = _stackPivot;
            spawned.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * 3);
            circle.transform.DOScale(circle.transform.localScale + Vector3.one * 1.35f, 1);
            CurrentEnemyNumber++;
        }
    }
    private void DestoryEnemy(GameObject obj)
    {
        ObjectManager.Instance.DestoryFromPool(Constants.Enemy, obj);
        CurrentEnemyNumber--;
    }

}
