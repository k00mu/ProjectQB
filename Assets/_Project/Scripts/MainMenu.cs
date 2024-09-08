// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using System;
using UnityEngine;

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

		private void Start()
		{
			_menuGroup._callback += HandleMenuGroupCallback;
			_optionGroup._callback += HandleOptionGroupCallback;
		}
		
		private void HandleMenuGroupCallback(string obj)
		{
			switch (obj)
			{
				case "Option":
					ShowOption();
					break;
				case "Quit":
					Komutils.Helpers.QuitGame();
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

		private void ShowState(MenuState state)
		{
			_menuGroup.gameObject.SetActive(state == MenuState.Menu);
			_optionGroup.gameObject.SetActive(state == MenuState.Option);
		}

		private void ShowMenu()
		{
			ShowState(MenuState.Menu);
		}

		private void ShowOption()
		{
			ShowState(MenuState.Option);
		}
	}
}