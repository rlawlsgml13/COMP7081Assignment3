using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashManager : MonoBehaviour {
    public AudioClip soundCrash;
    AudioSource myCrash;

    public static CrashManager insCrash;

    private void Awake()
    {
        if (CrashManager.insCrash == null)
            CrashManager.insCrash = this;
    }


    // Use this for initialization
    void Start () {
        myCrash = GetComponent<AudioSource>();
	}

    public void CrashSound()
    {
        myCrash.PlayOneShot(soundCrash);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
