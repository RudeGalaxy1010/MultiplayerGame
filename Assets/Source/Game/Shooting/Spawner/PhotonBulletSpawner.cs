using Photon.Pun;
using UnityEngine;

public class PhotonBulletSpawner : BulletSpawner
{
    public override void Destroy(Bullet bullet)
    {
        PhotonNetwork.Destroy(bullet.gameObject);
    }

    public override Bullet Instantiate(Vector2 at)
    {
        return PhotonNetwork.Instantiate(BulletPrefab.name, at, Quaternion.identity).GetComponent<Bullet>();
    }
}
