using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAI : MonoBehaviour {
    public float Movespeed = 40;

    // Use this for initialization
    void Start () {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * Movespeed;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "WallTop") {
            GetComponent<Rigidbody2D>().velocity = Vector2.down * Movespeed;

        }

        if (col.gameObject.name == "WallBottom")
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * Movespeed;

        }



    }

    }
