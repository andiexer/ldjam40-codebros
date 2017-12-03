using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeController : MonoBehaviour
{

    public float moveSpeed;
    public float timeBetweenMove;
    public float timeToMove;
    public float waitToReload;

    private Rigidbody2D _rb;
    private bool _isMoving;
    private Vector3 _moveDirection;
    private float _timeBetweenMoveCounter;
    private float _timeToMoveCounter;
    private bool _reloading;
    private GameObject _player;

	// Use this for initialization
	void Start ()
	{
	    _rb = GetComponent<Rigidbody2D>();
	    _timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
	    _timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);
    }
	
	// Update is called once per frame
	void Update () {
	    if (_isMoving)
	    {
	        _timeToMoveCounter -= Time.deltaTime;
	        _rb.velocity = _moveDirection;

	        if (_timeToMoveCounter < 0f)
	        {
	            _isMoving = false;
	            _timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
	        }
        }
	    else
	    {
	        _timeBetweenMoveCounter -= Time.deltaTime;
	        _rb.velocity = Vector2.zero;
	        if (_timeBetweenMoveCounter < 0)
	        {
	            _isMoving = true;
	            _timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);

                _moveDirection = new Vector3(Random.Range(-1f,1f), Random.Range(-1f,1f), 0);
	        }
	    }
	    if (_reloading)
	    {
	        waitToReload -= Time.deltaTime;
	        if (waitToReload < 0)
	        {
	            Application.LoadLevel(Application.loadedLevel);
	        }
	    }
	}
}
