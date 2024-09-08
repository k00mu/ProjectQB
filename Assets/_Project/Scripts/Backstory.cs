// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using UnityEngine;

namespace QuackleBit
{
	public class Backstory : MonoBehaviour
	{
		private void Start()
		{
			SceneHandler.Instance.SetNextScene("Lab");
			SceneHandler.Instance.LoadNextSceneWithLoading();
		}
	}
}