using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A class for handling states of buttons when user enters or exits a button's trigger box.
/// </summary>
/// <remarks>
/// Also includes functionality for modifying the timer + progress bars for each button
/// </remarks>
public class ButtonTrigger : MonoBehaviour
{
    private State currentState;

    [Header("Timer")]
    private float timer = 0.0f;
    [SerializeField, Range(0.0f, 1.0f), Tooltip("Varialbe for controlling the timer amount")] private float timerAmount = 0.1f;
    
    private bool buttonIsPressed = false;

    [Space(10)]

    [Header("Progress Bars")]
    [SerializeField, Tooltip("Select an image for play button progress bar")] private Image playProgressBar;
    [SerializeField, Tooltip("Select an image for settings button progress bar")] private Image settingsProgressBar;
    [SerializeField, Tooltip("Select an image for quit button progress bar")] private Image quitProgressBar;

    [Space(10)]

    [Header("Button Materials")]
    [SerializeField, Tooltip("Select a material for play button")] private Material playButtonMaterial;
    [SerializeField, Tooltip("Select a material for settings button")] private Material settingsButtonMaterial;
    [SerializeField, Tooltip("Select a material for quit button")] private Material quitButtonMaterial;

    /// <summary>
    /// Method that transitions from current state to a new state
    /// </summary>
    /// <param name="newState">New State</param>
    private void ChangeState(State newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }

    private void Start()
    {
        currentState = new IdleButtonState();
        currentState.Enter();
    }

    private void Update()
    {
        currentState.Execute();
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        // if player enters this button then change the state to PlayButtonState and modify the progress bar.
        if (other.gameObject.tag == "Player" && this.gameObject.name == "PlayButton")
        {
            ChangeState(new PlayButtonState(this.gameObject, playButtonMaterial));
            buttonIsPressed = true;

            while (buttonIsPressed == true && timer <= 1.0f)
            {
                timer += timerAmount;
                playProgressBar.fillAmount += timerAmount;
                yield return new WaitForSeconds(0.2f);
            }
        }

        // if player enters this button then change the state to SettingsButtonState and modify the progress bar.
        if (other.gameObject.tag == "Player" && this.gameObject.name == "SettingsButton")
        {
            ChangeState(new SettingsButtonState(this.gameObject, settingsButtonMaterial));
            buttonIsPressed = true;

            while (buttonIsPressed == true && timer <= 1.0f)
            {
                timer += timerAmount;
                settingsProgressBar.fillAmount += timerAmount;
                yield return new WaitForSeconds(0.2f);
            }
        }

        // if player enters this button then change the state to QuitButtonState and modify the progress bar.
        if (other.gameObject.tag == "Player" && this.gameObject.name == "QuitButton")
        {
            ChangeState(new QuitButtonState(this.gameObject, quitButtonMaterial));
            buttonIsPressed = true;

            while (buttonIsPressed == true && timer <= 1.0f)
            {
                timer += timerAmount;
                quitProgressBar.fillAmount += timerAmount;
                yield return new WaitForSeconds(0.2f);
            }
        }
    }

    private IEnumerator OnTriggerExit(Collider other)
    {
        // if player exits this button then change the state to IdleButtonState and modify the progress bar.
        if (other.gameObject.tag == "Player" && this.gameObject.name == "PlayButton")
        {
            ChangeState(new IdleButtonState());
            buttonIsPressed = false;

            while (buttonIsPressed == false && timer >= 0.0f)
            {
                timer -= timerAmount;
                playProgressBar.fillAmount -= timerAmount;
                yield return new WaitForSeconds(0.2f);
            }
        }

        // if player exits this button then change the state to IdleButtonState and modify the progress bar.
        if (other.gameObject.tag == "Player" && this.gameObject.name == "SettingsButton")
        {
            ChangeState(new IdleButtonState());
            buttonIsPressed = false;

            while (buttonIsPressed == false && timer >= 0.0f)
            {
                timer -= timerAmount;
                settingsProgressBar.fillAmount -= timerAmount;
                yield return new WaitForSeconds(0.2f);
            }
        }

        // if player exits this button then change the state to IdleButtonState and modify the progress bar.
        if (other.gameObject.tag == "Player" && this.gameObject.name == "QuitButton")
        {
            ChangeState(new IdleButtonState());
            buttonIsPressed = false;

            while (buttonIsPressed == false && timer >= 0.0f)
            {
                timer -= timerAmount;
                quitProgressBar.fillAmount -= timerAmount;
                yield return new WaitForSeconds(0.2f);
            }
        }
    }
}
