using System.Collections;
using UnityEngine;

public class Firetrap : MonoBehaviour
{
    [SerializeField] private float damage;

    [Header("Firetrap Timers")]
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;
    private Animator anim;
    private SpriteRenderer spriteRen;

    private bool triggered;
    private bool active;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRen = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(!triggered)
            {
                StartCoroutine(ActivateFiretrap());
            }
            if(active)
            {
                collision.GetComponent<Health>().TakeDamage(damage);
            }
        }
    }

    private IEnumerator ActivateFiretrap()
    {
        triggered= true;
        spriteRen.color= Color.red;
        yield return new WaitForSeconds(activationDelay);
        spriteRen.color = Color.white;
        active = true;
        anim.SetBool("activated", true);
        yield return new WaitForSeconds(activeTime);
        active= false;
        triggered = false;
        anim.SetBool("activated", false);

    }
}
