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
        public Builder  Build()
        {
            Order = new();

            while (Next())
                AddLineItem();
            
            return this;
        }

        public Order GetOrder() => Order;
        protected abstract void AddLineItem();
        protected abstract bool Next();


        #endregion
    }
}
