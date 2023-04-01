using Photon.Pun;
using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private const string DamageLessThanZeroMessage = "Coins value can't be less or equal 0";

    public event Action<int> CoinsValueChanged;

    private int _coins;

    [PunRPC]
    public void AddCoins(int value)
    {
        if (value <= 0)
        {
            throw new ArgumentException(DamageLessThanZeroMessage);
        }

        _coins += value;
        CoinsValueChanged?.Invoke(_coins);
    }
}
