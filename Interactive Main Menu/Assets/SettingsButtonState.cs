using UnityEngine;

/// <summary>
/// A class for handling states for Settings Button
/// </summary>
public class SettingsButtonState : State
{
    private GameObject settingsButton;

    public SettingsButtonState(GameObject settingsButton)
    {
        this.settingsButton = settingsButton;
    }
    public override void Enter()
    {
        Debug.Log("<color=cyan>Entering SettingsButtonState</color>");
    }

    public override void Execute()
    {
        Debug.Log("<color=cyan>Entering SettingsButtonState</color>");

        // scale the button down for a 'click button' effect
        settingsButton.transform.localScale = new Vector3(2.5f, 0.02f, 0.5f);
    }

    public override void Exit()
    {
        Debug.Log("<color=green>Entering SettingsButtonState</color>");
        
        // scale the button up to normal size
        settingsButton.transform.localScale = new Vector3(2.5f, 0.05f, 0.5f);
    }
}

