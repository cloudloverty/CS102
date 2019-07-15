using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHorMove : MonoBehaviour
{
    public float moveSpeed = 3f;
    Vector3 originalPos;
    Vector3 originalScale;
    bool MoveRight = false;
    public GameObject TrailObject;
    public bool bleeding = false;


    // Start is called before the first frame update
    void Start()
    {
        this.originalPos = this.transform.position;
        this.originalScale = this.transform.localScale;
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
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            if (bleeding) { transform.localScale = new Vector3(-originalScale.x, originalScale.y, originalScale.z); }
            else { transform.localScale = new Vector3(-originalScale.x, originalScale.y, originalScale.z); }
        }
        else
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            if (bleeding) { transform.localScale = new Vector3(originalScale.x, originalScale.y, originalScale.z); }
            else { transform.localScale = new Vector3(originalScale.x, originalScale.y, originalScale.z); }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("border"))
        {
            MoveRight = !MoveRight;
        }
    }

    public void FreezeEnemyH()
    {
        moveSpeed = 0f;
    }

}
