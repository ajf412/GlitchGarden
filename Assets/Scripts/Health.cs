using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int fullHealth = 50;
    [SerializeField] GameObject hitParticles;


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
        if (hitParticles)
        {
            GameObject hitParticlesOBJ = Instantiate(hitParticles, transform.position, transform.rotation);
            Destroy(hitParticlesOBJ, 1f);
        }
        
        // play hurt audio

        if(currentHealth <= 0)
        {
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        // if (!deathVFX) { return; }
        // play death VFX
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
