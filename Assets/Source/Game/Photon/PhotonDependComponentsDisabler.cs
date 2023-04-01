using Photon.Pun;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(PhotonView))]
public class PhotonDependComponentsDisabler : MonoBehaviour
{
    [SerializeField] private PhotonView _photonView;

    private void Awake()
    {
        if (_photonView.IsMine)
        {
            return;
        }

        Behaviour[] components = gameObject.GetComponents<IPhotonDependComponent>()
            .Select(c => c as Behaviour).ToArray();

        for (int i = 0; i < components.Length; i++)
        {
            components[i].enabled = false;
        }
    }
}
