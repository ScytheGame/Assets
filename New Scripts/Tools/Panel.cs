using UnityEngine;

namespace Menu
{
    public class Panel : MonoBehaviour
    {
        public GameObject Container = null;
        [SerializeField] string ID = ""; public string GetID { get { return ID; } }
        private bool IsInitalized = false;

        public virtual void Initialize()
        {
            if (IsInitalized)
                return;

            IsInitalized = true;
            Close();
        }
        public void Close()
        {
            Container.SetActive(false);
        }

        public void Open()
        {
            Container.SetActive(true);
        }
    }
}