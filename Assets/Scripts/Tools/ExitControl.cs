using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitControl : MonoBehaviour
{
    public string NextScene;
    public GameObject Visual;
    public Collider2D Collider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //TEST
        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    Debug.Log($"Loading scene of name[{NextScene}]");
        //    SceneManager.LoadScene(NextScene, LoadSceneMode.Single);
        //}
    }

    public void ActivateExit()
    {
        Visual.SetActive(true);
        Collider.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(NextScene, LoadSceneMode.Single);
        }
    }
}
