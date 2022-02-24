using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SignalBehaviour : MonoBehaviour
{
    public GameObject signal;
    public ParticleSystem signalParticles;
    public bool insideTrigger;
    public bool signalActive;
    private Vector3 scale;
    private float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        scale = signal.transform.localScale;
        insideTrigger = false;
        signalActive = false;
        signal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            signalParticles.Play();
            //StartCoroutine(signalling());
            if(insideTrigger == true)
            {
                Debug.Log("behaviour happening");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Lever")
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
    }

    private IEnumerator signalling()
    {
        signalActive = true;
        signal.SetActive(true);
        scale.x += Time.deltaTime * speed;
        scale.y += Time.deltaTime * speed;
        signal.transform.localScale = scale;

        yield return new WaitForSeconds(5f);
        signal.SetActive(false);
        scale.x = 1f;
        scale.y = 1f;
        signalActive = false;
    }
}
