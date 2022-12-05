using UnityEngine;

public class Contact : MonoBehaviour
{
    public AudioSource pinsAudio;
    public bool hit;

    private void Start()
    {
        
    }
    private void Update()
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
