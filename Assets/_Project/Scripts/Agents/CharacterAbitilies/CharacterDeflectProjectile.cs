// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using UnityEngine;
using Komutils.Extensions;
using System.Collections;

namespace QuackleBit
{
    public class CharacterDeflectProjectile : CharacterAbility
    {
        [SerializeField] private Vector3 _deflectorOffset = new Vector3(1f, 0f, 0f);
        [SerializeField] private Vector2 _deflectorSize = new Vector2(0.3f, 2.5f);
        
        [SerializeField] private bool _canMove;
        [SerializeField] private float _chargingTime = 0.5f;
        
        [SerializeField] private GameObject _deflector;
        private IEnumerator _deflectCoroutine;
        private WaitForSeconds _chargingWFS;
        private bool _isDeflecting;
        
        protected override void Initialization()
        {
            base.Initialization();
            
            int deflectorLayer = LayerMask.NameToLayer("Deflector");
            _deflector.layer = deflectorLayer;
            
            _deflector.SetActive(false);
            _chargingWFS = new WaitForSeconds(_chargingTime);
        }
        
        protected override void HandleInput()
        {
            if (!AbilityPermitted)
                return;
            
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
            
            if (!_canMove) 
                _characterHorizontalMovement.MovementForbidden = true;
            
            _deflectCoroutine = DeflectCoroutine();
            StartCoroutine(_deflectCoroutine);
        }

        private IEnumerator DeflectCoroutine()
        {
            MMAnimatorExtensions.UpdateAnimatorBool(_animator, _deflectChargingAnimationParameter, true, _character._animatorParameters, _character.PerformAnimatorSanityChecks);
            yield return _chargingWFS;
            MMAnimatorExtensions.UpdateAnimatorBool(_animator, _deflectChargingAnimationParameter, false, _character._animatorParameters, _character.PerformAnimatorSanityChecks);

            _isDeflecting = true;
            _deflector.SetActive(true);
        }
        
        private void DeflectStop()
        {
            if (!_deflector)
                return;
            
            _deflector.SetActive(false);
            _isDeflecting = false;
            
            if (!_canMove)
                _characterHorizontalMovement.MovementForbidden = false;
        }
        
        public void SetChargingTime(float time)
        {
            _chargingTime = time;
            _chargingWFS = new WaitForSeconds(_chargingTime);
        }
        
        // animation parameters
        protected const string _deflectChargingAnimationParameterName = "DeflectCharging";
        protected int _deflectChargingAnimationParameter;
        protected const string _deflectingAnimationParameterName = "Deflecting";
        protected int _deflectingAnimationParameter;

        /// <summary>
        /// Adds required animator parameters to the animator parameters list if they exist
        /// </summary>
        protected override void InitializeAnimatorParameters()
        {
            RegisterAnimatorParameter(_deflectingAnimationParameterName, AnimatorControllerParameterType.Bool, out _deflectingAnimationParameter);
            RegisterAnimatorParameter(_deflectChargingAnimationParameterName, AnimatorControllerParameterType.Bool, out _deflectChargingAnimationParameter);
        }

        /// <summary>
        /// At the end of each cycle, we send our Running status to the character's animator
        /// </summary>
        public override void UpdateAnimator()
        {
            MMAnimatorExtensions.UpdateAnimatorBool(_animator, _deflectingAnimationParameter, (_isDeflecting), _character._animatorParameters);
        }

        /// <summary>
        /// On reset ability, we cancel all the changes made
        /// </summary>
        public override void ResetAbility()
        {
            base.ResetAbility();
            if (_animator)
            {
                MMAnimatorExtensions.UpdateAnimatorBool(_animator, _deflectChargingAnimationParameter, false, _character._animatorParameters, _character.PerformAnimatorSanityChecks);    
                MMAnimatorExtensions.UpdateAnimatorBool(_animator, _deflectingAnimationParameter, false, _character._animatorParameters, _character.PerformAnimatorSanityChecks);
            }
            
            if (_deflector)
                _deflector.SetActive(false);
            
            _isDeflecting = false;
        }
    }
}
