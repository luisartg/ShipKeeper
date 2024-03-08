using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragSFXControl : MonoBehaviour
{
    public AudioClip dragSFX;

    [SerializeField]
    private float fadeSpeed = 1.5f;
    [SerializeField]
    private float maxVolume = 0.5f;

    private AudioSource dragAudio;
    private AudioFadeControl fadeControl;
    private Rigidbody2D objRb;
    private bool soundActive = false;

    // Start is called before the first frame update
    void Start()
    {
        dragAudio = gameObject.AddComponent<AudioSource>();
        fadeControl = gameObject.AddComponent<AudioFadeControl>();
        fadeControl.WorkWith(dragAudio, fadeSpeed);
        fadeControl.MaxVolume = maxVolume;
        objRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckForDrag();
    }

    private void CheckForDrag()
    {
        if (objRb.velocity.magnitude > 0.3)
        {
            TurnOnDragSFX();
        }
        else
        {
            TurnOffDragSFX();
        }
    }

    private void TurnOnDragSFX()
    {
        if (!soundActive)
        {
            soundActive = true;
            dragAudio.loop = true;
            dragAudio.clip = dragSFX;
            dragAudio.volume = 0;
            fadeControl.StartFadeIn();
        }
    }

    private void TurnOffDragSFX()
    {
        if (soundActive)
        {
            soundActive = false;
            fadeControl.StartFadeOut();
        }
    }
}
