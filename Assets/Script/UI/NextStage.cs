using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextStage : MonoBehaviour
{
    //private GameObject overPanel;
    public int lvl = 0;

    void Awake()
    {
        GameObject normalPanel;
        Debug.Log("UIevent");
        normalPanel = GameObject.Find("Time").gameObject;
        Debug.Log(normalPanel.name);
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
        SceneManager.LoadScene("Stage" + lvl);
    }

    public void NextStageBt()
    {
        Time.timeScale = 1.0f;
        int next = lvl + 1;
        SceneManager.LoadScene("Stage" + next);
    }


    public void NextStageUI()
    {
        GameObject overPanel = GameObject.Find("Canvas").transform.Find("NextStageUI").gameObject;
        Debug.Log("NextStageUI");
        Text errorText;
        errorText = GameObject.Find("Canvas").transform.Find("NextStageUI").transform.Find("NextStageTx").GetComponent<Text>();
        errorText.text = "Stage " + lvl + "\nclear";
        overPanel.SetActive(true);
    }

}
