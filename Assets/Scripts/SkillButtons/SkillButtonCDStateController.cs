using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SbSTanks
{
    public class SkillButtonCDStateController
    {
        private SkillButtonActiveStateController _skillButtonActiveStateController;
        private List<SkillButton> _buttonsOnCD;
        public SkillButtonCDStateController(SkillButtonActiveStateController skillButtonActiveStateController, StepController stepController)
        {
            _skillButtonActiveStateController = skillButtonActiveStateController;
            stepController.OnChangeTurn += UpdateButtonsOnCD;
            _buttonsOnCD = new List<SkillButton>(4);
        }

        public void AddButtonToCDList()
        {
            var button = _skillButtonActiveStateController.GetActiveButton();

            _buttonsOnCD.Add(button);
            button.CDImage.gameObject.SetActive(true);
            button.Button.interactable = false;
            UpdateCDStateUI();
        }

        public void UpdateCDStateUI()
        {
            foreach (var button in _buttonsOnCD)
            {
                button.CDText.text = button.CurrentCD.ToString();
            }
        }

        public void UpdateButtonsOnCD()
        {  
            if(_buttonsOnCD.Count != 0)
            {
                for (int i = 0; i < _buttonsOnCD.Count; i++)                            
                {
                    _buttonsOnCD[i].CurrentCD--;
                    if (_buttonsOnCD[i].CurrentCD <= 0)
                    {
                        RemoveCDState(_buttonsOnCD[i]);
                    }
                }
            }

            UpdateCDStateUI();
        }

        private void RemoveCDState(SkillButton skillButton)
        {
            _buttonsOnCD.Remove(skillButton);
            skillButton.CDImage.gameObject.SetActive(false);
            skillButton.Button.interactable = true;
            skillButton.CurrentCD = skillButton.MaxCD;
        }
    }
}