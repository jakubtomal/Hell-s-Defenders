using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    bool spawn = true;

    [SerializeField] float minSpawnDelay ;
    [SerializeField] float maxSpawnDelay ;

    [SerializeField] float finalMinSpawnDelay ;

    [SerializeField] float decreseDelay ;
    [SerializeField] float Delay ;
    [SerializeField] Attacker[] attackerPrefabs;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(Delay);
        while (spawn)
        {

            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            if (maxSpawnDelay - decreseDelay >= finalMinSpawnDelay)
            {
                maxSpawnDelay -= decreseDelay;
            }
            else
            {
                maxSpawnDelay = finalMinSpawnDelay;
            }


            if (minSpawnDelay - decreseDelay >= finalMinSpawnDelay)
            {
                minSpawnDelay -= decreseDelay;
            }
            else
            {
                minSpawnDelay = finalMinSpawnDelay;
            }
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

    public void StopSpawning()
    {
        spawn = false;
    }
}
