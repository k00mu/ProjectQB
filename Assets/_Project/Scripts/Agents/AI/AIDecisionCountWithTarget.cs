// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using MoreMountains.Tools;
using UnityEngine;
namespace QuackleBit.Agents.AI
{
	public class AIDecisionCountWithTarget : AIDecision
	{
		[SerializeField] private int _targetCount = 3;
		private int _currentCount;
		
		public override void Initialization()
		{
			_currentCount = 0;
		}

		public override bool Decide()
		{
			return EvaluateCount();
		}
		
		private bool EvaluateCount()
		{
			if (_currentCount >= _targetCount)
			{
				_currentCount = 0;
				return true;
			}
			
			_currentCount++;
			return false;
		}
	}
}