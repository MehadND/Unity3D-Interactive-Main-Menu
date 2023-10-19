/// <summary>
/// A Base class for a (button) state
/// </summary>
public abstract class State
{
    /// <summary>
    /// Method for handling when user enters this state
    /// </summary>
    public abstract void Enter();
    /// <summary>
    /// Method for handling when user is in this state
    /// </summary>
    public abstract void Execute();
    /// <summary>
    /// Method for handling when user exits this state
    /// </summary>
    public abstract void Exit();
}
