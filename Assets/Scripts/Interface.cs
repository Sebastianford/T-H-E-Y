using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    public int HP = 20;
    public Text Hit;

    // Start is called before the first frame update
    void Start()
    {
        health();
    }

    // Update is called once per frame
    void Update()
    {
        health();
    }

    void health()
    {
        Hit.text = HP.ToString();
    }
}
