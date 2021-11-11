using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SbSTanks
{
    public class PlayerController : IExecute, IDisposable
    {
        public event Action<ParticleSystem> OnLaunchShell;

        private PlayerModel _playerModel;
        private StepController _stepController;
        private Dictionary<Button, Enemy> _switchEnemyButtonsMatching = new Dictionary<Button, Enemy>();
        private List<Button> _switchEnemyButtons;
        private bool _isOnRotation;
        private bool _isOnRandomRotation;
        private Quaternion _targetRotation;
        private SkillButtonCDStateController _skillButtonCDStateController;

        private const float ROTATION_TIME = 0.5f;
        private float _lerpProgress = 0;
        private Quaternion _startRotation;
        public PlayerController(PlayerModel model, StepController stepController, UIModel uIModel, Enemy[] enemies, 
                    List<Button> switchEnemyButtons, SkillButtonCDStateController skillButtonCDStateController)
        {
            _stepController = stepController;
            _playerModel = model;
            _playerModel.GetpcInputSpace.OnSpaceDown += GetSpaceKey;
            _switchEnemyButtons = switchEnemyButtons;
            _skillButtonCDStateController = skillButtonCDStateController;

            for (int i = 0; i < enemies.Length; i++)
            {
                _switchEnemyButtonsMatching.Add(switchEnemyButtons[i], enemies[i]);
            }

            foreach(var element in _switchEnemyButtonsMatching)
            {
                element.Key.onClick.AddListener(
                    delegate
                    {
                        _targetRotation = Quaternion.LookRotation(element.Value.transform.position - _playerModel.GetPlayer.transform.position);
                        _isOnRotation = true; 
                        _startRotation = _playerModel.GetPlayer.transform.rotation;
                        _lerpProgress = 0; 
                    });
            }

            _playerModel.GetPlayer.OnGetRandomTarget += GetRandomTarget;
            OnLaunchShell += _playerModel.GetPlayer.LaunchShell;
        }

        public void GetRandomTarget()
        {
            _switchEnemyButtons[UnityEngine.Random.Range(0, (_switchEnemyButtons.Count-1))].onClick.Invoke();
            _isOnRandomRotation = true;
        }


        public void GetSpaceKey(bool f)
        {
            _playerModel.IsSpaceDown = f;
        }

        public void Execute(float deltaTime)
        {
            if (_stepController.isPlayerTurn && _playerModel.IsSpaceDown)
            {
                if (!_playerModel.GetPlayer.Parameters.Element.IsActive)
                    return;

                _stepController.isPlayerTurn = false;
                
                _playerModel.GetPlayer.Shot(_playerModel.GetShotEvent);
                _skillButtonCDStateController.AddButtonToCDList();
            }
            if (_isOnRotation)
            {
                RotatePlayer();
            }
        }

        private void RotatePlayer()
        {
            _lerpProgress += Time.deltaTime / ROTATION_TIME;
            _playerModel.GetPlayer.transform.rotation = Quaternion.Lerp(_startRotation, _targetRotation, _lerpProgress);

            if (_lerpProgress >= 1)
            {
                _isOnRotation = false;
                _lerpProgress = 0;
                if (_isOnRandomRotation)
                {
                    _isOnRandomRotation = false;
                    OnLaunchShell.Invoke(_playerModel.GetShotEvent);
                }
            }
        }

        public void Dispose()
        {
            foreach (var element in _switchEnemyButtonsMatching)
            {
                element.Key.onClick.RemoveAllListeners();

            }

            _playerModel.GetpcInputSpace.OnSpaceDown -= GetSpaceKey;
            _playerModel.GetPlayer.OnGetRandomTarget -= GetRandomTarget;
            OnLaunchShell -= _playerModel.GetPlayer.LaunchShell;
        }
    }
}

