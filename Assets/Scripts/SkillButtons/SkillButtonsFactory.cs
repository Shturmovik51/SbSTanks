using System.Collections.Generic;
using UnityEngine.UI;

namespace SbSTanks
{
    public class SkillButtonsFactory
    {
        private SkillButtonObjects[] _skillButtonObjects;
        private SkillButtonsConfig _skillButtonConfig;
        private List<SkillButton> _skillButtons;

        public SkillButtonsFactory(SkillButtonObjects[] skillButtonObjects, SkillButtonsConfig skillButtonConfig)
        {
            _skillButtonObjects = skillButtonObjects;
            _skillButtonConfig = skillButtonConfig;
            _skillButtons = new List<SkillButton>(_skillButtonObjects.Length);
        }

        public List<SkillButton> GetSkillButtons()
        {
            for (int i = 0; i < _skillButtonObjects.Length; i++)
            {
                var parameters = _skillButtonConfig.SkillButtonsParameters[i];
                var skillButton = new SkillButton(_skillButtonObjects[i].Button, _skillButtonObjects[i].CDImage, 
                        parameters.CoolDown, parameters.Description, parameters.ElementType, _skillButtonObjects[i].CDText);

                _skillButtons.Add(skillButton);
            }

            return _skillButtons;
        }
    }
}