using mmzkworks.DataStore;
using UnityEngine;

public class Startup : MonoBehaviour
{
    private void Awake()
    {
        IDataStore dataStore = new PlayerPrefsDataStore("DataStore_");
    }
}
