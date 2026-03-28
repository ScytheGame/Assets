using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
namespace Menu
{
    public class SettingsMenu : Panel
    {
        [SerializeField] Button AudioButton;
        [SerializeField] Button GraphicsButton;
        [SerializeField] Button BackButton;
        [SerializeField] Panel BackMenu;

        [SerializeField] GameObject SubMenuAudio;
        [SerializeField] GameObject SubMenuGameplay;
        [SerializeField] GameObject SubMenuGraphics;
        private SettingsSubMenu SubMenu = SettingsSubMenu.Gameplay;


        public override void Initialize()
        {
            base.Initialize();
            AudioButton.onClick.AddListener(Audio);
            GraphicsButton.onClick.AddListener(Graphics);
            BackButton.onClick.AddListener(Back);
        }
        private void Audio()
        {
            switch (SubMenu)
            {
                case SettingsSubMenu.Audio:
                    CloseAudio();
                    OpenGameplay();
                    break;
                case SettingsSubMenu.Gameplay:
                    CloseGameplay();
                    OpenAudio();
                    break;
                case SettingsSubMenu.Graphics:
                    CloseGraphics();
                    OpenAudio();
                    break;
            }
        }
        private void Graphics()
        {
            switch (SubMenu)
            {
                case SettingsSubMenu.Audio:
                    CloseAudio();
                    OpenGraphics();
                    break;
                case SettingsSubMenu.Gameplay:
                    CloseGameplay();
                    OpenGraphics();
                    break;
                case SettingsSubMenu.Graphics:
                    CloseGraphics();
                    OpenGameplay();
                    break;
            }
        }
        private void Back()
        {
            MenuManager.Open(BackMenu.GetID);
            Close();
        }

        private void CloseAudio()
        {
            SubMenuAudio.SetActive(false);
        }
        private void OpenAudio()
        {
            SubMenuAudio.SetActive(true);
        }

        private void CloseGameplay()
        {
            SubMenuGameplay.SetActive(false);
        }
        private void OpenGameplay()
        {
            SubMenuGameplay.SetActive(true);
        }

        private void CloseGraphics()
        {
            SubMenuGraphics.SetActive(false);
        }
        private void OpenGraphics()
        {
            SubMenuGraphics.SetActive(true);
        }
    }

    public enum SettingsSubMenu
    {
        Audio,
        Graphics,
        Gameplay,
    }

}
