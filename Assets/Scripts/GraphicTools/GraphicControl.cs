using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GraphicControl : MonoBehaviour
{
    public Sprite DestroyedSprite;
    public ShadowCaster2D ShadowCaster;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private Collider2D col;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    public void TurnOffInteraction()
    {
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        col.enabled = false;
    }

    public void TurnOffShadows()
    {
        ShadowCaster.enabled = false;
    }

    public void DestroyedState()
    {
        spriteRenderer.sprite = DestroyedSprite;
    }
}
