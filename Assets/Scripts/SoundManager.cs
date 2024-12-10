using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }


    [SerializeField] private AudioClip[] sounds; // Массив звуков
    private AudioSource audioSource; // Источник звука

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Проверяем, что компонент AudioSource существует
        if (audioSource == null)
        {
            Debug.LogError("Компонент AudioSource отсутствует на этом объекте.");
            return;
        }

        if (sounds == null || sounds.Length < 2)
        {
            Debug.LogError("Массив sounds не инициализирован должным образом или содержит недостаточно элементов.");
            return;
        }

        
    }


    private void OnYouWin()
    {
        StopMusic();
        PlayUsher();
    }

    private void OnGameOver()
    {
        StopMusic();
        PlayScream();
    }

    private void PlayMusicOnGameStarted()
    {
        // Проверяем, что массив содержит хотя бы один элемент
        if (sounds.Length > 0)
        {
            audioSource.clip = sounds[0]; // Устанавливаем первый трек
            audioSource.Play(); // Запускаем воспроизведение

        }
    }
    private void PlayUsher()
    {
        if (sounds.Length > 1)
        {
            audioSource.clip = sounds[1];
            audioSource.time = 2f;
            audioSource.Play();
        }
    }
    public void PlayScream()
    {
        if (sounds.Length > 2)
        {
            audioSource.PlayOneShot(sounds[2]);
        }
    }

    public void PlayHiss()
    {
        if (sounds.Length > 3)
        {
            audioSource.clip = sounds[3];
            audioSource.Play();
        }
    }

    public void PlayCountDown()
    {
        if (sounds.Length > 4)
        {
            audioSource.PlayOneShot(sounds[4]);
        }
    }

    public void PlayGo()
    {
        if (sounds.Length > 5)
        {
            audioSource.PlayOneShot(sounds[5]);
        }
    }

    public void PlayRonaldo()
    {
        if (sounds.Length > 6)
        {
            float orginalVolume = audioSource.volume;
            audioSource.volume /= 2;
            audioSource.PlayOneShot(sounds[6]);
            audioSource.volume = orginalVolume;
        }
    }


    private void StopMusic()
    {
        audioSource.Stop();
    }

    private void OnDestroy()
    {
        
        if (instance == this)
            instance = null;
    }



}


