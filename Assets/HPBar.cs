using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HPBar : MonoBehaviour
{
    public GameObject hpbar;
    public GameObject particles;
    public GameObject loc1;
    public GameObject loc2;
    public GameObject loc3;
    public float hp = 100f;
    public float pos = 0.000468202598f;
    public float scale = 0.00093f;
    private GameObject score;
    private bool dam1 = false;
    private bool dam2 = false;

    private void Start()
    {
        score = GameObject.Find("score");
        if (score != null)
        {
            score.GetComponent<Scoring>().startTimer();
        }
    }

    void Update()
    {
        hpbar.GetComponent<RectTransform>().anchoredPosition3D =
            new Vector3(-0.0465f + (hp * pos),
            hpbar.GetComponent<RectTransform>().anchoredPosition3D.y,
            hpbar.GetComponent<RectTransform>().anchoredPosition3D.z);
        hpbar.transform.localScale = new Vector3(hp * scale, hpbar.transform.localScale.y, hpbar.transform.localScale.z);
    }

    public void Damage()
    {
        hp -= 10f;
        if (hp <= 0) lose();
        else if (hp <= 35 && !dam2) smoke2();
        else if (hp <= 65 && !dam1) smoke1();
    }

    void lose()
    {
        if (score != null)
        {
            score.GetComponent<Scoring>().stopTimer();
            score.GetComponent<Scoring>().scoreTime = true;
            SceneManager.LoadScene("MenuScene");
        }
    }

    void smoke1()
    {
        GameObject temp = Instantiate(particles, loc1.transform.position, loc1.transform.rotation);
            temp.transform.localScale = new Vector3(0.18643f, 0.18643f, 0.18643f);
        temp.transform.parent = transform;
        dam1 = true;
    }

    void smoke2()
    {
        GameObject temp = Instantiate(particles, loc2.transform.position, loc2.transform.rotation);
        temp.transform.localScale = new Vector3(0.18643f, 0.18643f, 0.18643f);
        temp.transform.parent = transform;
        temp = Instantiate(particles, loc3.transform.position, loc3.transform.rotation);
        temp.transform.localScale = new Vector3(0.18643f, 0.18643f, 0.18643f);
        temp.transform.parent = transform;
        dam2 = true;
    }

}
