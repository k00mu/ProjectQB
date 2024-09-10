// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================
using UnityEngine;
namespace QuackleBit
{
	public class Miniboss : MonoBehaviour
	{
		[SerializeField] private Animator _animator;
		
		public void Stall(bool stall)
		{
			_animator.SetBool("Stall", stall);
		}
	}
}