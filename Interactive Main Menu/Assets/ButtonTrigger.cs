using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTrigger : MonoBehaviour
{
    private State currentState;

    public float timer = 0.0f;
    public float timerAmount = 0.5f;
    public bool buttonIsPressed = false;

    public Image playProgressBar;
    public Image settingsProgressBar;
    public Image quitProgressBar;

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
        if (other.gameObject.tag == "Player" && this.gameObject.name == "PlayButton")
        {
            ChangeState(new PlayButtonState(this.gameObject));
            buttonIsPressed = true;

            while (buttonIsPressed == true && timer <= 1.0f)
            {
                timer += timerAmount;
                playProgressBar.fillAmount += timerAmount;
                yield return new WaitForSeconds(0.2f);
            }
        }

        if (other.gameObject.tag == "Player" && this.gameObject.name == "SettingsButton")
        {
            ChangeState(new SettingsButtonState(this.gameObject));
            buttonIsPressed = true;

            while (buttonIsPressed == true && timer <= 1.0f)
            {
                timer += timerAmount;
                settingsProgressBar.fillAmount += timerAmount;
                yield return new WaitForSeconds(0.2f);
            }
        }

        if (other.gameObject.tag == "Player" && this.gameObject.name == "QuitButton")
        {
            ChangeState(new QuitButtonState(this.gameObject));
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
