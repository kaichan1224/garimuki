using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip idleSound;
    [SerializeField] private AudioClip battleSound;
    [SerializeField] private AudioClip successSound;
    [SerializeField] private AudioClip failSound;
    [SerializeField] private AudioClip evoSound;


    // Start is called before the first frame update
    void Start()
    {
        StartIdleBgm();
    }

    public void StopBgm()
    {
        audioSource.Stop();
    }

    public void StartBattleBgm()
    {
        audioSource.Stop();
        audioSource.clip = battleSound;
        audioSource.Play();
    }

    public void StartIdleBgm()
    {
        audioSource.Stop();
        audioSource.clip = idleSound;
        audioSource.Play();
    }

    public void StartSuccessBgm()
    {
        audioSource.Stop();
        audioSource.clip = successSound;
        audioSource.Play();
    }

    public void StartFailBgm()
    {
        audioSource.Stop();
        audioSource.clip = failSound;
        audioSource.Play();
    }

    public void StartEvoBgm()
    {
        audioSource.Stop();
        audioSource.clip = evoSound;
        audioSource.Play();
    }
}
