namespace Domain.Spec.Kernel;

public record SubmitOrder(
        List<LineItem> LineItems
    );