namespace Statistics
{
    public class CharacterScore
    {
        public System.Action<uint> OnScoreChanging;
        public uint _score;

        public uint Score
        {
            get => _score;
            set => OnScoreChanging?.Invoke(_score = value);
        }
    }
}