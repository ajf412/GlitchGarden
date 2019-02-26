using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 1f;
    [SerializeField] int projectileDamage = 20;

    void Update()
    {
        transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime);    
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit " + other.gameObject.name);

        // check if attacker
        Attacker attacker = other.gameObject.GetComponent<Attacker>();
        if(!attacker) { return; }
        
        // check for health component
        Health health = other.gameObject.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(projectileDamage);
        }
        Destroy(gameObject);
    }
}
