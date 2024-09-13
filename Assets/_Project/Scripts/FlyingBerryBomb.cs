// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using Komutils.Extensions;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using System;
using System.Collections;
using UnityEngine;

namespace QuackleBit
{
	public class FlyingBerryBomb : MonoBehaviour
	{
		private Transform _model;
		private BoxCollider2D _collider2D;
		private ThrownObject _thrownObject;
		
		private bool _isColliding;

		private void Awake()
		{
			_collider2D = GetComponent<BoxCollider2D>();
		}

		private void Update()
		{
			if (!_isColliding && _collider2D.isTrigger)
				_collider2D.isTrigger = false;
		}

		private void OnCollisionEnter2D(Collision2D other)
		{
			_isColliding = true;
			_collider2D.isTrigger = true;
		}

		public void MakeOrphan()
		{
			_model = transform.parent.GetChild(0);
			_thrownObject = GetComponent<ThrownObject>();
			if (Mathf.Approximately(_thrownObject.Direction.x, _model.localScale.x))
				_thrownObject.Speed *= -1;
			transform.parent = null;
		}

		public void Destroy()
		{
			Destroy(gameObject);
		}
	}
}