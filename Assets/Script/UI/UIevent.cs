using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIevent : MonoBehaviour
{
    private GameObject normalPanel;
    //private GameObject overPanel;

    void Awake()
    {
        Debug.Log("UIevent");
        normalPanel = GameObject.Find("Time").gameObject;
        //overPanel = GameObject.Find("OverUI").gameObject;
        Debug.Log(normalPanel.name);
        //Debug.Log(overPanel.name);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RetryBt()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Stage0");
        Debug.Log("retry" + Time.timeScale);
    }

    public void SetGameOverUI()
    {
        GameObject overPanel = GameObject.Find("Canvas").transform.Find("OverUI").gameObject;
        Debug.Log("SetGameOverUI");
        //normalPanel.SetActive(false);
        overPanel.SetActive(true);
    }

    public void SetTimeOutUI()
    {
        GameObject overPanel = GameObject.Find("Canvas").transform.Find("OverUI").gameObject;
        Debug.Log("SetTimeOutUI");
        Text errorText;
        errorText = GameObject.Find("Canvas").transform.Find("OverUI").transform.Find("GameOverTx").GetComponent<Text>();
        errorText.text = "TimeOutError";
        //normalPanel.SetActive(false);
        overPanel.SetActive(true);
    }


    public void NextStagetUI()
    {
        GameObject overPanel = GameObject.Find("Canvas").transform.Find("OverUI").gameObject;
        Debug.Log("NextStageUI");
        Text errorText;
        errorText = GameObject.Find("Canvas").transform.Find("OverUI").transform.Find("GameOverTx").GetComponent<Text>();
        //normalPanel.SetActive(false);
        overPanel.SetActive(true);
    }

}
