using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Border : MonoBehaviour
{
    public GameObject obj;
    Transform obsTf;
    float border;

    private void Awake()
    {
        obsTf = transform;
    }

    public void SetObstacle(int lv)
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {/*
        if (collision.CompareTag("Player"))
        {
            
            if (speed > border)
            {
                obj.SetActive(false);
                
            }
        }
        Debug.Log("collision");*/
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    internal void SetObstacle(object p)
    {
        throw new NotImplementedException();
    }
}
