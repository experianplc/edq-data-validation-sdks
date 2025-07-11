# Data Validation Solutions - Software Development Kits (SDKs)

The Experian DVS SDKs provide convenient access to the RESTful Experian APIs.

## Build status
![dotnet build status](https://github.com/experianplc/edq-data-validation-sdks/actions/workflows/dotnet.yml/badge.svg)
![java build status](https://github.com/experianplc/edq-data-validation-sdks/actions/workflows/gradle.yml/badge.svg)
![typescript build status](https://github.com/experianplc/edq-data-validation-sdks/actions/workflows/typescript.yml/badge.svg)

## Prerequisites

To use Experian's Data Validation Solution APIs and get a successful response, you'll need:

- A **license** to use the product. Haven't got a license? Talk to your account manager or [contact us](https://docs.experianaperture.io/more/contact-us/) to get it.
- Your **authentication token**. This confirms you are licensed to use the APIs and authenticates each request you send to the API. Existing customers can view and manage their tokens via the [Self Service Portal](https://docs.experianaperture.io/more/self-service-portal/).

## API Documentation

For detailed documentation of Experian's Data Validation Solution APIs, visit

- [Experian Address Validation](https://docs.experianaperture.io/address-validation/experian-address-validation/)
- [Experian Email Validation](https://docs.experianaperture.io/email-validation/experian-email-validation-v2)
- [Experian Phone Validation](https://docs.experianaperture.io/phone-validation/experian-phone-validation)

## Contributions

We welcome contributions from the community! Please follow the [fork and pull request](https://docs.github.com/en/get-started/exploring-projects-on-github/contributing-to-a-project) workflow.

## Sample usage

The examples below show how your application can easily create and customize address, email, and phone validation requests. In the below code snippets replace "YOUR AUTHENTICATION TOKEN" with the value of your token and "YOUR REFERENCE ID" with an identifier that can be used to uniquely identify your transaction within Experian's systems.

- [.NET](#dotnet)
- [Java](#java)
- [Typescript](#typescript)

### .NET

#### Address validation
```csharp
// Create a client
var configuration = AddressConfiguration
    .NewBuilder("YOUR AUTHENTICATION TOKEN")
    .SetTransactionId("YOUR REFERENCE ID")
    .UseDataset(Dataset.GbAddress)
    .UseMaxSuggestions(10)
    .Build();
var client = ExperianDataValidation.GetAddressClient(configuration);

// Search for an address
var searchResult = client.Search(SearchType.Autocomplete, "160 Blackfriars Rd");

// Pick the first address in the list of suggestions
var globalAddressKey = searchResult.Suggestions.First().GlobalAddressKey;

// Format the selected address with default layout
var result = client.Format(globalAddressKey);

// Do something with the result
```

#### Email validation
```csharp
// Create a client
var configuration = EmailConfiguration
    .NewBuilder("YOUR AUTHENTICATION TOKEN")
    .SetTransactionId("YOUR REFERENCE ID")
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
var configuration = PhoneConfiguration
    .NewBuilder("YOUR AUTHENTICATION TOKEN")
    .SetTransactionId("YOUR REFERENCE ID")
    .IncludeMetadata()
    .Build();
var client = ExperianDataValidation.GetPhoneClient(configuration);

// Validate a phone number
var result = client.ValidateAsync("+442074987788").GetAwaiter().GetResult();

if (result.PhoneType == Confidence.Landline) {
    // Do something with the result
}
```

### Java

#### Address validation
```java
// Create a client
final Configuration configuration = AddressConfiguration
    .newBuilder("YOUR AUTHENTICATION TOKEN")
    .setTransactionId("YOUR REFERENCE ID")
    .useDataset(Dataset.AU_ADDRESS)
    .useMaxSuggestions(5)
    .build();
var client = ExperianDataValidation.GetAddressClient(configuration);

// Search for an address
final SearchResult result = client.search(SearchType.SINGLELINE, "56 Queens R");

// Pick the first address in the list of suggestions
final var globalAddressKey = result.getSuggestions().get(0).getGlobalAddressKey();

// Format the selected address with default layout
final var result = client.format(globalAddressKey);

// Do something with the result
```

#### Email validation
```java
// Create a client
final Configuration configuration = EmailConfiguration
    .newBuilder("YOUR AUTHENTICATION TOKEN")
    .setTransactionId("YOUR REFERENCE ID")
    .includeMetadata()
    .build();
final EmailClient client = ExperianDataValidation.getEmailClient(configuration);

// Validate an email address
final var result = client.validate("support@experian.com");

if (result.getConfidence() == Confidence.VERIFIED) {
    // Do something with the result
}
```

#### Phone validation
```java
// Create a client
final Configuration configuration = PhoneConfiguration
    .newBuilder("YOUR AUTHENTICATION TOKEN")
    .setTransactionId("YOUR REFERENCE ID")
    .includeMetadata()
    .build();
final PhoneClient client = ExperianDataValidation.getPhoneClient(configuration);

// Validate a phone number
final var result = client.validate("+442074987788");

if (result.getConfidence() == Confidence.VERIFIED) {
    // Do something with the result
}
```

### Typescript
#### Address validation
```typescript
// Create a client
const config = new AddressConfiguration(
    "YOUR AUTHENTICATION TOKEN",
    {
        transactionId: "YOUR REFERENCE ID",
        datasets: [Datasets.AuAddress],
        maxSuggestions: 5
    }        
);
const client = new AddressClient(config);

// Search for an address
const searchResult = await client.search("56 Queens R");

// Pick the first address in the list of suggestions
const globalAddressKey = searchResult.suggestions[0].globalAddressKey;        

// Format the selected address with default layout
const result = await client.format(globalAddressKey);

// Do something with the result
```

#### Email validation
```typescript
// Create a client
const config = new EmailConfiguration(
    "YOUR AUTHENTICATION TOKEN",
    {
        transactionId: "YOUR REFERENCE ID",
        includeMetadata: true
    }        
);
const client = new EmailClient(config);

// Validate an email address
const result = await client.validate("support@experian.com");

if (result.getConfidence() == Confidence.VERIFIED) {
    // Do something with the result
}
```

#### Phone validation
```typescript
// Create a client
const config = new PhoneConfiguration(
    "YOUR AUTHENTICATION TOKEN",
    {
        transactionId: "YOUR REFERENCE ID",
        includeMetadata: true
    }        
);
const client = new PhoneClient(config);

// Validate a phone number
const result = await client.validate("+442074987788");

if (result.getConfidence() == Confidence.VERIFIED) {
    // Do something with the result
}
```
