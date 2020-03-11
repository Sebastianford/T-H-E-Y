using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    public int HP = 7;

    public bool canmove = true;
    public bool cancollide = true;



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


        if (HP <= 0)
            Destroy(this.gameObject);

        if (Input.GetMouseButtonUp(0))
        {
            cancollide = true;
        }
    }

    void OnCollisionStay(Collision col)
    {
        float downward = 1 * Time.deltaTime;


        if (col.gameObject.name == "Floor" || col.gameObject.name == "Midfloor" || col.gameObject.name == "Tower")
        {
            if (cancollide == true)
            {
                downward += transform.position.z;

                this.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, downward);

                canmove = false;
            }
        }

        if (col.gameObject.name == "Spawn")
        {
            downward += transform.position.z;

            this.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, downward);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(other.transform.parent.gameObject);
            HP -= 1;
        }
    }

    void OnMouseDrag()
    {
        if ( canmove == true)
        {
            cancollide = false;

            float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

            Vector3 pos_move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));

            transform.position = new Vector3(pos_move.x, transform.position.y, pos_move.z);
        }
    }

}
