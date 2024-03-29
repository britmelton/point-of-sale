﻿namespace Infrastructure.Read.Dtos;

public class LineItem
{
    #region Public Interface

    public Guid Id { get; init; }
    public Guid OrderId { get; init; }
    public Guid ProductId { get; init; }
    public decimal Price { get; init; }
    public ushort Quantity { get; init; }
    public decimal Subtotal { get; init; }

    #endregion
}

public class LineItemDto
{
    #region Creation

    public LineItemDto(Guid id, Guid orderId, Guid productId, decimal price, ushort quantity, decimal subtotal)
    {
        Id = id;
        OrderId = orderId;
        ProductId = productId;
        Price = price;
        Quantity = quantity;
        Subtotal = subtotal;
    }

    public LineItemDto(LineItem source) : this(
        source.Id,
        source.OrderId,
        source.ProductId,
        source.Price,
        source.Quantity,
        source.Subtotal
    )
    { }

    #endregion

    #region Public Interface

    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
    public decimal Price { get; set; }
    public ushort Quantity { get; set; }
    public decimal Subtotal { get; set; }

    #endregion

    #region Static Interface

    public static implicit operator LineItemDto(LineItem source) => new(source);

    #endregion
}
