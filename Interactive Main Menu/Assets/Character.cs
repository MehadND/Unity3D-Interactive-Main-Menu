using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Character : MonoBehaviour
{
    [SerializeField, Range(1f, 10f), Tooltip("Variable for controlling the speed of the player")] private float speed = 5.0f;
    private float horizontalInput;
    private float verticalInput;
    private Vector3 movedirection;

    void Update()
    {
        MovePlayer();
    }

    /// <summary>
    /// Method for moving the player based on input
    /// </summary>
    private void MovePlayer()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        movedirection = new Vector3(horizontalInput, 0, verticalInput);
        transform.Translate(movedirection * speed * Time.deltaTime);
    }
}
