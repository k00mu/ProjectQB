using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuackleBit
{
    public class CheatTeleport : MonoBehaviour
    {
        [SerializeField] private Transform miniboss;
        [SerializeField] private Transform boss;
        private Transform player;

        void Start() {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        public void toMiniboss() {
            player.position = miniboss.position;
        }

        public void toBoss() {
            player.position = boss.position;
        }
    }
}
