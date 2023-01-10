using UnityEngine;

namespace Enemy_Controller
{
    public class EnemyController : MonoBehaviour
    {
        private const string EnemyStopper = "EnemyStopper";
        private const string PlayerAttack = "PlayerAttack";
    
        [SerializeField] private Transform player;
        [SerializeField] private float _speed, _timeToRevert;

        public float attackDistance = 2f;
    
        private float _currentTimeToRevert;
        private float _faceDirection = 1f;
        private float _distToPlayer;

        private Animator _animator;
    
        private EnemyStates _currentState;

        private Rigidbody2D _rigidbody2D;
    
        private Vector2 _turnRight;
        private Vector2 _turnLeft;
    
        void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _currentTimeToRevert = 0f;
            _turnRight = new Vector2(1, 1);
            _turnLeft = new Vector2(-1, 1);  
        }
    
        void Update()
        {
            _distToPlayer = Vector2.Distance(_rigidbody2D.position, player.position);

            if (_currentTimeToRevert >= _timeToRevert)
            {
                _currentTimeToRevert = 0;
                _currentState = EnemyStates.RevertState;
            }
        
            AttackPlayer();
        
            switch (_currentState)
            {
                case EnemyStates.IdleState:
                    ChangeAnimationState(0);
                    _currentTimeToRevert += Time.deltaTime;
                    break;
                case EnemyStates.WalkState:
                    ChangeAnimationState(1);
                    _rigidbody2D.velocity = Vector2.right * _speed;
                    break;
                case EnemyStates.RevertState:
                    _faceDirection *= -1;
                    transform.localScale = new Vector3(_faceDirection, 1,1);
                    _speed *= -1;
                    _currentState = EnemyStates.WalkState;
                    break;
                case EnemyStates.AttackState:
                    ChangeAnimationState(3);
                    _currentState = EnemyStates.IdleState;
                    break;
                case EnemyStates.HurtState:
                    ChangeAnimationState(2);
                    _currentState = EnemyStates.IdleState;
                    break;
                case EnemyStates.DeathState:
                    ChangeAnimationState(4);
                    break;
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag(EnemyStopper))
            {
                _currentState = EnemyStates.IdleState;
            }

            if (col.CompareTag(PlayerAttack))
            {
                _currentState = EnemyStates.HurtState;
            }
        }
    
        void ChangeAnimationState(int value)
        {
            _animator.SetInteger("AnimState", value);
        }

        void AttackPlayer()
        {
            if (_distToPlayer < attackDistance)
            {
                if (transform.position.x < player.position.x)
                {
                    transform.localScale = _turnRight;
                }
                else
                {
                    transform.localScale = _turnLeft;
                }            
                _currentState = EnemyStates.AttackState;
            }
        }
    }
}
