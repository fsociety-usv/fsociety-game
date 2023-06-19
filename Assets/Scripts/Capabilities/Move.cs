using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[RequireComponent(typeof(Controller))]
public class Move : MonoBehaviour
{
    [SerializeField, Range(0f, 100f)] private float _maxSpeed = 4f;
    [SerializeField, Range(0f, 100f)] private float _maxAcceleration = 35f;
    [SerializeField, Range(0f, 100f)] private float _maxAirAcceleration = 20f;

    private Controller _controller;
    private Vector2 _direction, _desiredVelocity, _velocity;
    private Rigidbody2D _body;
    private Ground _ground;

    private float _maxSpeedChange, _acceleration;
    private bool _onGround;

    public Animator animator;
    private BackgroundScroller _backgroundScroller;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _ground = GetComponent<Ground>();
        _controller = GetComponent<Controller>();
        _backgroundScroller = FindObjectOfType<BackgroundScroller>();
    }

    private void Update()
    {
        _direction.x = _controller.input.RetrieveMoveInput();

        Transform characterTransform = GetComponent<Transform>();

        if (_direction.x > 0)
        {
            characterTransform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        if (_direction.x < 0)
        {
            characterTransform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }

        animator.SetFloat("Speed", Mathf.Abs(_direction.x));

        _desiredVelocity = new Vector2(_direction.x, 0f) * Mathf.Max(_maxSpeed - _ground.Friction, 0f);

        // Move the background based on player movement
        _backgroundScroller.scrollSpeed = _velocity.x/2;
    }

    private void FixedUpdate()
    {
        _onGround = _ground.OnGround;
        _velocity = _body.velocity;

        _acceleration = _onGround ? _maxAcceleration : _maxAirAcceleration;
        _maxSpeedChange = _acceleration * Time.deltaTime;
        _velocity.x = Mathf.MoveTowards(_velocity.x, _desiredVelocity.x, _maxSpeedChange);

        _body.velocity = _velocity;
    }
}