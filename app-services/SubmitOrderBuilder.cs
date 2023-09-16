using Domain;

namespace App.Services;

public class SubmitOrderBuilder : Order.Builder
{
    private IEnumerator<LineItem> _enumerator;
    private readonly List<LineItem> _lineItems = new();

    #region Public Interface

    public SubmitOrderBuilder Load(IEnumerable<LineItem> lineItems)
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
        Order.AddLineItem(productId, price, quantity);
    }

    protected override bool Next() => _enumerator.MoveNext();

    #endregion
}