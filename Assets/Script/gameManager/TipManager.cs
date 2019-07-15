using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipManager : MonoBehaviour
{
    private Text TipTx;
    private GameObject TipUI;

    // Start is called before the first frame update
    void Start()
    {
        TipTx = GameObject.Find("TipUI").transform.Find("Tip").GetComponent<Text>();
        TipUI = transform.parent.gameObject;
        TipTurnLeft();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TipTurnLeft()
    {
        StartCoroutine("TipTurnLeftCor");
        
    }
    IEnumerator TipTurnLeftCor()
    {
        TipTx.text = "turn_left를 3개를 모으세요! \n1개: 왼쪽 방향키 사용 가능 \n2개: 아래쪽 방향키 사용 가능\n3개: 오른쪽 방향키 사용 가능";
        yield return new WaitForSeconds(7f);
        TipTx.text = "";
        TipUI.SetActive(false);
    }

    public void TipKey()
    {
        StartCoroutine("TipKeyCor");

    }
    IEnumerator TipKeyCor()
    {
        TipTx.text = "문을 열기 위해서는 \n그 색깔에 맞는 키가 필요합니다";
        yield return new WaitForSeconds(5f);
        TipTx.text = "";
        TipUI.SetActive(false);
    }

    public void TipBeeper()
    {
        StartCoroutine("TipBeeperCor");

    }
    IEnumerator TipBeeperCor()
    {
        TipTx.text = "W를 눌러 \n부스터 아이템을 사용해보세요";
        yield return new WaitForSeconds(3f);
        TipTx.text = "";
        TipUI.SetActive(false);
    }

    public void TipMoveHubo()
    {
        StartCoroutine("TipMoveHuboCor");

    }
    IEnumerator TipMoveHuboCor()
    {
        TipTx.text = "휴보에게 맞서는 것은 \n좋은 생각이 아닙니다";
        yield return new WaitForSeconds(3f);
        TipTx.text = "";
        TipUI.SetActive(false);
    }

    public void TipBigCamera()
    {
        StartCoroutine("TipBigCameraCor");

    }
    IEnumerator TipBigCameraCor()
    {
        TipTx.text = "Q를 눌러 \n빅-피처 아이템을 사용해보세요";
        yield return new WaitForSeconds(3f);
        TipTx.text = "";
        TipUI.SetActive(false);
    }

    public void TipObserveHubo()
    {
        StartCoroutine("TipObserveHuboCor");

    }
    IEnumerator TipObserveHuboCor()
    {
        TipTx.text = "감시 모드 휴보의 \n시야에서 벗어나세요";
        yield return new WaitForSeconds(3f);
        TipTx.text = "";
        TipUI.SetActive(false);
    }

    public void TipTransparent()
    {
        StartCoroutine("TipTransparentCor");

    }
    IEnumerator TipTransparentCor()
    {
        TipTx.text = "E를 눌러 \n투명망토 아이템을 사용해보세요";
        yield return new WaitForSeconds(3f);
        TipTx.text = "";
        TipUI.SetActive(false);
    }

    public void TipTime()
    {
        StartCoroutine("TipTimeCor");

    }
    IEnumerator TipTimeCor()
    {
        TipTx.text = "좌측 상단에 \n남은 시간에 유의하세요!\n과제 듀는 여러분을 기다려주지 않습니다";
        yield return new WaitForSeconds(4f);
        TipTx.text = "";
        TipUI.SetActive(false);
    }
}


/*
 BigCameraItemsTx = GameObject.Find("ItemUI").transform.Find("BigCameraItems").GetComponent<Text>();
 BigCameraItemsTx.text = "빅-피처(Q): 0";
 */
