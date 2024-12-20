﻿// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace QuackleBit
{
	public class PauseGroup : MonoBehaviour
	{
		[SerializeField] private Button _resumeButton;
		[SerializeField] private Button _optionButton;
		[SerializeField] private Button _quitButton;
		
		public Action<string> Callback; 
		
		private void Start()
		{
			_resumeButton.onClick.AddListener(OnResumeButton);
			_optionButton.onClick.AddListener(OnOptionButton);
			_quitButton.onClick.AddListener(OnQuitButton);
		}
		
		private void OnResumeButton()
		{
			Callback?.Invoke("Resume");
		}
		
		private void OnOptionButton()
		{
			Callback?.Invoke("Option");
		}
		
		private void OnQuitButton()
		{
			Callback?.Invoke("Quit");
		}
	}
}