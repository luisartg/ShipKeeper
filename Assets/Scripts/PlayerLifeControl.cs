using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLifeControl : MonoBehaviour
{
    public float InvencivilityTime = 2f;
    public List<MonoBehaviour> ScriptsToTurnOffWhenDead = new();
    public SpriteRenderer visual;
    public ParticleSystem bloodPS;
    public AudioClip deadSound;
    public AudioClip damageSound;
    public AudioSource audioSource;
    public AudioSource audioTurnOff;

    private bool damageTimeOut = false;
    private LifeDisplay lifeDisplay = null;

    [SerializeField]
    private int lifePoints = 3;
    // Start is called before the first frame update
    void Start()
    {
        lifeDisplay = FindObjectOfType<LifeDisplay>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoDamage(int damagePoints)
    {
        if (damageTimeOut || lifePoints <= 0)
        {
            return;
        }

        StartCoroutine(DoDamageTimeOut());

        if (lifePoints > 0)
        {
            bloodPS.Play();
            audioSource.PlayOneShot(damageSound);
            lifePoints -= damagePoints;
            lifeDisplay.ReportLife(lifePoints);
        }

        if (lifePoints <= 0)
        {
            Dead();
        }
    }

    private IEnumerator DoDamageTimeOut()
    {
        damageTimeOut = true;
        yield return new WaitForSeconds(InvencivilityTime);
        damageTimeOut = false;
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

        StartCoroutine(ReloadAfterTime());
    }

    private IEnumerator ReloadAfterTime()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
