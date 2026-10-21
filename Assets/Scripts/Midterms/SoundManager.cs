using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource audioSource;

    public AudioClip bgmMusic;
    public AudioClip orbShootSound;
    public AudioClip electricShockSound;
    public AudioClip explosionSound;
    public AudioClip enemyDeathSound;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        audioSource.clip = bgmMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void StopBGM()
    {
        audioSource.Stop();
    }

    public void PlayOrbShoot()
    {
        audioSource.PlayOneShot(orbShootSound);
    }

    public void PlayElectricShock()
    {
        audioSource.PlayOneShot(electricShockSound);
    }

    public void PlayExplosion()
    {
        audioSource.PlayOneShot(explosionSound);
    }

    public void PlayEnemyDeath()
    {
        audioSource.PlayOneShot(enemyDeathSound);
    }
}