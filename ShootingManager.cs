using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ShootingManager : MonoBehaviour
{
  
    [SerializeField] private GameObject _bullet;
    private float timeBetweenShots;
    public Transform _target;
    [SerializeField] private PhotonView _photonView;


    public void OnShotButtonPress()
    {
         Instantiate(_bullet, _target.position, _target.transform.rotation);
    }
    
}
