using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace QuackleBit
{
    public class VolumeController : MonoBehaviour
    {
        [SerializeField] AudioMixer audioMixer;
        [SerializeField] string[] exposedParameters;
        [SerializeField] Slider slider;
        /// <summary>
        /// Update is called every frame, if the MonoBehaviour is enabled.
        /// </summary>
        void Update()
        {
            foreach (var parameter in exposedParameters)
            {
                audioMixer.SetFloat(parameter, slider.value);
            }
        }
    }
}
