using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

namespace QuackleBit
{
    public class CinematicBlackBar : MonoBehaviour
    {
        [SerializeField] private RectTransform topBlackBar;
        [SerializeField] private RectTransform bottomBlackBar;
        [SerializeField] private float animationDuration = 1.0f;
        [SerializeField] private float targetHeight = 100.0f;
        [SerializeField] private Image fadeOutImage; // New field for the fade-out image
        [SerializeField] private float fadeOutDelay = 2.0f; // Delay before starting the fade-out
        [SerializeField] private float fadeOutDuration = 1.0f; // Duration of the fade-out effect
        [SerializeField] private AudioMixer audioMixer; // New field for the audio mixer
        [SerializeField] private float volumeFadeDuration = 1.0f; // Duration for the volume fade-out
        [SerializeField] private float blackFadeDuration = 1.0f; // Duration for the white to black fade

        private Vector2 topBarOriginalSize;
        private Vector2 bottomBarOriginalSize;

        void Start()
        {
            topBarOriginalSize = topBlackBar.sizeDelta;
            bottomBarOriginalSize = bottomBlackBar.sizeDelta;
            ShowBars();
        }

        public void ShowBars()
        {
            StartCoroutine(AnimateBars(targetHeight));
            StartCoroutine(DelayedFadeOut());
        }

        private IEnumerator AnimateBars(float targetHeight)
        {
            float elapsedTime = 0.0f;
            Vector2 topBarTargetSize = new Vector2(topBarOriginalSize.x, targetHeight);
            Vector2 bottomBarTargetSize = new Vector2(bottomBarOriginalSize.x, targetHeight);

            while (elapsedTime < animationDuration)
            {
                topBlackBar.sizeDelta = Vector2.Lerp(topBlackBar.sizeDelta, topBarTargetSize, elapsedTime / animationDuration);
                bottomBlackBar.sizeDelta = Vector2.Lerp(bottomBlackBar.sizeDelta, bottomBarTargetSize, elapsedTime / animationDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            topBlackBar.sizeDelta = topBarTargetSize;
            bottomBlackBar.sizeDelta = bottomBarTargetSize;
        }

        private IEnumerator DelayedFadeOut()
        {
            yield return new WaitForSeconds(fadeOutDelay);
            StartCoroutine(FadeOutScreen());
        }

        private IEnumerator FadeOutScreen()
        {
            float elapsedTime = 0.0f;
            Color startColor = new Color(1, 1, 1, 0); // Transparent white
            Color endColor = new Color(1, 1, 1, 1); // Opaque white

            fadeOutImage.gameObject.SetActive(true);
            fadeOutImage.color = startColor;

            while (elapsedTime < fadeOutDuration)
            {
                fadeOutImage.color = Color.Lerp(startColor, endColor, elapsedTime / fadeOutDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            fadeOutImage.color = endColor;
            StartCoroutine(FadeToBlack());
        }

        private IEnumerator FadeOutVolume()
        {
            float elapsedTime = 0.0f;
            float startVolume;
            audioMixer.GetFloat("VolMaster", out startVolume);
            float endVolume = -80f; // Typically, -80 dB is considered silence in Unity's AudioMixer

            while (elapsedTime < volumeFadeDuration)
            {
                float newVolume = Mathf.Lerp(startVolume, endVolume, elapsedTime / volumeFadeDuration);
                audioMixer.SetFloat("VolMaster", newVolume);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            audioMixer.SetFloat("VolMaster", endVolume);
            
        }

        private IEnumerator FadeToBlack()
        {
            float elapsedTime = 0.0f;
            Color startColor = new Color(1, 1, 1, 1); // Opaque white
            Color endColor = new Color(0, 0, 0, 1); // Opaque black

            while (elapsedTime < blackFadeDuration)
            {
                fadeOutImage.color = Color.Lerp(startColor, endColor, elapsedTime / blackFadeDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            fadeOutImage.color = endColor;
            
            StartCoroutine(FadeOutVolume());
        }
    }
}