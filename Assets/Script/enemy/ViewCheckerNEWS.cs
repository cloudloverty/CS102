using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewCheckerNEWS : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player") && !GameObject.FindWithTag("Player").GetComponent<PlayerAction>().transparent) {
            Debug.Log("Gottha");
            transform.parent.gameObject.GetComponent<EnemyNEWSObserve>().ChaseStart();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player") && GameObject.FindWithTag("Player").GetComponent<PlayerAction>().transparent)
        {
            Debug.Log("Gottha");
            transform.parent.gameObject.GetComponent<EnemyNEWSObserve>().ChaseEnd();
        }
        if (collision.gameObject.tag.Equals("Player") && !GameObject.FindWithTag("Player").GetComponent<PlayerAction>().transparent)
        {
            Debug.Log("Gottha");
            transform.parent.gameObject.GetComponent<EnemyNEWSObserve>().ChaseStart();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Gottha");
            transform.parent.gameObject.GetComponent<EnemyNEWSObserve>().ChaseEnd();
        }
    }

}
