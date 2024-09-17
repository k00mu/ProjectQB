// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace QuackleBit
{
	public class QuitGroup : MonoBehaviour
	{
		[SerializeField] private Button _yesButton;
		[SerializeField] private Button _noButton;
		
		public Action<string> Callback; 
		
		private void Start()
		{
			_yesButton.onClick.AddListener(OnYesButtonClick);
			_noButton.onClick.AddListener(OnNoButtonClick);
		}
		
		private void OnYesButtonClick()
		{
			SceneManager.LoadScene("MainMenu");
		}

		private void OnNoButtonClick()
		{
			Callback?.Invoke("No");
		}
	}
}