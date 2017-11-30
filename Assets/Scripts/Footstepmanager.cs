using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footstepmanager : MonoBehaviour {
    public AudioClip soundStep;
    AudioSource mystep;

    public static Footstepmanager insStep;

    private void Awake()
    {
        if (Footstepmanager.insStep == null)
            Footstepmanager.insStep = this;
    }


    // Use this for initialization
    void Start()
    {
        mystep = GetComponent<AudioSource>();
    }

    public void StepSound()
    {
        mystep.PlayOneShot(soundStep);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
