using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float fullHealth = 50;
    [SerializeField] float currentHealth = 0;  // Shown for debugging purposes.
    [SerializeField] GameObject hitParticles = null;

    float difficulty = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        bool attacker = GetComponent<Attacker>();
        bool defender = GetComponent<Defender>();
        difficulty = PlayerPrefsController.GetMasterDifficulty();

        if(attacker){
            Debug.Log(gameObject.name + " orig health set to: " + fullHealth);
            fullHealth = fullHealth * difficulty;
            Debug.Log(gameObject.name + " diff health set to: " + fullHealth);
        }
        else if(defender)
        {
            Debug.Log(gameObject.name + " orig health set to: " + fullHealth);
            fullHealth = fullHealth / difficulty;
            Debug.Log(gameObject.name + " diff health set to: " + fullHealth);
        }

        currentHealth = fullHealth;
        Debug.Log(gameObject.name + " level health set to: " + currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DealDamage(float damage)
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

    public void Shred()
    {
        Destroy(gameObject);
    }

    IEnumerator Die()
    {
        // if (!deathVFX) { return; }
        // play death VFX
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
