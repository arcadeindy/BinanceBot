using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TradingBot.Models
{
    public class AccountInformation : INotifyPropertyChanged
    {
        private double makerCommission;

        public double MakerCommission
        {
            get { return makerCommission; }
            set
            {
                makerCommission = value;
                OnPropertyChanged("MakerCommission");
            }
        }
        public double TakerCommission { get; set; }
        public double BuyerCommission { get; set; }
        public double SellerCommission { get; set; }
        public bool CanTrade { get; set; }
        public bool CanWithdraw { get; set; }
        public bool CanDeposit { get; set; }
        public List<AssetBalance> Balances { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
