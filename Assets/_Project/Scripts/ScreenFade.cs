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

		public void FadeIn(float duration, bool disable = true)
		{
			StartCoroutine(FadeImage(_image, _image.color.a, 1, duration, disable));
		}
		
		public void FadeOut(float duration, bool disable = true)
		{
			StartCoroutine(FadeImage(_image, _image.color.a, 0, duration, disable));
		}

		private IEnumerator FadeImage(Image img, float start, float end, float duration, bool disable = true)
		{
			float elapsedTime = 0f;
			Color color = img.color;
			while (elapsedTime < duration)
			{
				elapsedTime += Time.deltaTime;
				color.a = Mathf.Lerp(start, end, elapsedTime / duration);
				img.color = color;
				yield return null;
			}
			color.a = end;
			img.color = color;
			
			if (disable)
				img.gameObject.SetActive(false);
		}
	}
}