// ==================================================
// 
//   Created by Atqa Munzir & Nico Dicky Hermawan
// 
// ==================================================

using MoreMountains.CorgiEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuackleBit
{
	public class Boss : MonoBehaviour
	{
		[Header("References")]
		[SerializeField] private Animator _animator;
		
		[Header("Ultimate")]
		[SerializeField] private GameObject _ultimatePrefab;
		[SerializeField] private Transform[] _ultimateBulletPointArray;
		private List<GameObject> _ultimateBulletList;
		
		[Header("Weakness")]
		[SerializeField] private GameObject _weaknessPrefab;
		[SerializeField] private Transform _weaknessPoint;
		private GameObject _weaknessBullet;
		
		private Character _targetCharacter;

		private Coroutine _attackCoroutine;

		public void Activate()
		{
			_targetCharacter = LevelManager.Current.Players[0];
			
			StartCoroutine(EndlessPatternCoroutine());
		}

		private IEnumerator EndlessPatternCoroutine()
        {
            while (true)
            {
                int patternIndex = Random.Range(0, 3); 
                switch (patternIndex)
                {
                    case 0:
                        yield return StartCoroutine(Pattern1Coroutine());
                        break;
                    case 1:
                        yield return StartCoroutine(Pattern2Coroutine());
                        break;
                    case 2:
                        yield return StartCoroutine(Pattern3Coroutine());
                        break;
                }
            }
        }

		private void Start()
		{
			_ultimateBulletList = new List<GameObject>();
			
			foreach (Transform t in _ultimateBulletPointArray)
			{
				GameObject ultimateBullet = Instantiate(_ultimatePrefab, t.position, Quaternion.identity);
				ultimateBullet.transform.parent = t;
				ultimateBullet.SetActive(false);
				_ultimateBulletList.Add(ultimateBullet);
			}
			_weaknessBullet = Instantiate(_weaknessPrefab, _weaknessPoint);
			_weaknessBullet.SetActive(false);
		}


		
		private IEnumerator NormalAttackCoroutine(string attackName)
		{
			_animator.Play(attackName);
			yield return new WaitUntil(() => _animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f);
		}
		
		private IEnumerator UltimateAttackCoroutine()
		{
			for (int i = 0; i < _ultimateBulletList.Count; i++)
			{
				GameObject bullet = _ultimateBulletList[i];
				bullet.transform.position = _ultimateBulletPointArray[i].position;
				Projectile projectile = bullet.GetComponent<Projectile>();

				Vector3 direction = _targetCharacter.transform.position - bullet.transform.position;
				direction.Normalize();

				projectile.SetDirection(direction, Quaternion.identity);
			}
			
			_animator.Play("ultimate");
			yield return new WaitForSeconds(0.2f);
			foreach (GameObject bullet in _ultimateBulletList)
			{
				bullet.SetActive(true);
			}
			yield return new WaitUntil(() => _animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f);
		}
		
		
		private IEnumerator WeaknessAttackCoroutine()
		{
			_weaknessBullet.transform.position = _weaknessPoint.position;
			Projectile projectile = _weaknessBullet.GetComponent<Projectile>();
			
			Vector3 direction = _targetCharacter.transform.position - _weaknessBullet.transform.position;
			direction.Normalize();
			projectile.SetOwner(gameObject);
			
			projectile.SetDirection(direction, Quaternion.identity);
			
			_animator.Play("weakness");
			yield return new WaitForSeconds(0.2f);
			_weaknessBullet.SetActive(true);
			yield return new WaitUntil(() => _animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f);
		}

		private IEnumerator Pattern1Coroutine()
        {
            yield return StartCoroutine(NormalAttackCoroutine("left"));
            yield return new WaitForSeconds(Random.Range(2f, 5f));
            
            yield return StartCoroutine(NormalAttackCoroutine("left"));
            yield return new WaitForSeconds(Random.Range(2f, 5f));
            
            yield return StartCoroutine(NormalAttackCoroutine("middle"));
            yield return new WaitForSeconds(Random.Range(2f, 5f));
            
            yield return StartCoroutine(NormalAttackCoroutine("right"));
            yield return new WaitForSeconds(Random.Range(2f, 5f));
            
            yield return StartCoroutine(NormalAttackCoroutine("right"));
            yield return new WaitForSeconds(Random.Range(2f, 5f));
            
            yield return StartCoroutine(UltimateAttackCoroutine());
            yield return new WaitForSeconds(Random.Range(2f, 5f));
            
            yield return StartCoroutine(UltimateAttackCoroutine());
            yield return new WaitForSeconds(Random.Range(2f, 5f));
            
            yield return StartCoroutine(UltimateAttackCoroutine());
        }

        private IEnumerator Pattern2Coroutine()
        {
            yield return StartCoroutine(NormalAttackCoroutine("middle"));
            yield return new WaitForSeconds(Random.Range(2f, 5f));
            
            yield return StartCoroutine(NormalAttackCoroutine("right"));
            yield return new WaitForSeconds(Random.Range(2f, 5f));
            
            yield return StartCoroutine(NormalAttackCoroutine("left"));
            yield return new WaitForSeconds(Random.Range(2f, 5f));
            
            yield return StartCoroutine(UltimateAttackCoroutine());
            yield return new WaitForSeconds(Random.Range(2f, 5f));
            
            yield return StartCoroutine(UltimateAttackCoroutine());
            yield return new WaitForSeconds(Random.Range(2f, 5f));
            
            yield return StartCoroutine(WeaknessAttackCoroutine());
        }

        private IEnumerator Pattern3Coroutine()
        {
            yield return StartCoroutine(NormalAttackCoroutine("right"));
            yield return new WaitForSeconds(Random.Range(2f, 5f));
            
            yield return StartCoroutine(NormalAttackCoroutine("middle"));
            yield return new WaitForSeconds(Random.Range(2f, 5f));
            
            yield return StartCoroutine(NormalAttackCoroutine("left"));
            yield return new WaitForSeconds(Random.Range(2f, 5f));
            
            yield return StartCoroutine(WeaknessAttackCoroutine());
            yield return new WaitForSeconds(Random.Range(2f, 5f));
            
            yield return StartCoroutine(UltimateAttackCoroutine());
            yield return new WaitForSeconds(Random.Range(2f, 5f));
            
            yield return StartCoroutine(UltimateAttackCoroutine());
        }
	}
}