// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace QuackleBit
{
	public class ScreenFade : MonoBehaviour
	{
		private Image _image;
		
		private void Awake()
		{
			_image = GetComponent<Image>();
		}

		public void FadeIn(float duration)
		{
			StartCoroutine(FadeInCoroutine(duration));
		}
		
		public void FadeOut(float duration)
		{
			StartCoroutine(FadeOutCoroutine(duration));
		}

		private IEnumerator FadeInCoroutine(float duration)
		{
			float t = 0f;
			while (t < 1f)
			{
				t += Time.deltaTime / duration;
				_image.color = new Color(_image.color.r, _image.color.g, _image.color.b, 1f - t);
				yield return null;
			}
		}
		
		private IEnumerator FadeOutCoroutine(float duration)
		{
			float t = 0f;
			while (t < 1f)
			{
				t += Time.deltaTime / duration;
				_image.color = new Color(_image.color.r, _image.color.g, _image.color.b, t);
				yield return null;
			}
		}
	}
}