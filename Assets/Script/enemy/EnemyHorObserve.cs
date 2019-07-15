using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHorObserve : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float observeTime = 3f;
    Vector3 originalPos;
    Vector3 originalLocalScale;
    GameObject view;
    public bool SeeRight = false;
    bool chasing = false;
    bool returning = false;
    public bool bothDirection = true;
    private AudioSource stompAudio;
    public AudioClip stomp;


    // Start is called before the first frame update
    void Start()
    {
        this.originalPos = this.transform.position;
        this.originalLocalScale = this.transform.localScale;
        view = transform.GetChild(0).gameObject;

        this.stompAudio = this.gameObject.AddComponent<AudioSource>();
        this.stompAudio.clip = this.stomp;
        this.stompAudio.loop = false;
        this.stompAudio.volume = 0.5f;

    }

    // Update is called once per frame
    void Update()
    {
        if (returning){
            transform.position = Vector3.MoveTowards(transform.position, originalPos, moveSpeed * Time.deltaTime);
            if (transform.position == originalPos) {
                returning = false;
                view.SetActive(true);
            }
        } else if (!chasing && bothDirection) {
            StartCoroutine("ChangeView");
        } else if (chasing) {
            if (SeeRight) {
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            } else {
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            }
        }
    }

    IEnumerator ChangeView()
    {
        if (SeeRight)
        {
            transform.localScale = new Vector3(-this.originalLocalScale.x, this.originalLocalScale.y, this.originalLocalScale.z);
            yield return new WaitForSeconds(observeTime);
            SeeRight = false;
        } else
        {
            transform.localScale = new Vector3(this.originalLocalScale.x, this.originalLocalScale.y, this.originalLocalScale.z);
            yield return new WaitForSeconds(observeTime);
            SeeRight = true;
        }
    }


    public void ChaseEnd()
    {
        chasing = false;
        returning = true;
        view.SetActive(false);
        stompAudio.Stop();
    }

    public void ChaseStart()
    {
        if (!chasing)
        {
            chasing = true;
            stompAudio.Play();
        }
    }

}
