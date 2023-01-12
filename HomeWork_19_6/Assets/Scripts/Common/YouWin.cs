using System;
using UnityEngine;

namespace Common
{
    public class YouWin : MonoBehaviour
    {
        private const string AnimState = "AnimState";
        private const string PlayerTag = "Player";
        
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag(PlayerTag))
                _animator.SetInteger(AnimState,1);
        }
    }
}
