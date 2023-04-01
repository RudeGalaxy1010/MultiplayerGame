using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;

public class PhotonBulletPool : BulletPool
{
    private List<Bullet> _bullets;

    private void Start()
    {
        Construct();
    }

    private void Construct()
    {
        _bullets = new List<Bullet>();

        for (int i = 0; i < StartCount; i++)
        {
            CreateBullet();
        }
    }

    public override Bullet Get()
    {
        Bullet bullet = null;

        for (int i = 0; i < _bullets.Count; i++)
        {
            if (_bullets[i].gameObject.activeInHierarchy)
            {
                bullet = _bullets[i];
                break;
            }
        }

        if (bullet == null)
        {
            bullet = CreateBullet();
        }

        _bullets.Remove(bullet);
        bullet.transform.SetParent(null);
        bullet.gameObject.SetActive(true);
        return bullet;
    }

    public override void Return(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        bullet.transform.SetParent(transform);
        _bullets.Add(bullet);
    }

    private Bullet CreateBullet()
    {
        Bullet bullet = PhotonNetwork.Instantiate(Prefab.name, Vector2.zero, Quaternion.identity).GetComponent<Bullet>();
        bullet.gameObject.SetActive(false);
        bullet.transform.SetParent(transform);
        _bullets.Add(bullet);
        return bullet;
    }
}
