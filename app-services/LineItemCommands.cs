﻿namespace App.Services;

public record AddLineItemsCommand(
    Guid CartId,
    List<CartLineItem> LineItems
    );

public record CartLineItem(
    Guid CartId,
    Guid ProductId,
    ushort Quantity,
    decimal Price
);