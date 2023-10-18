using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Character : MonoBehaviour
{
    [SerializeField, Range(1f, 10f)] private float speed = 5.0f;
    private float horizontalInput;
    private float verticalInput;
    private Vector3 movedirection;
    public GameObject playButtonGameObject;
    public GameObject settingsButtonGameObject;
    public GameObject quitButtonGameObject;

    public float timer = 0.0f;
    public float timerAmount = 0.5f;
    public bool buttonIsPressed = false;

    public UnityEngine.UI.Image progressBarImage;

    private void Start()
    {
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        movedirection = new Vector3(horizontalInput, 0, verticalInput);
        transform.Translate(movedirection * speed * Time.deltaTime);

        if (buttonIsPressed == true && timer <= 1.0f)
        {
            timer += timerAmount * Time.deltaTime;
            progressBarImage.fillAmount += timerAmount * Time.deltaTime;
        }
        else if (buttonIsPressed == false)
        {
            timer = 0.0f;
            progressBarImage.fillAmount = 0.0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == playButtonGameObject.name)
        {
            Debug.Log("Entered Play Button");
            playButtonGameObject.transform.localScale = new Vector3(2.5f, 0.02f, 0.5f);
            buttonIsPressed = true;
        }
        if (other.gameObject.name == settingsButtonGameObject.name)
        {
            Debug.Log("Entered Settings Button");
            settingsButtonGameObject.transform.localScale = new Vector3(2.5f, 0.02f, 0.5f);
            buttonIsPressed = true;
        }
        if (other.gameObject.name == quitButtonGameObject.name)
        {
            Debug.Log("Entered Quit Button");
            quitButtonGameObject.transform.localScale = new Vector3(2.5f, 0.02f, 0.5f);
            buttonIsPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == playButtonGameObject.name)
        {
            Debug.Log("Exited Play Button");
            playButtonGameObject.transform.localScale = new Vector3(2.5f, 0.05f, 0.5f);
            buttonIsPressed = false;
            timer = 0.0f;
        }
        if (other.gameObject.name == settingsButtonGameObject.name)
        {
            Debug.Log("Exited Settings Button");
            settingsButtonGameObject.transform.localScale = new Vector3(2.5f, 0.05f, 0.5f);
            buttonIsPressed = false;
            timer = 0.0f;
        }
        if (other.gameObject.name == quitButtonGameObject.name)
        {
            Debug.Log("Exited Quit Button");
            quitButtonGameObject.transform.localScale = new Vector3(2.5f, 0.05f, 0.5f);
            buttonIsPressed = false;
            timer = 0.0f;
        }
    }
}
