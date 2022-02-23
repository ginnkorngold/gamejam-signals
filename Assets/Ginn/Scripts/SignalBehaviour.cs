using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SignalBehaviour : MonoBehaviour
{
    public ParticleSystem signalParticals;
    private bool insideTrigger;

    // Start is called before the first frame update
    void Start()
    {
        insideTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            signalParticals.Play();
            if(insideTrigger == true)
            {
                Debug.Log("behaviour happening");
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
    }
}
