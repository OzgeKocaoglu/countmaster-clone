using UnityEngine;
using TMPro;

public class EnemyUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _stackCountText;
    public delegate void EnemyUIHandler();
    public static EnemyUIHandler On_Closed;

    private void Awake()
    {
        EnemySpawner.On_EnemySpawnerCountChange += StackCountChange;
        On_Closed += CloseText;
    }

    private void OnDestroy()
    {
        EnemySpawner.On_EnemySpawnerCountChange -= StackCountChange;
        On_Closed -= CloseText;
    }

    private void StackCountChange(int stackCount)
    {
        _stackCountText.text = stackCount.ToString();
    }
    private void CloseText()
    {
        this.gameObject.SetActive(false);
    }
}
