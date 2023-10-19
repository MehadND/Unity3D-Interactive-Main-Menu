using UnityEngine;

/// <summary>
/// A class for handling states for Quit Button
/// </summary>
public class QuitButtonState : State
{
    private GameObject quitButton;

    public QuitButtonState(GameObject quitButton)
    {
        this.quitButton = quitButton;
    }

    public override void Enter()
    {
        Debug.Log("<color=red>Entering QuitButtonState</color>");

    }

    public override void Execute()
    {
        Debug.Log("<color=red>Entering QuitButtonState</color>");

        // scale the button down for a 'click button' effect
        quitButton.transform.localScale = new Vector3(2.5f, 0.02f, 0.5f);
    }

    public override void Exit()
    {
        Debug.Log("<color=red>Entering QuitButtonState</color>");

        // scale the button up to normal size
        quitButton.transform.localScale = new Vector3(2.5f, 0.05f, 0.5f);
    }
}

