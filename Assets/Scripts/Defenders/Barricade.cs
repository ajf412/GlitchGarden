using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricade : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Attacker attacker = otherCollider.GetComponent<Attacker>();

        if (attacker)
        {
            //TODO play hit animation
        }
    }
}
