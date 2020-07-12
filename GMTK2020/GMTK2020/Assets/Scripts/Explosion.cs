using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float knockback = 20f;
    public float damage = 1f;
    public float radius = 1f;
    public float holdTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetRadius(float radius)
    {
        this.radius = radius;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public void Explode()
    {
        Collider2D[] hitableObjects = Physics2D.OverlapCircleAll(transform.position,radius);
        // stat playing animation
        // hit objects
        foreach(Collider2D hit in hitableObjects)
        {
            Vector2 dir = hit.transform.position - transform.position;
            Rigidbody2D other = hit.GetComponent<Rigidbody2D>();
            PlayerMovement player = hit.GetComponent<PlayerMovement>();
            if(player != null)
            {
                player.AddKnockback(dir, knockback, holdTime);
            }
            else if(other != null)
            {
                other.AddForce(dir * knockback, ForceMode2D.Impulse);
            }
        }
        StartCoroutine(waitToDelete());
    }

    private IEnumerator waitToDelete()
    {
        yield return new WaitForSecondsRealtime(holdTime);
        Destroy(gameObject);
    }
}
