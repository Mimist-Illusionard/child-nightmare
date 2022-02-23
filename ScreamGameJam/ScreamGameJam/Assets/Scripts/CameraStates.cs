using System.Collections;

using UnityEngine;


public class CameraStates : Executable
{
    public CharacterController Player;
    public Transform BedState;
    public Transform UsualState;

    public bool isUsualState;

    public override void Start()
    {
        base.Start();
        LoadBed();
    }

    public override void Execute()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !isUsualState) StartCoroutine(LoadUsualState());
    }

    public void LoadBed() => StartCoroutine(LoadBedState());
    public void LoadUsual() => StartCoroutine(LoadUsualState());

    private IEnumerator LoadBedState()
    {
        isUsualState = false;
        Player.enabled = false;
        BlackScreen.Singleton.FadeIn();

        yield return new WaitForSeconds(1.5f);
        Player.gameObject.transform.position = BedState.position;

        BlackScreen.Singleton.FadeOut();
    }

    private IEnumerator LoadUsualState()
    {
        BlackScreen.Singleton.FadeIn();

        yield return new WaitForSeconds(1.5f);
        Player.gameObject.transform.position = UsualState.position;

        BlackScreen.Singleton.FadeOut();
        Player.enabled = true;
        isUsualState = true;
    }
}
