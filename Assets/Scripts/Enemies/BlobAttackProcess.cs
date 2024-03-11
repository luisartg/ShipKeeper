using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobAttackProcess : MonoBehaviour
{

    public float PreAttackTime = 1f;
    public float AttackTrackStopTime = 0.1f;
    public float AttackTime = 0.4f;
    public float RestTime = 1f;

    public StateControl StatesControl;
    public SFXControl sfxControl;

    [SerializeField]
    private Collider2D proximityTrigger;

    private GameObject playerRef;
    private Vector2 targetPosition;

    /* Flow:
     * 1- Wait for trigger to know the player is near
     * 2- when player is near, disable trigger, prepare for attack, and then attack to the direction the player is.
     * 3- attack time out
     * 4- reactivate trigger, and repeat
    */

    // Start is called before the first frame update
    void Start()
    {
        StatesControl.ChangeTo((int)States.Base);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartAttack()
    {
        sfxControl.PlaySound((int)Sounds.PreAttack);
        StatesControl.ActivateState((int)States.PreAttack);
        StartCoroutine(WaitPreAttackTimeOut());
    }

    private IEnumerator WaitPreAttackTimeOut()
    {
        yield return new WaitForSeconds(PreAttackTime);
        targetPosition = playerRef.transform.position;
        StartCoroutine(WaitForTimeAfterAttackTrack());
    }

    private IEnumerator WaitForTimeAfterAttackTrack()
    {
        yield return new WaitForSeconds(AttackTrackStopTime);
        DoAttack();
    }

    private void DoAttack()
    {
        StatesControl.ActivateState((int)States.Attack);
        sfxControl.PlaySound((int)Sounds.Attack);
        Vector2 direction = targetPosition - (Vector2)transform.position;
        StatesControl.StatesList[(int)States.Attack].transform.localRotation
            = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90);
        StartCoroutine(WaitForAttackTime());
    }

    private IEnumerator WaitForAttackTime()
    {
        yield return new WaitForSeconds(AttackTime);
        StatesControl.ChangeTo((int)States.Base);
        StartCoroutine(WaitForRest());
    }

    private IEnumerator WaitForRest()
    {
        yield return new WaitForSeconds(RestTime);
        proximityTrigger.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerRef = collision.gameObject;
            proximityTrigger.enabled = false;
            StartAttack();
        }
    }

    private enum States
    {
        Base = 0,
        PreAttack = 1,
        Attack = 2
    }

    private enum Sounds
    {
        PreAttack = 0,
        Attack = 1
    }

    public void StopAttacks()
    {
        StopAllCoroutines();
        enabled = false;
    }
}
