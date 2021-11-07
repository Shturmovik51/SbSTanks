using System;
using TMPro;
using UnityEngine;

namespace SbSTanks
{
    public class StepController: IExecute
    {
        public bool isPlayerTurn = true;

        private TimerData _startTurnTimer;
        private TimerData _shotDelayTimer;
        private TimerData _endTurnTimer;
        private bool _isDelay = false;
        private Enemy[] _enemies;
        private Player _player;
        private TimerController _timerController;
        private int _currentEnemyTurnIndex;
        private int _step;
        private TextMeshProUGUI _stepText;

        public StepController(Enemy[] enemies, Player player, TimerController timerController, GameInitializationData data)
        {
            _enemies = enemies;
            _timerController = timerController;
            _stepText = data.StepPanelText;
            _stepText.text = (_step + 1).ToString();
            _player = player;
        }

        public void EnemiesTurn()
        {
            _startTurnTimer = new TimerData(2f, Time.time);
            _timerController.AddTimer(_startTurnTimer);
        }

        public void Execute(float deltaTime)
        {
            CheckStartTurn();

            CheckDelay();

            CheckEndTurn();
        }

        private void CheckEndTurn()
        {
            if (!(_endTurnTimer is null))
            {
                if (_endTurnTimer.IsTimerEnd)
                {
                    isPlayerTurn = true;
                    //for (int i = 0; i < _enemies.Length; i++)
                    //{
                    //    _enemies[i].isShotReturn = false;
                    //}

                    _endTurnTimer = null;
                    _isDelay = false;

                    if(_currentEnemyTurnIndex == 0)
                    {
                        _stepText.text = (_step + 1).ToString();
                        UpdateUnitElements();
                    }
                }
                _startTurnTimer = null;
            }
        }

        private void CheckDelay()
        {
            if (!(_shotDelayTimer is null))
            {
                if (_shotDelayTimer.IsTimerEnd)
                {
                    _isDelay = false;
                    _shotDelayTimer = null;
                }
            }
        }

        private void CheckStartTurn()
        {
            if (!(_startTurnTimer is null) && isPlayerTurn == false)
            {
                if (_startTurnTimer.IsTimerEnd)
                {
                    for (int i = 0; i < _enemies.Length; i++)
                    {
                        //if (!_isDelay && !_enemies[i].isShotReturn && i < _enemies.Length - 1)
                        //{
                        //    _shotDelayTimer = new TimerData(1f, Time.time);
                        //    EnemyShot(i, _shotDelayTimer);
                        //}
                        //else if (!_isDelay && i == _enemies.Length - 1)
                        //{
                        //    _endTurnTimer = new TimerData(4f, Time.time);
                        //    EnemyShot(i, _endTurnTimer);
                        //}    
                        
                        if(i == _currentEnemyTurnIndex)
                        {
                            _endTurnTimer = new TimerData(4f, Time.time);
                            EnemyShot(i, _endTurnTimer);
                        }                      

                    }

                    _currentEnemyTurnIndex++;

                    if (_currentEnemyTurnIndex > _enemies.Length - 1)
                    {
                        StartNewTurn();
                    }
                }
            }
        }

        private void UpdateUnitElements()
        {
            foreach (var enemy in _enemies)
            {
                enemy.ChangingElement();
            }

            _player.ChangingElement();
        }

        private void StartNewTurn()
        {
            for (int i = 0; i < _enemies.Length; i++)
            {
                _enemies[i].isShotReturn = false;
            }

            _currentEnemyTurnIndex = 0;
            _step++;
           // _stepText.text = (_step + 1).ToString();
        }

        private void EnemyShot(int index, TimerData timer)
        {
            _enemies[index].ReturnShot();
            _enemies[index].isShotReturn = true;
            _isDelay = true;
            _timerController.AddTimer(timer);
        }
    }
}
