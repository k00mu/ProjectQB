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
		public void LoadNextSceneWithLoading(Sprite sprite)
		{
			StartCoroutine(LoadNextSceneWithLoadingCoroutine(sprite));
		}
		
		private IEnumerator LoadNextSceneWithLoadingCoroutine()
		{
			FadeIn(Color.black, 1f, false);
			yield return new WaitForSeconds(1f);
			
			SceneManager.LoadScene("Loading");
			
			FadeOut(Color.black, 1f);
			yield return new WaitForSeconds(1f);
			
			yield return new WaitForSeconds(5f);
			
			FadeIn(Color.black, 1f, false);
			yield return new WaitForSeconds(1f);
			
			SceneManager.LoadScene(_nextScene);
			
			FadeOut(Color.black, 1f);
		}
		
		private IEnumerator LoadNextSceneWithLoadingCoroutine(Sprite sprite)
		{
			FadeIn(sprite, 1f, false);
			yield return new WaitForSeconds(1f);
			
			SceneManager.LoadScene("Loading");
			
			FadeOut(sprite, 1f);
			yield return new WaitForSeconds(1f);
			
			yield return new WaitForSeconds(5f);
			
			FadeIn(sprite, 1f, false);
			yield return new WaitForSeconds(1f);
			
			SceneManager.LoadScene(_nextScene);
			
			FadeOut(sprite, 1f);
		}
		
		public void LoadNextScene()
		{
			StartCoroutine(LoadNextSceneCoroutine());
		}
		public void LoadNextScene(Color color)
		{
			StartCoroutine(LoadNextSceneCoroutine(color));
		}
		public void LoadNextScene(Sprite sprite)
		{
			StartCoroutine(LoadNextSceneCoroutine(sprite));
		}
		
		private IEnumerator LoadNextSceneCoroutine()
		{
			FadeIn(Color.black, 1f, false);
			yield return new WaitForSeconds(1f);
			
			SceneManager.LoadScene(_nextScene);
			
			FadeOut(Color.black, 1f);
		}
		
		private IEnumerator LoadNextSceneCoroutine(Color color)
		{
			FadeIn(color, 1f, false);
			yield return new WaitForSeconds(1f);
			
			SceneManager.LoadScene(_nextScene);
			
			FadeOut(color, 1f);
		}

		private IEnumerator LoadNextSceneCoroutine(Sprite sprite)
		{
			FadeIn(sprite, 1f, false);
			yield return new WaitForSeconds(1f);
			
			SceneManager.LoadScene(_nextScene);
			
			FadeOut(sprite, 1f);
		}

		public void FadeIn(Color color, float duration, bool disable = true)
		{
			_screenFade.gameObject.SetActive(true);
			_screenFade.FadeIn(color, duration, disable);
		}
		public void FadeIn(Sprite sprite, float duration, bool disable = true)
		{
			_screenFade.gameObject.SetActive(true);
			_screenFade.FadeIn(sprite, duration, disable);
		}
		
		public void FadeOut(Color color, float duration, bool disable = true)
		{
			_screenFade.gameObject.SetActive(true);
			_screenFade.FadeOut(color, duration, disable);
		}
		public void FadeOut(Sprite sprite, float duration, bool disable = true)
		{
			_screenFade.gameObject.SetActive(true);
			_screenFade.FadeOut(sprite, duration, disable);
		}
	}
}