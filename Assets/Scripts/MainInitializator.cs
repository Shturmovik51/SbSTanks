using UnityEngine;

namespace SbSTanks
{
    public class MainInitializator
    {
        public MainInitializator(GameInitializationData data, GameController mainController)
        {
            var uiModel = new UIModel();

            var timerController = new TimerController();

            var stepController = new StepController(data.Enemies, data.Player, timerController, data);

            new ParticlesInitialization(data.Player, data.Enemies);
            var pcinputinitialization = new PCInputSpaceInitialization();
            var timerActionInvoker = new TimerActionInvoker();

            var playerModel = new PlayerModel(pcinputinitialization.GetInputSpace(), timerController, data.Player);
            new TimerSetsInitialization(playerModel, timerActionInvoker);

            var shellController = new ShellController(data.Player, data.Enemies);

            var skillButtonFactory = new SkillButtonsFactory(data.SkillButtons, data.SkillButtonsConfig);

            var skillButtonStateController = new SkillButtonStateController(skillButtonFactory.GetSkillButtons());
            



            mainController.Add(timerController);
            mainController.Add(stepController);
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