using System.Collections;

using UnityEngine;


public class CameraStates : Executable
{
    public BlackScreen BlackScreen;
    public CharacterController Player;
    public Transform BedState;
    public Transform UsualState;

    public bool isUsualState;

    private bool Block = false;
    public override void Start()
    {
        base.Start();
        LoadBed();
    }

    public override void Execute()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isUsualState && !Block) StartCoroutine(LoadUsualState());
    }

    public void LoadBed() => StartCoroutine(LoadBedState());
    public void LoadUsual() => StartCoroutine(LoadUsualState());

    private IEnumerator LoadBedState()
    {
        isUsualState = false;
        Player.enabled = false;
        BlackScreen.FadeIn();

        yield return new WaitForSeconds(1.5f);
        Player.gameObject.transform.position = BedState.position;

        BlackScreen.FadeOut();
    }

    private IEnumerator LoadUsualState()
    {
        BlackScreen.FadeIn();

        yield return new WaitForSeconds(1.5f);
        Player.gameObject.transform.position = UsualState.position;

        BlackScreen.FadeOut();
        Player.enabled = true;
        isUsualState = true;
    }

    public void BlockStates()
    {
        Block = true; 
    }
}
