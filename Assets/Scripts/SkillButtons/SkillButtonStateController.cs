using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SbSTanks
{
    public class SkillButtonStateController
    {
        private List<SkillButton> _skillButtons;

        public SkillButtonStateController(List<SkillButton> skillButtons)
        {
            _skillButtons = skillButtons;

            foreach (var button in _skillButtons)
            {
                button.Button.onClick.AddListener(() => SetActiveState(button));
            }
        }

        public SkillButton GetActiveButton()
        {
            SkillButton activeButton = null;
            foreach (var button in _skillButtons)
            {
                if (button.IsActive)
                    activeButton = button;
            }
            return activeButton;
        }

        private void SetActiveState(SkillButton button)
        {
            ResetButtonsState();

            button.IsActive = true;
            button.Button.image.color = Color.green;
        }

        public void ResetButtonsState()
        {
            foreach (var button in _skillButtons)
            {
                button.IsActive = false;
                button.Button.image.color = Color.white;
            }
        }
    }
}