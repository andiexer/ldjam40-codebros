﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float speed = 0.5f;
    public Transform Player;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 displacement = Player.position - transform.position;
        displacement = displacement.normalized;
        if (Vector2.Distance(Player.position, transform.position) > 1.0f)
        {
            transform.position += (displacement * speed * Time.deltaTime);

        }
        else
        {
            //do whatever the enemy has to do with the player
            //remove health from the player
        }

    }
}
