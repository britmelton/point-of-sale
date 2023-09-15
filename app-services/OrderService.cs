﻿using Domain;

namespace App.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepo;

    #region Creation

    public OrderService(IOrderRepository orderRepo)
    {
        _orderRepo = orderRepo;
    }

    #endregion

    #region IOrderService Implementation

    public Guid SubmitOrder(SubmitOrderCommand args)
    {
        var order = new SubmitOrderBuilder()
            .Load(args.LineItems)
            .Build()
            .GetOrder();
        order.Submit();

        _orderRepo.CreateOrder(order);
        _orderRepo.Update(order);

        return order.Id;
    }

    #endregion
}

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
        Order.AddLineItem(productId, quantity, price);
    }

    protected override bool Next() => _enumerator.MoveNext();

    #endregion
}
