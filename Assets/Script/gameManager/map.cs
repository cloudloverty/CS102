using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map : MonoBehaviour
{
    public GameObject beeper;

    public int beeperNum = 10;
    public int ver = 11;
    public int hor = 13;
    public bool randomBeeper = true;

    struct beeperStruct
    {
        public GameObject obj;
        public Transform tf;
        public bool active;
        public Vector3 pos;
    }
    private beeperStruct[] beepers;
    
    private Vector3 tempVec;

    void Createbeepers()
    {
        tempVec = Vector3.zero;


        beepers = new beeperStruct[beeperNum];
        for (int i = 0; i < beeperNum; i++)
        {
            tempVec.x = UnityEngine.Random.Range(-hor / 2, hor / 2);
            tempVec.y = UnityEngine.Random.Range(-ver / 2, ver / 2);

            beepers[i].obj = Instantiate(beeper, tempVec, Quaternion.identity) as GameObject;//create
            beepers[i].tf = beepers[i].obj.transform;
            beepers[i].pos = beepers[i].tf.position;
            beepers[i].active = true;
        }
    }

    public GameObject mapTile;

    struct MapStruct
    {
        public GameObject obj;
        public Transform tf;
        public bool active;
        public Vector3 pos;
    }
    void CreateMap()
    {
        float h = hor;
        float v = ver;
        for (int i = 0; i <= hor; i++)
        {
            for (int j = 0; j <= ver; j++)
            {
                tempVec.x = i - h / 2.0f;
                tempVec.y = j - v / 2.0f;
                MapStruct mapUnit = new MapStruct();
                mapUnit.obj = Instantiate(mapTile, tempVec, Quaternion.identity) as GameObject;
                mapUnit.tf = mapUnit.obj.transform;
                mapUnit.pos = mapUnit.tf.position;
                mapUnit.active = true;

            }
        }

    }




    private void Awake()
    {
        CreateMap();
        if (randomBeeper) Createbeepers();



    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
    }

    public void FreezeMap()
    {
    }
}