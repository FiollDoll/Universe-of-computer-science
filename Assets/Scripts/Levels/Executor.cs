using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Executor : MonoBehaviour
{
    public float moveDistance = 1f;
    private Queue<Vector3> _actions = new Queue<Vector3>();
    private Queue<Vector3> _actionsRot = new Queue<Vector3>();
    [SerializeField] private Transform posWin;
    private bool onEnd = false;

    public void AddAction(Vector3 direction) => _actions.Enqueue(direction);
    
    public void AddActionRot(Vector3 direction) => _actionsRot.Enqueue(direction);
    
    public void DeleteLastAction()
    {
        if (_actions.Count == 0) return;
        
        // Просто action
        Queue<Vector3> tempQueue = new Queue<Vector3>();

        while (_actions.Count > 1)
            tempQueue.Enqueue(_actions.Dequeue());

        _actions.Dequeue();

        while (tempQueue.Count > 0)
            _actions.Enqueue(tempQueue.Dequeue());
        
        // actionRot
        Queue<Vector3> tempQueueRot = new Queue<Vector3>();

        while (_actionsRot.Count > 1)
            tempQueueRot.Enqueue(_actionsRot.Dequeue());

        _actionsRot.Dequeue();

        while (tempQueueRot.Count > 0)
            _actionsRot.Enqueue(tempQueueRot.Dequeue());
    }
    
    public void StartActions() => StartCoroutine(ExecuteActions());
    
    public void StopActions() => StopAllCoroutines();

    private IEnumerator ExecuteActions()
    {
        // Создаем новые очереди и копируем значения из оригинальных
        Queue<Vector3> newActions = new Queue<Vector3>(_actions);
        Queue<Vector3> newActionsRot = new Queue<Vector3>(_actionsRot);
    
        while (newActions.Count > 0)
        {
            Vector3 direction = newActions.Dequeue();
            Vector3 rotation = newActionsRot.Dequeue();
        
            transform.position += direction * moveDistance;
            transform.Rotate(rotation);
        
            yield return new WaitForSeconds(0.5f); // Задержка между действиями
        }

        Vector3 roundWinPos = new Vector3(Mathf.Round(posWin.transform.position.x),
            Mathf.Round(posWin.transform.position.y), 0);
        Vector3 roundExecutor = new Vector3(Mathf.Round(transform.position.x),
            Mathf.Round(transform.position.y), 0);
        
        if (roundExecutor == roundWinPos)
            onEnd = true;
        GamesManager.Instance.EndExecutor(onEnd);
    }
}