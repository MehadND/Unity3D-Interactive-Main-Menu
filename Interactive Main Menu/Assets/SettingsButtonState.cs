using UnityEngine;

/// <summary>
/// A class for handling states for Settings Button
/// </summary>
public class SettingsButtonState : State
{
    private GameObject settingsButton;
    private Material material;
    public SettingsButtonState(GameObject settingsButton, Material material)
    {
        this.settingsButton = settingsButton;
        this.material = material;
    }
    public override void Enter()
    {
        Debug.Log("<color=cyan>Entering SettingsButtonState</color>");
        material.color = Color.magenta;
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
        material.color = Color.gray;
    }
}

