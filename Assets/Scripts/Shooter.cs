using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile = null, releasePoint = null;

    public void Attack(float damage)
    {
        if (projectile && releasePoint)
        {
            Instantiate(projectile, releasePoint.transform.position, Quaternion.identity);
        }
    }
}
