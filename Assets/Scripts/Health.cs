using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int fullHealth = 50;

    int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = fullHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DealDamage(int damage)
    {
        currentHealth -= damage;
        // Play hurt vfx
        // play hurt audio

        if(currentHealth <= 0)
        {
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        // play death VFX
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
