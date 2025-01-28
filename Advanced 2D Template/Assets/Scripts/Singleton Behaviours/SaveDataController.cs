using UnityEngine;

namespace SingletonBehaviours
{
    public class SaveDataController : Types.SingletonBehaviour<SaveDataController>
    {
        [SerializeField] private Types.Miscellaneous.SaveDataAsset _default;
        [SerializeField] private string _directory;

        private Types.Miscellaneous.SaveData _currentData;
        public Types.Miscellaneous.SaveData CurrentData => _currentData;

        public override void Initialize()
        {
            base.Initialize();

            _currentData = Helpers.SerializationHelper.Load(_default.Value, _directory, "SaveData.json");
        }

        public override void Shutdown()
        {
            Helpers.SerializationHelper.Save(_currentData, _directory, "SaveData.json");

            base.Shutdown();
        }
    }
}
