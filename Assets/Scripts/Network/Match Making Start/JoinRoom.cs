using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JoinRoom : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI roomName;

    public void SetRoomName(string _roomName)
    {
        roomName.text = _roomName;
    }
}
