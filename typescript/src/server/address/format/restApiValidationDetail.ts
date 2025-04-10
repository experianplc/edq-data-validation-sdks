export type RestApiValidationDetail = {
    building_firm_name_corrected?: boolean;
    primary_number_corrected?: boolean;
    street_corrected?: boolean;
    rural_route_highway_contract_matched?: boolean;
    city_name_corrected?: boolean;
    city_name_alias_matched?: boolean;
    state_corrected?: boolean;
    zip_code_corrected?: boolean;
    secondary_num_retained?: boolean;
    iden_pre_st_info_retained?: boolean;
    gen_pre_st_info_retained?: boolean;
    post_st_info_retained?: boolean;
};