using UnityEngine;

public class CorpseFollowPlayer : MonoBehaviour
{
    public Corpse corpse;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            corpse.FollowPlayerStart(collision.gameObject.GetComponent<PlayerLifeControl>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            corpse.FollowPlayerEnd();
        }
    }
}
