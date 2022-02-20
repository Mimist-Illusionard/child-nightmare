using UnityEngine;


public class Log : MonoBehaviour
{
    [SerializeField] private string _logMessage;
    public void LogMessage()
    {
        Debug.Log(_logMessage);
    }
}
