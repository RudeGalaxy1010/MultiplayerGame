using Source.Bootstrap;
using Source.Game.Coins;
using TMPro;

namespace Source.UI
{
    public class CoinsCounter : ICoinsCounter, IUnsubscribeOnlyHandler
    {
        private const string StartTextValue = "0";

        private TMP_Text _counterText;
        
        private IPlayerWallet _wallet;

        public CoinsCounter(TMP_Text counterText)
        {
            _counterText = counterText;
        }
        
        public void SetPlayerWallet(IPlayerWallet wallet)
        {
            _wallet = wallet;
            _wallet.CoinsValueChanged += OnCoinsValueChanged;
            _counterText.text = StartTextValue;
        }

        private void OnCoinsValueChanged(int value)
        {
            _counterText.text = value.ToString();
        }

        public void Unsubscribe()
        {
            if (_wallet != null)
            {
                _wallet.CoinsValueChanged -= OnCoinsValueChanged;
            }
        }
    }
}
