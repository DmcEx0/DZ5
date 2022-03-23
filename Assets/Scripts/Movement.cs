using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private bool _isMovingRight;
    private bool _isMovingLeft;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _isMovingRight = Input.GetKey(KeyCode.D);
        _isMovingLeft = Input.GetKey(KeyCode.A);

        float yDirection = 0;
        float zDirection = 0;

        Move();

        if (_isMovingRight)
            transform.Translate(_speed * Time.deltaTime, yDirection, zDirection);

        if (_isMovingLeft)
            transform.Translate(_speed * Time.deltaTime * -1, yDirection, zDirection);
    }

    private void Move()
    {
        _animator.SetBool("isMove", _isMovingRight || _isMovingLeft);
    }
}
