using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float xSpeed = 0.1f;
    public float ySpeed = 0.1f;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(DestroyBullet());
    }


    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        position.x += xSpeed;
        position.y += ySpeed;
        transform.position = position;

    }
    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
