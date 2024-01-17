namespace _Project.Scripts.SaveSystem
{
    public interface ISaveSystem
    {
        public void Save();
        public void Load();
        public void RemoveSaves();
    }
}