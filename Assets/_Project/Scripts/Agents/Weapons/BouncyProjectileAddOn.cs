﻿// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using MoreMountains.CorgiEngine;
using UnityEngine;

namespace QuackleBit
{
	public class BouncyProjectileAddOn : BouncyProjectile
	{
		public void SetSpeed(float speed)
		{
			Speed = speed;
		}
		
		protected override void Bounce(RaycastHit2D hit)
		{
			BounceFeedback?.PlayFeedbacks();
			
			if (_owner != null)
			{
				_reflectedDirection = (_owner.transform.position - transform.position).normalized;
				Direction = _reflectedDirection.normalized;
			}
			else
			{	
				_reflectedDirection = Vector3.Reflect(_raycastDirection, hit.normal);
				// you could then get the bounce angle like so
				// float angle = Vector3.Angle(_raycastDirection, _reflectedDirection);
				Direction = _reflectedDirection.normalized;
			}
			
			this.transform.right = _spawnerIsFacingRight ? _reflectedDirection.normalized : -_reflectedDirection.normalized;
			
			Speed *= _randomSpeedModifier;
			_bouncesLeft--;
		}
	}
}