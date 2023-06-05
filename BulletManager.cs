using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private int _damage;
    [SerializeField] private LayerMask _whatIsSolid;
    private Transform target;
    [SerializeField] private GameObject _playerPrefab;

    private void Start()
    {
        target = _playerPrefab.GetComponent<ShootingManager>()._target;
        Destroy(gameObject, 3);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !collision.gameObject.GetComponent<PlayerController>()._photonView.IsMine)
        {
            collision.gameObject.GetComponent<CharacterHealth>().GiveDamage(_damage);
        }
    }

    void Update()
    {
        transform.Translate(Vector2.right * _bulletSpeed * Time.deltaTime);
    }
   
    
}
