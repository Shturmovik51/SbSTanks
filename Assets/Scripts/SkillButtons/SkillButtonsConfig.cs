using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SbSTanks
{
    [CreateAssetMenu(fileName = nameof(SkillButtonsConfig), menuName = "GameData/SkillButtonsConfig")]
    public class SkillButtonsConfig : ScriptableObject
    {
        [SerializeField] private SkillButtonsParameters[] _skillButtonsParameters;
        public SkillButtonsParameters[] SkillButtonsParameters => _skillButtonsParameters;
    }
}