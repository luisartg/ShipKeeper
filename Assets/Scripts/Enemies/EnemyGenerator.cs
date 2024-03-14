using System.Collections;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public float TimeGap = 0.5f;
    public int MaxEnemies = 1;
    public int MinEnemies = 0;

    private bool nestActive = true;
    private int enemiesGenerated = 0;
    private int enemiesNeeded = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && nestActive)
        {
            nestActive = false;
            StartEnemyGeneration();
        }
    }

    private void StartEnemyGeneration()
    {
        enemiesNeeded = UnityEngine.Random.Range(MinEnemies, MaxEnemies + 1);
        Debug.Log($"Enemies needed {enemiesNeeded}");

        StartCoroutine(GenerateEnemy());
    }

    private IEnumerator GenerateEnemy()
    {
        Debug.Log("Generate Enemy Was Called");
        if (enemiesGenerated < enemiesNeeded)
        {
            Instantiate(EnemyPrefab, gameObject.transform.position, gameObject.transform.rotation);
            enemiesGenerated++;
            Debug.Log($"Enemy number: {enemiesGenerated}");
            yield return new WaitForSeconds(TimeGap);
            StartCoroutine(GenerateEnemy());
        }
        else
        {
            yield return null;
        }
    }
}
