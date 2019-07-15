using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    private Text timer;
    public int timeLeft = 60;
    bool timeUp = false;
    private AudioSource overAudio;
    public AudioClip over;

    private void Awake()
    {
        timer = GameObject.Find("Time").GetComponent<Text>();
        timer.text = " Time Left\n " + timeLeft + "s";
        StartCoroutine("PlusScoreRoutine");
    }


    public void PlusScore(int plusPoint)
    {
        timeLeft -= plusPoint;
        timer.text = " Time Left\n " + timeLeft.ToString() + "s";
    }


    IEnumerator PlusScoreRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            PlusScore(1);
        }
    }

    // Start is called before the first frame update
    void Start()
    {


        this.overAudio = this.gameObject.AddComponent<AudioSource>();
        this.overAudio.clip = this.over;
        this.overAudio.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft < 0 && !timeUp)
        {
            timeUp = true;
            StopAllCoroutines();
            Time.timeScale = 0;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
            GameObject.Find("Canvas").transform.Find("OverUI").GetComponent<UIevent>().SetTimeOutUI();
            overAudio.Play();
        }
    }
}
