using System.Collections;
using UnityEngine;
using TMPro;

namespace QuackleBit
{
    public class RunningText : MonoBehaviour
    {
        [SerializeField] private TMP_Text tmpText;
        [SerializeField] private string[] textSequence;
        [SerializeField] private float duration = 2.0f; // Duration for each text display
        [SerializeField] private float fadeDuration = 0.5f; // Duration for fade in/out

        private Coroutine textSequenceCoroutine;

        IEnumerator Start()
        {
            yield return new WaitForSeconds(5.0f);
            if (tmpText != null && textSequence.Length > 0)
            {
                StartCoroutine(UpdateTextSequence());
            }
        }

        private IEnumerator UpdateTextSequence()
        {
            for (int index = 0; index < textSequence.Length; index++)
            {
                // Set the text and fade in
                tmpText.text = textSequence[index];
                yield return StartCoroutine(FadeTextToFullAlpha(fadeDuration, tmpText));

                // Wait for the duration
                yield return new WaitForSeconds(duration);

                // Fade out
                yield return StartCoroutine(FadeTextToZeroAlpha(fadeDuration, tmpText));
            }

            // Optionally, you can clear the text after the sequence ends
            tmpText.text = string.Empty;
        }

        private IEnumerator FadeTextToFullAlpha(float t, TMP_Text text)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
            while (text.color.a < 1.0f)
            {
                text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / t));
                yield return null;
            }
        }

        private IEnumerator FadeTextToZeroAlpha(float t, TMP_Text text)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
            while (text.color.a > 0.0f)
            {
                text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / t));
                yield return null;
            }
        }

        // Public method to restart the text sequence
        public void RestartTextSequence()
        {
            if (textSequenceCoroutine != null)
            {
                StopCoroutine(textSequenceCoroutine);
            }

            if (tmpText != null && textSequence.Length > 0)
            {
                textSequenceCoroutine = StartCoroutine(UpdateTextSequence());
            }
        }
    }
}