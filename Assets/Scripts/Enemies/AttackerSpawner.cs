using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    bool spawn = true;
    [SerializeField] Attacker[] mobs = null;
    [SerializeField] float minSpawnDelay = 1.0f;
    [SerializeField] float maxSpawnDelay = 5.0f;

    IEnumerator Start()
    {
        while(spawn)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        // Spawn random mob
        Spawn(mobs[Random.Range(0, mobs.Length)]);
    }

    private void Spawn(Attacker attacker)
    {
        // spawn new mob
        Attacker newAttacker = Instantiate(attacker, transform.position, Quaternion.identity) as Attacker;
        // set the mob's parent as spawner's transform.
        newAttacker.transform.parent = transform;
    }
}
