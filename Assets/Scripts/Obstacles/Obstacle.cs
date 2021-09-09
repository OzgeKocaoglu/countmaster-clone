using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    public abstract void ExecuteTriggerObstacle(GameObject obj);
    public abstract void ExitedTriggerObstacle(GameObject obj);
    public abstract void ExecuteObstacle();
}
