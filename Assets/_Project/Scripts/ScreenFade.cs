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
		private Sprite _defaultSprite;

		private void Awake()
		{
			_image = GetComponent<Image>();
			_defaultSprite = _image.sprite;
		}

		public void FadeIn(Color color, float duration, bool disable = true)
		{
			_image.color = new Color(color.r, color.g, color.b);
			StartCoroutine(FadeImage(_image, _image.color.a, 1, duration, disable));
		}
		public void FadeIn(Sprite sprite, float duration, bool disable = true)
		{
			_image.color = Color.white;
			_image.sprite = sprite;
			StartCoroutine(FadeImage(_image, _image.color.a, 1, duration, disable));
		}

		public void FadeOut(Color color, float duration, bool disable = true)
		{
			_image.color = new Color(color.r, color.g, color.b);
			StartCoroutine(FadeImage(_image, _image.color.a, 0, duration, disable));
		}
		public void FadeOut(Sprite sprite, float duration, bool disable = true)
		{
			_image.color = Color.white;
			_image.sprite = sprite;
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

			img.sprite = _defaultSprite;
		}
	}
}