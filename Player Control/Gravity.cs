using UnityEngine;

public class Gravity
{
    private float _gravityScale = 1f;
    private float _mass = 1f;

    public Gravity(float gravityScale, float mass)
    {
        _gravityScale = gravityScale;
        _mass = mass;
    }

    public float GetAcceleration()
    {
        return _gravityScale * _mass * Time.deltaTime;
    }
}
