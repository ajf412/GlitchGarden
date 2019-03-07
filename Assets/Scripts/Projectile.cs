using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 1f;
    [SerializeField] int projectileDamage = 20;
    [SerializeField] float destroyTime = 3f;

    private void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    void Update()
    {
        transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime);    
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // check if attacker
        Health health = other.gameObject.GetComponent<Health>();
        Attacker attacker = other.gameObject.GetComponent<Attacker>();
      
        if (attacker && health)
        {
            Debug.Log(gameObject.name + " is hitting " + other.name);
            health.DealDamage(projectileDamage);
            Destroy(gameObject);
        }
    }
}
