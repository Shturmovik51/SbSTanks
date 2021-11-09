using System.Collections.Generic;
using UnityEngine.UI;

namespace SbSTanks
{
    public class SkillButtonsFactory
    {
        private Button[] _buttons;
        private SkillButtonsConfig _skillButtonConfig;
        private List<SkillButton> _skillButtons;

        public SkillButtonsFactory(Button[] buttons, SkillButtonsConfig skillButtonConfig)
        {
            _buttons = buttons;
            _skillButtonConfig = skillButtonConfig;
            _skillButtons = new List<SkillButton>(_buttons.Length);
        }

        public List<SkillButton> GetSkillButtons()
        {
            for (int i = 0; i < _buttons.Length; i++)
            {
                var parameters = _skillButtonConfig.SkillButtonsParameters[i];
                var skillButton = new SkillButton(_buttons[i], parameters.CoolDown, parameters.Description, parameters.ElementType);

                _skillButtons.Add(skillButton);
            }

            return _skillButtons;
        }
    }
}