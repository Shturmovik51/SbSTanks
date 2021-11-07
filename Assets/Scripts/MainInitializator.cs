using UnityEngine;

namespace SbSTanks
{
    public class MainInitializator
    {
        public MainInitializator(GameInitializationData data, GameController mainController)
        {
            var uiModel = new UIModel();

            var timerController = new TimerController();
            mainController.Add(timerController);

            var stepController = new StepController(data.Enemies, data.Player, timerController, data);
            mainController.Add(stepController);

            new ParticlesInitialization(data.Player, data.Enemies);
            var pcinputinitialization = new PCInputSpaceInitialization();
            var timerActionInvoker = new TimerActionInvoker();

            var playerModel = new PlayerModel(pcinputinitialization.GetInputSpace(), timerController, data.Player);
            new TimerSetsInitialization(playerModel, timerActionInvoker);

            var shellController = new ShellController(data.Player, data.Enemies);
            mainController.Add(shellController);

            mainController.Add(new InputController(pcinputinitialization.GetInputSpace()));
            mainController.Add(new PlayerController(playerModel, stepController, uiModel, data.Enemies, data.EnemiesSwitchButtons));
            mainController.Add(new ButtonActivationController(uiModel, stepController));
            

            for (int i = 0; i < data.Enemies.Length; i++)
            {
                data.Enemies[i].Init(data.EnemyInitializationData, shellController, stepController);
            }
            
            data.Player.Init(data.PlayerInitializationData, shellController, stepController);
        }
    }
}