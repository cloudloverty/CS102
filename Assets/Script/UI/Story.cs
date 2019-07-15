using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Story : MonoBehaviour
{
    int lines;
    Animator nupjuk;
    Animator scene;
    private Text Txt;
    Text button;

    // Start is called before the first frame update
    void Start()
    {
        lines = 0;
        nupjuk = GameObject.Find("nupjuk_nb").GetComponent<Animator>();
        scene = GameObject.Find("all_wrong").GetComponent<Animator>();
        Txt = GameObject.Find("Canvas").transform.Find("Text").GetComponent<Text>();
        button = GameObject.Find("Button").transform.Find("Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextButton()
    {
        if (lines % 2 == 0)
        {
            scene.SetTrigger("calm");
        }
        else
        {
            scene.SetTrigger("mad");
        }

        if (lines % 4 < 2 )
        {
            nupjuk.SetTrigger("cool_down");
            Debug.Log("cool nupjuk");
        }
        else
        {
            nupjuk.SetTrigger("mad");
            Debug.Log("mad nupjuk");

        }
            Debug.Log("lines " + lines);
        if (lines == 0)
        {
            Txt.text = "이정도 했으면 제발 좀 돌아가라고";
        }

        if (lines == 1)
        {
            Txt.text = "하 OO 한번 해보자는거지?";
        }

        if (lines == 2)
        {
            Txt.text = "아니, 잠깐만. 이게뭐야";
        }
        if (lines == 3)
        {
            Txt.text = "전산과 교수님들이...";
        }
        if (lines == 4)
        {
            Txt.text = "교수님들이, 만점토끼를 납치해서 만점이 안나오는거라고??";
        }
        if (lines == 5)
        {
            Txt.text = "과제 듀가 3시간 남았는데?";
        }
        if (lines == 6)
        {
            Txt.text = "휴보가 만점토끼를 지키고 있다고 하니까 빨리 구해서 과제좀 끝내자";
            button.text = "Start";
        }

        if (lines == 7)
        {
            SceneManager.LoadScene("Stage0");
        }


        lines++;
    }
}
