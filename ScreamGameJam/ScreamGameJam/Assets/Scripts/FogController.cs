using UnityEngine;


public class FogController : MonoBehaviour
{
    public void SetFog(float fogValue)
    {
        RenderSettings.fogEndDistance = fogValue;
    }
}  
