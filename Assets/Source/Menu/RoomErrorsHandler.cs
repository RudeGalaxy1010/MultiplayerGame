using Photon.Pun;
using System.Collections;
using TMPro;
using UnityEngine;

public class RoomErrorsHandler : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_Text _errorText;
    [SerializeField] private float _showTime;

    private Coroutine _showErrorCoroutine;

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        ShowError(returnCode, message);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        ShowError(returnCode, message);
    }

    private void ShowError(short returnCode, string message)
    {
        if (_showErrorCoroutine != null)
        {
            StopCoroutine(_showErrorCoroutine);
            _showErrorCoroutine = null;
        }

        _showErrorCoroutine = StartCoroutine(ShowErrorByTime(returnCode, message, _showTime));
    }

    private IEnumerator ShowErrorByTime(short returnCode, string message, float time)
    {
        _errorText.text = $"{message}, error code:{returnCode}";
        yield return new WaitForSeconds(time);
        _errorText.text = "";
        _showErrorCoroutine = null;
    }
}
