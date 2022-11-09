using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.Demo.Cockpit;
using Photon.Realtime;
using TMPro;
using UnityEngine.UI;

public class MatchmakingLobbyManager : MonoBehaviourPunCallbacks
{
    //Data
    [SerializeField] private JoinRoom joinRoomPrefab;
    private List<JoinRoom> joinRoomList = new List<JoinRoom>();
    [SerializeField] private Transform contentObjects;
    
    //Lobby Info
    [SerializeField] private TMP_InputField roomInputField;
    [SerializeField] private GameObject lobbyPanel;
    [SerializeField] private GameObject roomPanel;
    [SerializeField] private TextMeshProUGUI roomName;

    private void Start()
    {
        JoinLobby();
    }

    public void OnClickCreate()
    {
        if (roomInputField.text.Length >= 1)
        {
            PhotonNetwork.CreateRoom(roomInputField.text, new RoomOptions() {MaxPlayers = 2});
        }
    }

    private void JoinLobby()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedRoom()
    {
        lobbyPanel.SetActive(false);
        roomPanel.SetActive(true);
        roomName.text = "Room Name: " + PhotonNetwork.CurrentRoom.Name;
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        UpdateRoomList(roomList);
    }

    private void UpdateRoomList(List<RoomInfo> list)
    {
        foreach (JoinRoom room in joinRoomList)
        {
            Destroy(room.gameObject);
        }
        joinRoomList.Clear();

        foreach (RoomInfo room in list)
        {
            JoinRoom newRoom = Instantiate(joinRoomPrefab, contentObjects);
            newRoom.SetRoomName(room.Name);
            joinRoomList.Add(newRoom);
        }
    }
}
