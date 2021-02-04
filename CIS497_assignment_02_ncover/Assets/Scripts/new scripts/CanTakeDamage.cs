/*
 * Nathan Cover
 * CanTakeDamage.cs
 * Assignment_02
 * Class with virtual overwriteable methods. holds base functionality for objects that can take damage.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Assignment_02
{
 public class CanTakeDamage : MonoBehaviour
 {
  [SerializeField] protected int _health = 3;
  [SerializeField] private float _iframeTime = 0.2f;
  private bool _canTakeDamage = true;
  [SerializeField] public GameManager _gameManager;

  public int GetHealth()
  {
   return _health;
  }

  public void TakeDamage()
  {
   TakeDamage(1); //default damage to take if no parameter is specified
  }
    
  public virtual void TakeDamage(int damageToTake)
  {
   if (_canTakeDamage)
   {
    _canTakeDamage = false;
    StartCoroutine(InvincibleFrames());
    _health -= damageToTake;
    if (_health <= 0)
    {
     _health = 0;
     Death();   
    }   
   }
  }
    
  private IEnumerator InvincibleFrames()
  {
   yield return new WaitForSeconds(_iframeTime);
   _canTakeDamage = true;
  }

  protected virtual void Death()
  {
   Destroy(this.gameObject);
  }
 }
}
