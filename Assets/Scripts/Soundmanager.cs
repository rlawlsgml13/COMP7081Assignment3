using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundmanager : MonoBehaviour {
    public AudioClip soundExplosion;
    AudioSource myAudio;

    public static Soundmanager instance;

    private void Awake()
    {
        if (Soundmanager.instance == null) ;
        Soundmanager.instance = this;
    }
    // Use this for initialization
    void Start () {
       
       PlaySound();
	}

    public void PlaySound()
    {
        
      //  
      //  {
         //   myAudio = GetComponent<AudioSource>();
         //   myAudio.PlayOneShot(soundExplosion);
         //   Debug.Log("dd");

        //  }

        if (Input.GetKeyUp(KeyCode.M))
        {
            Debug.Log("M");

        }
    }


    void Update()
    {

    }
}
	

