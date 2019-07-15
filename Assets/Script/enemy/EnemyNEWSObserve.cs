using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNEWSObserve : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float observeTime = 3f;
    Vector3 originalPos;
    Vector3 originalLocalScale;
    GameObject viewVer;
    GameObject viewHor;
    bool chasing = false;
    bool returning = false;
    public bool SeeUp = false;
    public bool SeeDown = false;
    public bool SeeRight = false;
    public bool SeeLeft = false;
    private AudioSource stompAudio;
    public AudioClip stomp;



    // Start is called before the first frame update
    void Start()
    {
        this.originalPos = this.transform.position;
        this.originalLocalScale = this.transform.localScale;
        viewVer = transform.GetChild(0).gameObject;
        viewHor = transform.GetChild(1).gameObject;

        this.stompAudio = this.gameObject.AddComponent<AudioSource>();
        this.stompAudio.clip = this.stomp;
        this.stompAudio.loop = false;
        this.stompAudio.volume = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (returning)
        {
            transform.position = Vector3.MoveTowards(transform.position, originalPos, moveSpeed * Time.deltaTime);
            if (transform.position == originalPos)
            {
                returning = false;
                viewVer.SetActive(true);
            }
        }
        else if (!chasing)
        {
            StartCoroutine("ChangeView");
        }
        else if (chasing)
        {
            if (SeeUp)
            {
                transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
            }
            else if (SeeRight)
            {
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            }
            else if (SeeDown)
            {
                transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
            }
            else if (SeeLeft)
            {
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            }
        }
    }

    IEnumerator ChangeView()
    {
        if (SeeUp)
        {
            transform.localScale = new Vector3(this.originalLocalScale.x, -this.originalLocalScale.y, this.originalLocalScale.z);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = GameObject.FindWithTag("enemyBackFlipped").GetComponent<SpriteRenderer>().sprite;
            viewHor.SetActive(false);
            viewVer.SetActive(true);
            yield return new WaitForSeconds(observeTime);
            SeeUp = false;
            SeeRight = true;
        }
        else if (SeeRight)
        {
            transform.localScale = new Vector3(-this.originalLocalScale.x, this.originalLocalScale.y, this.originalLocalScale.z);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = GameObject.FindWithTag("enemySideLeft").GetComponent<SpriteRenderer>().sprite;
            viewVer.SetActive(false);
            viewHor.SetActive(true);
            yield return new WaitForSeconds(observeTime);
            SeeRight = false;
            SeeDown = true;
        }
        else if (SeeDown)
        {
            transform.localScale = new Vector3(this.originalLocalScale.x, this.originalLocalScale.y, this.originalLocalScale.z);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = GameObject.FindWithTag("enemyFront").GetComponent<SpriteRenderer>().sprite;
            viewHor.SetActive(false);
            viewVer.SetActive(true);
            yield return new WaitForSeconds(observeTime);
            SeeDown = false;
            SeeLeft = true;
        }
        else if (SeeLeft)
        {
            transform.localScale = new Vector3(this.originalLocalScale.x, this.originalLocalScale.y, this.originalLocalScale.z);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = GameObject.FindWithTag("enemySideLeft").GetComponent<SpriteRenderer>().sprite;
            viewVer.SetActive(false);
            viewHor.SetActive(true);
            yield return new WaitForSeconds(observeTime);
            SeeLeft = false;
            SeeUp = true;
        }

    }

    public void ChaseEnd()
    {
        stompAudio.Stop();
        chasing = false;
        returning = true;
        viewVer.SetActive(false);
    }

    public void ChaseStart()
    {
        if (!chasing)
        {
            stompAudio.Play();
            chasing = true;
        }
    }

}