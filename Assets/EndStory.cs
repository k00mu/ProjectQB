using System.Collections;
using System.Collections.Generic;
using Komutils.Typewriter;
using UnityEngine;

namespace QuackleBit
{
    public class EndStory : MonoBehaviour
    {
        private float timer = 3f;
        void Start()
        {
            Typewriter.Add("and enjoy the music composed by Nico");
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
