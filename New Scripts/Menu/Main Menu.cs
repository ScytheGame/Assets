using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace Menu
{
    public class MainMenu : Panel
    {
        [SerializeField] Button PlayButton = null;
        [SerializeField] Button SettingsButton = null;
        [SerializeField] Panel SettingsMenu = null;
        [SerializeField] Button QuitButton = null;
        [SerializeField] Button StatsButton = null;
        [SerializeField] Panel StatsMenu = null;
        [SerializeField] Button SkillTreeButton = null;
        [SerializeField] Panel SkillTreeMenu = null;

        public override void Initialize()
        {
            base.Initialize();
            PlayButton.onClick.AddListener(Play);
            SettingsButton.onClick.AddListener(Settings);
            QuitButton.onClick.AddListener(QuitGame);
            StatsButton.onClick.AddListener(Stats);
            SkillTreeButton.onClick.AddListener(SkillTree);
        }

        private void Play()
        {
            SceneManager.LoadScene("Game Scene");
        }
        private void Settings()
        {
            MenuManager.Open(SettingsMenu.GetID);
            Close();
        }
        private void QuitGame()
        {
            Application.Quit();
        }
        private void Stats()
        {
            MenuManager.Open(StatsMenu.GetID);
            Close();
        }
        private void SkillTree()
        {
            MenuManager.Open(SkillTreeMenu.GetID);
            Close();
        }
    }
}
