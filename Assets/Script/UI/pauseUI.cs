using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void resume()
    {
        Time.timeScale = 1;
        GameObject.Find("Canvas").transform.Find("Pause").gameObject.SetActive(false);
    }

    public void quit()
    {
        SceneManager.LoadScene("StartScene");
    }
}
