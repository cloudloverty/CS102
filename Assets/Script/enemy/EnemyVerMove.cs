using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVerMove : MonoBehaviour
{
    public float moveSpeed = 3f;
    Vector3 originalPos;
    bool MoveUp = false;
    public GameObject TrailObject;
    public bool threeHead = false;
    public bool bleeding = false;

    //yuy
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
        float currentY = this.transform.position.y;
        if (MoveUp)
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
            if (threeHead) { this.gameObject.GetComponent<SpriteRenderer>().sprite = GameObject.FindWithTag("enemyThreeHeadBack").GetComponent<SpriteRenderer>().sprite; }
            else if (bleeding) { this.gameObject.GetComponent<SpriteRenderer>().sprite = GameObject.FindWithTag("enemyHorrorBack").GetComponent<SpriteRenderer>().sprite; }
            else { this.gameObject.GetComponent<SpriteRenderer>().sprite = GameObject.FindWithTag("enemyBack").GetComponent<SpriteRenderer>().sprite; }
            
        }
        else
        {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
            if (threeHead) { this.gameObject.GetComponent<SpriteRenderer>().sprite = GameObject.FindWithTag("enemyThreeHeadFront").GetComponent<SpriteRenderer>().sprite; }
            else if (bleeding) { this.gameObject.GetComponent<SpriteRenderer>().sprite = GameObject.FindWithTag("enemyHorrorFront").GetComponent<SpriteRenderer>().sprite; }
            else { this.gameObject.GetComponent<SpriteRenderer>().sprite = GameObject.FindWithTag("enemyFront").GetComponent<SpriteRenderer>().sprite; }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("border"))
        {
            MoveUp = !MoveUp;
        }
    }

    public void FreezeEnemyV()
    {
        moveSpeed = 0f;
    }

}
