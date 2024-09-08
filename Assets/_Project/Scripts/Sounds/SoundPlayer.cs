using UnityEngine;
using UnityEngine.Events;

namespace QuackleBit
{
    public class SoundPlayer : MonoBehaviour
    {
        private AudioSource audioSource;
        private AudioSource bgmSource;
        [SerializeField] private UnityEvent onStart;

        void Start()
        {
            audioSource = GetComponent<AudioSource>();

           
            bgmSource = gameObject.AddComponent<AudioSource>();
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