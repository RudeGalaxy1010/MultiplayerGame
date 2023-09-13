using Photon.Pun;
using Source.SceneLoading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Source.UI
{
    public class EndGamePanel : MonoBehaviour
    {
        private ISceneLoader _sceneLoader;
        
        [SerializeField] private TMP_Text _winnerText;
        [SerializeField] protected TMP_Text _coinsValueText;
        [SerializeField] private GameObject _panelView;
        [SerializeField] private Button _returnButton;

        public void Construct(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }
        
        private void OnEnable()
        {
            _returnButton.onClick.AddListener(OnButtonClick);
        }

        private void OnDisable()
        {
            _returnButton.onClick.RemoveListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            _sceneLoader.LoadMenu();
        }
        
        [PunRPC]
        public void Show(string winnerName, int coinsValue)
        {
            _panelView.SetActive(true);
            _winnerText.text = $"{winnerName} is the winner!";
            _coinsValueText.text = $"With {coinsValue} coins";
        }
    }
}
