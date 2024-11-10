using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.CorgiEngine
{
    public class Stamina : MonoBehaviour
    {
        public float maxStamina = 100;
        public float stamina = 100;
        public float drain = 0.1f;

        public CharacterGlide characterGlide;

        // Update is called once per frame
        void Update()
        {
            if (characterGlide._gliding)
            {
                //Drain stamina per second
                stamina -= drain * Time.deltaTime;
            }
            if(stamina <= 0)
            {
                characterGlide.GlideStop();
            }
        }

        public void ResetStamina()
        {
            stamina = maxStamina;
        }
    }
}
