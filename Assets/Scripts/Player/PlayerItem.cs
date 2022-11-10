using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
using Photon.Pun;
using Photon.Realtime;
<<<<<<< HEAD
using Hashtable = ExitGames.Client.Photon.Hashtable;
=======
>>>>>>> main
=======
>>>>>>> parent of 58827b2... Network Player choice and spawn1

public class PlayerItem : MonoBehaviourPunCallbacks
{
<<<<<<< HEAD
    [SerializeField] private TextMeshProUGUI playerName;
<<<<<<< HEAD
    [SerializeField] private Color highlightColor;
    [SerializeField] private GameObject leftArrowButton;
    [SerializeField] private GameObject rightArrowButton;
    private Image backgroundImage;

    private ExitGames.Client.Photon.Hashtable playerProperties = new ExitGames.Client.Photon.Hashtable();
    [SerializeField] private Image playerAvatar;
    [SerializeField] private Sprite[] avatars;

    private Player player;
    private void Start()
    {
        backgroundImage = GetComponent<Image>();

        playerProperties["name"] = "Liam";
        playerProperties["age"] = 15;
        print(playerProperties["name"]);
    }

    public void SetPlayerInfo(Player _player)
    {
        playerName.text = _player.NickName;
        player = _player;
        UpdatePlayerItem(player);
    }

    public void ApplyLocalChanges()
    {
        backgroundImage.color = highlightColor;
        leftArrowButton.SetActive(true);
        rightArrowButton.SetActive(true);
    }

    public void OnClickLeftArrow()
    {
        if ((int)playerProperties["playerAvatar"] == 0)
        {
            playerProperties["playerAvatar"] = avatars.Length - 1;
        }
        else
        {
            playerProperties["playerAvatar"] = (int)playerProperties["playerAvatar"] - 1;
        }
        PhotonNetwork.SetPlayerCustomProperties(playerProperties);
    }

    public void OnClickRightArrow()
    {
        if ((int)playerProperties["playerAvatar"] == avatars.Length - 1)
        {
            playerProperties["playerAvatar"] = 0;
        }
        else
        {
            playerProperties["playerAvatar"] = (int)playerProperties["playerAvatar"] + 1;
        }

        PhotonNetwork.SetPlayerCustomProperties(playerProperties);
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
        if (player == targetPlayer)
        {
            UpdatePlayerItem(targetPlayer);
        }
    }

    private void UpdatePlayerItem(Player _player)
    {
        if (player.CustomProperties.ContainsKey("playerAvatar"))
        {
            playerAvatar.sprite = avatars[(int)player.CustomProperties["playerAvatar"]];
            playerProperties["playerAvatar"] = (int) player.CustomProperties["playerAvatar"];
        }
        else
        {
            playerProperties["playerAvatar"] = 0;
        }
=======
=======
    // Start is called before the first frame update
    void Start()
    {
        
    }
>>>>>>> parent of 58827b2... Network Player choice and spawn1

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        playerName.text = _player.NickName;
>>>>>>> main
=======
        
>>>>>>> parent of 58827b2... Network Player choice and spawn1
<<<<<<< Updated upstream
    }
>>>>>>> parent of 58827b2... Network Player choice and spawn1

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        playerName.text = _player.NickName;
>>>>>>> main
=======
        
>>>>>>> parent of 58827b2... Network Player choice and spawn1
=======
>>>>>>> parent of 48dc655... Network - Player choice and spawn2
=======
>>>>>>> Stashed changes
    }
}
