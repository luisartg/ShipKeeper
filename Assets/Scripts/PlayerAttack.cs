using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public bool IsAttacking {
        get { return _isAttacking; }
    }

    [SerializeField]
    private Collider2D axeCollider;
    [SerializeField]
    private Collider2D shotgunCollider;
    [SerializeField]
    private float axeAttackTimeOut = 1;
    [SerializeField]
    private float axeColliderTime = 0.5f;
    //[SerializeField]
    //private float shotgunAttackTimeOut = 2;
    //[SerializeField]
    //private float shotgunColliderTime = 1;

    private PlayerSFXManager playerSFXManager;
    private PlayerMovement playerMovement;
    private Animator playerAnim;
    private bool _isAttacking =  false;
    private bool axeEnabled = true;
    //private bool shotgunEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerAnim = GetComponent<Animator>();
        playerSFXManager = GetComponent<PlayerSFXManager>();

        axeCollider.enabled = false;
        shotgunCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isAttacking)
        {
            CheckForAxeAttack();
        }
    }

    private void CheckForAxeAttack()
    {
        if (!playerAnim.GetBool("Aim"))
        {
            if (Input.GetMouseButtonDown(0) && axeEnabled)
            {
                DoAxeAttack();
            }
        }
    }

    private void DoAxeAttack()
    {
        playerAnim.SetTrigger("AxeAttack");
        playerSFXManager.PlayAxeSwing();
        StartCoroutine(ColliderTime(axeColliderTime, axeCollider));
        StartCoroutine(ActivateAimMovementTemporarily(axeColliderTime));
        StartCoroutine(DisableAxeTemporarily());
    }

    IEnumerator ColliderTime(float seconds, Collider2D collider)
    {
        _isAttacking = true;
        collider.enabled = true;
        yield return new WaitForSeconds(seconds);
        collider.enabled = false;
        _isAttacking = false;
    }

    IEnumerator ActivateAimMovementTemporarily(float seconds)
    {
        playerMovement.ForceAimMode(true);
        yield return new WaitForSeconds(seconds);
        playerMovement.ForceAimMode(false);
    }

    IEnumerator DisableAxeTemporarily()
    {
        axeEnabled = false;
        yield return new WaitForSeconds(axeAttackTimeOut);
        axeEnabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damage = collision.gameObject.GetComponent<IDamageable>();
        if (damage != null)
        {
            if (!axeEnabled)
            {
                damage.DoDamage(1);
            }
        }
    }
}
