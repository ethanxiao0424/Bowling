using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] pins;
    Vector3[] originalPos;
    Quaternion[] originalRot;
    [SerializeField] Gut gut;
    int pinDown;
    public bool miss=false;
    public GameObject ball;
    Rigidbody ballRb;
    [SerializeField] ScoreManager scoreManager;
    private Rigidbody[] pinsRb;

    private void Start()
    {
        //pins = GameObject.FindGameObjectsWithTag("Pin");
        ballRb = ball.GetComponent<Rigidbody>();
        originalPos = new Vector3[pins.Length];
        originalRot = new Quaternion[pins.Length];
        pinsRb = new Rigidbody[pins.Length];
        for (int i = 0; i < pins.Length; i++)
        {
            pinsRb[i] = pins[i].GetComponent<Rigidbody>();
            originalPos[i] = pins[i].transform.position;
            originalRot[i] = pins[i].transform.rotation;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || ball.transform.position.y < -40)
        {
            scoreManager.Score();
            Init();
        }
    }
   
    void Init()
    {
        pinDown = gut.pinDown;
        ball.transform.position = new Vector3(0, 0.0399999991f, 0.209999993f);
        ballRb.velocity = Vector3.zero;
        ballRb.angularVelocity = Vector3.zero;

        if (pinDown == 10)
        {
            InitPinsPosAndRot();
            SetActivePins();
        }
        else if(pinDown<10 && !miss)
        {
            for (int i = 0; i < pins.Length; i++)
            {
 
            }
            miss = true;
        }
        else if(pinDown<10 && miss)
        {
            InitPinsPosAndRot();
            SetActivePins();
            miss = false;
        }

        gut.pinDown = 0;    
    }

    public void InitPinsPosAndRot()
    {
        for (int i = 0; i < pins.Length; i++)
        {
            pinsRb[i].velocity = Vector3.zero;
            pinsRb[i].angularVelocity = Vector3.zero;
            pins[i].transform.SetPositionAndRotation(originalPos[i], originalRot[i]);
        }
    }

    void SetActivePins()
    {
        for (int i = 0; i < pins.Length; i++)
        {
            pins[i].SetActive(true);
        }
    }
}
