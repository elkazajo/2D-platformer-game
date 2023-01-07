using Player_Controller.Collision;
using Player_Controller.Player_Behaviours;
using Player_Controller.Player_Inputs;
using UnityEngine;

namespace Managers
{
    public class PlayerManager : MonoBehaviour
    {
        private InputState _inputState;
        private Walk _walkBehaviour;
        private Animator _animator;
        private CollisionState _collisionState;

        private void Awake()
        {
            _inputState = GetComponent<InputState>();
            _walkBehaviour = GetComponent<Walk>();
            _animator = GetComponent<Animator>();
            _collisionState = GetComponent<CollisionState>();
        }

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
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
        }

        void ChangeAnimationState(int value)
        {
            _animator.SetInteger("AnimState", value);
        }
    }
}
