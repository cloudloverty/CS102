﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawRotateRight : MonoBehaviour
{
    public float anticlockSpeed = 800f;
    public float clockSpeed = 150f;
    Vector3 originalPos;

    // Start is called before the first frame update
    void Start()
    {
        this.originalPos = this.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        moveControl();
    }

    void moveControl()
    {
        if (!gameObject.transform.parent.GetComponent<SawHorMoveToRight>().isMoveRight()) //slow rotation
        {
            transform.Rotate(Vector3.forward * clockSpeed * Time.deltaTime);

        }
        else
        {
            transform.Rotate(Vector3.back * anticlockSpeed * Time.deltaTime);
        }
    }

}
