using UnityEngine;

public class AngleBracketsModifer : IModifer
{
    public Vector2 Move(Vector2 inputVector, IPlayerInput input)
    {
        return new Vector2(input.bracketsInput, inputVector.y).normalized;
    }
}
