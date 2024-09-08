// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace QuackleBit
{
	public enum MenuState
	{
		Menu,
		Option,
		Quit
	}
	
	public class MainMenu : MonoBehaviour
	{
		
		[SerializeField] private MenuGroup _menuGroup;
		[SerializeField] private OptionGroup _optionGroup;
		[SerializeField] private QuitGroup _quitGroup;
		
		[SerializeField] private GameObject _overlay;

		private void Start()
		{
			_menuGroup._callback += HandleMenuGroupCallback;
			_optionGroup._callback += HandleOptionGroupCallback;
			_quitGroup._callback += HandleQuitGroupCallback;
		}
		
		private void HandleMenuGroupCallback(string obj)
		{
			switch (obj)
			{
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
					_overlay.SetActive(false);
					ShowMenu();
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(obj), obj, null);
			}
		}

		private void ShowState(MenuState state)
		{
			_menuGroup.gameObject.SetActive(state == MenuState.Menu);
			_optionGroup.gameObject.SetActive(state == MenuState.Option);
			_quitGroup.gameObject.SetActive(state == MenuState.Quit);
		}

		private void ShowMenu()
		{
			ShowState(MenuState.Menu);
		}

		private void ShowOption()
		{
			ShowState(MenuState.Option);
		}

		private void ShowQuit()
		{
			_overlay.SetActive(true);
			ShowState(MenuState.Quit);
		}
	}
}