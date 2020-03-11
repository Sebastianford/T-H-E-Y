using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bases : MonoBehaviour
{

    public int HP = 20;
    public int cash = 10;
    public int time = 100;
    public float timecount = 0;
    public float cashcount = 0;
    public Text Hit;
    public Text Money;
    public Text Timing;
    public Transform towerspawn;
    public Transform wall;
    public Transform shooter;
    public KeyCode shoot;
    public KeyCode stall;
    public AudioSource amp;
    public AudioClip dreamscape;
    public AudioClip spawned;


    // Start is called before the first frame update
    void Start()
    {
        health();
        funds();
        timetogo();
    }

    // Update is called once per frame
    void Update()
    {
        funds();

        timecount += Time.deltaTime;
        cashcount += Time.deltaTime;

        if (timecount >= 1)
        {
            timecount = 0;
            time -= 1;
            timetogo();
        }

        if(cashcount >= 5)
        {
            cash += 2;
            cashcount = 0;
            funds();
        }

        if (Input.GetKeyDown(stall) && cash >= 3)
        {
            cash -= 3;
            funds();
            Instantiate(wall, towerspawn.position, towerspawn.rotation);
        }

        if (Input.GetKeyDown(shoot) && cash >= 9)
        {
            cash -= 9;
            funds();
            Instantiate(shooter, towerspawn.position, towerspawn.rotation);
        }

        if (HP <= 0)
        {
            SceneManager.LoadScene("Death");
        }

        if (time <= 0)
        {
            SceneManager.LoadScene("Victory");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(other.transform.parent.gameObject);

            HP = HP - 1;
            health();
        }

        if (other.tag == "Boss")
        {
            Destroy(other.gameObject);
            Destroy(other.transform.parent.gameObject);

            HP = HP - 2;
            health();
        }

        if (other.tag == "Tower")
        {
            Destroy(other.gameObject);
            Destroy(other.transform.parent.gameObject);
        }
    }

    void health()
    {
        Hit.text = HP.ToString();
    }

    void funds()
    {
        Money.text = cash.ToString();
    }

    void timetogo()
    {
        Timing.text = time.ToString();
    }
}
