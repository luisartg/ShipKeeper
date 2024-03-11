using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class PlayerLifeControl : MonoBehaviour
{
    public List<MonoBehaviour> ScriptsToTurnOffWhenDead = new();
    public SpriteRenderer visual;
    public ParticleSystem bloodPS;
    public AudioClip deadSound;
    public AudioClip damageSound;
    public AudioSource audioSource;
    public AudioSource audioTurnOff;

    [SerializeField]
    private int lifePoints = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoDamage(int damagePoints)
    {
        if (lifePoints > 0)
        {
            bloodPS.Play();
            audioSource.PlayOneShot(damageSound);
            lifePoints -= damagePoints;
        }

        if (lifePoints <= 0)
        {
            Dead();
        }
    }

    private void Dead()
    {
        foreach (MonoBehaviour m in ScriptsToTurnOffWhenDead)
        {
            m.enabled = false;
        }
        visual.enabled = false;
        bloodPS.Play();
        audioSource.PlayOneShot(deadSound);
        audioTurnOff.Stop();
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Collider2D>().enabled = false;
    }
}