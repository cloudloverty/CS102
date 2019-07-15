using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class huboHead : MonoBehaviour
{
    GameObject sideHead;
    // Start is called before the first frame update
    void Start()
    {
        sideHead = gameObject.transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("HeadChange");

    }

    IEnumerator HeadChange()
    {
        while (true) {
            sideHead.SetActive(false);
            yield return new WaitForSeconds(4f);
            sideHead.SetActive(true);
            yield return new WaitForSeconds(4f);
        }

    }


}
