using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    private List<IExecute> _executableObjects;

    private void Start()
    {
        _executableObjects = new List<IExecute>();
    }

    private void Update()
    {
        if (_executableObjects.Count > 0)
        {
            for (int i = 0; i < _executableObjects.Count; i++)
            {
                _executableObjects[i].Execute();
            }
        }
    }
}