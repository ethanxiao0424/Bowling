using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public GameObject ball;
    Rigidbody rb;
    public AudioSource ballAudio;
    [SerializeField]float force;
    bool isShooting = false;
    bool isGoingRight = true;
    bool start = false;

    void Start()
    {
        rb = ball.GetComponent<Rigidbody>();
        rb.maxAngularVelocity = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                rb.AddForce(Vector3.forward * force);
                ballAudio.Play();
                isShooting = true;
            }

            if (!isShooting)
            {
                MoveBall();
            }
        }
    }

    void MoveBall()
    {
        if(isGoingRight)
        {
            ball.transform.Translate(Vector3.right * Time.deltaTime);
        }
        else
        {
            ball.transform.Translate(Vector3.left * Time.deltaTime);
        }

        if (ball.transform.position.x > 0.5f)
        {
            isGoingRight = false;
        }

        if(ball.transform.position.x < -0.5f)
        {
            isGoingRight = true;
        }
    }
    public void StartMoveBall()
    {
        start = true;
        isShooting = false;
    }
    
}
