using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AttackUniversal[] attackUniversal;
    public AudioSource sfxSource;
    public AudioClip[] whooshSfx;
    public AudioClip[] punchSfx;
    public AudioClip roundBell;
    // Start is called before the first frame update
    void Start()
    {
        attackUniversal[0].PlaySound.AddListener(PlaySFX);
        attackUniversal[1].PlaySound.AddListener(PlaySFX);
        attackUniversal[2].PlaySound.AddListener(PlaySFX);
        attackUniversal[3].PlaySound.AddListener(PlaySFX);
        attackUniversal[4].PlaySound.AddListener(PlaySFX);
        attackUniversal[5].PlaySound.AddListener(PlaySFX);
        attackUniversal[6].PlaySound.AddListener(PlaySFX);
        attackUniversal[7].PlaySound.AddListener(PlaySFX);
        GameManager.Instance.FreezeEnemy.AddListener(RingBell);
    }

    void PlaySFX(string effectType)
    {

        if (effectType == SfxTags.WHOOSH_SFX)
        {
            int random = Random.Range(0, whooshSfx.Length);
            sfxSource.clip = whooshSfx[random];
            sfxSource.Play();
        }
        else if (effectType == SfxTags.HIT_SFX)
        {
            int random = Random.Range(0, punchSfx.Length);
            sfxSource.clip = punchSfx[random];
            sfxSource.Play();
        }


    }

    void RingBell()
    {
        sfxSource.clip = roundBell;
        sfxSource.Play();
    }

}
