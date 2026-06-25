using UnityEngine;

public class PlayerInput : MonoBehaviour, IPlayerInput
{
    public Vector2 moveInput => InputManager.Instance.Actions.Player.Move.ReadValue<Vector2>();
    public Vector2 altMoveInput => InputManager.Instance.Actions.Player.AltMove.ReadValue<Vector2>();
    public float bracketsInput => InputManager.Instance.Actions.Player.Brackets.ReadValue<float>();
    public Vector2 lookInput => InputManager.Instance.Actions.Player.Look.ReadValue<Vector2>();
    public bool jump => InputManager.Instance.Actions.Player.Jump.ReadValue<float>() == 1;
    public bool sprint => InputManager.Instance.Actions.Player.Sprint.ReadValue<float>() == 1;
}
