using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip gameOverSound;

    [SerializeField] private AudioSource audioSource;
    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void PlaySound(AudioClipEnum sound)
    {
        switch(sound)
        {
            case AudioClipEnum.Jump:
                audioSource.clip = jumpSound; 
                break;
            case AudioClipEnum.GameOver:
                audioSource.clip = gameOverSound;
                break;
        }

        audioSource.Play();
    }
}

public enum AudioClipEnum
{
    Jump, 
    GameOver
}