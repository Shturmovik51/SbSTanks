using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SbSTanks
{
    public class SkillButtonActiveStateController
    {
        private List<SkillButton> _skillButtons;
        private Element _playerElement;
        private SkillButton _activeButton;
        public SkillButtonActiveStateController(List<SkillButton> skillButtons, Player player)
        {
            _skillButtons = skillButtons;
            _playerElement = player.Parameters.Element;

            foreach (var button in _skillButtons)
            {
                button.Button.onClick.AddListener(() => SetActiveState(button));
            }
        }

        public SkillButton GetActiveButton()
        {
            //SkillButton activeButton = null;
            //foreach (var button in _skillButtons)
            //{
            //    if (button.IsActive)
            //        activeButton = button;
            //}
            ResetButtonsState();
            return _activeButton;
        }

        private void SetActiveState(SkillButton button)
        {
            ResetButtonsState();

            button.IsActive = true;
            button.Button.image.color = Color.green;
            _playerElement.SetElementType(button.ElementType);

            _activeButton = button;
        }

        public void ResetButtonsState()
        {
            _playerElement.DeactivateElement();

            foreach (var button in _skillButtons)
            {
                button.IsActive = false;
                button.Button.image.color = Color.white;
            }
        }
    }
}