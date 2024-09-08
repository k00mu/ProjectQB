// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using WaitForSeconds = UnityEngine.WaitForSeconds;

namespace QuackleBit
{
	public class Intro : MonoBehaviour
	{
		[SerializeField] private VideoPlayer _videoPlayer;
		[SerializeField] private TextMeshProUGUI _teamTextMP;
		
		private void Start()
		{
			_teamTextMP.gameObject.SetActive(false);
			_videoPlayer.gameObject.SetActive(false);
			
			StartCoroutine(PlayIntro());
		}
		
		private IEnumerator PlayIntro()
		{
			_videoPlayer.gameObject.SetActive(true);
			
			SceneHandler.Instance.FadeOut(1f);
			yield return new WaitForSeconds(1f);
			
			_videoPlayer.Play();
			yield return new WaitUntil(() => _videoPlayer.isPlaying == false);
			
			SceneHandler.Instance.FadeIn(1f);
			yield return new WaitForSeconds(1f);
			
			_videoPlayer.gameObject.SetActive(false);
			
			_teamTextMP.gameObject.SetActive(true);
			
			SceneHandler.Instance.FadeOut(1f);
			yield return new WaitForSeconds(1f);
			
			yield return new WaitForSeconds(3f);
			
			SceneHandler.Instance.FadeIn(1f);
			yield return new WaitForSeconds(1f);
			
			_teamTextMP.gameObject.SetActive(false);

			SceneHandler.Instance.SetNextScene("MainMenu");
			SceneHandler.Instance.LoadNextSceneWithLoading();
		}
	}
}