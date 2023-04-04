using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    private float _spead = 7f;
    private Rigidbody2D _rididbody;
    private BoxCollider2D _boxCollider;
    private float _force = 10f;
    private float _minHeight = -150f;
    public bool IsCheat;
    public List<GameObject> Enemy;
    private bool _isGround;
    private Animator _animator;
    private SpriteRenderer _sprite;
    public Joystick _joystick;
    private enum  MovementState {idle,runnig,jump }

    void Start()
    {
        
        _rididbody = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
        _isGround = false;
        
    }

    // Update is called once per frame
    void Update()
    {
       // float dirXComp = Input.GetAxisRaw("Horizontal");
        //_rididbody.velocity = new Vector2(dirXComp * _spead, _rididbody.velocity.y);
       
        float dirX = _joystick.Horizontal;
        float verticalMove = _joystick.Vertical;

        _rididbody.velocity = new Vector2(dirX * _spead, _rididbody.velocity.y);
       
        if (verticalMove>.5f && _isGround == true)
        {
            _rididbody.AddForce(Vector2.up * _force, ForceMode2D.Impulse);
            _isGround = false;

        }
        /*
        if (Input.GetKeyDown(KeyCode.Space) && _isGround == true)
        {
            _rididbody.AddForce(Vector2.up * _force, ForceMode2D.Impulse);
            _isGround = false;

        }
        */
        AnimationRunning();
        
       
       
        
        if (transform.position.y < _minHeight && IsCheat)
        {
            transform.position = new Vector3(0, 0, 0);
        }
        else if (transform.position.y < _minHeight)
        {
            Destroy(gameObject);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGround = true;
        }
    }
    private void AnimationRunning()
        
    {
        MovementState state;
        if (_joystick.Horizontal > 0f && _isGround == true)
        {
            state = MovementState.runnig;
            // _animator.SetBool("running", true);
            _sprite.flipX = false;
        }
        else if (_joystick.Horizontal < 0f && _isGround == true)
        {
            state = MovementState.runnig;
            //_animator.SetBool("running", true);
            _sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
            // _animator.SetBool("running", false);
        }
        if (_rididbody.velocity.y > .1f)
        {
            state = MovementState.jump;
        }
        _animator.SetInteger("state", (int)state);
        /*
        if (Input.GetAxisRaw("Horizontal")> 0f&& _isGround == true)
        {
            state = MovementState.runnig;
           // _animator.SetBool("running", true);
            _sprite.flipX = false;
        }
        else if (Input.GetAxisRaw("Horizontal")< 0f && _isGround == true)
        {
            state = MovementState.runnig;
            //_animator.SetBool("running", true);
            _sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
            // _animator.SetBool("running", false);
        }
        if(_rididbody.velocity.y> .1f)
        {
            state = MovementState.jump;
        }
        _animator.SetInteger("state", (int)state);
        */
    }
}