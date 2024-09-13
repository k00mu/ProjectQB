// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================
using MoreMountains.CorgiEngine;
using System;
using UnityEngine;
namespace QuackleBit
{
	public class Gameplay : MonoBehaviour
	{
		private Character _targetCharacter;
		private bool _characterSet;

		private void Update()
		{
			if (!_characterSet)
			{
				if (!LevelManager.Current) return;
				if (!LevelManager.Current.Players[0]) return;
				_targetCharacter = LevelManager.Current.Players[0];
				_characterSet = true;
			}
		}
		
		public void EnableDoubleJump()
		{
			_targetCharacter.FindAbility<CharacterJump>().NumberOfJumps = 2;
		}

		public void EnableAttack()
		{
			_targetCharacter.FindAbility<CharacterHandleWeapon>().AbilityPermitted = true;
		}
		
		public void EnableDeflect()
		{
			_targetCharacter.FindAbility<CharacterDeflectProjectile>().AbilityPermitted = true;
		}
		
		public void EnableDash()
		{
			_targetCharacter.FindAbility<CharacterDash>().AbilityPermitted = true;
		}
		
		public void EnableAllAbilities()
		{
			EnableDoubleJump();
			EnableAttack();
			EnableDeflect();
			EnableDash();
		}
	}
}