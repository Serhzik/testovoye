using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour {
    int score;
    MoveControl loco;
    public event Action<bool> MayLoad;
    public event Action<int> Score;
    public List <Station> stations;
    bool onStation, canLoad;

    private void Start()
    {
        loco = GetComponent<MoveControl>();
        foreach(Station station in stations)
        {
            station.CanLoadAction += OnStation;
        }
    }
    void OnStation(bool state)
    {
        if (state)
        {
            onStation = true;
            
        }
        else
        {
            onStation = false;
            canLoad = false;
            if (MayLoad != null)
                MayLoad(false);
        }
    }
    private void OnDestroy()
    {
        foreach (Station station in stations)
        {
            station.CanLoadAction -= OnStation;
        }
    }
    private void Update()
    {
        if (onStation && !canLoad)
        {
            if (loco.GetSpeed() < 0.2f)
            {
                canLoad = true;
                if (MayLoad != null)
                    MayLoad(true);
            }
        }
    }

    public void Load()
    {
        score++;
        if (Score != null)
            Score(score);
        OnStation(false);
    }
    
}
