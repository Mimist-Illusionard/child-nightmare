using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderPaths : MonoBehaviour,IExecute
{
    public PathCreation.Examples.PathFollower MainFollower;
    [Space]
    public float firsPathDist;
    public PathCreation.PathCreator firsPath;
    [Space]
    public RuntimeAnimatorController animation;
    public float animationTime;

    public void Execute()
    {
        if(MainFollower.distanceTravelled >= firsPathDist && MainFollower.pathCreator == firsPath) { StartAnim(); }
    }
      
    private void Start()
    {
        GameManager.Singleton.AddExecuteObject(this);
    }


    private void StartAnim()
    {
        MainFollower.enabled = false;
        StartCoroutine(waitAnim());
    }

    private void StartSecondPath()
    {
        Destroy(gameObject);
    }

    IEnumerator waitAnim()
    {
        gameObject.GetComponent<Animator>().runtimeAnimatorController = animation;
        yield return new WaitForSeconds(animationTime);
        gameObject.GetComponent<Animator>().runtimeAnimatorController = null;
        StartSecondPath();
    }

    private void OnDestroy()
    {
        GameManager.Singleton.RemoveExecuteObject(this);
    }
}
