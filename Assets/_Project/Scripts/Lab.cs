// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using MoreMountains.CorgiEngine;
using System;
using System.Collections;
using UnityEngine;

namespace QuackleBit
{
	public class Lab : MonoBehaviour
	{
		[SerializeField] private GameObject _labOpeningCutsceneGO;
		[SerializeField] private Sprite _labOpeningCutsceneLastFrameSprite;
		
		private Character _currentCharacter;
		
		
		private void Start()
		{
			StartCoroutine(LabOpeningCoroutine());
		}

		private void Update()
		{
			if (!_currentCharacter&& LevelManager.Current.Players[0])
			{
				_currentCharacter = LevelManager.Current.Players[0];
			}
		}

		private IEnumerator LabOpeningCoroutine()
		{
			yield return new WaitUntil(() => _currentCharacter);
			CharacterHorizontalMovement currentCharacterHZ = _currentCharacter.FindAbility<CharacterHorizontalMovement>();
			
			_labOpeningCutsceneGO.SetActive(true);
			currentCharacterHZ.AbilityPermitted = false;
			
			Animator labOpeningCutsceneAnimator = _labOpeningCutsceneGO.GetComponent<Animator>();
			yield return new WaitUntil(() => labOpeningCutsceneAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f);
			
			SceneHandler.Instance.FadeOut(_labOpeningCutsceneLastFrameSprite, 1f);
			yield return new WaitForSeconds(1f);
			
			_labOpeningCutsceneGO.SetActive(false);
			currentCharacterHZ.AbilityPermitted = true;
		}
	}
}