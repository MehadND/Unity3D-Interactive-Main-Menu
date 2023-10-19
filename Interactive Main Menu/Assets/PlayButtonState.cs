using UnityEngine;

public class PlayButtonState : State
{
    private GameObject playButton;

    public PlayButtonState(GameObject playButton)
    {
        this.playButton = playButton;
    }
    public override void Enter()
    {
        Debug.Log("<color=green>Entering PlayButtonState</color>");
    }

    public override void Execute()
    {
        Debug.Log("<color=green>Executing PlayButtonState</color>");

        playButton.transform.localScale = new Vector3(2.5f, 0.02f, 0.5f);

    }

    public override void Exit()
    {
        Debug.Log("<color=green>Exiting PlayButtonState</color>");

        playButton.transform.localScale = new Vector3(2.5f, 0.05f, 0.5f);
    }
}

