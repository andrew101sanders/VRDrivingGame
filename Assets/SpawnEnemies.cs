using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public float enemies = 0f;
    public GameObject enemyPrefab;
    public GameObject playerCar;
    private LinkedList<GameObject> activeEnemyCars;
    private LinkedList<GameObject> inactiveEnemyCars;
    private int id = 0;

    void Start()
    {
        activeEnemyCars = new LinkedList<GameObject>();
        inactiveEnemyCars = new LinkedList<GameObject>();
        spawnNewEnemy();
        spawnNewEnemy();
        spawnNewEnemy();
        spawnNewEnemy();
        spawnNewEnemy();
    }

    void Update()
    {
        if (enemies < 3)
        {
            respawnNewEnemy();
        }
    }

    void spawnNewEnemy()
    {
        GameObject c = Instantiate(enemyPrefab, transform);
        c.GetComponent<EnemyHP>().carlist = c.transform.parent.gameObject;
        inactiveEnemyCars.AddFirst(c);
        c.transform.position = new Vector3(-500, -500, -500);
        c.GetComponent<EnemyHP>().enabled = false;
        c.GetComponent<AutoDrive>().enabled = false;
        // c.SetActive(false);
    }

    void respawnNewEnemy()
    {
        GameObject temp = inactiveEnemyCars.First.Value;
    //    temp.SetActive(true);
        activeEnemyCars.AddLast(temp);
        inactiveEnemyCars.RemoveFirst();
        if (Random.Range(0, 2) == 1)
        {
            temp.transform.position = new Vector3(Random.Range(48f, 51.8f), 0.01539606f, playerCar.transform.position.z + 50f);
        }
        else temp.transform.position = new Vector3(Random.Range(48f, 51.8f), 0.01539606f, playerCar.transform.position.z - 50f);
        temp.transform.rotation = playerCar.transform.rotation;
        temp.transform.GetChild(1).GetChild(0).GetComponent<ColorSwap>().swapcol();
        temp.GetComponent<EnemyHP>().hp = 100f;
        temp.GetComponent<EnemyHP>().mesh0();
        temp.GetComponent<EnemyHP>().enabled = true;
        temp.GetComponent<AutoDrive>().enabled = true;
        enemies++;
    }

    public void removeCar(GameObject id)
    {
    //    activeEnemyCars.Find(id).Value.SetActive(false);
        inactiveEnemyCars.AddLast(activeEnemyCars.Find(id).Value);
        activeEnemyCars.Remove(id);
        id.transform.position = new Vector3(-500, -500, -500);
        id.GetComponent<EnemyHP>().enabled = false;
        id.GetComponent<AutoDrive>().enabled = false;
    }
}
