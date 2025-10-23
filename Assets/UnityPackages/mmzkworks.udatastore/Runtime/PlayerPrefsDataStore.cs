using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace mmzkworks.DataStore
{
    public sealed class PlayerPrefsDataStore : IDataStore
    {
        private string _keyPrefix;
        
        public PlayerPrefsDataStore(string keyPrefix)
        {
            _keyPrefix = keyPrefix;
        }

        public UniTask SetAsync(string key, int value)
        {
            var persistentKey = GetPersistentKey(key);
            PlayerPrefs.SetInt(persistentKey, value);
            return UniTask.CompletedTask;        
        }

        public UniTask SetAsync(string key, float value)
        {
            var persistentKey = GetPersistentKey(key);
            PlayerPrefs.SetFloat(persistentKey, value);
            return UniTask.CompletedTask;        
        }

        public UniTask SetAsync(string key, bool value)
        {
            var persistentKey = GetPersistentKey(key);
            PlayerPrefs.SetInt(persistentKey, value? 1 : 0);
            return UniTask.CompletedTask;
        }

        public UniTask SetAsync(string key, string value)
        {
            var persistentKey = GetPersistentKey(key);
            PlayerPrefs.SetString(persistentKey, value);
            return UniTask.CompletedTask;
        }

        public UniTask FlushAsync()
        {
            PlayerPrefs.Save();
            return UniTask.CompletedTask;
        }

        public UniTask<IEnumerable<string>> GetListAsync()
        {
            throw new System.NotImplementedException();
        }

        public UniTask<bool> ExistsAsync(string key)
        {
            var persistentKey = GetPersistentKey(key);
            return UniTask.FromResult(PlayerPrefs.HasKey(persistentKey));
        }

        public UniTask<int> GetIntAsync(string key)
        {
            var persistentKey = GetPersistentKey(key);
            var value = PlayerPrefs.GetInt(persistentKey);
            return UniTask.FromResult(value);
        }

        public UniTask<float> GetFloatAsync(string key)
        {
            var persistentKey = GetPersistentKey(key);
            var value = PlayerPrefs.GetFloat(persistentKey);
            return UniTask.FromResult(value);
        }

        public UniTask<bool> GetBoolAsync(string key)
        {
            var persistentKey = GetPersistentKey(key);
            var value = PlayerPrefs.GetInt(persistentKey) == 1;
            return UniTask.FromResult(value);
        }

        public UniTask<string> GetStringAsync(string key)
        {
            var persistentKey = GetPersistentKey(key);
            var value = PlayerPrefs.GetString(persistentKey);
            return UniTask.FromResult(value);
        }

        private string GetPersistentKey(string key)
        {
            return _keyPrefix + key;
        }
    }
}
