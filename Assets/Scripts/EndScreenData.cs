using UnityEngine;
using UnityEngine.UI;

namespace SbSTanks
{
    [System.Serializable]
    public struct EndScreenData
    {
        [SerializeField] private GameObject _endScreenPanel;
        [SerializeField] private Button _restartButton;

        public GameObject EndScreenPanel => _endScreenPanel;
        public Button RestartButton => _restartButton;
    }
}