using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace QuackleBit
{
    public class CheatMenu : MonoBehaviour
    {
        private string inputSequence = "";
        private string secretCode = "aezakmi";
        [SerializeField] private UnityEvent secretEvent;

        void Start()
        {
            StartCoroutine(ClearInputSequencePeriodically());
        }

        void Update()
        {
            foreach (char c in Input.inputString)
            {
                inputSequence += c;

                if (inputSequence.Contains(secretCode))
                {
                    TriggerSecretEvent();
                    inputSequence = ""; 
                }

                if (inputSequence.Length > secretCode.Length)
                {
                    inputSequence = inputSequence.Substring(inputSequence.Length - secretCode.Length);
                }
            }
        }

        private void TriggerSecretEvent()
        {
            Debug.Log("Secret event triggered!");
            secretEvent.Invoke();
        }

        private IEnumerator ClearInputSequencePeriodically()
        {
            while (true)
            {
                yield return new WaitForSeconds(5.0f);
                inputSequence = "";
                Debug.Log("Input sequence cleared.");
            }
        }
    }
}