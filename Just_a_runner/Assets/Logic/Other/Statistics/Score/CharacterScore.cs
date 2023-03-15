using DataManagement;
using System;

namespace Statistics
{
    public class CharacterScore
    {
        private const string StorageKey = "a0Hxglwcjk3u4i9vok4oanDEak$m0c";

        public Action<uint> OnScoreChanging;
        private SafeUInt32 _currentScore;

        public SafeUInt32 CurrentScore
        {
            get => _currentScore;
            set => OnScoreChanging?.Invoke(_currentScore = value);
        }

        public uint GetMaxScore()
        {
            if (SafeDataStorage.Contains(StorageKey))
            {
                var deserializedScore = SafeUInt32.Deserialize(SafeDataStorage.Load(StorageKey));

                if (deserializedScore >= _currentScore)
                    return deserializedScore;
            }

            SafeDataStorage.Save(StorageKey, _currentScore.Serialize());

            return _currentScore;
        }
    }
}