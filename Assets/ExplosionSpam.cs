using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace QuackleBit
{
    public class ExplosionSpam : MonoBehaviour
    {
        [SerializeField] private GameObject explosionPrefab;
        [SerializeField] private int poolSize = 20;
        [SerializeField] private float initialSpawnInterval = 1.0f;
        [SerializeField] private float finalSpawnInterval = 0.1f;
        [SerializeField] private float intervalDecreaseDuration = 10.0f;
        [SerializeField] private float timerDuration = 15.0f; 
        [SerializeField] private bool useLogarithmicDecrease = true;
        [SerializeField] private Transform targetObject;
        [SerializeField] private float spawnRadius = 5.0f;
        [SerializeField] private UnityEvent onTimerComplete;
        [SerializeField] private SpriteRenderer targetSpriteRenderer; 

        private Queue<GameObject> explosionPool;
        private List<GameObject> activeExplosions;
        private float elapsedTime = 0.0f;

        void Start()
        {
            InitializePool();
            StartCoroutine(SpawnExplosions());
            StartCoroutine(TimerCoroutine());
            StartCoroutine(ManageDeactivations());
        }

        private void InitializePool()
        {
            explosionPool = new Queue<GameObject>();
            activeExplosions = new List<GameObject>();

            for (int i = 0; i < poolSize; i++)
            {
                GameObject explosion = Instantiate(explosionPrefab, this.transform);
                explosion.SetActive(false);

                // Ensure the explosion is rendered at the very front layer
                SpriteRenderer spriteRenderer = explosion.GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    spriteRenderer.sortingOrder = 1000; // Set a high sorting order value
                }

                explosionPool.Enqueue(explosion);
            }
        }

        private IEnumerator SpawnExplosions()
        {
            while (elapsedTime < timerDuration)
            {
                if (explosionPool.Count > 0)
                {
                    SpawnExplosion();
                }
                else
                {
                    Debug.LogWarning("Explosion pool is empty!");
                }

                float currentInterval = CalculateCurrentInterval();
                yield return new WaitForSeconds(currentInterval);
            }

            onTimerComplete.Invoke();
        }

        private void SpawnExplosion()
        {
            GameObject explosion = explosionPool.Dequeue();
            explosion.transform.position = GetRandomPositionAroundTarget();
            explosion.SetActive(true);
            activeExplosions.Add(explosion);

            // Change the color of the target sprite to red and then back to white
            if (targetSpriteRenderer != null)
            {
                StartCoroutine(ChangeColorCoroutine());
            }

            // Schedule deactivation
            StartCoroutine(DeactivateAfterTime(explosion, 1.0f));
        }

        private IEnumerator ChangeColorCoroutine()
        {
            targetSpriteRenderer.color = new Color(1.0f, 0.078f, 0.078f); 
            yield return new WaitForSeconds(0.03f); 
            targetSpriteRenderer.color = Color.white; 
        }

        private float CalculateCurrentInterval()
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / intervalDecreaseDuration);

            return useLogarithmicDecrease
                ? Mathf.Lerp(initialSpawnInterval, finalSpawnInterval, Mathf.Log10(1 + 9 * t))
                : Mathf.Lerp(initialSpawnInterval, finalSpawnInterval, t);
        }

        private Vector2 GetRandomPositionAroundTarget()
        {
            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            float randomDistance = Random.Range(0, spawnRadius);
            return (Vector2)targetObject.position + randomDirection * randomDistance;
        }

        private IEnumerator DeactivateAfterTime(GameObject obj, float time)
        {
            yield return new WaitForSeconds(time);
            obj.SetActive(false);
        }

        private IEnumerator ManageDeactivations()
        {
            while (true)
            {
                for (int i = activeExplosions.Count - 1; i >= 0; i--)
                {
                    if (!activeExplosions[i].activeInHierarchy)
                    {
                        explosionPool.Enqueue(activeExplosions[i]);
                        activeExplosions.RemoveAt(i);
                    }
                }
                yield return new WaitForSeconds(0.5f); // Check for deactivations every 0.5 seconds
            }
        }

        private IEnumerator TimerCoroutine()
        {
            yield return new WaitForSeconds(timerDuration);
            onTimerComplete.Invoke();
        }
    }
}