// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using MoreMountains.CorgiEngine;
using System.Collections;
using UnityEngine;

namespace QuackleBit
{
    public class RandomMovingPlatformTriggerTimer : MonoBehaviour
    {
        [SerializeField] private float minTime = 0f;
        [SerializeField] private float maxTime = 2f;
        private MovingPlatform movingPlatform;
        
        private void Awake()
        {
            movingPlatform = GetComponent<MovingPlatform>();
        }

        private void Start()
        {
            StartCoroutine(TriggerMovingPlatformInRandomTime(minTime, maxTime));
        }
        
        private IEnumerator TriggerMovingPlatformInRandomTime(float min, float max)
        {
            yield return new WaitForSeconds(Random.Range(min, max));
            movingPlatform.AuthorizeMovement();
        }
    }
}