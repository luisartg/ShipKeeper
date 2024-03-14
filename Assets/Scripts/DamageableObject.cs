using System.Collections;
using UnityEngine;

public class DamageableObject : MonoBehaviour, IDamageable
{
    public int HealthPoints {
        get { return _healthPoints; }
    }
    [SerializeField]
    private int _healthPoints = 1;

    private HitSFXControl hitSFXControl;
    private GraphicControl graphicControl;

    // Start is called before the first frame update
    void Start()
    {
        hitSFXControl = GetComponent<HitSFXControl>();
        graphicControl = GetComponent<GraphicControl>();
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
            StartCoroutine(DestroyAfterSeconds(2));
            hitSFXControl.PlayDestroy();
            graphicControl.DestroyedState();
            graphicControl.TurnOffInteraction();
            graphicControl.TurnOffShadows();
        }
        else
        {
            hitSFXControl.PlayHit();
        }
    }

    IEnumerator DestroyAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }

}
