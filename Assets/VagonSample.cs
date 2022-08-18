using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using WebSocketSharp;

public class VagonSample : MonoBehaviour
{
    WebSocket ws;
    bool shouldChange = false;
    int msgCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        ws = new WebSocket("ws://localhost:7788");
        ws.Connect();
        ws.OnMessage += (sender, e) =>
        {
            Debug.Log("Got " + e.Data);
            msgCount++;
            ws.Send(e.Data);
        };
    }

    // Update is called once per frame
    void Update()
    {
        var obj = GameObject.Find("label");
        var tmptext = obj.GetComponent<TextMeshProUGUI>();
        tmptext.text = $"Got {msgCount} messages";
    }
}
