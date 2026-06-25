using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement settings")]
    [SerializeField] private float walkSpeed = 1.5f;
    [SerializeField] private float runSpeed = 3f;
    [SerializeField] private float jumpScale = 10f;
    [Header("Gravity")]
    [SerializeField] private float gravityScale = 4f;
    [SerializeField] private float mass = 10f;

    private IPlayerInput _input; 
    private InputModifer _inputModifer;
    private Gravity _gravity;
    private CharacterController _controller;
    private Vector3 _velocity;

    

    private void Awake()
    {
        _input = GetComponent<IPlayerInput>();
        _inputModifer = GetComponent<InputModifer>();
        _controller = GetComponent<CharacterController>();
        _gravity = new Gravity(gravityScale, mass);
    }

    private void Update()
    {
        if (_input.jump)
            Jump();

        UpdateMove();
        Debug.Log(_input.bracketsInput);
    }

    private void Jump()
    {
        if (_controller.isGrounded)
            _velocity.y = jumpScale;
    }
    
    private void UpdateMove()
    {
        var input = _inputModifer.GetMoveVector(_input).normalized;
        input *= 0.01f * (_input.sprint ? runSpeed : walkSpeed); // определение скорости

        var moveVector = new Vector3();
        moveVector += transform.right * input.x;    // добавление к вентору координаты вперёд
        moveVector += transform.forward * input.y;  // добавление к вектору координаты вбок

        _controller.Move(moveVector + _velocity * Time.deltaTime); // перемещение

        _velocity.y = _controller.isGrounded ? -1f : _velocity.y - _gravity.GetAcceleration(); // расчёт гравитации
    }
}
