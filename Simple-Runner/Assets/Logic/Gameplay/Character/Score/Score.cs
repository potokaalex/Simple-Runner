using DataManagement;
using System;

namespace Character
{
    public class Score
    {
        private const string StorageKey = "a0Hxglwcjk3u4i9vok4oanDEak$m0c";
        public Action<uint> OnScoreChanging;

        private IDataStorage _dataStorage;
        private SafeUInt32 _currentScore;

        public Score(IDataStorage dataStorage)
            => _dataStorage = dataStorage;

        public SafeUInt32 CurrentScore
        {
            get => _currentScore;
            set => OnScoreChanging?.Invoke(_currentScore = value);
        }

        public uint GetMaxScore()
        {
            if (_dataStorage.Contains(StorageKey))
            {
                var deserializedScore = SafeUInt32.Deserialize(_dataStorage.Load(StorageKey, Array.Empty<byte>()));

                if (deserializedScore >= _currentScore)
                    return deserializedScore;
            }

            _dataStorage.Save(StorageKey, _currentScore.Serialize());

            return _currentScore;
        }
    }
}
