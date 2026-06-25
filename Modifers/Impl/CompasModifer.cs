using UnityEngine;

public class CompasModifer : IModifer
{
    public Vector2 Move(Vector2 inputVector, IPlayerInput input)
    {
        return new Vector2(inputVector.y, -inputVector.x);
    }
}
