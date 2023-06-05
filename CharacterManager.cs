using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class CharacterManager : MonoBehaviour
{
    private PhotonView _photonView;
    [SerializeField] private GameObject _playerPrefab;

    void Start()
    {
        _photonView = GetComponent<PhotonView>();
        if (_photonView.IsMine)
        {
            CreateController();
        }
    }

    
    private void CreateController()
    {      
        var player = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerController"), Vector3.zero, Quaternion.identity);
        _playerPrefab.GetComponent<ShootingManager>()._target = player.transform;
    }
    
}

