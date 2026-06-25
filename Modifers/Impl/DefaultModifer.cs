using UnityEngine;

public class DefaultModifer : IModifer
{
    public Vector2 Move(Vector2 inputVector, IPlayerInput input)
    {
        return inputVector;
    }
}
