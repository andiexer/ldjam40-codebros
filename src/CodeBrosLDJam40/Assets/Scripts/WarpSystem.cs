using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpSystem : MonoBehaviour
{

    public Transform targetObject;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("an object entered!");
        other.gameObject.transform.position = targetObject.position;
        Camera.main.transform.position = new Vector3(targetObject.position.x, targetObject.position.y, -10f);
    }
}