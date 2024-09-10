using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuackleBit
{
    public class IntroBGM : MonoBehaviour
    {
        private void Awake() {
            DontDestroyOnLoad(gameObject);
        }
        private AudioSource audioSource;

        private void Start() {
            audioSource = GetComponent<AudioSource>();
            audioSource.loop = true;
        }

        public void PlayBGM() {
            audioSource.Play();
        }

    }
}
