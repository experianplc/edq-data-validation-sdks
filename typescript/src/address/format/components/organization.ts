import { BusinessOrganization } from "./businessOrganization";

export type Organization = {
    departmentName?: string;
    secondaryDepartmentName?: string;
    companyName?: string;
    business?: BusinessOrganization;
};