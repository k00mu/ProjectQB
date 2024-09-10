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
	public class OptionGroup : MonoBehaviour
	{
		[SerializeField] private Slider _audioAmountSlider;
		[SerializeField] private Button _backButton;
		
		public Action<string> Callback; 
		
		private void Start()
		{
			_backButton.onClick.AddListener(OnBackButtonClick);
		}
		
		private void OnBackButtonClick()
		{
			Callback?.Invoke("Back");
		}
	}
}