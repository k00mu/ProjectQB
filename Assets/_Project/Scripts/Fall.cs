// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using UnityEngine;

namespace QuackleBit
{
	public class Fall : MonoBehaviour
	{
		public void FallEnding()
		{
			SceneHandler.Instance.SetNextScene("Gameplay");
			SceneHandler.Instance.LoadNextScene();
		}
	}
}