using System;
using UnityEngine;


public class InputManager : BaseSingleton<InputManager>, IExecute
{
    [SerializeField] private KeyCode FlyButton;
    [SerializeField] private KeyCode SelectButton;

    public Action<float, float> OnInput;
    public Action OnFlyButton;
    public Action OnSelectButton;

    private void Start()
    {
        GameManager.Singleton.AddExecuteObject(this);
    }

    public void Execute()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        OnInput?.Invoke(x, z);

        if (Input.GetKey(FlyButton)) OnFlyButton?.Invoke();
        if (Input.GetKey(SelectButton)) OnSelectButton?.Invoke();
    }

}
