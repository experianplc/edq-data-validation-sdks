using DVSClient.Server.Address.Format;

namespace DVSClient.Address.Format
{
    public class AddressMetadata
    {
        public IEnumerable<string> Sources { get; }
        public string NumberOfHouseholds { get; }
        public string JustBuiltDate { get; }
        public string Umrrn { get; }
        public string Udprn { get; }
        public string Dpid { get; }
        public string Gnafpid { get; }
        public string PafAddressKey { get; }
        public string Hin { get; }
        public string DeliveryPointBarcode { get; }
        public string BarcodeCheckDigit { get; }
        public string BarcodeSortPlanNumber { get; }

        public AddressMetadata(RestApiAddressFormatMetadata apiMetadata)
        {
            var apiInfo = apiMetadata.AddressInfo;
            if (apiInfo != null)
            {
                Sources = apiInfo.Sources ?? new List<string>();
                NumberOfHouseholds = apiInfo.NumberOfHouseholds ?? string.Empty;
                JustBuiltDate = apiInfo.JustBuiltDate ?? string.Empty;

                var identifier = apiInfo.Identifier;
                if (identifier != null)
                {
                    Umrrn = identifier.Umrrn ?? string.Empty;
                    Udprn = identifier.Udprn ?? string.Empty;
                    Dpid = identifier.Dpid ?? string.Empty;
                    Gnafpid = identifier.Gnafpid ?? string.Empty;
                    PafAddressKey = identifier.PafAddressKey ?? string.Empty;
                    Hin = identifier.Hin ?? string.Empty;
                }
                else
                {
                    Umrrn = string.Empty;
                    Udprn = string.Empty;
                    Dpid = string.Empty;
                    Gnafpid = string.Empty;
                    PafAddressKey = string.Empty;
                    Hin = string.Empty;
                }
            }
            else
            {
                Sources = new List<string>();
                NumberOfHouseholds = string.Empty;
                JustBuiltDate = string.Empty;
                Umrrn = string.Empty;
                Udprn = string.Empty;
                Dpid = string.Empty;
                Gnafpid = string.Empty;
                PafAddressKey = string.Empty;
                Hin = string.Empty;
            }

            var barcode = apiMetadata.Barcode;
            if (barcode != null)
            {
                DeliveryPointBarcode = barcode.DeliveryPointBarcode ?? string.Empty;
                BarcodeCheckDigit = barcode.CheckDigit ?? string.Empty;
                BarcodeSortPlanNumber = barcode.SortPlanNumber ?? string.Empty;
            }
            else
            {
                DeliveryPointBarcode = string.Empty;
                BarcodeCheckDigit = string.Empty;
                BarcodeSortPlanNumber = string.Empty;
            }
        }
    }
}