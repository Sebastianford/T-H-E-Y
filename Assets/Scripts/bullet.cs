using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float up = 0 * Time.deltaTime;

        up = 1 * Time.deltaTime;

        up += transform.position.z;

        this.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, up);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(other.transform.parent.gameObject);
            Destroy(this.gameObject);
        }

        if (other.tag == "Boss" || other.tag == "Floor" || other.tag == "Midfloor" || other.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }
}
