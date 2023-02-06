using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeDuration = 1f;
    [SerializeField] float shakeMagnitutde = 0.1f;

    Vector3 initalPostion;
    void Start()
    {
        initalPostion = transform.position;
    }
    public void Play()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        float elapsedTime = 0;
        while (elapsedTime< shakeDuration)
        {

            transform.position = initalPostion + (Vector3)UnityEngine.Random.insideUnitCircle * shakeMagnitutde;
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = initalPostion;
       
    }
}
