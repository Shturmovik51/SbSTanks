using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SbSTanks
{
    public class EndScreenController
    {
        private GameObject _endScreenPanel;

        public EndScreenController(EndScreenData endScreenData, StepController stepController)
        {
            _endScreenPanel = endScreenData.EndScreenPanel;
            endScreenData.RestartButton.onClick.AddListener(OnClickRestartButton);
            stepController.OnEndGame += EndGameScreen;
        }

        private void EndGameScreen()
        {
            _endScreenPanel.SetActive(true);
            Time.timeScale = 0;
        }

        private void OnClickRestartButton()
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
        }
    }
}