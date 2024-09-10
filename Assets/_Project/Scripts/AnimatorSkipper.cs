using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace QuackleBit
{
    public class AnimatorSkipper : MonoBehaviour
    {
        [SerializeField] private Animator anim;
        [SerializeField] private bool skippable = false;
        [SerializeField] private float warningDuration = 2.0f; 
        [SerializeField ]private TMP_Text warningText;

        private void Start()
        {
            anim = GetComponent<Animator>();
            if (warningText != null)
            {
                // Set initial alpha to 0
                Color color = warningText.color;
                color.a = 0;
                warningText.color = color;
            }
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                if (!skippable)
                {
                    skippable = true;
                    StartCoroutine(WarningCoroutine());
                }
                else
                {
                    SkipAnimation();
                }
            }
        }

        private IEnumerator WarningCoroutine()
        {
            Debug.Log("Press Space again to skip the animation.");
            if (warningText != null)
            {
                Color color = warningText.color;
                color.a = 1;
                warningText.color = color;

                float elapsedTime = 0f;
                while (elapsedTime < warningDuration)
                {
                    elapsedTime += Time.deltaTime;
                    color.a = Mathf.Lerp(1, 0, elapsedTime / warningDuration);
                    warningText.color = color;
                    yield return null;
                }

                // Ensure the text is fully transparent at the end
                color.a = 0;
                warningText.color = color;
            }

            skippable = false;
        }

        private void SkipAnimation()
        {
            warningText.enabled = false;
            // Skip the animation
            anim.SetBool("Skip", true);
            Debug.Log("Animation skipped.");
        }
    }
}