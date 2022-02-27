using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SoundManager : MonoBehaviour
{

    /*[SerializeField] private AudioSource musicSource;
    
    [Serializable]
    public struct Clips
    {
        public string name;
        public AudioClip audioClip;
    }
    
    [SerializeField]
    private Clips audioClip;*/


    public static SoundManager Instance;
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /*private void Update()
    {
        if(musicSource.isPlaying)
        {
            return;
        }
        musicSource.Play();
    }


    public void UpdateMusic(string audioName)
    {
        musicSource.clip = audioClip.audioClip;
        musicSource.Play();
    }*/
}