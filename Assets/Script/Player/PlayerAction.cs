using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAction : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;
    private float rotationSpeed = 200f;  
    private Vector3 direction;
    private Vector3 rotation;
    bool keyed = false;
    bool subkey = false;
    bool errored = false;
    public bool pills = false;
    public bool tutorial = false;

    private AudioSource itemAudio;
    public AudioClip itemSound;
    private AudioSource coinAudio;
    public AudioClip coin;
    private AudioSource doorAudio;
    public AudioClip door;
    private AudioSource bumpAudio;
    public AudioClip bump;
    private AudioSource speedUpAudio;
    public AudioClip speedUp;
    private AudioSource invisibleAudio;
    public AudioClip invisible;
    private AudioSource successAudio;
    public AudioClip success;
    private AudioSource overAudio;
    public AudioClip over;

    ////////////Item////////////
    public int left = 0;
    public bool usingSpeedUpItem = false;
    public bool usingBigCameraItem = false;
    public bool usingTransparentItem = false;
    public bool transparent = false;


    /////////////Etc////////////
    GameObject TipUI;

    // Start is called before the first frame update
    void Start()
    {
        if (tutorial) { TipUI = GameObject.Find("Canvas").transform.Find("TipUI").gameObject; }
        this.itemAudio = this.gameObject.AddComponent<AudioSource>();
        this.itemAudio.clip = this.itemSound;
        this.itemAudio.loop = false;
        this.itemAudio.volume = 0.5f;

        this.coinAudio = this.gameObject.AddComponent<AudioSource>();
        this.coinAudio.clip = this.coin;
        this.coinAudio.loop = false;
        this.coinAudio.volume = 0.5f;

        this.doorAudio = this.gameObject.AddComponent<AudioSource>();
        this.doorAudio.clip = this.door;
        this.doorAudio.loop = false;

        this.bumpAudio = this.gameObject.AddComponent<AudioSource>();
        this.bumpAudio.clip = this.bump;
        this.bumpAudio.loop = false;
        this.bumpAudio.volume = 0.6f;

        this.speedUpAudio = this.gameObject.AddComponent<AudioSource>();
        this.speedUpAudio.clip = this.speedUp;
        this.speedUpAudio.loop = false;

        this.invisibleAudio = this.gameObject.AddComponent<AudioSource>();
        this.invisibleAudio.clip = this.invisible;
        this.invisibleAudio.loop = false;

        this.successAudio = this.gameObject.AddComponent<AudioSource>();
        this.successAudio.clip = this.success;
        this.successAudio.loop = false;
        this.successAudio.volume = 1.5f;

        this.overAudio = this.gameObject.AddComponent<AudioSource>();
        this.overAudio.clip = this.over;
        this.overAudio.loop = false;

    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Move();

    }

    public void Move()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp01(viewPos.x);
        viewPos.y = Mathf.Clamp01(viewPos.y);
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
        transform.position = worldPos;

        transform.Translate(direction * speed * Time.deltaTime);
        transform.Rotate(rotation * rotationSpeed * Time.deltaTime);
    }

    private void GetInput()
    {
        Vector3 v3Pos = this.transform.position;
        v3Pos.z = 0;
        this.transform.position = v3Pos;

        direction = Vector3.zero;
        rotation = Vector3.zero;

        if (Input.GetKey(KeyCode.P))
        {
            left = 3;
            GameObject.Find("BigCameraItems").GetComponent<ItemManager>().CameraItems = 99;
            GameObject.Find("SpeedUpItems").GetComponent<ItemManager>().SpeedItems = 99;
            GameObject.Find("TransparentItems").GetComponent<ItemManager>().TransparentItems = 99;
            transform.localScale = new Vector3(0.25F, 0.35F, transform.localScale.z);
        }

        if (Input.GetKey(KeyCode.RightArrow)&& left > 2) //
        { //right
            //direction += Vector3.right;
            rotation += Vector3.back;
        }
        if (Input.GetKey(KeyCode.LeftArrow) && left > 0)
        { //left
            //direction += Vector3.left;
            rotation += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        { //up
            direction += Vector3.up;
        }
        if (Input.GetKey(KeyCode.DownArrow) && left > 1)
        { //down
            direction += Vector3.down;
        }
        if (Input.GetKey(KeyCode.Q) && (usingBigCameraItem == false))
        { //use camera item
            usingBigCameraItem = true;
            GameObject.Find("BigCameraItems").GetComponent<ItemManager>().UseBigCameraItem();
        }
        if (Input.GetKey(KeyCode.W) && (usingSpeedUpItem == false))
        { //use speed item
            GameObject.Find("SpeedUpItems").GetComponent<ItemManager>().UseSpeedUpItem();
        }
        if (Input.GetKey(KeyCode.E) && (usingTransparentItem == false))
        { //use transparent item
            GameObject.Find("TransparentItems").GetComponent<ItemManager>().UseTransparentItem();
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 0;
            GameObject.Find("Canvas").transform.Find("Pause").gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("beeper"))
        {
            collision.gameObject.SetActive(false);
            GameObject.Find("SpeedUpItems").GetComponent<ItemManager>().PlusSpeedUpItem();
            this.itemAudio.Play();
        }
        else if (collision.gameObject.tag.Equals("Enemy") || collision.gameObject.tag.Equals("HideEnemy") || collision.gameObject.tag.Equals("HideEnemyH"))
        {
            this.overAudio.Play();
            this.gameObject.GetComponent<Renderer>().enabled = false;
            GameObject.Find("Canvas").transform.Find("OverUI").GetComponent<UIevent>().SetGameOverUI();
            Time.timeScale = 0f;
            
        }
        else if (collision.gameObject.tag.Equals("key"))
        {
            keyed = true;
            collision.gameObject.SetActive(false);
            this.coinAudio.Play();
            if (pills)
            {
                GameObject.Find("HideEnemy").transform.GetChild(2).gameObject.SetActive(true);
                GameObject.Find("HideEnemy").transform.GetChild(3).gameObject.SetActive(true);
                GameObject.Find("HideEnemy").transform.GetChild(4).gameObject.SetActive(true);
            }
            
        }
        else if (collision.gameObject.tag.Equals("subKey"))
        {
            subkey = true;
            collision.gameObject.SetActive(false);
            this.coinAudio.Play();
            if (pills)
            {
                GameObject.Find("HideEnemy").transform.GetChild(0).gameObject.SetActive(true);
                GameObject.Find("HideEnemy").transform.GetChild(1).gameObject.SetActive(true);
            }
        }
        else if (collision.gameObject.tag.Equals("CameraItem"))
        {
            GameObject.Find("BigCameraItems").GetComponent<ItemManager>().PlusBigCameraItems();
            collision.gameObject.SetActive(false);
            this.itemAudio.Play();
        }
        else if (collision.gameObject.tag.Equals("turnLeft"))
        {
            left++;
            collision.gameObject.SetActive(false);
            this.coinAudio.Play();
        }
        else if (collision.gameObject.tag.Equals("waitEve"))
        {
            successAudio.Play();
            Debug.Log("Meet Eve");
            Time.timeScale = 0;
            GameObject.Find("Canvas").transform.Find("NextStageUI").GetComponent<NextStage>().NextStageUI();
        }
        else if (collision.gameObject.tag.Equals("potion"))
        {
            collision.gameObject.SetActive(false);
            GameObject.Find("TransparentItems").GetComponent<ItemManager>().PlusTransparentItem();
            this.itemAudio.Play();
        }

        if (tutorial)
        {
            if (collision.gameObject.name == "key_Tip")
            {
                TipUI.SetActive(true);
                GameObject.Find("Tip").GetComponent<TipManager>().TipKey();
            }
            else if (collision.gameObject.name == "beeper_Tip")
            {
                TipUI.SetActive(true);
                GameObject.Find("Tip").GetComponent<TipManager>().TipBeeper();
            }
            else if (collision.gameObject.name == "MoveHubo_Tip")
            {
                TipUI.SetActive(true);
                GameObject.Find("Tip").GetComponent<TipManager>().TipMoveHubo();
            }
            else if (collision.gameObject.name == "BigCamera_Tip")
            {
                TipUI.SetActive(true);
                GameObject.Find("Tip").GetComponent<TipManager>().TipBigCamera();
            }
            else if (collision.gameObject.name == "ObserveHubo_Tip")
            {
                TipUI.SetActive(true);
                GameObject.Find("Tip").GetComponent<TipManager>().TipObserveHubo();
            }
            else if (collision.gameObject.name == "Transparent_Tip")
            {
                TipUI.SetActive(true);
                GameObject.Find("Tip").GetComponent<TipManager>().TipTransparent();
            }
            else if (collision.gameObject.name == "Time_Tip")
            {
                TipUI.SetActive(true);
                GameObject.Find("Tip").GetComponent<TipManager>().TipTime();
            }
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            this.overAudio.Play();
            Debug.Log("enemy");
            this.gameObject.GetComponent<Renderer>().enabled = false;
            GameObject.Find("Canvas").transform.Find("OverUI").GetComponent<UIevent>().SetGameOverUI();
            Time.timeScale = 0f;
        }

        if (collision.gameObject.CompareTag("Door"))
        {
            if (keyed)
            {
                GameObject.FindWithTag("waitEve").GetComponent<EveMove>().changeEve();
                collision.gameObject.SetActive(false);
                this.doorAudio.Play();

            }
            else
            {
                if (subkey) StartCoroutine("TypeError");
                else StartCoroutine("syntaxError");
                this.bumpAudio.Play();
            }
        }
        if (collision.gameObject.CompareTag("subDoor"))
        {
            if (subkey)
            {
                collision.gameObject.SetActive(false);
                this.doorAudio.Play();
            }
            else
            {
                if (keyed) StartCoroutine("TypeError");
                else StartCoroutine("syntaxError");
                this.bumpAudio.Play();
            }
        }
    }

    IEnumerator syntaxError()
    {
        if (!errored)
        {
            errored = true;
            GameObject overPanel = GameObject.Find("Canvas").transform.Find("Syntax").gameObject;
            overPanel.SetActive(true);
            yield return new WaitForSeconds(2f);
            overPanel.SetActive(false);
            errored = false;
        }
    }

    IEnumerator TypeError()
    {
        if (!errored)
        {
            errored = true;
            GameObject overPanel = GameObject.Find("Canvas").transform.Find("Syntax").gameObject;
            Text text = GameObject.Find("Canvas").transform.Find("Syntax").transform.Find("Text").GetComponent<Text>();
            text.text = "TypeError";
            overPanel.SetActive(true);
            yield return new WaitForSeconds(2f);
            overPanel.SetActive(false);
            text.text = "SyntaxError";
            errored = false;
        }
    }

    public void SpeedUp()
    {
        StartCoroutine("SpeedBuff");
    }


    IEnumerator SpeedBuff()
    {
        if (usingSpeedUpItem == false)
        {
            speedUpAudio.Play();
            usingSpeedUpItem = true;
            float original_speed = speed;
            speed *= 2;
            Color color = gameObject.GetComponent<SpriteRenderer>().color;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g * 0.2f, color.b * 0.2f, color.a);
            yield return new WaitForSeconds(2.5f);
            color = gameObject.GetComponent<SpriteRenderer>().color;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g * 5, color.b * 5, color.a);
            speed = original_speed;
            usingSpeedUpItem = false;
        }

    }

    public void Invisible()
    {
        StartCoroutine("invisibleRoutine");
    }

    IEnumerator invisibleRoutine()
    {
        if (usingTransparentItem == false)
        {
            invisibleAudio.Play();
            transparent = true;

            SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
            usingTransparentItem = true;
            Color color = renderer.color;
            renderer.color = new Color(color.r, color.g, color.b, color.a * 0.2f);
            yield return new WaitForSeconds(3f);
            color = renderer.color;
            renderer.color = new Color(color.r, color.g, color.b, color.a * 5);
            usingTransparentItem = false;

            transparent = false;
        }
    }

    public void CameraFlag()
    {
        usingBigCameraItem = !usingBigCameraItem;
    }




}
