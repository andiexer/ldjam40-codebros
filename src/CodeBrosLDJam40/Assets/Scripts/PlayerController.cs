using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetAxisRaw("Horizontal") > 0.1  || Input.GetAxisRaw("Horizontal") < -0.1)
	    {
	        transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0));
	    }
	    if (Input.GetAxisRaw("Vertical") > 0.1 || Input.GetAxisRaw("Vertical") < -0.1)
	    {
	        transform.Translate(new Vector3(0, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime ,0));
	    }
    }
}
