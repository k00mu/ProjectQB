// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using WaitForSeconds = UnityEngine.WaitForSeconds;

namespace QuackleBit
{
	public class Intro : MonoBehaviour
	{
		[SerializeField] private VideoPlayer _videoPlayer;
		[SerializeField] private ScreenFade _screenFade;
		
		private void Start()
		{
			StartCoroutine(PlayIntro());
		}
		
		private IEnumerator PlayIntro()
		{
			_screenFade.FadeIn(0.5f);
			yield return new WaitForSeconds(0.5f);
			_videoPlayer.Play();
			yield return new WaitUntil(() => _videoPlayer.isPlaying == false);
			_screenFade.FadeOut(0.5f);
			yield return new WaitForSeconds(0.5f);
			SceneManager.LoadScene("Loading");
		}
	}
}