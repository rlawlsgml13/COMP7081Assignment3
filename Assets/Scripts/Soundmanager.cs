using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundmanager : MonoBehaviour {
    public AudioClip soundExplosion;
    AudioSource myAudio;
    public int bgmOnOff = 1;

    public static Soundmanager instance;

    private void Awake()
    {
        if (Soundmanager.instance == null) ;
        Soundmanager.instance = this;
    }
    // Use this for initialization
    void Start () {
        myAudio = GetComponent<AudioSource>();
        myAudio.PlayOneShot(soundExplosion);
    }

    public void PlaySound()
    {

        //
        //  
       


        //  

        if (Input.GetKeyUp(KeyCode.M))
        {
            
            if (bgmOnOff == 1) {
                Debug.Log("off");
                myAudio.GetComponent<AudioSource>().volume = 0;
                bgmOnOff = 0;
            } else if (bgmOnOff == 0)
            {
                Debug.Log("on");
                myAudio.GetComponent<AudioSource>().volume = 1;

                bgmOnOff = 1;
            }

      //      
       //     myAudio.enabled = !myAudio.enabled;
       //     Debug.Log("M");

        } 
    }


    void Update()
    {

        PlaySound();
    }
}
	

