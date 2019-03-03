using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 1f;
    [SerializeField] int projectileDamage = 20;

    private void Start()
    {
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime);    
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit " + other.gameObject.name);

        // check if attacker
        Health health = other.gameObject.GetComponent<Health>();
        Attacker attacker = other.gameObject.GetComponent<Attacker>();
      
        if (attacker && health)
        {
            health.DealDamage(projectileDamage);
            Destroy(gameObject);
        }
    }
}
