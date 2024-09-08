// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;
using WaitForSeconds = UnityEngine.WaitForSeconds;

namespace QuackleBit
{
	public class Intro : MonoBehaviour
	{
		[SerializeField] private VideoPlayer _videoPlayer;
		[SerializeField] private RawImage _logoRawImage;
		[SerializeField] private TextMeshProUGUI _teamTextMP;
		
		private void Start()
		{
			_videoPlayer.gameObject.SetActive(false);
			_logoRawImage.gameObject.SetActive(false);
			_teamTextMP.gameObject.SetActive(false);
			
			string videoUrl= System.IO.Path.Combine(Application.streamingAssetsPath, "Logo.mp4");
			_videoPlayer.url = videoUrl;
			
			StartCoroutine(PlayIntro());
		}
		
		private IEnumerator PlayIntro()
		{
			_videoPlayer.gameObject.SetActive(true);
			_logoRawImage.gameObject.SetActive(true);
			
			SceneHandler.Instance.FadeOut(Color.black, 1f);
			yield return new WaitForSeconds(1f);
			
			_videoPlayer.Play();
			yield return new WaitUntil(() => _videoPlayer.isPlaying);
			yield return new WaitUntil(() => !_videoPlayer.isPlaying);
			
			SceneHandler.Instance.FadeIn(Color.black, 1f);
			yield return new WaitForSeconds(1f);
			
			_videoPlayer.gameObject.SetActive(false);
			_logoRawImage.gameObject.SetActive(false);
			_teamTextMP.gameObject.SetActive(true);
			
			SceneHandler.Instance.FadeOut(Color.black, 1f);
			yield return new WaitForSeconds(1f);
			
			yield return new WaitForSeconds(3f);

			SceneHandler.Instance.SetNextScene("MainMenu");
			SceneHandler.Instance.LoadNextSceneWithLoading();
		}
	}
}