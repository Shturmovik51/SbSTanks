using System;
using TMPro;
using UnityEngine;

namespace SbSTanks
{
    public class StepController: IExecute
    {
        public event Action OnChangeTurn;
        public event Action OnEndGame;
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
            if (AllEnemiesDeathCheck())
                _startTurnTimer = new TimerData(0f, Time.time);
            else
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

                    StartNewTurn();

                    //if(_currentEnemyTurnIndex == 0)
                    //{
                    //    _stepText.text = (_step + 1).ToString();
                    //    OnChangeTurn.Invoke();
                    //    UpdateUnitElements();

                    //}
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
                        if (!_isDelay && !_enemies[i].isShotReturn && i < _enemies.Length - 1)
                        {
                            _shotDelayTimer = new TimerData(1f, Time.time);
                            EnemyShot(i, _shotDelayTimer);
                        }
                        else if (!_isDelay && i == _enemies.Length - 1)
                        {
                            if (AllEnemiesDeathCheck())
                                _endTurnTimer = new TimerData(0f, Time.time);
                            else
                                _endTurnTimer = new TimerData(4f, Time.time);
                            EnemyShot(i, _endTurnTimer);
                        }

                        //if(i == _currentEnemyTurnIndex)
                        //{
                        //    _endTurnTimer = new TimerData(4f, Time.time);
                        //    EnemyShot(i, _endTurnTimer);
                        //}                      

                    }

                    //_currentEnemyTurnIndex++;

                    //if (_currentEnemyTurnIndex > _enemies.Length - 1)
                    //{
                    //    StartNewTurn();
                    //    return;
                    //}
                }
            }
        }

        private void UpdateUnitElements()
        {
            foreach (var enemy in _enemies)
            {
                enemy.ChangingElement();
            }

            //_player.ChangingElement();
        }

        private void StartNewTurn()
        {
            if(AllEnemiesDeathCheck())
                OnEndGame?.Invoke();

            //_currentEnemyTurnIndex = 0;
            _step++;

            _stepText.text = (_step + 1).ToString();
            OnChangeTurn.Invoke();
            UpdateUnitElements();

            // _stepText.text = (_step + 1).ToString();
        }

        private bool AllEnemiesDeathCheck()
        {
            bool isAllEnemiesDead = true;

            for (int i = 0; i < _enemies.Length; i++)
            {
                _enemies[i].isShotReturn = false;
                if (!_enemies[i].IsDead)
                    isAllEnemiesDead = false;
            }
            return isAllEnemiesDead;
        }

        private void EnemyShot(int index, TimerData timer)
        {
            if(!_enemies[index].IsDead)
                _enemies[index].ReturnShot();
            _enemies[index].isShotReturn = true;
            _isDelay = true;
            _timerController.AddTimer(timer);
        }
    }
}
