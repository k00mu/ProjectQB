// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================
using Komutils.Extensions;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace QuackleBit.UI
{
	public class HeartGUI : MonoBehaviour
	{
		/// the sprite to use when the heart is full
		[Tooltip("the sprite to use when the heart is full")]
		public Sprite HeartFull;
		/// the sprite to use when the heart is empty
		[Tooltip("the sprite to use when the heart is empty")]
		public Sprite HeartEmpty;
		/// the size of the heart to display
		[Tooltip("the size of the heart to display")]
		public Vector2 HeartSize = new Vector2(50,50);

		protected List<Image> Hearts;
		
		private Health _health;

		private bool set;

		/// <summary>
		/// On Start we initialize our hearts
		/// </summary>
		protected virtual void Start()
		{
			Initialization();
		}

		/// <summary>
		/// On Init we draw all our provision hearts
		/// </summary>
		protected virtual void Initialization()
		{
			DrawHearts();
		}

		/// <summary>
		/// Draws as many hearts as provisioned
		/// </summary>
		protected virtual void DrawHearts()
		{
			if (!LevelManager.Current) return;

			// we init our list
			Hearts = new List<Image>();

			// we clean any existing hearts
			foreach (Transform child in this.transform)
			{
				Destroy(child.gameObject);
			}
			
			int healthCount = (int)(_health.MaximumHealth / 10f);

			// we draw as many hearts as needed
			for (int i=0; i<healthCount; i++)
			{
				GameObject heart = new GameObject ();
				heart.transform.SetParent (this.transform);
				heart.transform.localPosition = heart.transform.localPosition.With(z:0f);
				heart.name = "Heart" + i;

				Image heartImage = heart.AddComponent<Image> ();
				heartImage.sprite = HeartFull;
				heartImage.preserveAspect = true;

				heart.MMGetComponentNoAlloc<RectTransform> ().localScale = Vector3.one;
				heart.MMGetComponentNoAlloc<RectTransform> ().sizeDelta = HeartSize;

				Hearts.Add (heartImage);
			}
			set = true;
		}

		/// <summary>
		/// On Update we'll keep our hearts updated
		/// </summary>
		protected virtual void Update()
		{
			if (!set)
			{
				_health = LevelManager.Current.Players[0].GetComponent<Health>();
				Initialization();
			}
			else
			{
				UpdateHearts();
			}
		}

		/// <summary>
		/// Every frame we make sure all our hearts are in the desired state
		/// </summary>
		protected virtual void UpdateHearts()
		{
			int healthCount = (int)(_health.CurrentHealth / 10);
			int maxHealthCount = (int)(_health.MaximumHealth / 10);
			for (int i=0; i < maxHealthCount; i++)
			{
				if ((i < maxHealthCount) && (Hearts [i].sprite != HeartEmpty))
				{
					Hearts [i].sprite = HeartEmpty;
				}
					
				if ((i < healthCount) && (Hearts [i].sprite != HeartFull))
				{
					Hearts [i].sprite = HeartFull;
				}

				if ((i < maxHealthCount) && (Hearts [i].enabled == false))
				{
					Hearts [i].enabled = true;
				}

				if ((i >= maxHealthCount) && (Hearts [i].enabled != false))
				{
					Hearts [i].enabled = false;
				}
			}
		}
	}
}