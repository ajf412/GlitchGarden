using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 1f;
    [SerializeField] float projectileDamage = 20f;
    [SerializeField] float destroyTime = 3f;

    private void Start()
    {
        Destroy(gameObject, destroyTime);
        projectileDamage /= PlayerPrefsController.GetMasterDifficulty();
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
            health.DealDamage(projectileDamage);
            Destroy(gameObject);
        }
    }
}
