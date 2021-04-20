using Interfaces;
using UnityEngine;
using Extensions;


namespace Player
{
    class PlayerController : IExecutable, ICleanable, IInitializable
    {
        #region Fields

        private PlayerModel _playerModel;
        private PlayerView _playerView;
        private float _horizontalValue;
        private float _verticalValue;
        private IInputProvider _horizontalInputProider;
        private IInputProvider _verticalInputProvider;
        private Rigidbody _rigidbody;
        private IMoralProvider _moralProvider;
        private Vector3 _moveDirection;
        private Animator _animator;
        private AudioSource _audioSource;
        private float _timeToStep, _currentTimeToStep;
        private AnimationEvent _animationEvent;
        private int isWalkingHash;

        #endregion

        #region Constructor

        public PlayerController(PlayerModel playerModel, PlayerView playerView, (IInputProvider horizontal, IInputProvider vertical) input, IMoralProvider moralProvider)
        {
            this._playerModel = playerModel;
            this._playerView = playerView;
            this._moralProvider = moralProvider;
            this._moralProvider.onPlayerHPChange += ChangePlayerHp;
            this._playerView.OnStepPlay += StepSoundPlay;
            _horizontalInputProider = input.horizontal;
            _verticalInputProvider = input.vertical;
            _horizontalInputProider.OnAxisChange += OnHorizontalAxisChange;
            _verticalInputProvider.OnAxisChange += OnVerticalAxisChange;
            _rigidbody = this._playerView.gameObject.GetOrAddComponent<Rigidbody>();
            _rigidbody.freezeRotation = true;
            _playerView.OnRoomEnter += RoomEnter;
            _animator = _playerView.gameObject.GetComponent<Animator>();
            _audioSource = _playerView.GetComponent<AudioSource>();
            _audioSource.playOnAwake = false;
            _timeToStep = 0.3f;
            _currentTimeToStep = _timeToStep;
            isWalkingHash = Animator.StringToHash("isWalking");
        }




        #endregion

        #region Methods

        private void RoomEnter(string nameRoom)
        {
            return;
        }

        private void ChangePlayerHp(float damage)
        {
            _playerModel.PlayerStruct.HP -= damage;
        }

        private void OnVerticalAxisChange(float value)
        {
            _verticalValue = value;
        }

        private void OnHorizontalAxisChange(float value)
        {
            _horizontalValue = value;
        }

        public void Clean()
        {
            _horizontalInputProider.OnAxisChange -= OnHorizontalAxisChange;
            _verticalInputProvider.OnAxisChange -= OnVerticalAxisChange;
            this._moralProvider.onPlayerHPChange -= ChangePlayerHp;
        }

        public void Execute(float deltaTime)
        {
            Move(deltaTime);
            CheckHealth();
        }

        private void Move(float deltaTime)
        {
            //if (_currentTimeToStep < 0)
            //{
            //    _audioSource.Play();
            //    _currentTimeToStep = _timeToStep;
            //}
            _moveDirection = new Vector3(_horizontalValue, 0, _verticalValue).normalized * _playerModel.PlayerStruct.Speed;
            //_rigidbody.velocity = new Vector3(_moveDirection.x, _rigidbody.velocity.y, _moveDirection.z);
            if (_moveDirection.sqrMagnitude > 0)
            {
                _currentTimeToStep -= deltaTime;
                _animator.SetBool(isWalkingHash, true);
            }
            else
            {
                _animator.SetBool(isWalkingHash, false);
            }
            if (_moveDirection.sqrMagnitude > 0)
            {
                Quaternion newRotation = Quaternion.LookRotation(_moveDirection);
                _playerView.transform.rotation = Quaternion.Slerp(_playerView.transform.rotation, newRotation, Time.deltaTime * _playerModel.PlayerStruct.TurningSpeed);
            }
            

        }

        private void CheckHealth()
        {
            if (_playerModel.PlayerStruct.HP < 0)
            {
                Die();
            }
        }

        public void StepSoundPlay()
        {
            _audioSource.Play();
        }

        private void Die() 
        {
            _playerView.gameObject.SetActive(false);
        }

        public void Initialize()
        {
            
        }

        #endregion
    }
}
