using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingScene : MonoBehaviour
{
    int lines;
    private Text Txt;
    GameObject nupjuk;
    Animator nMove;

    // Start is called before the first frame update
    void Start()
    {
        lines = 0;
        Txt = GameObject.Find("Canvas").transform.Find("Text").GetComponent<Text>();
        nupjuk = GameObject.Find("nupjuk_nb");
        nMove = GameObject.Find("nupjuk_nb").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextButton()
    {
        if (lines == 0)
        {
            GameObject.FindWithTag("Enemy").SetActive(false);
            GameObject.FindWithTag("Enemy").SetActive(false);
            GameObject.FindWithTag("Enemy").SetActive(false);
            Txt.text = "만점토끼는 그 대가로 넙죽이의 과제를 끝내주었고";
        }
        if (lines == 1)
        {
            Vector3 p = new Vector3(-1, 0.6f, 0);
            GameObject.Find("rabbit_happy_nb").transform.position = p;
            Txt.text = "만점토끼는 그 대가로 넙죽이의 과제를 끝내주었고";
        }
        if (lines == 2)
        {
            Txt.text = "넙죽이는 프밍기의 첫번째 과제를 무사히 끝낼 수 있었습니다. ";
            StartCoroutine("moveNupjuk");
        }
        if (lines == 3)
        {
            Txt.text = "하지만 프밍기 첫번째 과제를 만점토끼에게 맡겨버린 결과";
        }
        if (lines == 4)
        {
            Txt.text = "넙죽이는 중간고사를 망하게 되고";
            nupjuk.GetComponent<SpriteRenderer>().sprite = GameObject.Find("nupjuk_surprise").GetComponent<SpriteRenderer>().sprite;

        }
        if (lines == 5)
        {
            Txt.text = "다음해 재수강을 하게 되었습니다. ";
            nupjuk.GetComponent<SpriteRenderer>().sprite = GameObject.Find("nupjuk_sad").GetComponent<SpriteRenderer>().sprite;
        }
        if (lines == 6)
        {
            nMove.SetTrigger("mad");
            Txt.text = "내년에 다시만나요~";
        }
        if (lines == 7)
        {
            SceneManager.LoadScene("StartScene");
        }

        lines++;
    }

    IEnumerator moveNupjuk()
    {

        Vector3 origin = GameObject.Find("nupjuk_nb").transform.position;
        nupjuk.transform.position = new Vector3(-5, 1, 0);
        yield return new WaitForSeconds(0.2f);
        nupjuk.transform.position = origin;
        yield return new WaitForSeconds(0.2f);
        nupjuk.transform.position = new Vector3(-5, 1, 0);
        yield return new WaitForSeconds(0.2f);
        nupjuk.transform.position = origin;
    }
}
