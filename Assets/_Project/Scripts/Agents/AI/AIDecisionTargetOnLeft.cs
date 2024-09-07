// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using MoreMountains.CorgiEngine;
using MoreMountains.Tools;

namespace QuackleBit.Agents.AI
{
	public class AIDecisionTargetOnLeft : AIDecision
	{
		protected Character _targetCharacter;
        
		/// <summary>
		/// On Decide we check whether the Target is facing us
		/// </summary>
		/// <returns></returns>
		public override bool Decide()
		{
			return EvaluateTargetOnLeft();
		}

		/// <summary>
		/// Returns true if the Brain's Target is facing us (this will require that the Target has a Character component)
		/// </summary>
		/// <returns></returns>
		protected virtual bool EvaluateTargetOnLeft()
		{
			if (!_brain.Target)
			{
				return false;
			}

			_targetCharacter = _brain.Target.gameObject.MMGetComponentNoAlloc<Character>();
			if (!_targetCharacter)
				return false;
			
			return this.transform.position.x > _targetCharacter.transform.position.x;
		}
	}
}