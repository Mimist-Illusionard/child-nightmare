using UnityEngine;


public class InteractiveRaycast : Executable
{
    public LayerMask Layer;
    public override void Execute()
    {
        RaycastHit hit;
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 30f);
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward * 30f, out hit, 30f, Layer))
        {
            if (!hit.collider.TryGetComponent<Interactive>(out var interactive)) return;

            interactive.Logic();
        }
    }   
}