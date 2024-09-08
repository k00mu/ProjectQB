// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using Komutils.Typewriter;
using UnityEngine;

namespace QuackleBit
{
	public class Backstory : MonoBehaviour
	{
		
		
		private void Start()
		{
			Typewriter.Add("Once upon a time, in a future where Earth's\noxygen levels had dropped to critical levels,\nhumanity struggled to survive...");
			Typewriter.Add("In a hidden laboratory, a scientist conducted secret experiments,\ncreating Ro, a tiny humanoid plant designed as a last hope\nfor a dying world...");
			Typewriter.Add("As time passed, humanity could no longer endure...");
			Typewriter.Add("Centuries later, Ro was born into a world on the brink of collapse.\nShe was born, and the world was nearly at its end...");
			Typewriter.Add("A Journey of a Wildflower Ro...", () => {
                SceneHandler.Instance.SetNextScene("Lab");
                SceneHandler.Instance.LoadNextSceneWithLoading();
			});
            
            Typewriter.Activate();
		}
		
		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Return))
			{
				Typewriter.Instance.WriteNextStringInQueue();
			}
		}
	}
}