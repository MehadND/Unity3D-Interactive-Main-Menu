using UnityEngine;

/// <summary>
/// A class for handling states for Play Button
/// </summary>
public class PlayButtonState : State
{
    private GameObject playButton;
    private Material material;

    public PlayButtonState(GameObject playButton, Material material)
    {
        this.playButton = playButton;
        this.material = material;
    }
    public override void Enter()
    {
        Debug.Log("<color=green>Entering PlayButtonState</color>");
        material.color = Color.green;
    }

    public override void Execute()
    {
        Debug.Log("<color=green>Executing PlayButtonState</color>");

        // scale the button down for a 'click button' effect
        playButton.transform.localScale = new Vector3(2.5f, 0.02f, 0.5f);
    }

    public override void Exit()
    {
        Debug.Log("<color=green>Exiting PlayButtonState</color>");

        // scale the button up to normal size
        playButton.transform.localScale = new Vector3(2.5f, 0.05f, 0.5f);
        material.color = Color.gray;
    }
}

