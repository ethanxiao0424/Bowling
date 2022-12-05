using UnityEngine;

public class Contact : MonoBehaviour
{
    public AudioSource pinsAudio;
    public bool hit;
    public GameObject[] pins;
    int pinDown=0;
    public GameObject ball;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || ball.transform.position.y < -20)
        {
            CountPinKnock();
            Debug.Log(pinDown);
        } 
    }

    void CountPinKnock()
    {
        for (int i = 0; i < pins.Length; i++)
        {
            if (pins[i].transform.eulerAngles.z > 5 && pins[i].transform.eulerAngles.z < 355&&pins[i].activeSelf)
            {
                pinDown++;
                pins[i].SetActive(false);
            }
        }
    }

    void CalculateScore()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.name == "BowlingBall")
        {
            hit = true;
            pinsAudio.Play();
        }
    }
}
