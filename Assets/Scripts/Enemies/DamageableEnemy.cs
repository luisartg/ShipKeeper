using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

[ExecuteInEditMode]
public class DamageableEnemy : MonoBehaviour, IDamageable
{
    [SerializeField]
    private int healthPoints = 3;
    
    public SFXControl sfxControl;
    public GameObject destroyContainer;

    private IDestroyable destroyProcess;

    private void Start()
    {
        destroyProcess = destroyContainer.GetComponent<IDestroyable>();
    }

    public void DoDamage(int damagePoints)
    {
        if (healthPoints > 0)
        {
            healthPoints -= damagePoints;
            if (healthPoints <= 0)
            {
                // TODO: drop loot?
                healthPoints = 0;
                destroyProcess.StartDestroy();

            }
            else
            {
                sfxControl.PlaySound((int)Sounds.getHit);
            }
        }
    }

    private enum Sounds
    {
        getHit = 0
    }
}
