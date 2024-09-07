// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using MoreMountains.CorgiEngine;
using MoreMountains.Tools;

namespace QuackleBit.Agents.AI
{
	public class AIActionFaceToTarget : AIAction
	{
		protected Character _character;
		
		public override void Initialization()
		{
			_character = GetComponentInParent<Character>();
		}

		public override void PerformAction()
		{
			if (this.transform.position.x > _brain.Target.position.x)
			{
				_character.Face(Character.FacingDirections.Left);
			}
			else
			{
				_character.Face(Character.FacingDirections.Right);
			}
		}
	}
}