using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public Transform tower;
    public Transform bullet;

    public float rate = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rate += Time.deltaTime;

        if (rate >= 4)
        {
            Instantiate(bullet, tower.position, tower.rotation, bullet);
            rate = 0;
        }
    }
}
