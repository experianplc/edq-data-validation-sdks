using DVSClient.Server.Address.Format;

namespace DVSClient.Address.Format.Components
{
        public class Organization
        {
            public string? DepartmentName { get; }
            public string? SecondaryDepartmentName { get; }
            public string? CompanyName { get; }
            public BusinessOrganization? Business { get; }

            public Organization(RestApiAddressFormatComponents.RestApiAddressComponentOrganization api)
            {
                DepartmentName = api.DepartmentName ?? string.Empty;
                SecondaryDepartmentName = api.SecondaryDepartmentName ?? string.Empty;
                CompanyName = api.CompanyName ?? string.Empty;
                Business = api.Business != null ? new BusinessOrganization(api.Business.CompanyName) : null;
            }
        }
    }