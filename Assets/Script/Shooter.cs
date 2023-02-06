using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLife = 5f;
    [SerializeField] float baseFireRate = 0.2f;

    [Header("AI")]
    [SerializeField] float fireRateRandom = 0f;
    [SerializeField] float minimumFireRate = 0.1f;
    [SerializeField] bool useAI;

    [HideInInspector] public bool isFiring;
    Coroutine firingCoroutine;
    AudioPlayer audioPlayer;

    private void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
       
        if (useAI)
        {
            isFiring = true; 
        }
    }

   
    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (isFiring && firingCoroutine == null)
        {
           firingCoroutine= StartCoroutine(FireContinously());
        }
        else if (!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine  = null;
        }
        
    }

    IEnumerator FireContinously()
    {
        while (true)
        {
            GameObject laser = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            Rigidbody2D rb = laser.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = -transform.up*projectileSpeed;
            }
            Destroy(laser, projectileLife);

            float timetoNext = UnityEngine.Random.Range(baseFireRate - fireRateRandom, baseFireRate + fireRateRandom);
            timetoNext = Mathf.Clamp(timetoNext,minimumFireRate,float.MaxValue);
            audioPlayer.PlayShootingClip();
            yield return new WaitForSeconds(timetoNext);

        }
    }
}
