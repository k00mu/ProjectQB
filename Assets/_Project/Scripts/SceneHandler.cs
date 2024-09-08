// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using Komutils;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace QuackleBit
{
	public class SceneHandler : MonoBehaviourSingletonDDOL<SceneHandler>
	{
		[SerializeField] private ScreenFade _screenFade;
		private string _currentScene;
		private string _nextScene;

		public string GetCurrentScene()
		{
			return _currentScene;
		}
		
		public void SetNextScene(string nextScene)
		{
			_nextScene = nextScene;
		}
		
		public void LoadNextSceneWithLoading()
		{
			StartCoroutine(LoadNextSceneWithLoadingCoroutine());
		}
		
		private IEnumerator LoadNextSceneWithLoadingCoroutine()
		{
			SceneManager.LoadScene("Loading");
			
			FadeOut(1f);
			yield return new WaitForSeconds(1f);
			
			yield return new WaitForSeconds(5f);
			
			FadeIn(1f, false);
			yield return new WaitForSeconds(1f);
			
			SceneManager.LoadScene(_nextScene);
			FadeOut(1f);
		}

		public void FadeIn(float duration, bool disable = true)
		{
			_screenFade.gameObject.SetActive(true);
			_screenFade.FadeIn(duration, disable);
		}
		
		public void FadeOut(float duration, bool disable = true)
		{
			_screenFade.gameObject.SetActive(true);
			_screenFade.FadeOut(duration, disable);
		}
	}
}