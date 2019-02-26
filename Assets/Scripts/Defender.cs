using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] GameObject projectile, releasePoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack(float damage)
    {
        if (projectile && releasePoint)
        {
            Instantiate(projectile, releasePoint.transform.position, Quaternion.identity);
        }
    }
}
