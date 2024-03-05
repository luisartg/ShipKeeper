using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableObject : MonoBehaviour
{
    public int HealthPoints {
        get { return _healthPoints; }
    }
    [SerializeField]
    private int _healthPoints = 1;

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
        _healthPoints -= damagePoints;
        if (_healthPoints <= 0)
        {
            // TODO: drop loot?
            Destroy(gameObject);
        }
    }
}
