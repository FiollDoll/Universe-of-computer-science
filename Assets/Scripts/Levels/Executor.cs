using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Executor : MonoBehaviour
{
    public float moveDistance = 1f;
    private Queue<Vector3> _actions = new Queue<Vector3>();
    private Queue<Vector3> _actionsRot = new Queue<Vector3>();

    public void AddAction(Vector3 direction) => _actions.Enqueue(direction);
    
    public void AddActionRot(Vector3 direction) => _actionsRot.Enqueue(direction);
    
    
    public void StartActions()
    {
        StartCoroutine(ExecuteActions());
    }
    
    private IEnumerator ExecuteActions()
    {
        while (_actions.Count > 0)
        {
            Vector3 direction = _actions.Dequeue();
            Vector3 rotation = _actionsRot.Dequeue();
            transform.position += direction * moveDistance;
            transform.Rotate(rotation);
            yield return new WaitForSeconds(1f); // Задержка между действиями
        }
    }
}