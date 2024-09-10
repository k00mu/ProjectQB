// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using Komutils.Typewriter;
using System.Collections;
using UnityEngine;

namespace QuackleBit
{
	public class Backstory : MonoBehaviour
	{
		private float timer;
		
		private void Start()
		{
			Typewriter.Add("Once upon a time, in a future where Earth's\noxygen levels had dropped to critical levels,\nhumanity struggled to survive...");
			Typewriter.Add("In a hidden laboratory, a scientist conducted secret experiments,\ncreating Ro, a tiny humanoid plant designed as a last hope\nfor a dying world...");
			Typewriter.Add("As time passed, humanity could no longer endure...");
			Typewriter.Add("Centuries later, Ro was born into a world on the brink of collapse.\nShe was born, and the world was nearly at its end...");
			Typewriter.Add("A Journey of a Wildflower Ro...", () => {
                StartCoroutine(EndBackstory());
			});
            
            Typewriter.Activate();
		}
		private IEnumerator EndBackstory()
		{
			yield return new WaitForSeconds(3f);
			SceneHandler.Instance.SetNextScene("Lab");
			SceneHandler.Instance.LoadNextSceneWithLoading();
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
			{
				Typewriter.Instance.WriteNextStringInQueue();
				timer = 0f;
			}

			if (Typewriter.Instance.IsActive())
				return;
			
			timer += Time.deltaTime;
			if (!(timer > 5f))
				return;
				
			Typewriter.Instance.WriteNextStringInQueue();
			timer = 0f;
		}
	}
}