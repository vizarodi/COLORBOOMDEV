using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemy : MonoBehaviour
{
    public int timeBetweenSpawn;
    public int enemyToSpawn;
    public bool canSpawn = true;
    public GameObject slowEnemy, fastEnemy;
    public GameObject player;
    void Update()
    {
        if (canSpawn == true && player.active == true){
            canSpawn=false;
            timeBetweenSpawn = Random.Range(2, 4);
            enemyToSpawn = Random.Range(1, 3);
            StartCoroutine(waitToSpawn());
        }
    }

    IEnumerator waitToSpawn(){
        yield return new WaitForSeconds(timeBetweenSpawn);
        if (enemyToSpawn == 1){
            Instantiate(slowEnemy, this.transform.position, Quaternion.identity);
            canSpawn = true;
        }
        if (enemyToSpawn == 2){
            Instantiate(fastEnemy, this.transform.position, Quaternion.identity);
            canSpawn = true;
        }
    }
}
