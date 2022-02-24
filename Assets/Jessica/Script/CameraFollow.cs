using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float followSpeed = 10f;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    public Vector3 cameraOffset;

    private int testObserverNumber;

    private Vector3 velocity = Vector3.zero;

    private Transform playerPosition;

    private void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        Follow(playerPosition);
    }

    public void Follow(Transform target)
    {
        Vector3 targetPos = target.position + cameraOffset;
        Vector3 clampedPos = new Vector3(Mathf.Clamp(targetPos.x, xMin, xMax), (Mathf.Clamp(targetPos.y, yMin, yMax)), targetPos.z);
        Vector3 smoothPos = Vector3.SmoothDamp(transform.position, clampedPos, ref velocity, followSpeed * Time.fixedDeltaTime);

        transform.position = smoothPos;
    }

    private void TestFunctionForObserver(int testNumber)
    {
        testObserverNumber = testNumber;
        Debug.Log(testObserverNumber);
    }

    private void OnEnable()
    {
        PlayerMovement.observerTest += TestFunctionForObserver;
    }

    private void OnDisable()
    {
        PlayerMovement.observerTest -= TestFunctionForObserver;
    }

}
