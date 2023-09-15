namespace Domain;

//putting everything with submitting a new order here
public partial class Order
{
    #region Creation

    private Order()
    {
        OrderNumber = GenerateOrderNumber();
        LineItems = new();
    }

    #endregion

    public abstract class Builder
    {
        #region Public Interface

        protected Order Order;
        public void Build()
        {
            Order = new Order();

            while (Next())
            {
                AddLineItem();
            }

        }

        public abstract void AddLineItem();
        public abstract bool Next();


        #endregion
    }
}
