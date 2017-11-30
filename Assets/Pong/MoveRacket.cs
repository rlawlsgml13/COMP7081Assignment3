using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRacket : MonoBehaviour {

    public KeyCode Upkey;
    public KeyCode DownKey;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKey(Upkey))
        {


            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 30f);

        }

        else if (Input.GetKey(DownKey))
        {

            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -30f);


        }

        else this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);


      

    }
}
