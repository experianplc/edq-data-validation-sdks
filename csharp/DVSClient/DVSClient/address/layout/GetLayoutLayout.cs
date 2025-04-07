using DVSClient.Common;
using DVSClient.Server.Address.Layout;

namespace DVSClient.Address.Layout
{
    public class GetLayoutLayout
    {
        internal string Id { get; }
        internal string Name { get; }
        internal string Comment { get; }
        internal IEnumerable<AppliesTo> AppliesTo { get; }
        internal IEnumerable<ILayoutLine> Lines { get; }
        internal Status? Status { get; }
        internal string LicenseId { get; }

        public GetLayoutLayout(RestApiGetLayoutLayout? layout)
        {
            Id = layout?.Id ?? string.Empty;
            Name = layout?.Name ?? string.Empty;
            Comment = layout?.Comment ?? string.Empty;
            AppliesTo = layout?.AppliesTo != null ? layout.AppliesTo.Select(a => new AppliesTo(a)).ToList() : new List<AppliesTo>();
            Lines = layout?.Lines != null ? layout.Lines.Select(p => GetLayoutLine(AppliesTo, p)).ToList() : new List<ILayoutLine>();
            Status = layout?.Status?.GetEnumValueFromJsonName<Status>();
            LicenseId = layout?.LicenseId ?? string.Empty;
        }

        private ILayoutLine GetLayoutLine(IEnumerable<AppliesTo> appliesTo, RestApiAddressLayoutLine line)
        {
            if (line.Elements == null || !line.Elements.Any())
            {
                return new LayoutLineVariable(line);
            }
            return new LayoutLineFixed(appliesTo, line);
        }
    }
}