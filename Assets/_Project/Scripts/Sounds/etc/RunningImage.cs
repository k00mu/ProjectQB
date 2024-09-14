using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace QuackleBit
{
    public class RunningImage : MonoBehaviour
    {
        [SerializeField] private Image imageComponent;
        [SerializeField] private Sprite[] imageSequence;
        [SerializeField] private float duration = 2.0f; // Duration for each image display
        [SerializeField] private float fadeDuration = 0.5f; // Duration for fade in/out
        [SerializeField] UnityEvent onSequenceEnd;

        private Coroutine imageSequenceCoroutine;

        IEnumerator Start()
        {
            yield return new WaitForSeconds(1.0f);
            if (imageComponent != null && imageSequence.Length > 0)
            {
                StartCoroutine(UpdateImageSequence());
            }
        }

        private IEnumerator UpdateImageSequence()
        {
            for (int index = 0; index < imageSequence.Length; index++)
            {
                yield return StartCoroutine(FadeInImage(imageSequence[index]));
                yield return new WaitForSeconds(duration);

                // Skip fade out for the last image
                if (index < imageSequence.Length - 1)
                {
                    yield return StartCoroutine(FadeOutImage());
                }else{
                yield return new WaitForSeconds(1f);
                onSequenceEnd.Invoke();}
                StartCoroutine(FadeOutImage());
            }
        }

        private IEnumerator FadeInImage(Sprite newImage)
        {
            imageComponent.sprite = newImage;
            imageComponent.color = new Color(imageComponent.color.r, imageComponent.color.g, imageComponent.color.b, 0);
            float elapsedTime = 0.0f;

            while (elapsedTime < fadeDuration)
            {
                elapsedTime += Time.deltaTime;
                float alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
                imageComponent.color = new Color(imageComponent.color.r, imageComponent.color.g, imageComponent.color.b, alpha);
                yield return null;
            }

            imageComponent.color = new Color(imageComponent.color.r, imageComponent.color.g, imageComponent.color.b, 1);
        }

        private IEnumerator FadeOutImage()
        {
            float elapsedTime = 0.0f;

            while (elapsedTime < fadeDuration)
            {
                elapsedTime += Time.deltaTime;
                float alpha = Mathf.Clamp01(1 - (elapsedTime / fadeDuration));
                imageComponent.color = new Color(imageComponent.color.r, imageComponent.color.g, imageComponent.color.b, alpha);
                yield return null;
            }

            imageComponent.color = new Color(imageComponent.color.r, imageComponent.color.g, imageComponent.color.b, 0);
        }
    }
}