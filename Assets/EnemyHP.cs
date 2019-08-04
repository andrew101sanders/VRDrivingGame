using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public float hp = 100f;
    public Mesh Normal;
    public Mesh Damaged1;
    public Mesh Damaged2;
    public GameObject explosion1;
    public GameObject explosion2;
    public GameObject carlist;
    private GameObject score;

    private void Start()
    {
        score = GameObject.Find("score");
    }

    public void Damage(float dam)
    {
        hp -= dam;
        if (hp <= 0) blowup();
        else if (hp <= 35) mesh2();
        else if (hp <= 65) mesh1();
        GetComponent<ShootPlayer>().currentHue = .162f;
    }

    void blowup()
    {
        if (score != null)
        {
            score.GetComponent<Scoring>().increaseKilled();
        }
        GameObject ex = Instantiate(explosion1, transform.position, transform.rotation);
        ex.transform.localScale = new Vector3(.5f, .5f, .5f);
        Destroy(ex, 5f);
        ex = Instantiate(explosion2, transform.position, transform.rotation);
        ex.transform.localScale = new Vector3(.5f, .5f, .5f);
        Destroy(ex, 5f);
        carlist.GetComponent<SpawnEnemies>().enemies--;
        carlist.GetComponent<SpawnEnemies>().removeCar(gameObject);
        //   Destroy(gameObject);
    }

    public void mesh0()
    {
        transform.GetChild(1).GetChild(0).GetComponent<MeshFilter>().mesh = Normal;
    }

    void mesh1()
    {
        transform.GetChild(1).GetChild(0).GetComponent<MeshFilter>().mesh = Damaged1;
    }

    void mesh2()
    {
        transform.GetChild(1).GetChild(0).GetComponent<MeshFilter>().mesh = Damaged2;
    }
}
