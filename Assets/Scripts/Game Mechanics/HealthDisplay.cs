using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] float maxHealth = 100;
    float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = Mathf.Round(maxHealth / PlayerPrefsController.GetMasterDifficulty());
        displayHealth();
    }

    private void displayHealth()
    {
        gameObject.GetComponent<Text>().text = currentHealth.ToString();
    }

    public void UpdateHealth(float changeInHealth)
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
