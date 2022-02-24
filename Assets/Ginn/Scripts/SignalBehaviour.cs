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

    [Header("Level one")]
    public float speed;
    public GameObject platform;
    public GameObject conveyer;



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
            if(insideTrigger == false)
            {
                signalActive = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lever"))
        {
            insideTrigger = false;
            signalActive = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lever"))
        {
            insideTrigger = true;
            Debug.Log("Inside trigger for lever");
        }
        if(collision.gameObject.CompareTag("Door"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
            if(collision.gameObject.name == "Lever02")
            {
                platform.transform.position = new Vector2(platform.transform.position.x, -3f);
            }
            if (collision.gameObject.name == "Lever03")
            {
                conveyer.transform.position = new Vector2(-2.5f, conveyer.transform.position.y);
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "MoveablePlatform")
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, 2f);
            platform.transform.position = new Vector2(platform.transform.position.x, 2f);
        }

        if(collision.gameObject.name == "Basket")
        {
            gameObject.transform.position = new Vector2(5.15f, gameObject.transform.position.y);
            conveyer.transform.position = new Vector2(5.15f, gameObject.transform.position.y);
        }
    }
}
