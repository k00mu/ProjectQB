using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuackleBit
{
    public class ListenerSwitch : MonoBehaviour
    {
        [SerializeField]private AudioListener listener;
        [SerializeField]private AudioListener roListiner;
        [SerializeField]bool isROAvailable = false;

        void Start()
        {
            listener = GetComponent<AudioListener>();
            listener.enabled = true;
        }

        void Update() {
            //find gameobject with tag "Player"
            GameObject ro = GameObject.FindGameObjectWithTag("Player");
            if (ro != null) {
                //check if the object has a listener
                roListiner = ro.GetComponent<AudioListener>();
                if (roListiner != null) {
                    isROAvailable = true;
                }
            }else{
                isROAvailable = false;
            }
            if (!isROAvailable) {
                listener.enabled = true;
            } else {
                listener.enabled = false;
                roListiner.enabled = true;
            }
        }
    }
}
