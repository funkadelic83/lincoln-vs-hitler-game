using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    //private AudioClip musicClip;
    private AudioSource musicSource;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.StartGameNow.AddListener(PlayMusic);
        musicSource = GetComponent<AudioSource>();
        //musicClip = musicSource.clip;
        GameManager.Instance.EndGame.AddListener(StopMusic);
    }

    void PlayMusic()
    {
        musicSource.time = 3f;
        musicSource.Play();
    }

    void StopMusic(string winner)
    {
        musicSource.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
