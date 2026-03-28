using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
namespace Menu 
{
    public class MenuManager : MonoBehaviour
    {
        Dictionary<string, Panel> Panels = new Dictionary<string, Panel>();
        bool Initialized = false;
        Canvas[] Canvases = null;
        static MenuManager singleton = null;

        public static MenuManager Singleton
        {
            get
            {
                if (singleton == null)
                {
                    singleton = FindAnyObjectByType<MenuManager>();

                    if (singleton == null)
                    {
                        singleton = new GameObject("MenuManager").AddComponent<MenuManager>();
                    }
                    singleton.Initialize();
                }
                return singleton;
            }
        }

        private void Initialize()
        {
            if (Initialized) return;
            Initialized = true;
            Panels.Clear();
            Canvases = FindObjectsByType<Canvas>();

            if (Canvases != null)
            {
                foreach (Canvas canvas in Canvases)
                {
                    Panel[] Panels = canvas.GetComponentsInChildren<Panel>(true);
                    if (Panels != null)
                    {
                        foreach (Panel panel in Panels)
                        {
                            if (panel != null && !this.Panels.ContainsKey(panel.GetID))
                            {
                                panel.Initialize();
                                this.Panels.Add(panel.GetID, panel);
                            }
                        }
                    }
                }
            }
        }

        private void OnDestroy()
        {
            if (singleton == this)
            {
                singleton = null;
            }
        }

        public static Panel GetSingleton(string ID)
        {
            if (Singleton.Panels.ContainsKey(ID))
            {
                return Singleton.Panels[ID];
            }
            return null;
        }

        public static void Open(string ID)
        {
            Panel panel = GetSingleton(ID);
            if (panel != null)
            {
                panel.Open();
            }
        }

        public static void Close(string ID)
        {
            Panel panel = GetSingleton(ID);
            if (panel != null)
            {
                panel.Close();
            }
        }

        public static void CloseAll()
        {
            foreach (var panel in Singleton.Panels.Values)
            {
                panel.Close();
            }
        }
    }
}