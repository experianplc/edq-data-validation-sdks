
export type RestApiAddressLookupElectricityMeter = {
    mpan?: string; // Meter Point Administration Number
    address_line_1?: string; // Metering Point address line 1
    address_line_2?: string; // Metering Point address line 2
    address_line_3?: string; // Metering Point address line 3
    address_line_4?: string; // Metering Point address line 4
    address_line_5?: string; // Metering Point address line 5
    address_line_6?: string; // Metering Point address line 6
    address_line_7?: string; // Metering Point address line 7
    address_line_8?: string; // Metering Point address line 8
    address_line_9?: string; // Metering Point address line 9
    address_postal_code?: string; // Metering Point postcode
    trading_status?: string; // MPAN trading status
    trading_status_efd?: string; // MPAN trading status effective from date
    profile_class?: string; // Profile Class
    profile_class_efd?: string; // Profile Class effective from date
    meter_timeswitch_class?: string; // Meter Time-switch Class
    meter_timeswitch_class_efd?: string; // Meter Time-switch Class effective from date
    line_loss_factor?: string; // Line Loss Factor Class
    line_loss_factor_efd?: string; // Line Loss Factor Class effective from date
    standard_settlement_configuration?: string; // Standard Settlement Configuration
    standard_settlement_configuration_efd?: string; // Standard Settlement Configuration effective from date
    energisation_status?: string; // Energisation status
    energisation_status_efd?: string; // Energisation status effective from date
    gsp_group_id?: string; // Grid Supply Point Group Id
    gsp_group_efd?: string; // Grid Supply Point Group effective from date
    data_aggregator_mpid?: string; // Data Aggregator MPID
    data_aggregator_efd?: string; // Data Aggregator appointment effective from date
    data_collector_mpid?: string; // Data Collector MPID
    data_collector_efd?: string; // Data Collector appointment effective from date
    supplier_mpid?: string; // Supplier MPID
    supplier_efd?: string; // Effective from date of the current supplier
    meter_operator_mpid?: string; // Meter Operator MPID
    meter_operator_efd?: string; // Meter Operator appointment effective from date
    measurement_class?: string; // Measurement Class
    measurement_class_efd?: string; // Measurement Class effective from date
    green_deal_in_effect?: boolean; // An indicator whether Green Deal is currently active for this MPAN
    smso_mpid?: string; // Smart Metering System Operator MPID
    smso_efd?: string; // Smart Metering System Operator effective from date
    dcc_service_flag?: boolean; // Data Communications Company Service Flag
    dcc_service_flag_efd?: string; // Data Communications Company Service Flag effective from date
    ihd_status?: string; // In Home Display Install status
    ihd_status_efd?: string; // In Home Display Install status effective from date
    smets_version?: string; // Smart Metering Equipment Technical Specification version
    distributor_mpid?: string; // Distributor MPID
    metered_indicator?: boolean; // Metered Indicator
    metered_indicator_efd?: string; // Metered Indicator effective from date
    metered_indicator_etd?: string; // Metered Indicator effective to date
    consumer_type?: string; // Consumer Type
    relationship_status_indicator?: string; // Relationship Status Indicator
    rmp_state?: string; // RMP State
    rmp_efd?: string; // RMP State effective from date
    domestic_consumer_indicator?: boolean; // Domestic Consumer Indicator as supplied via CSS messages
    css_supplier_mpid?: string; // Current supplier as supplied via CSS messages
    css_supply_start_date?: string; // Current supply start date as supplier via CSS messages
    meter_serial_number?: string; // Meter Serial Number
    meter_install_date?: string; // Meter Install Date
    meter_type?: string; // Meter Type
    map_mpid?: string; // Meter Asset Provider MPID
    map_mpid_efd?: string; // Meter Asset Provider effective from date
    installing_supplier_mpid?: string; // Installing Supplier MPID
};
    