using UnityEngine;

public class FollowPlayerCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        Vector2 playerPos = transform.position;
        Camera.main.transform.position =
            new Vector3(
                playerPos.x,
                playerPos.y,
                Camera.main.transform.position.z);
    }
}
