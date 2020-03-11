using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public float leftspawncount = 0;
    public float rightspawncount = -3;
    public float deathcount = 0;

    public Transform left;
    public Transform right;
    public Transform leftboss;
    public Transform rightboss;
    public Transform leftspawn;
    public Transform rightspawn;

    public int bosses = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        leftspawncount += Time.deltaTime;
        rightspawncount += Time.deltaTime;


        if (leftspawncount >= 5)
        {
            Instantiate(left, leftspawn.position, leftspawn.rotation);
            leftspawncount = 0;
            bosses++;

        }

        if (rightspawncount >= 5)
        {
            Instantiate(right, rightspawn.position, rightspawn.rotation);
            rightspawncount = 0;
            bosses++;
        }

        if (bosses >= 25)
        {
            deathcount += Time.deltaTime;

            if (deathcount >= 8)
            {
                Instantiate(leftboss, leftspawn.position, leftspawn.rotation);
            }

            if (deathcount >= 8)
            {
                Instantiate(rightboss, rightspawn.position, rightspawn.rotation);
                deathcount = 0;
            }
        }
    }
}
