using UnityEngine;

public class Contact : MonoBehaviour
{
    public AudioSource pinsAudio;
    public bool hit;
    public GameObject[] pin;
    public bool[] knockDown;
    int pinDown;
    public static int Score = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            CheckPinKnock();
        }
    }
    void CheckPinKnock()
    {
        foreach (GameObject go in pin)
        {
            if (go.transform.position.y<0.15)
            {
                pinDown++;
                Debug.Log(pinDown);
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
