using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Rightmove : MonoBehaviour
{

    public int bossHP = 2;
    public ParticleSystem dead;
    public Transform walter;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float downward = 0 * Time.deltaTime;

        downward = -1 * Time.deltaTime;

        downward += transform.position.z;

        this.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, downward);

        if (bossHP <= 0)
        {
            Instantiate(dead, walter.position, walter.rotation);
            Destroy(this.gameObject);
        }
    }

    void OnCollisionStay(Collision col)
    {
        float downward2 = 1 * Time.deltaTime;
        float horizontal = 1 * Time.deltaTime;

        if (col.gameObject.name == "Floor")
        {
            horizontal = transform.position.x - horizontal;
            downward2 += transform.position.z;

            this.gameObject.transform.position = new Vector3(horizontal, transform.position.y, downward2);
        }


        if (col.gameObject.name == "Midfloor")
        {
            horizontal += transform.position.x;
            downward2 += transform.position.z;

            this.gameObject.transform.position = new Vector3(horizontal, transform.position.y, downward2);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tower" && this.tag == "Boss")
        {
            Destroy(other.gameObject);
            bossHP -= 1;
        }
    }
}