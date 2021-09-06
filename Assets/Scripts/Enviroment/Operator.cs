using UnityEngine;
using TMPro;

public enum OperatorType
{
    Add,
    Mul
}

public class Operator : MonoBehaviour
{
    [SerializeField] private int _operatorValue;
    [SerializeField] private OperatorType type;
    private TMP_Text _operatorText;

    private void Awake()
    {
        _operatorText = gameObject.GetComponentInChildren<TMP_Text>();
        OperatorUISwitch();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == Constants.Player)
        {
            MainOperator.On_OperatorTriggered?.Invoke(this.transform.parent.GetComponent<MainOperator>().id);
            StackManager.On_AddingStack?.Invoke(_operatorValue, type);
        }
    }
    private void OperatorUISwitch()
    {
        switch (type)
        {
            case OperatorType.Add:
                _operatorText.text = Constants.AddOperator  + _operatorValue.ToString();
                break;
            case OperatorType.Mul:
                _operatorText.text = Constants.MulOperator + _operatorValue.ToString();
                break;
        }
    }
}
