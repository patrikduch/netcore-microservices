using System;

namespace GameCatalog.RabbitMq
{
    public record GameCatalogItemUCreated(Guid ItemId, string Name, string Description);
    public record GameCatalogItemUpdated(Guid ItemId, string Name, string Description);
    public record GameCatalogItemDeleted(Guid ItemId);

}
