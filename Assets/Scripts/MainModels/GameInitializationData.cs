﻿using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

namespace SbSTanks
{
    [Serializable]
    public struct GameInitializationData
    {
        [SerializeField] private Player _player;
        [SerializeField] private Enemy[] _enemies;
        [SerializeField] private UnitInitializationData _playerInitializationData;
        [SerializeField] private UnitInitializationData _enemyInitializationData;
        [SerializeField] private List<Button> _enemiesSwitchButtons;

        public Player Player { get => _player; }
        public Enemy[] Enemies { get => _enemies; }
        public UnitInitializationData PlayerInitializationData { get => _playerInitializationData; }
        public UnitInitializationData EnemyInitializationData { get => _enemyInitializationData; }
        public List<Button> EnemiesSwitchButtons { get => _enemiesSwitchButtons; }
    }
}