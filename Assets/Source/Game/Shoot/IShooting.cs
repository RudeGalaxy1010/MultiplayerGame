using Source.Bootstrap;
using UnityEngine;

namespace Source.Game.Shoot
{
    public interface IShooting : IService
    {
        void SetFirePoint(Transform firePoint);
    }
}
