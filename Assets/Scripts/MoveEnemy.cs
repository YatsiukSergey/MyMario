using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public GameObject LeftBorder;
    public GameObject RightBorder;
    private Rigidbody2D _rigidbody;
    private bool _isRightDirection;
    private float _spead=5;
    private void Start()
    {
            _rigidbody= GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (_isRightDirection)
        {
            _rigidbody.velocity = Vector2.right * _spead;
            if (transform.position.x > RightBorder.transform.position.x)
            {
                _isRightDirection = false;
            }
        }
        else
        {
            _rigidbody.velocity = Vector2.left * _spead;
            if (transform.position.x < LeftBorder.transform.position.x)
            {
                _isRightDirection = true;
            }
        }
    }

}
