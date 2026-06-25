using UnityEngine;

public interface IPlayerInput
{
    Vector2 moveInput { get; }
    Vector2 altMoveInput { get; }
    float bracketsInput { get; }
    Vector2 lookInput { get; }
    bool jump { get; }
    bool sprint { get; }
    // bool crouch { get; }
}
