using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadEve : MonoBehaviour
{
    public float moveSpeed = 1f;
    Vector3 originalPos;
    bool MoveRight = false;
    bool met = false;


    // Start is called before the first frame update
    void Start()
    {
        this.originalPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        moveControl();
        if (met) transform.localScale = new Vector3(0.5f, 0.5f, 1);
    }

    void moveControl()
    {
        if (MoveRight)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("border"))
        {
            if (MoveRight == false)
            {
                MoveRight = true;
                transform.localScale = new Vector3(-0.2f, 0.24f, 1);
            }
            else
            {
                MoveRight = false;
                transform.localScale = new Vector3(0.2f, 0.24f, 1);
            }
        }
    }


    public void changeEve()
    {
        Debug.Log("change");
        moveSpeed = 0;
        this.transform.position = originalPos;
        //this.gameObject.SetActive(false);
        //GameObject.FindWithTag("Eve").SetActive(true);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = GameObject.FindWithTag("Eve").GetComponent<SpriteRenderer>().sprite;
        //this.transform.localScale = new Vector3(3, 3, 3);
        met = true;
    }

}