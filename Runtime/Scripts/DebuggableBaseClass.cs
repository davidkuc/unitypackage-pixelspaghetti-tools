using UnityEngine;

public abstract class Debuggable : MonoBehaviour
{
    [SerializeField] protected bool showDebugLogs;

    protected virtual void PrintDebugLog(string message)
    {
#if UNITY_EDITOR
        if (showDebugLogs)
            Debug.Log($"GameObject: {gameObject.name} - Class: {GetType().Name} \r\n Message --> {message}");
#endif
    }
}
