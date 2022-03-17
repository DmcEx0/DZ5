using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        bool isMovingRight = Input.GetKey(KeyCode.D);
        bool isMovingLeft = Input.GetKey(KeyCode.A);

        _animator.SetBool("isMove", isMovingRight || isMovingLeft);

        if (isMovingRight)
            transform.Translate(_speed * Time.deltaTime, 0, 0);

        if (isMovingLeft)
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
    }
}
