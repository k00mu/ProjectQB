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
	public class TooltipContainer : MonoBehaviour
	{
		[SerializeField] private Sprite _attackTooltip;
		[SerializeField] private Sprite _dashTooltip;
		[SerializeField] private Sprite _deflectTooltip;
		[SerializeField] private Sprite _doubleJumpTooltip;
		[SerializeField] private Sprite _paraglideTooltip;

		[SerializeField] private Image _image;
		private CanvasGroup _canvasGroup;
		
		private void OnEnable()
		{
			_canvasGroup = GetComponent<CanvasGroup>();
		}
		
		public void ShowTooltip(Sprite sprite)
		{
			_image.sprite = sprite;
			_canvasGroup.alpha = 1;
			_canvasGroup.interactable = true;
			_canvasGroup.blocksRaycasts = true;
		}
		
		public void ShowAttackTooltip()
		{
			ShowTooltip(_attackTooltip);
		}
		
		public void ShowDeflectTooltip()
		{
			ShowTooltip(_deflectTooltip);
		}
		
		public void ShowDashTooltip()
		{
			ShowTooltip(_dashTooltip);
		}
		
		public void ShowDoubleJumpTooltip()
		{
			ShowTooltip(_doubleJumpTooltip);
		}
	}
}