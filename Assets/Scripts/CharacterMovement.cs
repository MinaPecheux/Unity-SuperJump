using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : MonoBehaviour
{
    private const float _SPEED = 3f;
    private const float _JUMP_FORCE = 8f;

    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _meshTransform;
    private Rigidbody _rigidbody;

    private LayerMask _groundLayer;

    private Vector3 _vel;
    private bool _jumping;

    private RaycastHit _hit;

    private void Awake()
    {
        _groundLayer = LayerMask.GetMask("Ground");
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _vel = _rigidbody.velocity;

        if (!_jumping)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                _StartRun(1);
            else if (Input.GetKeyDown(KeyCode.RightArrow))
                _StartRun(-1);

            if (Input.GetKey(KeyCode.LeftArrow))
                _vel.x = -_SPEED;
            else if (Input.GetKey(KeyCode.RightArrow))
                _vel.x = _SPEED;

            if (Input.GetKeyDown(KeyCode.Space))
                _Jump();
        }

        else if (
            _vel.y < Mathf.Epsilon &&
            Physics.Raycast(transform.position, Vector3.down, out _hit, 0.1f, _groundLayer)
        ) _Ground();

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
            _StopRun();

        _rigidbody.velocity = _vel;
    }

    private void _StartRun(float dir)
    {
        _meshTransform.rotation = Quaternion.LookRotation(new Vector3(dir, 0f, 0f));
        _animator.SetBool("Running", true);
    }

    private void _StopRun()
    {
        _animator.SetBool("Running", false);
    }

    private void _Jump()
    {
        _animator.SetTrigger("Jump");
        _vel.y += _JUMP_FORCE;
        _jumping = true;
    }

    private void _Ground()
    {
        _animator.SetTrigger("Grounded");
        _vel.y = 0;
        _jumping = false;
    }
}
