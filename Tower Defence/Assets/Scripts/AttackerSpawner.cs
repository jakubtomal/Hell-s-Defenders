using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    bool spawn = true;

    [SerializeField] float minSpawnDelay = 1.0f;
    [SerializeField] float maxSpawnDelay = 5.0f;
    [SerializeField] Attacker[] attackerPrefabs;

    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        Spawn(attackerPrefabs[Random.Range(0, attackerPrefabs.Length)]);
    }

    private void Spawn(Attacker myAttacker)
    {
        Attacker attacker = Instantiate(myAttacker, transform.position, Quaternion.identity) as Attacker;

        attacker.transform.parent = transform;
    }
}
