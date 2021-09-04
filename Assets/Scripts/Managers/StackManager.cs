using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManager : MonoBehaviour
{
    public delegate void StackHandler(int numOfCharacter, OperatorType operatorType);
    public static StackHandler On_AddingStack;

    [SerializeField] private GameObject _stackPivot;
    private int _numberOfStackCount;

    private void Awake()
    {
        On_AddingStack += AddCharacterOnStack;
        _numberOfStackCount = 1;
    }

    private void OnDestroy()
    {
        On_AddingStack -= AddCharacterOnStack;
    }

    private void AddCharacterOnStack(int numOfCharacter, OperatorType operatorType)
    {
        switch (operatorType)
        {
            case OperatorType.Add:
                Debug.Log($"Adding Character on stack: {numOfCharacter}");
                _numberOfStackCount += numOfCharacter;
                Debug.Log($"Current stack number is {_numberOfStackCount}");
                break;
            case OperatorType.Mul:
                Debug.Log($"Mul Character on stack: {numOfCharacter}");
                int sum = _numberOfStackCount * numOfCharacter;
                _numberOfStackCount = sum;
                Debug.Log($"Current stack number is {_numberOfStackCount}");
                break;
            default:
                Debug.Log("Invalid operator.");
                break;
        }
    }


}
