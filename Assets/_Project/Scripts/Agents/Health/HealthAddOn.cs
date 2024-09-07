// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using MoreMountains.CorgiEngine;
using System.Collections.Generic;
using UnityEngine;

namespace QuackleBit
{
	public class HealthAddOn : Health
	{
		public override void Damage(float damage, GameObject instigator, float flickerDuration,
			float invincibilityDuration, Vector3 damageDirection, List<TypedDamage> typedDamages = null)
		{
			if (MasterHealth)
			{
				MasterHealth.Damage(damage, instigator, flickerDuration, invincibilityDuration, damageDirection, typedDamages);
			}
			else
			{
				base.Damage(damage, instigator, flickerDuration, invincibilityDuration, damageDirection, typedDamages);
			}
		}
	}
}