import { Countries, Country } from "../../common/country";
import { RestApiAddressFormatComponents } from "../../server/address/format/restApiAddressFormatComponents";
import { AdditionalElements } from "./components/additionalElements";
import { ComponentBuilding } from "./components/componentBuilding";
import { DeliveryService } from "./components/deliveryService";
import { Locality } from "./components/locality";
import { Organization } from "./components/organization";
import { PostalCode } from "./components/postalCode";
import { RouteService } from "./components/routeService";
import { Street } from "./components/street";
import { SubBuilding } from "./components/subBuilding";

export type AddressComponents = {
    language?: string;
    country?: Country;
    postalCode?: PostalCode;
    deliveryService?: DeliveryService;
    secondaryDeliveryService?: DeliveryService;
    subBuilding?: SubBuilding;
    building?: ComponentBuilding;
    organization?: Organization;
    street?: Street;
    secondaryStreet?: Street;
    routeService?: RouteService;
    locality?: Locality;
    physicalLocality?: Locality;
    additionalElements?: AdditionalElements;
};

export function restApiResponseToAddressComponents(response: RestApiAddressFormatComponents): AddressComponents {

    const result: AddressComponents = {};
        
    result.language = response.language ?? "";
    result.country = response.country_iso_3 ? Countries.fromIso3(response.country_iso_3) : undefined;
    result.postalCode = mapPostalCode(response.postal_code);
    result.deliveryService = mapDeliveryService(response.delivery_service);
    result.secondaryDeliveryService = mapDeliveryService(response.secondary_delivery_service);
    result.subBuilding = mapSubBuilding(response.sub_building);
    result.building = mapBuilding(response.building);
    result.organization = mapOrganization(response.organization);
    result.street = mapStreet(response.street);
    result.secondaryStreet = mapStreet(response.secondary_street);
    result.routeService = mapRouteService(response.route_service);
    result.locality = mapLocality(response.locality);
    result.physicalLocality = mapLocality(response.physical_locality);
    result.additionalElements = mapAdditionalElements(response.additional_elements);

    return result;
}

function mapPostalCode(postalCode?: RestApiAddressFormatComponents['postal_code']): PostalCode | undefined {
    return postalCode ? {
        fullName: postalCode.full_name,
        primary: postalCode.primary,
        secondary: postalCode.secondary
    } : undefined;
}

function mapDeliveryService(service?: RestApiAddressFormatComponents['delivery_service']): DeliveryService | undefined {
    return service ? {
        fullName: service.full_name,
        serviceType: service.service_type,
        serviceNumber: service.service_number,
        postCentreName: service.post_centre_name
    } : undefined;
}

function mapSubBuilding(subBuilding?: RestApiAddressFormatComponents['sub_building']): SubBuilding | undefined {
    return subBuilding ? {
        name: subBuilding.name ?? "",
        entrance: subBuilding.entrance,
        floor: subBuilding.floor,
        door: subBuilding.door
    } : undefined;
}

function mapBuilding(building?: RestApiAddressFormatComponents['building']): ComponentBuilding | undefined {
    return building ? {
        buildingName: building.building_name,
        secondaryName: building.secondary_name,
        buildingNumber: building.building_number,
        secondaryNumber: building.secondary_number,
        allotmentNumber: building.allotment_number
    } : undefined;
}

function mapOrganization(organization?: RestApiAddressFormatComponents['organization']): Organization | undefined {
    return organization ? {
        departmentName: organization.department_name,
        secondaryDepartmentName: organization.secondary_department_name,
        companyName: organization.company_name,
        business: organization.business
    } : undefined;
}

function mapStreet(street?: RestApiAddressFormatComponents['street']): Street | undefined {
    return street ? {
        fullName: street.full_name,
        prefix: street.prefix,
        name: street.name,
        type: street.type,
        suffix: street.suffix
    } : undefined;
}

function mapRouteService(routeService?: RestApiAddressFormatComponents['route_service']): RouteService | undefined {
    return routeService ? {
        fullName: routeService.full_name,
        serviceType: routeService.service_type,
        serviceNumber: routeService.service_number,
        deliveryName: routeService.delivery_name,
        qualifier: routeService.qualifier
    } : undefined;
}

function mapLocality(locality?: RestApiAddressFormatComponents['locality']): Locality | undefined {
    return locality ? {
        region: locality.region,
        subRegion: locality.sub_region,
        town: locality.town,
        district: locality.district,
        subDistrict: locality.sub_district
    } : undefined;
}

function mapAdditionalElements(additionalElements?: RestApiAddressFormatComponents['additional_elements']): AdditionalElements | undefined {
    return additionalElements ? {
        locality: additionalElements.locality ? {
            subRegion: additionalElements.locality.sub_region ? {
                administrativeCounty: additionalElements.locality.sub_region.administrative_county ?? "",
                formerPostalCounty: additionalElements.locality.sub_region.former_postal_county ?? "",
                traditionalCounty: additionalElements.locality.sub_region.traditional_county ?? ""
            } : undefined
        } : undefined
    } : undefined;
}