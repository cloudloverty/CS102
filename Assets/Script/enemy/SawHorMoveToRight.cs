using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawHorMoveToRight : MonoBehaviour
{
    public float attackSpeed = 8f;
    public float chargeSpeed = 1.5f;
    Vector3 originalPos;
    bool MoveRight = false;

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
        if (MoveRight)
        {
            transform.Translate(Vector3.right * attackSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * chargeSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("border"))
        {
            if (MoveRight == false) { MoveRight = true; } else { MoveRight = false; }
        }
    }

    public bool isMoveRight()
    {
        return MoveRight;
    }

}
