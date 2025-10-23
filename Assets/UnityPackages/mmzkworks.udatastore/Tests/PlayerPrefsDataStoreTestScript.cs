using System.Collections;
using Cysharp.Threading.Tasks;
using mmzkworks.DataStore;
using UnityEngine.Assertions;
using UnityEngine.TestTools;

public class PlayerPrefsDataStoreTestScript
{
    [UnityTest]
    public IEnumerator DataStore_New() => UniTask.ToCoroutine(async () =>
    {
        IDataStore dataStore = new PlayerPrefsDataStore("DataStore_");
    });

    [UnityTest]
    public IEnumerator DataStore_CanSetAndGetInt() => UniTask.ToCoroutine(async () =>
    {
        IDataStore dataStore = new PlayerPrefsDataStore("DataStore_");
        await dataStore.SetAsync("Int1", 123);
        var value = await dataStore.GetIntAsync("Int1");
        Assert.AreEqual(value, 123);
    });

    [UnityTest]
    public IEnumerator DataStore_CanSetAndGetFloat() => UniTask.ToCoroutine(async () =>
    {
        IDataStore dataStore = new PlayerPrefsDataStore("DataStore_");
        await dataStore.SetAsync("Float1", 12.8f);
        var value = await dataStore.GetFloatAsync("Float1");
        Assert.AreEqual(value, 12.8f);
    });
    
    [UnityTest]
    public IEnumerator DataStore_CanSetAndGetBool() => UniTask.ToCoroutine(async () =>
    {
        IDataStore dataStore = new PlayerPrefsDataStore("DataStore_");
        await dataStore.SetAsync("Bool1", true);
        var value = await dataStore.GetBoolAsync("Bool1");
        Assert.AreEqual(value, true);
    });
    
    [UnityTest]
    public IEnumerator DataStore_CanSetAndGetString() => UniTask.ToCoroutine(async () =>
    {
        IDataStore dataStore = new PlayerPrefsDataStore("DataStore_");
        await dataStore.SetAsync("String1", "abcdef");
        var value = await dataStore.GetStringAsync("String1");
        Assert.AreEqual(value, "abcdef");
    });

    [UnityTest]
    public IEnumerator DataStore_CanFlush() => UniTask.ToCoroutine(async () =>
    {
        IDataStore dataStore = new PlayerPrefsDataStore("DataStore_");
        await dataStore.SetAsync("Float1", 123.456f);
        await dataStore.FlushAsync();
        var value = await dataStore.GetFloatAsync("Float1");
    });
    
}
