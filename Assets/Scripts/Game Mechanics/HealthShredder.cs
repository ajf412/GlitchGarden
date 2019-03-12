using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthShredder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("HealthShredder hit by " + collision.name);
        if (collision.GetComponent<Attacker>())
        {
            int damage = -collision.GetComponent<Attacker>().GetDamage();
            FindObjectOfType<HealthDisplay>().UpdateHealth(damage);
            Destroy(collision.gameObject);
        }
    }
}