using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    private Text SpeedUpItemsTx;
    private Text BigCameraItemsTx;
    private Text TransparentItemsTx;
    public int CameraItems = 0;
    public int SpeedItems = 0;
    public int TransparentItems = 0;
    GameObject overPanel;
    private AudioSource wrongAudio;
    public AudioClip wrong;

    private void Awake()
    {
        BigCameraItemsTx = GameObject.Find("ItemUI").transform.Find("BigCameraItems").GetComponent<Text>();
        BigCameraItemsTx.text = "빅-피처(Q): 0";
        SpeedUpItemsTx = GameObject.Find("ItemUI").transform.Find("SpeedUpItems").GetComponent<Text>();
        SpeedUpItemsTx.text = "부스터(W): 0";
        TransparentItemsTx = GameObject.Find("ItemUI").transform.Find("TransparentItems").GetComponent<Text>();
        TransparentItemsTx.text = "투명망토(E): 0";
        
    }

    public void PlusBigCameraItems()
    {
        CameraItems += 1;
        BigCameraItemsTx.text = "빅-피처(Q): " + CameraItems.ToString();
    }

    public void PlusSpeedUpItem()
    {
        SpeedItems += 1;
        SpeedUpItemsTx.text = "부스터(W): " + SpeedItems.ToString();
    }

    public void PlusTransparentItem()
    {
        TransparentItems += 1;
        TransparentItemsTx.text = "투명망토(E): " + TransparentItems.ToString();
    }

    public void UseBigCameraItem()
    {
        if (CameraItems > 0)
        {
            CameraItems -= 1;
            BigCameraItemsTx.text = "빅-피처(Q): " + CameraItems.ToString();
            GameObject.Find("Main Camera").GetComponent<CameraMove>().WideCamera();
        }
        else
        {
            wrongAudio.Play();
            overPanel = GameObject.Find("Canvas").transform.Find("Errors").gameObject;
            StartCoroutine("cameraError");
        }
    }

    IEnumerator cameraError()
    {
        overPanel.SetActive(true);
        yield return new WaitForSeconds(2f);
        GameObject.Find("wallE").GetComponent<PlayerAction>().CameraFlag();
        overPanel.SetActive(false);
    }

    public void UseSpeedUpItem()
    {
        if (SpeedItems > 0)
        {
            SpeedItems -= 1;
            SpeedUpItemsTx.text = "부스터(W): " + SpeedItems.ToString();
            GameObject.Find("wallE").GetComponent<PlayerAction>().SpeedUp();
        }
        else
        {
            wrongAudio.Play();
            overPanel = GameObject.Find("Canvas").transform.Find("Errors").gameObject;
            Debug.Log("speedup");
            //Text text = GameObject.Find("Canvas").transform.Find("Errors").transform.Find("Text").GetComponent<Text>();
            StartCoroutine("showPanel");
        }
    }
    IEnumerator showPanel()
    {
        overPanel.SetActive(true);
        yield return new WaitForSeconds(2f);
        //GameObject.Find("wallE").GetComponent<PlayerAction>().CameraFlag();
        overPanel.SetActive(false);
    }

    public void UseTransparentItem()
    {
        if (TransparentItems > 0)
        {
            TransparentItems -= 1;
            TransparentItemsTx.text = "투명망토(E): " + TransparentItems.ToString();
            GameObject.Find("wallE").GetComponent<PlayerAction>().Invisible();
        }
        else
        {
            wrongAudio.Play();
            overPanel = GameObject.Find("Canvas").transform.Find("Errors").gameObject;
            Debug.Log("transparent");
            //Text text = GameObject.Find("Canvas").transform.Find("Errors").transform.Find("Text").GetComponent<Text>();
            StartCoroutine("showPanel");
        }
    }

    // Start is called before the first frame update
    void Start()
    {


        this.wrongAudio = this.gameObject.AddComponent<AudioSource>();
        this.wrongAudio.clip = this.wrong;
        this.wrongAudio.loop = false;
        this.wrongAudio.volume = 0.6f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
