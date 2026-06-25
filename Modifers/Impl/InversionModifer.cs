using UnityEngine;

public class InversionModifer : IModifer
{
    public Vector2 Move(Vector2 inputVector, IPlayerInput input)
    {
        return inputVector * -1;
    }
}
