using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StackManager : MonoBehaviour
{
    [SerializeField] private GameObject _stackPivot;
    private int _numberOfStackCount;

    public int NumberOfStackCount
    {
        get
        {
            return _numberOfStackCount;
        }
        set
        {
            if(_numberOfStackCount != value)
            {
                On_StackNumberChange?.Invoke(_numberOfStackCount, value);
                _numberOfStackCount = value;
            }

        }
    }

    public delegate void StackHandler(int numOfCharacter, OperatorType operatorType);
    public static StackHandler On_AddingStack;
    public event Action<int, int> On_StackNumberChange;

    private void Awake()
    {
        On_AddingStack += AddCharacterOnStack;
        On_StackNumberChange += CreateCharacter;
        _numberOfStackCount = 1;
    }

    private void OnDestroy()
    {
        On_AddingStack -= AddCharacterOnStack;
        On_StackNumberChange -= CreateCharacter;
    }

    private void AddCharacterOnStack(int numOfCharacter, OperatorType operatorType)
    {
        switch (operatorType)
        {
            case OperatorType.Add:
                Debug.Log($"Adding Character on stack: {numOfCharacter}");
                NumberOfStackCount += numOfCharacter;
                Debug.Log($"Current stack number is {NumberOfStackCount}");
                break;
            case OperatorType.Mul:
                Debug.Log($"Mul Character on stack: {numOfCharacter}");
                int sum = NumberOfStackCount * numOfCharacter;
                NumberOfStackCount = sum;
                Debug.Log($"Current stack number is {NumberOfStackCount}");
                break;
            default:
                Debug.Log("Invalid operator.");
                break;
        }
    }
    private void CreateCharacter(int beforeNumberOfStack, int lastNumberOfStack)
    {
        int tempCount = beforeNumberOfStack;
        while(tempCount != lastNumberOfStack)
        {
            GameObject temp = ObjectManager.Instance.SpawnFromPool("Character", _stackPivot.transform.position, Quaternion.identity);
            temp.transform.parent = _stackPivot.transform;
            tempCount++;
        }
    }
}
