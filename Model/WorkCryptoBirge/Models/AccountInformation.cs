using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TradingBot.Models
{
    public class AccountInformation : INotifyPropertyChanged
    {
        private decimal makerCommission;

        public decimal MakerCommission
        {
            get { return makerCommission; }
            set
            {
                makerCommission = value;
                OnPropertyChanged("MakerCommission");
            }
        }
        public decimal TakerCommission { get; set; }
        public decimal BuyerCommission { get; set; }
        public decimal SellerCommission { get; set; }
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
