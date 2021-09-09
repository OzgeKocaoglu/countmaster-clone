using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _stackCountText;

    private void Awake()
    {
        StackManager.On_StackNumberChangeUI += ChangeStackText;
    }

    private void OnDestroy()
    {
        StackManager.On_StackNumberChangeUI -= ChangeStackText;
    }

    private void ChangeStackText(int before, int lastNumberStack)
    {
        _stackCountText.text = lastNumberStack.ToString();
    }
}
