using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    [SerializeField] private ParticleSystem correctLetterParticle;
    [SerializeField] private ParticleSystem wordCompletedParticle;

    private void Start()
    {
        EventBus.OnLetterChecked += OnCorrectLetter;
        EventBus.OnWordCompleted += OnWordCompleted;
    }

    private void OnCorrectLetter(bool isCorrectLetter)
    {
        if (isCorrectLetter)
            PlayParticle(correctLetterParticle);
    }

    private void OnWordCompleted() => PlayParticle(wordCompletedParticle);

    private void PlayParticle(ParticleSystem particle) => particle.Play();


    private void OnDestroy()
    {
        EventBus.OnLetterChecked -= OnCorrectLetter;
        EventBus.OnWordCompleted -= OnWordCompleted;
    }
}
