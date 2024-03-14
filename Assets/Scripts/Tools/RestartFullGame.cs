using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartFullGame : MonoBehaviour
{

    private float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            time += Time.deltaTime;
            if (time > 3)
            {
                SceneManager.LoadScene("SplashScreen");
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            time = 0;
        }
    }
}
