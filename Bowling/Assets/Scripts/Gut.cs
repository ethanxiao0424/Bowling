using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gut : MonoBehaviour
{
    public int pinDown = 0;
    GameObject[] pins;
    [SerializeField] GameManager gameManager;
    [SerializeField] ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        pins = gameManager.pins;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "BowlingBall")
        {
            CountPinKnock();
            scoreManager.Roll(pinDown);
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

}
