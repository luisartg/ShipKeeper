using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerLightControl : MonoBehaviour
{
    public AudioClip actionSound;
    [SerializeField]
    private bool lightEnabled = true;

    private Light2D lightSource;
    private AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        lightSource = GetComponent<Light2D>();
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.volume = 0.5f;
        SwitchLight(lightEnabled, false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            lightEnabled = !lightEnabled;
            SwitchLight(lightEnabled);
        }
    }

    private void SwitchLight(bool lightOn,bool useSound = true)
    {
        if (lightOn)
        {
            lightSource.intensity = 1;
        }
        else
        {
            lightSource.intensity = 0;
        }
        if (useSound)
        {
            audioSource.PlayOneShot(actionSound);
        }
    }
}
