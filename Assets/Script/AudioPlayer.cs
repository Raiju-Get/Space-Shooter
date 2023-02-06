using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] float shootingVolume = 1f;

    [Header("Impact")]
    [SerializeField] AudioClip impactClip;
    [SerializeField] [Range(0f, 1f)] float ImpactVolume = 1f;

    static AudioPlayer instance;
    
    private void Awake()
    {
        ManaheSingleton();
    }

    private void ManaheSingleton()
    {
        //int instance =   FindObjectsOfType(GetType()).Length;
        //if (instance >1)
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayShootingClip()
    {
        PlayClip(shootingClip, shootingVolume);
    }

    public void PlayImpactClip()
    {
        PlayClip(impactClip, ImpactVolume); 
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            Vector3 camerpos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, camerpos, volume);
        }
    }

}
