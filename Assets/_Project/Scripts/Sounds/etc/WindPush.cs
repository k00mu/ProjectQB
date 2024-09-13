using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuackleBit
{
    public class WindPush : MonoBehaviour
    {
        [SerializeField] private float windForce = 5.0f; // The force of the wind
        [SerializeField] private float duration = 30.0f; // Duration for which the wind effect should run
        private GameObject player;
        private Rigidbody2D playerRb;
        private Coroutine windCoroutine;
        [SerializeField] private GameObject Left;
        [SerializeField] private GameObject Right;

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(FindPlayerAndApplyWind());
        }

        /// <summary>
        /// Update is called every frame, if the MonoBehaviour is enabled.
        /// </summary>
        void Update()
        {
            if (player != null)
            gameObject.transform.position = player.transform.position;
        }

        private IEnumerator FindPlayerAndApplyWind()
        {
            yield return new WaitForSeconds(3.0f);
            player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                playerRb = player.GetComponent<Rigidbody2D>();
                windCoroutine = StartCoroutine(ApplyWindForcePeriodically());
                StartCoroutine(StopWindAfterDuration());
            }
        }

        private IEnumerator ApplyWindForcePeriodically()
        {
            while (true)
            {
                yield return new WaitForSeconds(3.0f);
                if (playerRb != null)
                {
                    ApplyWindForce();
                }
            }
        }

        private void ApplyWindForce()
        {
            float windForceValue = Random.Range(-windForce, windForce); // Randomly choose a value between -5 and 5
            if (windForceValue < 0)
            {
                Left.SetActive(false);
                Right.SetActive(true);
            }
            else
            {
                Left.SetActive(true);
                Right.SetActive(false);
            }
            Vector2 force = new Vector2(windForceValue, 0);
            playerRb.velocity = force; // Directly set the velocity for kinematic Rigidbody2D
            Debug.Log("Wind force applied: " + force);
        }

        private IEnumerator StopWindAfterDuration()
        {
            yield return new WaitForSeconds(duration);
            if (windCoroutine != null)
            {
                StopCoroutine(windCoroutine);
                playerRb.velocity = Vector2.zero; // Set the player's velocity to zero
                Debug.Log("Wind effect stopped after " + duration + " seconds.");
            }
        }
    }
}