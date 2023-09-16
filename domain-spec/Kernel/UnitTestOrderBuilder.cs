namespace Domain.Spec.Kernel;

public class UnitTestOrderBuilder : Order.Builder
{
    private IEnumerator<LineItem> _enumerator;
    private readonly List<LineItem> _lineItems = new();

    #region Public Interface

    public UnitTestOrderBuilder Load(IEnumerable<LineItem> lineItems)
    {
        _lineItems.Clear();
        _lineItems.AddRange(lineItems);
        _enumerator = _lineItems.GetEnumerator();

        return this;
    }

    #endregion

    #region Protected Interface

    protected override void AddLineItem()
    {
        var (productId, quantity, price) = _enumerator.Current;
        Order.AddLineItem(productId, quantity, price);
    }

    protected override bool Next() => _enumerator.MoveNext();

    #endregion
}