using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    //private AudioClip musicClip;
    private AudioSource musicSource;
    public AudioClip introMusic;
    public AudioClip gameMusic;
    public AudioClip victoryMusic;
    public AudioClip defeatMusic;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.StartGameNow.AddListener(PlayMusic);
        musicSource = GetComponent<AudioSource>();
        musicSource.clip = introMusic;
        musicSource.time = 24f;
        //musicClip = musicSource.clip;
        GameManager.Instance.EndGame.AddListener(StopMusic);
    }

    void PlayMusic()
    {
        musicSource.Stop();
        musicSource.clip = gameMusic;
        musicSource.time = 1f;
        musicSource.Play();
    }

    void StopMusic(string winner)
    {
        musicSource.Stop();
        if (winner == "Player")
        {
            //Debug.Log(winner);
            musicSource.clip = victoryMusic;
            musicSource.time = 0f;
            musicSource.loop = false;
            musicSource.Play();
        } else
        {
            musicSource.clip = defeatMusic;
            musicSource.time = 0f;
            musicSource.loop = false;
            musicSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
