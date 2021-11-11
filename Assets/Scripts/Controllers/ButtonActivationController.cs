using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SbSTanks
{
    public class ButtonActivationController : IExecute
    {
        private List<Button> _canvasButtons;
        private StepController _stepController;
        private bool _isPreviousPlayerTurn;

        private const int REQUIRED_CANVAS = 0;

        public ButtonActivationController(UIModel uIModel, StepController stepController)
        {
            _isPreviousPlayerTurn = true;
            _stepController = stepController;
            _canvasButtons = new List<Button>();
            _canvasButtons.AddRange(uIModel.GetCanvases[REQUIRED_CANVAS].GetComponentsInChildren<Button>());
        }
        public void Execute(float deltaTime)
        {
            //if(_stepController.isPlayerTurn != _isPreviousPlayerTurn)
            //{
            //    for (int i = 0; i< _canvasButtons.Count; i++)
            //    {
            //        _canvasButtons[i].interactable = !_canvasButtons[i].interactable;

            //    }
            //    _isPreviousPlayerTurn = !_isPreviousPlayerTurn;
            //}
        }
    }
}

