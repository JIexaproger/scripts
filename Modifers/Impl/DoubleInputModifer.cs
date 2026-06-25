using UnityEngine;

public class DoubleInputModifer : IModifer
{
    public Vector2 Move(Vector2 inputVector, IPlayerInput input)
    {
        Vector2 altVector = input.altMoveInput;
        return new Vector2(altVector.x == inputVector.x ? altVector.x : 0, altVector.y == inputVector.y ? altVector.y : 0);
    }
}
