using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Camera m_OrthographicCamera;
    public GameObject player;
    public float CameraSpeed = 2;
    Transform AT;

    private AudioSource zoomInAudio;
    public AudioClip zoomIn;
    private AudioSource zoomOutAudio;
    public AudioClip zoomOut;


    private void LateUpdate()
    {
        //transform.position = new Vector3(AT.position.x, AT.position.y, AT.position.z - 10f);
    }

    // Start is called before the first frame update
    void Start()
    {
        //AT = player.transform;
        this.zoomInAudio = this.gameObject.AddComponent<AudioSource>();
        this.zoomInAudio.clip = this.zoomIn;
        this.zoomInAudio.loop = false;

        this.zoomOutAudio = this.gameObject.AddComponent<AudioSource>();
        this.zoomOutAudio.clip = this.zoomOut;
        this.zoomOutAudio.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        Camera.main.transform.position = player.transform.position - Vector3.forward;
    }

    public void WideCamera()
    {
        StartCoroutine("WideCameraCor");
    }

    IEnumerator WideCameraCor()
    {
        float elapsed = 0;
        zoomInAudio.Play();
        while (elapsed <= 0.6f)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / 0.6f);
            m_OrthographicCamera.orthographicSize = Mathf.Lerp(2f, 5f, t);
            yield return null;
        }

        yield return new WaitForSeconds(7);

        elapsed = 0;
        zoomOutAudio.Play();
        while (elapsed <= 0.6f)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / 0.6f);
            m_OrthographicCamera.orthographicSize = Mathf.Lerp(5f, 2f, t);
            yield return null;
        }
        GameObject.Find("wallE").GetComponent<PlayerAction>().CameraFlag();
    }
}
