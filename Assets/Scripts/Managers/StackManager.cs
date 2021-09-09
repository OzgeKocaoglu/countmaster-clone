using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class StackManager : MonoBehaviour
{
    [SerializeField] private GameObject _stackPivot;
    private int _numberOfStackCount;
    private int numberOfObjects = 4;
    private List<GameObject> stackObjects;
    [SerializeField] private GameObject circle;

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
                
                if (_numberOfStackCount - value < 0)
                {
                    On_StackNumberChange?.Invoke(_numberOfStackCount, value);
                }
                _numberOfStackCount = value;
                Debug.Log(_numberOfStackCount);
                On_StackNumberChangeUI?.Invoke(_numberOfStackCount, value);

            }

        }
    }

    public delegate void StackHandler(int numOfCharacter, OperatorType operatorType);
    public static StackHandler On_AddingStack;
    public static event Action<int, int> On_StackNumberChange, On_StackNumberChangeUI;

    private void Awake()
    {
        NumberOfStackCount = 1;
        On_AddingStack += AddCharacterOnStack;
        On_StackNumberChange += CreateCharacter;

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
    public void RemoveCharacterOnStack()
    {
        NumberOfStackCount--;
        //circle.transform.DOScale(circle.transform.localScale - Vector3.one * 1.35f, 1);
    }
    private void CreateCharacter(int beforeNumberOfStack, int lastNumberOfStack)
    {
        int tempCount = beforeNumberOfStack;

        while(tempCount != lastNumberOfStack) { 
            var spawned = ObjectManager.Instance.SpawnFromPool(Constants.Character, _stackPivot.transform.position, Quaternion.identity);

            spawned.transform.parent = _stackPivot.transform;
            spawned.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * 3);
            spawned.transform.position = new Vector3(spawned.transform.position.x, 0.2f, spawned.transform.position.z);
            spawned.transform.DOScale(0.6f, 1);
            circle.transform.DOScale(circle.transform.localScale + Vector3.one * 1.35f, 1);
            tempCount++;
        }
    }
}
