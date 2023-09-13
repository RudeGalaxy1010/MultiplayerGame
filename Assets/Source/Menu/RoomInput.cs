using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Menu
{
    public class RoomInput : MonoBehaviour
    {
        [SerializeField] private Button _joinButton;
        [SerializeField] private Button _createButton;
        [SerializeField] private TMP_InputField _nickNameInputField;
        [SerializeField] private TMP_InputField _roomNameInputField;
        [SerializeField] private RoomManagement _roomManagement;

        private string NickName => _nickNameInputField.text;
        private string RoomName => _roomNameInputField.text;

        private void OnEnable()
        {
            _joinButton.onClick.AddListener(OnJoinButtonClick);
            _createButton.onClick.AddListener(OnCreateButtonClick);
        }

        private void OnDisable()
        {
            _joinButton.onClick.RemoveListener(OnJoinButtonClick);
            _createButton.onClick.RemoveListener(OnCreateButtonClick);
        }

        private void OnJoinButtonClick()
        {
            _roomManagement.JoinRoom(NickName, RoomName);
        }

        private void OnCreateButtonClick()
        {
            _roomManagement.CreateRoom(NickName, RoomName);
        }
    }
}
