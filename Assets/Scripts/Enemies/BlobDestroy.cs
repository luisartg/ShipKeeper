using Assets.Scripts.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[Serializable]
public class BlobDestroy : MonoBehaviour, IDestroyable
{
    public SFXControl sFXControl;
    public BlobAttackProcess attackProcess;
    public StateControl stateControl;
    public float TimeBeforeDestroy = 10f;

    private GameplayControl gameplayControl;

    private void Start()
    {
        gameplayControl = FindObjectOfType<GameplayControl>();
        gameplayControl.MonsterReport();
    }

    public void StartDestroy()
    {
        gameplayControl.MonsterKillReport();
        sFXControl.PlaySound((int) Sounds.Dead);
        attackProcess.StopAttacks();
        stateControl.ChangeTo((int) States.Dead);
        StartCoroutine(WaitForDestroy());
    }

    private IEnumerator WaitForDestroy()
    {
        yield return new WaitForSeconds(TimeBeforeDestroy);
        Destroy(gameObject);
    }

    private enum Sounds
    {
        Dead = 2
    }

    private enum States
    {
        Dead = 3
    }
}
