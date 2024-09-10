// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using MoreMountains.CorgiEngine;
using System;
using TMPro;
using UnityEngine;

namespace QuackleBit
{
	public class PauseSplash : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _titleTextMP;
		
		[SerializeField] private PauseGroup _pauseGroup;
		[SerializeField] private OptionGroup _optionGroup;
		[SerializeField] private QuitGroup _quitGroup;

		private void OnEnable()
		{
			_pauseGroup.Callback += HandlePauseGroupCallback;
			_optionGroup.Callback += HandleOptionGroupCallback;
			_quitGroup.Callback += HandleQuitGroupCallback;
		}

		private void OnDisable()
		{
			_pauseGroup.Callback -= HandlePauseGroupCallback;
			_optionGroup.Callback -= HandleOptionGroupCallback;
			_quitGroup.Callback -= HandleQuitGroupCallback;
		}
		
		private void HandlePauseGroupCallback(string obj)
		{
			switch (obj)
			{
				case "Resume":
					CorgiEngineEvent.Trigger(CorgiEngineEventTypes.TogglePause);
					break;
				case "Option":
					ShowOption();
					break;
				case "Quit":
					ShowQuit();
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(obj), obj, null);
			}
		}
		
		private void HandleOptionGroupCallback(string obj)
		{
			switch (obj)
			{
				case "Back":
					ShowMenu();
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(obj), obj, null);
			}
		}
		
		private void HandleQuitGroupCallback(string obj)
		{
			switch (obj)
			{
				case "No":
					ShowMenu();
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(obj), obj, null);
			}
		}
		
		private void ShowState(MenuState state)
		{
			_pauseGroup.gameObject.SetActive(state == MenuState.Menu);
			_optionGroup.gameObject.SetActive(state == MenuState.Option);
			_quitGroup.gameObject.SetActive(state == MenuState.Quit);
		}
		
		private void ShowMenu()
		{
			_titleTextMP.text = "Game Paused";
			ShowState(MenuState.Menu);
		}
		
		private void ShowOption()
		{
			_titleTextMP.text = "Game Paused";
			ShowState(MenuState.Option);
		}
		
		private void ShowQuit()
		{
			_titleTextMP.text = "Quit Game";
			ShowState(MenuState.Quit);
		}
	}
}