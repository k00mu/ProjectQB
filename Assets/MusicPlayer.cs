using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace QuackleBit
{
    public class MusicPlayer : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip[] playlist;
        [SerializeField] private float fadeDuration = 1.0f; // Duration for fade in/out
        [SerializeField] AudioMixer audioMixer;

        private int currentTrackIndex = 0;

        void Start()
        {
            audioMixer.SetFloat("VolMaster", 0.0f);
            if (playlist.Length > 0)
            {
                StartCoroutine(PlayPlaylist());
            }
        }

        private IEnumerator PlayPlaylist()
        {
            while (true)
            {
                audioSource.clip = playlist[currentTrackIndex];
                audioSource.Play();
                yield return StartCoroutine(FadeIn(audioSource, fadeDuration));

                // Wait until the current track is almost finished
                yield return new WaitForSeconds(audioSource.clip.length - fadeDuration);

                yield return StartCoroutine(FadeOut(audioSource, fadeDuration));

                // Move to the next track, looping back to the start if necessary
                currentTrackIndex = (currentTrackIndex + 1) % playlist.Length;
            }
        }

        private IEnumerator FadeIn(AudioSource audioSource, float duration)
        {
            float startVolume = 0f;
            audioSource.volume = startVolume;

            while (audioSource.volume < 1.0f)
            {
                audioSource.volume += Time.deltaTime / duration;
                yield return null;
            }

            audioSource.volume = 1.0f;
        }

        private IEnumerator FadeOut(AudioSource audioSource, float duration)
        {
            float startVolume = audioSource.volume;

            while (audioSource.volume > 0)
            {
                audioSource.volume -= startVolume * Time.deltaTime / duration;
                yield return null;
            }

            audioSource.volume = 0;
            audioSource.Stop();
        }
    }
}