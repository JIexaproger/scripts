using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    [SerializeField] private Transform cameraParent;
    [SerializeField] private float cameraSensitive = 0.5f;
    [SerializeField] private float cameraRotateMin = -90;
    [SerializeField] private float cameraRotateMax = 90;

    private IPlayerInput _input;
    private Vector2 _look;

    private void Awake()
    {
        _input = GetComponent<IPlayerInput>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        _look += _input.lookInput * 0.1f * cameraSensitive;

        _look.y = Mathf.Clamp(_look.y, cameraRotateMin, cameraRotateMax);

        cameraParent.localRotation = Quaternion.Euler(-_look.y, 0, 0);
        transform.rotation = Quaternion.Euler(0, _look.x, 0);
    }
}
