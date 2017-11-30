using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Console : MonoBehaviour {

    public Text ps4console;
    public Color color1 = Color.red;
    public Color color2 = Color.blue;
    public Color color3 = Color.green;
   
    public InputField console;

	// Use this for initialization
	void Start () {

        console.gameObject.SetActive(false);
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.C)) {


            console.gameObject.SetActive(true);


            if (Input.GetKeyDown(KeyCode.Return))
            {



                OnEnter();



            }


        }
		
	}
    public void OnEnter() {

        

        if (console.text == "b1") {

            Camera.main.backgroundColor = color1;
            console.gameObject.SetActive(false);



        }

        if (console.text == "b2")
        {

            Camera.main.backgroundColor = color2;

            console.gameObject.SetActive(false);


        }


        if (console.text == "b3")
        {

            Camera.main.backgroundColor = color3;

            console.gameObject.SetActive(false);


        }

        console.text = "";
        console.ActivateInputField();

   

    }

}
