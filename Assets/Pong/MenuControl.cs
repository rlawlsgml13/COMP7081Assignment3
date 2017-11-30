using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour {

    public Button PlayH_Button;
    public Button PlayA_Button;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

   
	}

    public void PlayVHuman() {

        SceneManager.LoadScene(1);

    }

    public void PlayVAi()
    {

        SceneManager.LoadScene(2);

    }

}
