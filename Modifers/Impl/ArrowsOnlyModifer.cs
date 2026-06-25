using UnityEngine;

public class ArrowsOnlyModifer : IModifer
{
    public Vector2 Move(Vector2 inputVector, IPlayerInput input)
    {
        return input.altMoveInput;
    }
}
