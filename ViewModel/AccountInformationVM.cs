using Model.API;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TradingBot.Models;

namespace ViewModel
{
    public class AccountInformationVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private AccountInformation accountInformation;
        BinanceAPI api { get; set; }

        public AccountInformationVM()
        {
            api = new BinanceAPI(SettingsAPI.baseUrl);
        }

        public AccountInformation AccountInformation
        {
            get { return accountInformation; }
            set
            {
                accountInformation = value;
                OnPropertyChanged("AccountInformation");
            }
        }

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
