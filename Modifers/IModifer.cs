using UnityEngine;

public interface IModifer
{
    Vector2 Move(Vector2 inputVector, IPlayerInput input);
}