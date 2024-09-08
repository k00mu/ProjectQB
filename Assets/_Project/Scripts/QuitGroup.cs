// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using System;
using UnityEngine;
using UnityEngine.UI;

namespace QuackleBit
{
	public class QuitGroup : MonoBehaviour
	{
		[SerializeField] private Button _yesButton;
		[SerializeField] private Button _noButton;
		
		public Action<string> _callback; 
		
		private void Start()
		{
			_yesButton.onClick.AddListener(OnYesButtonClick);
			_noButton.onClick.AddListener(OnNoButtonClick);
		}
		
		private void OnYesButtonClick()
		{
			Komutils.Helpers.QuitGame();
		}

		private void OnNoButtonClick()
		{
			_callback?.Invoke("No");
		}
	}
}