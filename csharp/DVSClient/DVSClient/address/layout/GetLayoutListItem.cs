using DVSClient.Common;
using DVSClient.Server.Address.Layout;

namespace DVSClient.Address.Layout
{
    public class GetLayoutListItem
    {
        internal string Id { get; }
        internal string Name { get; }
        internal IEnumerable<AppliesTo> AppliesTo { get; }
        internal LayoutStatus? Status { get; }

        public GetLayoutListItem(RestApiGetLayoutsListItem item)
        {
            Id = item.Id ?? throw new ArgumentNullException(nameof(item.Id));
            Name = item.Name ?? throw new ArgumentNullException(nameof(item.Name));
            AppliesTo = item.AppliesTo != null ? item.AppliesTo.Select(a => new AppliesTo(a)).ToList() : new List<AppliesTo>();
            Status = item.Status?.GetEnumValueFromJsonName<LayoutStatus>();
        }
    }
}