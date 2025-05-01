import { RestApiAddressLookupElectricityMeter } from "../../server/address/lookup/restApiAddressLookupElectricityMeter";

export type LookupElectricityMeter = {
    mpan?: string; // Meter Point Administration Number
    addressLine1?: string; // Metering Point address line 1
    addressLine2?: string; // Metering Point address line 2
    addressLine3?: string; // Metering Point address line 3
    addressLine4?: string; // Metering Point address line 4
    addressLine5?: string; // Metering Point address line 5
    addressLine6?: string; // Metering Point address line 6
    addressLine7?: string; // Metering Point address line 7
    addressLine8?: string; // Metering Point address line 8
    addressLine9?: string; // Metering Point address line 9
    addressPostalCode?: string; // Metering Point postcode
    tradingStatus?: string; // MPAN trading status
    tradingStatusEfd?: string; // MPAN trading status effective from date
    profileClass?: string; // Profile Class
    profileClassEfd?: string; // Profile Class effective from date
    meterTimeswitchClass?: string; // Meter Time-switch Class
    meterTimeswitchClassEfd?: string; // Meter Time-switch Class effective from date
    lineLossFactor?: string; // Line Loss Factor Class
    lineLossFactorEfd?: string; // Line Loss Factor Class effective from date
    standardSettlementConfiguration?: string; // Standard Settlement Configuration
    standardSettlementConfigurationEfd?: string; // Standard Settlement Configuration effective from date
    energisationStatus?: string; // Energisation status
    energisationStatusEfd?: string; // Energisation status effective from date
    gspGroupId?: string; // Grid Supply Point Group Id
    gspGroupEfd?: string; // Grid Supply Point Group effective from date
    dataAggregatorMpid?: string; // Data Aggregator MPID
    dataAggregatorEfd?: string; // Data Aggregator appointment effective from date
    dataCollectorMpid?: string; // Data Collector MPID
    dataCollectorEfd?: string; // Data Collector appointment effective from date
    supplierMpid?: string; // Supplier MPID
    supplierEfd?: string; // Effective from date of the current supplier
    meterOperatorMpid?: string; // Meter Operator MPID
    meterOperatorEfd?: string; // Meter Operator appointment effective from date
    measurementClass?: string; // Measurement Class
    measurementClassEfd?: string; // Measurement Class effective from date
    greenDealInEffect?: boolean; // An indicator whether Green Deal is currently active for this MPAN
    smsoMpid?: string; // Smart Metering System Operator MPID
    smsoEfd?: string; // Smart Metering System Operator effective from date
    dccServiceFlag?: boolean; // Data Communications Company Service Flag
    dccServiceFlagEfd?: string; // Data Communications Company Service Flag effective from date
    ihdStatus?: string; // In Home Display Install status
    ihdStatusEfd?: string; // In Home Display Install status effective from date
    smetsVersion?: string; // Smart Metering Equipment Technical Specification version
    distributorMpid?: string; // Distributor MPID
    meteredIndicator?: boolean; // Metered Indicator
    meteredIndicatorEfd?: string; // Metered Indicator effective from date
    meteredIndicatorEtd?: string; // Metered Indicator effective to date
    consumerType?: string; // Consumer Type
    relationshipStatusIndicator?: string; // Relationship Status Indicator
    rmpState?: string; // RMP State
    rmpEfd?: string; // RMP State effective from date
    domesticConsumerIndicator?: boolean; // Domestic Consumer Indicator as supplied via CSS messages
    cssSupplierMpid?: string; // Current supplier as supplied via CSS messages
    cssSupplyStartDate?: string; // Current supply start date as supplier via CSS messages
    meterSerialNumber?: string; // Meter Serial Number
    meterInstallDate?: string; // Meter Install Date
    meterType?: string; // Meter Type
    mapMpid?: string; // Meter Asset Provider MPID
    mapMpidEfd?: string; // Meter Asset Provider effective from date
    installingSupplierMpid?: string; // Installing Supplier MPID
};

export function restApiResponseToLookupElectricityMeter(response: RestApiAddressLookupElectricityMeter): LookupElectricityMeter {
    function parseDate(dateString: Date): Date {
        return new Date(dateString.toString().replace(" ", "T"));
    }

    return {
        mpan: response.mpan,
        addressLine1: response.address_line_1,
        addressLine2: response.address_line_2,
        addressLine3: response.address_line_3,
        addressLine4: response.address_line_4,
        addressLine5: response.address_line_5,
        addressLine6: response.address_line_6,
        addressLine7: response.address_line_7,
        addressLine8: response.address_line_8,
        addressLine9: response.address_line_9,
        addressPostalCode: response.address_postal_code,
        tradingStatus: response.trading_status,
        tradingStatusEfd: response.trading_status_efd,
        profileClass: response.profile_class,
        profileClassEfd: response.profile_class_efd,
        meterTimeswitchClass: response.meter_timeswitch_class,
        meterTimeswitchClassEfd: response.meter_timeswitch_class_efd,
        lineLossFactor: response.line_loss_factor,
        lineLossFactorEfd: response.line_loss_factor_efd,
        standardSettlementConfiguration: response.standard_settlement_configuration,
        standardSettlementConfigurationEfd: response.standard_settlement_configuration_efd,
        energisationStatus: response.energisation_status,
        energisationStatusEfd: response.energisation_status_efd,
        gspGroupId: response.gsp_group_id,
        gspGroupEfd: response.gsp_group_efd,
        dataAggregatorMpid: response.data_aggregator_mpid,
        dataAggregatorEfd: response.data_aggregator_efd,
        dataCollectorMpid: response.data_collector_mpid,
        dataCollectorEfd: response.data_collector_efd,
        supplierMpid: response.supplier_mpid,
        supplierEfd: response.supplier_efd,
        meterOperatorMpid: response.meter_operator_mpid,
        meterOperatorEfd: response.meter_operator_efd,
        measurementClass: response.measurement_class,
        measurementClassEfd: response.measurement_class_efd,
        greenDealInEffect: response.green_deal_in_effect,
        smsoMpid: response.smso_mpid,
        smsoEfd: response.smso_efd,
        dccServiceFlag: response.dcc_service_flag,
        dccServiceFlagEfd: response.dcc_service_flag_efd,
        ihdStatus: response.ihd_status,
        ihdStatusEfd: response.ihd_status_efd,
        smetsVersion: response.smets_version,
        distributorMpid: response.distributor_mpid,
        meteredIndicator: response.metered_indicator,
        meteredIndicatorEfd: response.metered_indicator_efd,
        meteredIndicatorEtd: response.metered_indicator_etd,
        consumerType: response.consumer_type,
        relationshipStatusIndicator: response.relationship_status_indicator,
        rmpState: response.rmp_state,
        rmpEfd: response.rmp_efd,
        domesticConsumerIndicator: response.domestic_consumer_indicator,
        cssSupplierMpid: response.css_supplier_mpid,
        cssSupplyStartDate: response.css_supply_start_date,
        meterSerialNumber: response.meter_serial_number,
        meterInstallDate: response.meter_install_date,
        meterType: response.meter_type,
        mapMpid: response.map_mpid,
        mapMpidEfd: response.map_mpid_efd,
        installingSupplierMpid: response.installing_supplier_mpid,
    };
}
    