// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using MoreMountains.CorgiEngine;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
namespace QuackleBit
{
	public class Gameplay : MonoBehaviour
	{
		private Character _targetCharacter;
		private bool _characterSet;
		
		private bool _doubleJumpEnabled;
		private bool _attackEnabled;
		private bool _deflectEnabled;
		private bool _dashEnabled;
		
		private CharacterHandleWeapon _characterHandleWeapon;
		private CharacterJump _characterJump;
		private CharacterDash _characterDash;
		private CharacterDeflectProjectile _characterDeflectProjectile;

		private void Update()
		{
			if (!_characterSet)
			{
				if (!LevelManager.Current) return;
				if (!LevelManager.Current.Players[0]) return;
				_targetCharacter = LevelManager.Current.Players[0];
				_characterSet = true;
				
				_characterHandleWeapon = _targetCharacter.FindAbility<CharacterHandleWeapon>();
				_characterJump = _targetCharacter.FindAbility<CharacterJump>();
				_characterDash = _targetCharacter.FindAbility<CharacterDash>();
				_characterDeflectProjectile = _targetCharacter.FindAbility<CharacterDeflectProjectile>();
			}
			else
			{
				if (_attackEnabled && !_characterHandleWeapon.AbilityPermitted)
					EnableAttack();
				
				if (_deflectEnabled && !_characterDeflectProjectile.AbilityPermitted)
					EnableDeflect();
				
				if (_dashEnabled && !_characterDash.AbilityPermitted)
					EnableDash();
				
				if (_doubleJumpEnabled && !_characterJump.NumberOfJumps.Equals(2))
					EnableDoubleJump();
			}
		}
		
		public void EnableDoubleJump()
		{
			_characterJump.NumberOfJumps = 2;
			_doubleJumpEnabled = true;
		}

		public void EnableAttack()
		{
			_characterHandleWeapon.AbilityPermitted = true;
			_attackEnabled = true;
		}
		
		public void EnableDeflect()
		{
			_characterDeflectProjectile.AbilityPermitted = true;
			_deflectEnabled = true;
		}
		
		public void EnableDash()
		{
			_characterDash.AbilityPermitted = true;
			_dashEnabled = true;
		}
		
		public void EnableAllAbilities()
		{
			EnableDoubleJump();
			EnableAttack();
			EnableDeflect();
			EnableDash();
		}

		public void GameplayEnding()
		{
			SceneHandler.Instance.SetNextScene("Outro");
			SceneHandler.Instance.FadeOut(Color.white,1f,true);
			SceneHandler.Instance.LoadNextScene();
		}
	}
}