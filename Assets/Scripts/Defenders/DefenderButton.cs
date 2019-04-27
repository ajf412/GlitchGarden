using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab = null;

    private void Start()
    {
        foreach(Transform child in transform)
        {
            if(child.name == "Text")
            {
                if (defenderPrefab)
                {
                    child.GetComponent<Text>().text = defenderPrefab.GetComponent<Defender>().GetCoinCost().ToString();
                }
                else
                {
                    child.GetComponent<Text>().text = "";
                }
            }
        }
    }

    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach(DefenderButton button in buttons)
        {
            Image image = button.gameObject.transform.GetChild(0).GetComponent<Image>();
            image.color = new Color32(84, 84, 84, 255);
        }

        Image thisImage = this.gameObject.transform.GetChild(0).GetComponent<Image>();
        thisImage.color = Color.white;
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
    }
}
