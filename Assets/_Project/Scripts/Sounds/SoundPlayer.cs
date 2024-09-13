using UnityEngine;
using UnityEngine.Events;

namespace QuackleBit
{
    public class SoundPlayer : MonoBehaviour
    {
        [SerializeField]private AudioSource audioSource;
        [SerializeField]private AudioSource bgmSource;
        [SerializeField] private UnityEvent onStart;

        void Start()
        {
            audioSource = gameObject.AddComponent<AudioSource>();

           
            bgmSource = gameObject.AddComponent<AudioSource>();

            audioSource.playOnAwake = false;
            audioSource.spatialBlend = 1f;
            audioSource.rolloffMode = AudioRolloffMode.Linear;
            audioSource.minDistance = 1f;
            audioSource.maxDistance = 10f;
            bgmSource.playOnAwake = false;
            bgmSource.loop = true;
            onStart.Invoke();
        }

        public void PlaySound(SoundEvent soundEvent)
        {
            if (soundEvent == null || soundEvent.clip == null) return;

            AudioSource source = soundEvent.isBGM ? bgmSource : audioSource;
            if (source != null)
            {
                source.clip = soundEvent.clip;
                source.outputAudioMixerGroup = soundEvent.audioMixerGroup;
                source.volume = soundEvent.volume;
                source.Play();
            }
        }

        public void StopBGM()
        {
            if (bgmSource != null)
            {
                bgmSource.Stop();
            }
        }
    }
}