using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

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
        [SerializeField] private Button[] _skillButtons;
        [SerializeField] private List<TextMeshProUGUI> HPValues;
        [SerializeField] private TextMeshProUGUI _stepPanelText;
        [SerializeField] private SkillButtonsConfig _skillButtonsConfig;
        public Player Player { get => _player; }
        public Enemy[] Enemies { get => _enemies; }
        public UnitInitializationData PlayerInitializationData { get => _playerInitializationData; }
        public UnitInitializationData EnemyInitializationData { get => _enemyInitializationData; }
        public List<Button> EnemiesSwitchButtons { get => _enemiesSwitchButtons; }
        public TextMeshProUGUI StepPanelText => _stepPanelText;                
        public Button[] SkillButtons => _skillButtons;        
        public SkillButtonsConfig SkillButtonsConfig => _skillButtonsConfig;


    }
}