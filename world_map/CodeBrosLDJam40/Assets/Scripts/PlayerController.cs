using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;

    private Animator _anim;
    private bool _playerMoving;
    private Vector3 _lastMove;

	// Use this for initialization
	void Start ()
	{
	    _anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

	    _playerMoving = false;

        if (Input.GetAxisRaw("Horizontal") > 0.1  || Input.GetAxisRaw("Horizontal") < -0.1)
	    {
	        transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0));
	        _playerMoving = true;
            _lastMove = new Vector3(Input.GetAxisRaw("Horizontal"), 0);
	    }
	    if (Input.GetAxisRaw("Vertical") > 0.1 || Input.GetAxisRaw("Vertical") < -0.1)
	    {
	        transform.Translate(new Vector3(0, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime ,0));
	        _playerMoving = true;
	        _lastMove = new Vector3(0, Input.GetAxisRaw("Vertical"));
        }

        _anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        _anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        _anim.SetBool("PlayerMoving", _playerMoving);
        _anim.SetFloat("LastMoveX", _lastMove.x);
	    _anim.SetFloat("LastMoveY", _lastMove.y);
    }
}
