using Colyseus;
using Colyseus.Schema;
using System;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerManager : ColyseusManager<MultiplayerManager>
{
    private ColyseusRoom<State> _room;
    private float _lastUpdateTime = 0;

    protected override async void Awake()
    {
        base.Awake();
        Instance.InitializeClient();
       _room = await Instance.client.JoinOrCreate<State>("state_handler", new Dictionary<string, object>() { { "mc", 8 } });
        _room.OnStateChange += OnStateChange;
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        _room?.Leave();
    }

    private void OnStateChange(State state, bool isfirststate)
    {
        if (isfirststate == false) return;
        _room.OnStateChange -= OnStateChange;
        state.players.ForEach(ChangePlayer);
    }

    private void ChangePlayer(string arg1, Player arg2)
    {
        arg2.OnChange += Change;
    }

    private void Change(List<DataChange> changes)
    {
        float ping = Time.time - _lastUpdateTime;
        _lastUpdateTime = Time.time;
        Debug.Log(ping);
    }

    private void Update()
    {
        _room?.Send("move", new Dictionary<string, object> { { "x", 1 }, { "y" , 1} });
    }
}