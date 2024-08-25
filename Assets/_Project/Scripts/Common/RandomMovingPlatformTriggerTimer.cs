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
        private MovingPlatform movingPlatform;
        
        private void Awake()
        {
            movingPlatform = GetComponent<MovingPlatform>();
        }

        private void Start()
        {
            StartCoroutine(TriggerMovingPlatformInRandomTime(0, 3));
        }
        
        private IEnumerator TriggerMovingPlatformInRandomTime(float min, float max)
        {
            yield return new WaitForSeconds(Random.Range(min, max));
            movingPlatform.AuthorizeMovement();
        }
    }
}