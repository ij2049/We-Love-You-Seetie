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
    
    //Player Button
    [SerializeField] private GameObject btn_play;
    public List<PlayerItem> playerItemList = new List<PlayerItem>();
    public PlayerItem playerItemPrefab;
    public Transform playerItemParent;

    //scene
    [SerializeField] private string nextSceName;
    
    public float timeBtwUpdates = 1.5f;
    private float nextUpdateTime;
    private void Start()
    {
        JoinLobby();
    }

    private void Update()
    {
        //if the players are two button active true
        if (PhotonNetwork.IsMasterClient && PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            btn_play.SetActive(true);
        }
        else
        {
            btn_play.SetActive(false);
        }
    }

    public void OnClickCreate()
    {
        if (roomInputField.text.Length >= 1)
        {
            PhotonNetwork.CreateRoom(roomInputField.text, new RoomOptions() {MaxPlayers = 2, BroadcastPropsChangeToAll = true});
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
        UpdatePlayerList();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        if (Time.time >= nextUpdateTime)
        {
            UpdateRoomList(roomList);
            nextUpdateTime = Time.time + timeBtwUpdates;
        }
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

    public void JoinRoom(string _roomName)
    {
        PhotonNetwork.JoinRoom(_roomName);
    }
    
    public void OnClickLeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        roomPanel.SetActive(false);
        lobbyPanel.SetActive(true);
        roomInputField.text = "";
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }
    
    //Player
    private void UpdatePlayerList()
    {
        foreach (PlayerItem item in playerItemList)
        {
            Destroy(item.gameObject);
        }
        playerItemList.Clear();

        if (PhotonNetwork.CurrentRoom == null)
        {
            return;
        }

        foreach (KeyValuePair<int, Player> player in PhotonNetwork.CurrentRoom.Players)
        {
            PlayerItem newPlayerItem = Instantiate(playerItemPrefab, playerItemParent);
<<<<<<< HEAD
            newPlayerItem.SetPlayerInfo(player.Value);
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> main

            if (player.Value == PhotonNetwork.LocalPlayer)
            {
                newPlayerItem.ApplyLocalChanges();    
            }
            
=======
>>>>>>> main
=======
>>>>>>> parent of 58827b2... Network Player choice and spawn1
<<<<<<< HEAD
=======
>>>>>>> parent of 232c541... Merge2
=======
>>>>>>> main
            playerItemList.Add(newPlayerItem);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        UpdatePlayerList();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        UpdatePlayerList();
    }

    public void OnClickPlayButton()
    { 
        if(nextSceName != null)
        {PhotonNetwork.LoadLevel(nextSceName);}
    }
}
