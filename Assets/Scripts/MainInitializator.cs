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

            for (int i = 0; i < data.Enemies.Length; i++)
            {
                data.Enemies[i].Init(data.EnemyInitializationData, shellController, stepController);
            }
            
            data.Player.Init(data.PlayerInitializationData, shellController, stepController);

            var skillButtonFactory = new SkillButtonsFactory(data.SkillButtonObjects, data.SkillButtonsConfig);

            var skillButtonStateController = new SkillButtonActiveStateController(skillButtonFactory.GetSkillButtons(), data.Player);
            var skillButtonCDController = new SkillButtonCDStateController(skillButtonStateController, stepController);

            var playerController = new PlayerController(playerModel, stepController, uiModel, data.Enemies, 
                                            data.EnemiesSwitchButtons, skillButtonCDController);

            var endScreenController = new EndScreenController(data.EndScreenData, stepController);


            mainController.Add(timerController);
            mainController.Add(stepController);
            mainController.Add(shellController);
            mainController.Add(new InputController(pcinputinitialization.GetInputSpace()));
            mainController.Add(playerController);
            mainController.Add(new ButtonActivationController(uiModel, stepController));
            

        }
    }
}