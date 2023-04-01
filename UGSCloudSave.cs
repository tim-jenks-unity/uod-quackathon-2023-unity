using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.CloudSave;

public class UGSCloudSave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       InitUGS();
    }

    async void InitUGS()
    {
        Debug.Log("Start UGS");
        await UnityServices.InitializeAsync();
        Debug.Log("UGS Ready");
        await AuthenticationService.Instance.SignInAnonymouslyAsync();
        Debug.Log("UGS Signed In");
        var ourData = CloudSaveService.Instance.Data.LoadAllAsync();
        await ourData;
        Debug.LogFormat("UGS Loaded Data {0}", ourData.Result["MySaveKey"]);

    }

    async void SaveData()
    {
        var data = new Dictionary<string, object>{ { "MySaveKey", "HelloWorld" } };
        await CloudSaveService.Instance.Data.ForceSaveAsync(data);
        Debug.Log("UGS Saved Data");
    }

    // Update is called once per frame
    void Update()
    {        
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("UGS Saving Data!");
            SaveData();
        }
    }
}
