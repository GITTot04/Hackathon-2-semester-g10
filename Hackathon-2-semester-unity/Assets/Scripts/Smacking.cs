using UnityEngine;

public class Smacking : MonoBehaviour
{
    public float smackForce = 10f;
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Smackable"))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 smackDirection = (collision.transform.position - transform.position).normalized;
                rb.AddForce(smackDirection * smackForce, ForceMode2D.Impulse);
            }
        }
    }
}