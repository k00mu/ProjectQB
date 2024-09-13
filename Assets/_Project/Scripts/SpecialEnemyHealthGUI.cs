// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using MoreMountains.CorgiEngine;
using UnityEngine;
using UnityEngine.UI;

namespace QuackleBit
{
	public class SpecialEnemyHealthGUI : MonoBehaviour
	{
		[SerializeField] private Slider _slider;
		[SerializeField] private GameObject _handleSlideArea;
		[SerializeField] private Health _health;

		protected virtual void Update()
		{
			UpdateHealth();
		}

		protected virtual void UpdateHealth()
		{
			float healthPercentage = _health.CurrentHealth / _health.MaximumHealth;

			_slider.value = healthPercentage;

			_handleSlideArea.SetActive(_slider.value is <= 0.975f and >= 0.025f);
		}
	}
}