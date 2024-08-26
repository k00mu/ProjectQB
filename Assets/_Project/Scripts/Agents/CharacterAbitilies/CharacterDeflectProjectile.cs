// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using UnityEngine;
using Komutils.Extensions;

namespace QuackleBit
{
    public class CharacterDeflectProjectile : CharacterAbility
    {
        [SerializeField] private Vector3 _deflectorOffset = new Vector3(1f, 0f, 0f);
        [SerializeField] private Vector2 _deflectorSize = new Vector2(0.3f, 2.5f);
        private BoxCollider2D _deflector;
        
        protected override void Initialization()
        {
            base.Initialization();
            
            GameObject deflectorObject = new GameObject("Deflector");
            deflectorObject.transform.SetParent(_character.CharacterModel.transform);
            
            int deflectorLayer = LayerMask.NameToLayer("Deflector");
            deflectorObject.layer = deflectorLayer;
            deflectorObject.transform.localPosition = _deflectorOffset;
            
            _deflector = deflectorObject.GetOrAddComponent<BoxCollider2D>();
            _deflector.size = _deflectorSize;
        }
        
        protected override void HandleInput()
        {
            if (_inputManager.SecondaryShootButton.State.CurrentState == MMInput.ButtonStates.ButtonDown)
            {
                DeflectStart();
            }
            
            if (_inputManager.SecondaryShootButton.State.CurrentState == MMInput.ButtonStates.ButtonUp)
            {
                DeflectStop();
            }
        }
        
        private void DeflectStart()
        {
            if (!_deflector)
                return;
            
            _deflector.enabled = true;
        }
        
        private void DeflectStop()
        {
            if (!_deflector)
                return;
            
            _deflector.enabled = false;
        }
    }
}
