using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed;
    [SerializeField] int damage = 50;
    

    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * projectileSpeed);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.GetComponent<Attacker>() )
        {
            collision.GetComponent<Health>().DealDamage(damage);
            Destroy(gameObject);
        }
    }
}
