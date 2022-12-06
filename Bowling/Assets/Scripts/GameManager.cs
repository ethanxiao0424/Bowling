using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] pins;
    Vector3[] originalPos;
    Quaternion[] originalRot;
    int pinDown = 0;
    bool miss;
    public GameObject ball;
    Rigidbody ballRb;
    public GameObject scoreManager;
    private Rigidbody[] pinsRb;

    private void Start()
    {
        ballRb = ball.GetComponent<Rigidbody>();
        originalPos = new Vector3[pins.Length];
        originalRot = new Quaternion[pins.Length];
        pins = GameObject.FindGameObjectsWithTag("Pin");
        for (int i = 0; i < pins.Length; i++)
        {
            originalPos[i] = pins[i].transform.position;
            originalRot[i] = pins[i].transform.rotation;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || ball.transform.position.y < -20)
        {
            Init();
            scoreManager.GetComponent<ScoreManager>().Score();
        }
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "BowlingBall")
        {
            CountPinKnock();
            scoreManager.GetComponent<ScoreManager>().Roll(pinDown);
        }
    }
    void CountPinKnock()
    {
        for (int i = 0; i < pins.Length; i++)
        {
            if (pins[i].transform.eulerAngles.z > 5 && pins[i].transform.eulerAngles.z < 355 && pins[i].activeSelf)
            {
                pinDown++;
                pins[i].SetActive(false);
            }
        }
    }

    void Init()
    {
        ball.transform.position = new Vector3(0, 0.0399999991f, 0.209999993f);
        ballRb.velocity = Vector3.zero;
        ballRb.angularVelocity = Vector3.zero;

        if (pinDown == 10)
        {
            InitPins();
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
            InitPins();
        }
        pinDown = 0;

        void InitPins()
        {
            for (int i = 0; i < pins.Length; i++)
            {
                pins[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
                pins[i].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                pins[i].transform.position = originalPos[i];
                pins[i].transform.rotation = originalRot[i];
                pins[i].SetActive(true);
            }
        }
    }
}
