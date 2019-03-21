using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        displayHealth();
    }

    private void displayHealth()
    {
        gameObject.GetComponent<Text>().text = currentHealth.ToString();
    }

    public void UpdateHealth(int changeInHealth)
    {
        currentHealth += changeInHealth;

        if (currentHealth <= 0)
        {
            FindObjectOfType<LevelController>().LevelDefeat();
        }
        else
        {
            displayHealth();
        }
    }
}
