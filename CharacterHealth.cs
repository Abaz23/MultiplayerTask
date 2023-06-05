using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CharacterHealth : MonoBehaviour
{
    public int _health;
    [SerializeField] private PhotonView _photonView;
 
    public void GiveDamage(int damage)
    {
        _photonView.RPC("TakeDamage", RpcTarget.All, damage);
    }

    [PunRPC]
    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Destroy(gameObject);
            
        }
    }
}
