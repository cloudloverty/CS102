using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startButton()
    {
        SceneManager.LoadScene("Story");
    }
    

    public void AboutButton()
    {
        GameObject.Find("Panel").transform.GetChild(4).gameObject.SetActive(true);
    }

    public void AboutClose()
    {
        GameObject.Find("Panel").transform.GetChild(4).gameObject.SetActive(false);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
