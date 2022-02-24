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
    public GameObject platform01;
    public GameObject conveyer01;

    [Header("Level two")]
    public GameObject platform02;
    private GravityController gravity;

    [Header("Level three")]
    public GameObject platform03;
    public GameObject platform04;
    public GameObject platform05;
    public GameObject conveyer02;


    void Start()
    {
        insideTrigger = false;
        signalActive = false;

        gravity = GetComponent<GravityController>();
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
        if (collision.gameObject.CompareTag("Gravity"))
        {
            Debug.Log("Inside trigger");
            gravity.Switch();
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
                platform01.transform.position = new Vector2(platform01.transform.position.x, -3f);
            }
            if (collision.gameObject.name == "Lever03")
            {
                conveyer01.transform.position = new Vector2(-2.5f, conveyer01.transform.position.y);
            }
            if(collision.gameObject.name == "Lever04")
            {
                platform02.transform.position = new Vector2(-7.5f, platform02.transform.position.y);
            }
            if(collision.gameObject.name == "Lever05")
            {
                platform03.transform.position = new Vector2(-6.5f, platform03.transform.position.y);
                platform04.transform.position = new Vector2(platform04.transform.position.x, 5f);
                platform05.transform.position = new Vector2(platform05.transform.position.x, 4.5f);
            }
            if(collision.gameObject.name == "Lever06")
            {
                platform04.transform.position = new Vector2(platform04.transform.position.x, 8f);
            }
            if(collision.gameObject.name == "Lever07")
            {
                conveyer02.transform.position = new Vector2(-2f, conveyer02.transform.position.y);
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "MoveablePlatform")
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, 2f);
            platform01.transform.position = new Vector2(platform01.transform.position.x, 2f);
        }

        if(collision.gameObject.name == "Basket")
        {
            gameObject.transform.position = new Vector2(5.15f, gameObject.transform.position.y);
            conveyer01.transform.position = new Vector2(5.15f, gameObject.transform.position.y);
        }
    }
}
