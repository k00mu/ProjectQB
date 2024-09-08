// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using Komutils.Extensions;
using MoreMountains.Tools;
using System;
using System.Collections;
using UnityEngine;

namespace QuackleBit
{
	public class FlyingBerryBomb : MonoBehaviour
	{
		private BoxCollider2D _collider2D;

		private void Awake()
		{
			_collider2D = GetComponent<BoxCollider2D>();
		}

		private void Update()
		{
			if (_collider2D.isTrigger)
				_collider2D.isTrigger = false;
		}

		public void MakeOrphan()
		{
			transform.parent = null;
		}

		public void Destroy()
		{
			Destroy(gameObject);
		}
	}
}