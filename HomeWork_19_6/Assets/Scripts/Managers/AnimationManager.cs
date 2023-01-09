using Player_Controller.Collision;
using Player_Controller.Player_Behaviours;
using Player_Controller.Player_Inputs;
using UnityEngine;

namespace Managers
{
    public class AnimationManager : MonoBehaviour
    {
        private InputState _inputState;
        private Walk _walkBehaviour;
        private Animator _animator;
        private CollisionState _collisionState;
        private Health _health;

        private void Awake()
        {
            _inputState = GetComponent<InputState>();
            _walkBehaviour = GetComponent<Walk>();
            _animator = GetComponent<Animator>();
            _collisionState = GetComponent<CollisionState>();
            _health = GetComponent<Health>();
        }

        void Update()
        {
            if (_collisionState.isGrounded)
            {
                ChangeAnimationState(0);
            }
        
            if (_inputState.absVelocityX > 0)
            {
                ChangeAnimationState(1);
            }

            if (_walkBehaviour.isRunning)
            {
                ChangeAnimationState(2);
            }

            if (_inputState.absVelocityY > 0)
            {
                ChangeAnimationState(3);
            }
            
            if (!_collisionState.isGrounded && _collisionState.isOnWall)
            {
                ChangeAnimationState(4);
            }
            
            if (_health.receivedDamage)
            {
                ChangeAnimationState(5);
            }

            if (!_health.isAlive)
            {
                ChangeAnimationState(6);
            }
        }

        void ChangeAnimationState(int value)
        {
            _animator.SetInteger("AnimState", value);
        }
    }
}
