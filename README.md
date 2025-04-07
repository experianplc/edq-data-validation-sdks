# Data Validation Solutions - Software Development Kits (SDKs)

The Experian DVS SDKs provide convenient access to the RESTful Experian APIs.

## API Documentation

For detailed documentation of Experian's Data Validation Solution APIs, visit

- [Experian Address Validation](https://docs.experianaperture.io/address-validation/experian-address-validation/)
- [Experian Email Validation](https://docs.experianaperture.io/email-validation/experian-email-validation-v2)
- [Experian Phone Validation](https://docs.experianaperture.io/phone-validation/experian-phone-validation)

## Sample usage

The examples below show how your application can easily create and customize address, email, and phone validation requests.

### Dotnet

#### Address validation
```csharp
// Create a client
var configuration = Configuration
    .NewBuilder(<YOUR AUTHENTICATION TOKEN>)
    .SetTransactionId(<REFERENCE ID>)
    .UseDataset(Dataset.GbAddress)
    .UseMaxSuggestions(10)
    .Build();
var client = ExperianDataValidation.GetAddressClient(configuration);

// Search for an address
var searchResult = client.Search(SearchType.Autocomplete, "56 Queens R");

// Pick the first address in the list of suggestions
var globalAddressKey = searchResult.Suggestions.First().GlobalAddressKey;

// Format the selected address with default layout
var formatResult = client.Format(globalAddressKey);

// Do something with the result
```

#### Email validation
```csharp
// Create a client
var configuration = Configuration
    .NewBuilder(<YOUR AUTHENTICATION TOKEN>)
    .SetTransactionId(<REFERENCE ID>)
    .IncludeMetadata()
    .Build();
var emailClient = ExperianDataValidation.GetEmailClient(configuration);

// Validate an email address
var result = emailClient.ValidateAsync("support@experian.com").GetAwaiter().GetResult();

if (result.Confidence == Confidence.Verified) {
    // Do something with the result
}
```

#### Phone validation
```csharp
// Create a client
var configuration = Configuration
    .NewBuilder(<YOUR AUTHENTICATION TOKEN>)
    .SetTransactionId(<REFERENCE ID>)
    .IncludeMetadata()
    .Build();
var client = ExperianDataValidation.GetPhoneClient(configuration);

// Validate an phone number
var result = client.ValidateAsync("+442074987788").GetAwaiter().GetResult();

if (result.PhoneType == Confidence.Landline) {
    // Do something with the result
}
```

### Java

#### Address validation
```java
// Create a client
final Configuration configuration = Configuration
    .newBuilder(<YOUR AUTHENTICATION TOKEN>)
    .useDataset(Dataset.AU_ADDRESS)
    .useMaxSuggestions(5)
    .build();
var client = ExperianDataValidation.GetAddressClient(configuration);

// Search for an address
final com.experian.dvs.client.address.search.Result result = client.search(SearchType.SINGLELINE, "56 Queens R");

// Pick the first address in the list of suggestions
final var globalAddressKey = result.getSuggestions().get(0).getGlobalAddressKey();

// Format the selected address with default layout
final var formatResult = client.format(globalAddressKey);

// Do something with the result
```

#### Email validation
```java
// Create a client
final Configuration configuration = Configuration
    .newBuilder(<YOUR AUTHENTICATION TOKEN>)
    .includeMetadata()
    .build();
final Client client = ExperianDataValidation.getEmailClient(configuration);

// Validate an email address
final var result = client.validate("support@experian.com");

if (result.getConfidence() == Confidence.VERIFIED) {
    // Do something with the result
}
```

#### Phone validation
```java
// Create a client
final Configuration configuration = Configuration
    .newBuilder(<YOUR AUTHENTICATION TOKEN>)
    .includeMetadata()
    .build();
final Client client = ExperianDataValidation.getPhoneClient(configuration);

// Validate an email address
final var result = client.validate("+442074987788");

if (result.getConfidence() == Confidence.VERIFIED) {
    // Do something with the result
}
```