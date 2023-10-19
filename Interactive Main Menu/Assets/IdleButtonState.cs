using UnityEngine;

/// <summary>
/// A class for handling states for Idle Button
/// /// </summary>
public class IdleButtonState : State
{
    public override void Enter()
    {
        Debug.Log("Entering IdleButtonState");
    }

    public override void Execute()
    {
        Debug.Log("Executing IdleButtonState");
    }

    public override void Exit()
    {
        Debug.Log("Exiting IdleButtonState");
    }
}

