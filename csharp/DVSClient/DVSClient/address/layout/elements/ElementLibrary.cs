using System.Reflection;

namespace DVSClient.Address.Layout.Elements
{
    public abstract class ElementLibrary
    {
        private ElementLibrary()
        {
            throw new InvalidOperationException("Utility class");
        }

        private static readonly Dictionary<Dataset, Type> DatasetToAddressElementClassMap = new Dictionary<Dataset, Type>
        {
            { Dataset.AuAddress, typeof(Aus) },
            { Dataset.AuAddressGnaf, typeof(Aug) },
            { Dataset.GbAddress, typeof(Gbr) },
        };

        private static readonly Dictionary<Dataset, Dictionary<string, IAddressElement>> ElementNameToAddressElementMap = new Dictionary<Dataset, Dictionary<string, IAddressElement>>();

        private static Dictionary<string, IAddressElement> GetElementNameToAddressElementMap(Dataset dataset)
        {
            if (!DatasetToAddressElementClassMap.TryGetValue(dataset, out var cls))
            {
                throw new ArgumentException($"No AddressElements class found for dataset: {dataset.DatasetCode}");
            }

            try
            {
                if (cls != null)
                {
                    var fields = cls.GetFields(BindingFlags.Static | BindingFlags.Public);
                    var elementNameToAddressElementMap = new Dictionary<string, IAddressElement>();

                    MethodInfo? methodInfo = cls.GetMethod("GetElement");

                    if (fields != null && methodInfo != null)
                    {
                        for (int i = 0; i < fields.Length; i++)
                        {
                            IAddressElement? info = (IAddressElement?)methodInfo.Invoke(methodInfo, new object[] { fields[i].Name });
                            if (info != null)
                            {
                                elementNameToAddressElementMap[info.GetElementName()] = info;
                            }
                        }

                        return elementNameToAddressElementMap;
                    }
                }

                throw new InvalidOperationException($"Error looking up address elements for dataset {dataset}");
            }
            catch (Exception e) when (e is TargetInvocationException || e is MethodAccessException)
            {
                throw new InvalidOperationException($"Error looking up address elements for dataset {dataset}", e);
            }
        }

        public static IAddressElement? GetAddressElementFromElementName(IEnumerable<AppliesTo> appliesTo, string? elementName)
        {
            foreach (var nextAppliesTo in appliesTo)
            {
                foreach (var dataset in nextAppliesTo.Datasets)
                {
                    var addressElement = GetAddressElementFromElementName(dataset, elementName);
                    if (addressElement != null)
                    {
                        return addressElement;
                    }
                }
            }
            return null;
        }

        public static IAddressElement? GetAddressElementFromElementName(Dataset dataset, string? elementName)
        {
            ElementNameToAddressElementMap.TryAdd(dataset, GetElementNameToAddressElementMap(dataset));
            ElementNameToAddressElementMap.TryGetValue(dataset, out var dictionaryEntry);

            if (dictionaryEntry != null && !string.IsNullOrWhiteSpace(elementName))
            {
                return dictionaryEntry.TryGetValue(elementName, out var addressElement) ? addressElement : null;
            }

            return null;
        }
    }
}