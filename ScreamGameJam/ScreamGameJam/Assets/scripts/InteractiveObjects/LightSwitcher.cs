using System.Collections.Generic;
using UnityEngine;


public sealed class LightSwitcher : Interactive
{
    [SerializeField] private List <Light> _lights;

    public override bool IsInteractiveByPlayer { get; set; }

    public override void Initialize()
    {
        IsInteractiveByPlayer = true;
    }

    public override void InteractLogic()
    {
        for (int i = 0; i < _lights.Count; i++)
        {
            _lights[i].enabled = !_lights[i].enabled;
        }
    }
}
