using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataRefresher : MonoBehaviour
{
    public SaveDataManager saveDataManager;

    bool refreshTriggered = false;
    float dataRefreshTime = 240.0f;
    float dataRefreshTimeer = 0.0f;

    void OnApplicationPause(bool gamePaused)
    {
        if (!gamePaused)
        {
            saveDataManager.LoadPlayerModelData();
        }
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            if (!refreshTriggered)
            {
                RefreshTheTimer();
                refreshTriggered = true;
            }       
        }
        else
        {
            if (refreshTriggered)
            {
                refreshTriggered = false;
            }

            dataRefreshTimeer += Time.deltaTime;

            if (dataRefreshTimeer >= dataRefreshTime)
            {
                RefreshData();
            }
        }
    }

    void RefreshTheTimer()
    {
        dataRefreshTimeer = 0;
    }

    void RefreshData()
    {
        saveDataManager.LoadPlayerModelData();
        dataRefreshTimeer = 0;
    }
}
