using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SignalBehaviour : MonoBehaviour
{
    public ParticleSystem signalParticles;
    public bool insideTrigger;
    public bool signalActive;

    [Header("Level Tutorial")]
    public GameObject doorOneOpen;
    public GameObject doorOneClosed;

    //[Header("Level one")]



    void Start()
    {
        insideTrigger = false;
        signalActive = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            signalParticles.Play();
            if(insideTrigger == true)
            {
                signalActive = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lever"))
        {
            insideTrigger = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lever"))
        {
            insideTrigger = true;
        }
        if(collision.gameObject.CompareTag("Door"))
        {
            SceneManager.LoadScene(+1);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(signalActive == true)
        {
            if(collision.gameObject.name == "Lever/Trigger01")
            {
                doorOneClosed.SetActive(false);
                doorOneOpen.SetActive(true);
            }
        }
    }
}
