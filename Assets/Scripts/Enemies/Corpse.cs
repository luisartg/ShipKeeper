using Assets.Scripts.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corpse : MonoBehaviour, IDestroyable
{
    public SFXControl soundControl;
    public float CrawlSpeed = 1f; // units per sec
    public GameObject DeadState;

    private bool followPlayer = false;
    private bool currentlyScreaming = false;
    private bool dead = false;
    private PlayerLifeControl playerLifeControl;
    private Rigidbody2D enemyRb;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (followPlayer && !dead)
        {
            MoveTowardsPlayer();
            ProduceSound();
        }
    }

    private void ProduceSound()
    {
        if (!currentlyScreaming)
        {
            currentlyScreaming = true;
            int soundId = UnityEngine.Random.Range(0, 2);
            soundControl.PlaySound(soundId);
            int waitTime = UnityEngine.Random.Range(0, 2);
            StartCoroutine(WaitBeforeNextSound(waitTime));
        }
    }

    private IEnumerator WaitBeforeNextSound(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        currentlyScreaming = false;
    }

    private void MoveTowardsPlayer()
    {
        enemyRb.velocity = (playerLifeControl.gameObject.transform.position - transform.position)
            .normalized * CrawlSpeed;
    }

    public void FollowPlayerStart(PlayerLifeControl playerRef)
    {
        playerLifeControl = playerRef;
        followPlayer = true;
    }

    public void FollowPlayerEnd()
    {
        playerLifeControl = null;
        followPlayer = false;
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerLifeControl>().DoDamage(1);
        }
    }

    public void StartDestroy()
    {
        // What happens when this dies
        dead = true;
        enemyRb.velocity = Vector2.zero;
        enemyRb.isKinematic = true;
        gameObject.GetComponent<Collider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        DeadState.SetActive(true);
        StartCoroutine(WaitBeforeFullDestroy());
    }

    private IEnumerator WaitBeforeFullDestroy()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
