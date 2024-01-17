using UnityEngine;

namespace _Project.Scripts.GameEngine.Systems.GameResources
{
    //Нельзя менять!
    public sealed class Resource : MonoBehaviour
    {
        [SerializeField]
        private string id;

        [SerializeField]
        private int amount;
        
        public string ID
        {
            get => id;
        }

        public int Amount
        {
            get => amount;
            set => amount = value;
        }
    }
}