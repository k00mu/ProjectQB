// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using UnityEngine;
using Komutils.Extensions;

namespace QuackleBit
{
	public class ForceChangeCameraSize : MonoBehaviour
	{
		[SerializeField] private float _targetSize = 4.5f;
		private Camera _camera;
		
		private void Awake()
		{
			_camera = gameObject.GetOrAddComponent<Camera>();
		}

		private void Update()
		{
			if (Mathf.Approximately(_camera.orthographicSize, _targetSize)) 
				return;
			ChangeCameraSize();
		}

		private void ChangeCameraSize()
		{
			_camera.orthographicSize = _targetSize;
		}
	}
}