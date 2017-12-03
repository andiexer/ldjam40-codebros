using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;

    private Animator _anim;
    private bool _playerMoving;
    private bool _attacking;
    public float AttackTime;
    private float _attackTimeCounter;
    private Vector3 _lastMove;
    private Rigidbody2D _rigidbody2D;

    // Use this for initialization
    void Start()
    {
        _anim = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        _playerMoving = false;

        if (!_attacking)
        {
            if (Input.GetAxisRaw("Horizontal") > 0.1f || Input.GetAxisRaw("Horizontal") < -0.1f)
            {
                //transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
                _rigidbody2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, _rigidbody2D.velocity.y);
                _playerMoving = true;
                _lastMove = new Vector3(Input.GetAxisRaw("Horizontal"), 0);
            }
            if (Input.GetAxisRaw("Vertical") > 0.1f || Input.GetAxisRaw("Vertical") < -0.1f)
            {
                //transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);
                _playerMoving = true;
                _lastMove = new Vector3(0, Input.GetAxisRaw("Vertical"));
            }

            if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
            {
                _rigidbody2D.velocity = new Vector2(0f, _rigidbody2D.velocity.y);
            }

            if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
            {
                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0f);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _attackTimeCounter = AttackTime;
                _attacking = true;
                _rigidbody2D.velocity = Vector2.zero;
                _anim.SetBool("IsAttacking", _attacking);
            }
        }

        if (_attackTimeCounter > 0)
        {
            _attackTimeCounter -= Time.deltaTime;
        }

        if (_attackTimeCounter <= 0)
        {
            _attacking = false;
            _anim.SetBool("IsAttacking", false);
        }

        _anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        _anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        _anim.SetBool("PlayerMoving", _playerMoving);
        _anim.SetFloat("LastMoveX", _lastMove.x);
        _anim.SetFloat("LastMoveY", _lastMove.y);

    }
}
