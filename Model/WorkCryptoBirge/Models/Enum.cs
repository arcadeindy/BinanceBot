namespace TradingBot.Models
{
    public enum OrderTypes
    {
        LIMIT,
        MARKET,
        STOP_LOSS,
        STOP_LOSS_LIMIT,
        TAKE_PROFIT,
        TAKE_PROFIT_LIMIT,
        LIMIT_MAKER
    }
    public enum OrderStatuses
    {
        NEW,
        PARTIALLY_FILLED,
        FILLED,
        CANCELED,
        PENDING_CANCEL,
        REJECTED,
        EXPIRED,
    }
    public enum OrderSides
	{
		BUY,
		SELL
	}
	public enum TimesInForce
	{
		GTC,
		IOC,
		FOK
	}

    public enum ListOrderStatus
    {
        EXECUTING,
        ALL_DONE,
        REJECT
    }

    public enum ListStatusType
    {
        RESPONSE,
        EXEC_STARTED,
        ALL_DONE
    }

    public enum ContingencyType
    {
        OCO
    }
}
