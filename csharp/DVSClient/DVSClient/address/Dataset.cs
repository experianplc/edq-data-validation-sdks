using DVSClient.Common;

namespace DVSClient.Address
{
    public class Dataset
    {
        public static readonly Dataset AuAddress = new Dataset("au-address", Country.Australia, new List<SearchType> { SearchType.Autocomplete, SearchType.Singleline, SearchType.Typedown, SearchType.Validate, SearchType.LookupV2 }, Accuracy.APlus, Accuracy.APlus);
        public static readonly Dataset AuAddressGnaf = new Dataset("au-address-gnaf", Country.Australia, new List<SearchType> { SearchType.Autocomplete, SearchType.Singleline, SearchType.Typedown, SearchType.Validate, SearchType.LookupV2 }, Accuracy.APlus, Accuracy.APlus);
        public static readonly Dataset AuAddressDatafusion = new Dataset("au-address-datafusion", Country.Australia, new List<SearchType> { SearchType.Autocomplete, SearchType.Singleline, SearchType.Typedown, SearchType.LookupV2 }, Accuracy.APlus, Accuracy.APlus);
        public static readonly Dataset CaAddress = new Dataset("ca-address", Country.Canada, new List<SearchType> { SearchType.Autocomplete, SearchType.Singleline, SearchType.Typedown, SearchType.Validate, SearchType.LookupV2 }, Accuracy.APlus, Accuracy.APlus);
        public static readonly Dataset IeAddress = new Dataset("ie-address", Country.Ireland, new List<SearchType> { SearchType.Singleline, SearchType.Typedown }, Accuracy.APlus, Accuracy.APlus);
        public static readonly Dataset IeAddressEh = new Dataset("ie-address-eh", Country.Ireland, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset IeAdditionalEircode = new Dataset("ie-additional-eircode", Country.Ireland, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.APlus);
        public static readonly Dataset IeAddressEcad = new Dataset("ie-address-ecad", Country.Ireland, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2, SearchType.Singleline, SearchType.Typedown }, Accuracy.APlus, Accuracy.APlus);
        public static readonly Dataset NzAddress = new Dataset("nz-address", Country.NewZealand, new List<SearchType> { SearchType.Autocomplete, SearchType.Singleline, SearchType.Typedown, SearchType.Validate, SearchType.LookupV2 }, Accuracy.APlus, Accuracy.APlus);
        public static readonly Dataset NzAdditionalDatafusion = new Dataset("nz-additional-datafusion", Country.NewZealand, new List<SearchType> { SearchType.Autocomplete, SearchType.Singleline, SearchType.Typedown, SearchType.Validate, SearchType.LookupV2 }, Accuracy.APlus, Accuracy.APlus);
        public static readonly Dataset GbAddress = new Dataset("gb-address", Country.UnitedKingdom, new List<SearchType> { SearchType.Autocomplete, SearchType.Singleline, SearchType.Typedown, SearchType.Validate, SearchType.LookupV2 }, Accuracy.APlus, Accuracy.APlus);
        public static readonly Dataset GbAddressAddressbase = new Dataset("gb-address-addressbase", Country.UnitedKingdom, new List<SearchType> { SearchType.Autocomplete, SearchType.Singleline, SearchType.Typedown, SearchType.Validate, SearchType.LookupV1 }, Accuracy.APlus, Accuracy.APlus);
        public static readonly Dataset GbAdditionalAddressbaseislands = new Dataset("gb-additional-addressbaseislands", Country.UnitedKingdom, new List<SearchType> { SearchType.Singleline, SearchType.Typedown, SearchType.Validate, SearchType.LookupV1 }, Accuracy.APlus, Accuracy.APlus);
        public static readonly Dataset GbAdditionalBusiness = new Dataset("gb-additional-business", Country.UnitedKingdom, new List<SearchType> { SearchType.Autocomplete, SearchType.Singleline, SearchType.Typedown }, Accuracy.APlus, Accuracy.APlus);
        public static readonly Dataset GbAdditionalElectricity = new Dataset("gb-additional-electricity", Country.UnitedKingdom, new List<SearchType> { SearchType.Autocomplete, SearchType.Singleline, SearchType.Typedown, SearchType.LookupV2 }, Accuracy.APlus, Accuracy.APlus);
        public static readonly Dataset GbAdditionalGas = new Dataset("gb-additional-gas", Country.UnitedKingdom, new List<SearchType> { SearchType.Autocomplete, SearchType.Singleline, SearchType.Typedown, SearchType.LookupV2 }, Accuracy.APlus, Accuracy.APlus);
        public static readonly Dataset GbAdditionalNames = new Dataset("gb-additional-names", Country.UnitedKingdom, new List<SearchType> { SearchType.Singleline, SearchType.Typedown }, Accuracy.APlus, Accuracy.APlus);
        public static readonly Dataset GbAddressStreetlevel = new Dataset("gb-address-streetlevel", Country.UnitedKingdom, new List<SearchType> { SearchType.Singleline, SearchType.Typedown }, Accuracy.APlus, Accuracy.APlus);
        public static readonly Dataset GbAdditionalBusinessextended = new Dataset("gb-additional-businessextended", Country.UnitedKingdom, new List<SearchType> { SearchType.Singleline, SearchType.Typedown, SearchType.Validate, SearchType.LookupV1 }, Accuracy.APlus, Accuracy.APlus);
        public static readonly Dataset GbAdditionalNotyetbuilt = new Dataset("gb-additional-notyetbuilt", Country.UnitedKingdom, new List<SearchType> { SearchType.Autocomplete, SearchType.Singleline, SearchType.Typedown, SearchType.Validate, SearchType.LookupV2 }, Accuracy.APlus, Accuracy.APlus);
        public static readonly Dataset GbAdditionalMultipleresidence = new Dataset("gb-additional-multipleresidence", Country.UnitedKingdom, new List<SearchType> { SearchType.Autocomplete, SearchType.Singleline, SearchType.Typedown, SearchType.Validate, SearchType.LookupV2 }, Accuracy.APlus, Accuracy.APlus);
        public static readonly Dataset GbAddressWales = new Dataset("gb-address-wales", Country.UnitedKingdom, new List<SearchType> { SearchType.Singleline, SearchType.Typedown, SearchType.Validate }, Accuracy.APlus, Accuracy.APlus);
        public static readonly Dataset UsAddress = new Dataset("us-address", Country.UnitedStatesOfAmerica, new List<SearchType> { SearchType.Autocomplete, SearchType.Singleline, SearchType.Typedown, SearchType.Validate, SearchType.LookupV2 }, Accuracy.APlus, Accuracy.APlus);
        public static readonly Dataset VeAddressEd = new Dataset("ve-address-ed", Country.Venezuela, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset VeAddressEh = new Dataset("ve-address-eh", Country.Venezuela, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.APlus);
        public static readonly Dataset CuAddressEd = new Dataset("cu-address-ed", Country.Cuba, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.AMinus);
        public static readonly Dataset CuAddressEh = new Dataset("cu-address-eh", Country.Cuba, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.AMinus);
        public static readonly Dataset AfAddressEd = new Dataset("af-address-ed", Country.Afghanistan, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.B);
        public static readonly Dataset AfAddressEh = new Dataset("af-address-eh", Country.Afghanistan, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.B);
        public static readonly Dataset AlAddressEd = new Dataset("al-address-ed", Country.Albania, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.A);
        public static readonly Dataset AlAddressEh = new Dataset("al-address-eh", Country.Albania, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.A);
        public static readonly Dataset DzAddressEd = new Dataset("dz-address-ed", Country.Algeria, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.APlus);
        public static readonly Dataset DzAddressEh = new Dataset("dz-address-eh", Country.Algeria, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.APlus);
        public static readonly Dataset AsAddressEh = new Dataset("as-address-eh", Country.AmericanSamoa, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset AdAddressEd = new Dataset("ad-address-ed", Country.Andorra, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.A);
        public static readonly Dataset AdAddressEh = new Dataset("ad-address-eh", Country.Andorra, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.A);
        public static readonly Dataset AoAddressEd = new Dataset("ao-address-ed", Country.Angola, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset AoAddressEh = new Dataset("ao-address-eh", Country.Angola, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset AiAddressEd = new Dataset("ai-address-ed", Country.Anguilla, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset AiAddressEh = new Dataset("ai-address-eh", Country.Anguilla, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset AqAddressEd = new Dataset("aq-address-ed", Country.Antarctica, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.AMinus, Accuracy.B);
        public static readonly Dataset AgAddressEd = new Dataset("ag-address-ed", Country.AntiguaAndBarbuda, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.B);
        public static readonly Dataset AgAddressEh = new Dataset("ag-address-eh", Country.AntiguaAndBarbuda, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.B);
        public static readonly Dataset ArAddressEd = new Dataset("ar-address-ed", Country.Argentina, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset ArAddressEh = new Dataset("ar-address-eh", Country.Argentina, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset AmAddressEd = new Dataset("am-address-ed", Country.Armenia, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.AMinus);
        public static readonly Dataset AmAddressEh = new Dataset("am-address-eh", Country.Armenia, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.AMinus);
        public static readonly Dataset AwAddressEd = new Dataset("aw-address-ed", Country.Aruba, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.AMinus);
        public static readonly Dataset AwAddressEh = new Dataset("aw-address-eh", Country.Aruba, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.AMinus);
        public static readonly Dataset AtAddressEh = new Dataset("at-address-eh", Country.Austria, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset AtAddressEd = new Dataset("at-address-ed", Country.Austria, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset AzAddressEd = new Dataset("az-address-ed", Country.Azerbaijan, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.APlus);
        public static readonly Dataset AzAddressEh = new Dataset("az-address-eh", Country.Azerbaijan, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset BsAddressEd = new Dataset("bs-address-ed", Country.Bahamas, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.AMinus, Accuracy.A);
        public static readonly Dataset BsAddressEh = new Dataset("bs-address-eh", Country.Bahamas, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.A);
        public static readonly Dataset BhAddressEd = new Dataset("bh-address-ed", Country.Bahrain, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.A);
        public static readonly Dataset BhAddressEh = new Dataset("bh-address-eh", Country.Bahrain, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.A);
        public static readonly Dataset BdAddressEd = new Dataset("bd-address-ed", Country.Bangladesh, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.AMinus);
        public static readonly Dataset BdAddressEh = new Dataset("bd-address-eh", Country.Bangladesh, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.AMinus);
        public static readonly Dataset BbAddressEd = new Dataset("bb-address-ed", Country.Barbados, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.AMinus);
        public static readonly Dataset BbAddressEh = new Dataset("bb-address-eh", Country.Barbados, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.AMinus);
        public static readonly Dataset ByAddressEd = new Dataset("by-address-ed", Country.Belarus, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset ByAddressEh = new Dataset("by-address-eh", Country.Belarus, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset BeAddress = new Dataset("be-address", Country.Belgium, new List<SearchType> { SearchType.Singleline, SearchType.Typedown }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset BeAddressEd = new Dataset("be-address-ed", Country.Belgium, new List<SearchType> { SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset BeAddressEh = new Dataset("be-address-eh", Country.Belgium, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset BzAddressEd = new Dataset("bz-address-ed", Country.Belize, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.AMinus);
        public static readonly Dataset BzAddressEh = new Dataset("bz-address-eh", Country.Belize, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.AMinus);
        public static readonly Dataset BjAddressEd = new Dataset("bj-address-ed", Country.Benin, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset BjAddressEh = new Dataset("bj-address-eh", Country.Benin, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset BmAddressEd = new Dataset("bm-address-ed", Country.Bermuda, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset BmAddressEh = new Dataset("bm-address-eh", Country.Bermuda, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset BtAddressEd = new Dataset("bt-address-ed", Country.Bhutan, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset BtAddressEh = new Dataset("bt-address-eh", Country.Bhutan, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset BoAddressEd = new Dataset("bo-address-ed", Country.Bolivia, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.BMinus);
        public static readonly Dataset BoAddressEh = new Dataset("bo-address-eh", Country.Bolivia, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.BMinus);
        public static readonly Dataset BqAddressEd = new Dataset("bq-address-ed", Country.BonaireSintEustatiusAndSaba, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset BqAddressEh = new Dataset("bq-address-eh", Country.BonaireSintEustatiusAndSaba, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset BaAddressEd = new Dataset("ba-address-ed", Country.BosniaAndHerzegovina, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.APlus);
        public static readonly Dataset BaAddressEh = new Dataset("ba-address-eh", Country.BosniaAndHerzegovina, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset BwAddressEd = new Dataset("bw-address-ed", Country.Botswana, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.A);
        public static readonly Dataset BwAddressEh = new Dataset("bw-address-eh", Country.Botswana, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.A);
        public static readonly Dataset BrAddressEd = new Dataset("br-address-ed", Country.Brazil, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset BrAddressEh = new Dataset("br-address-eh", Country.Brazil, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset IoAddressEd = new Dataset("io-address-ed", Country.BritishIndianOceanTerritory, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.B);
        public static readonly Dataset BnAddressEd = new Dataset("bn-address-ed", Country.BruneiDarussalam, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.AMinus, Accuracy.A);
        public static readonly Dataset BnAddressEh = new Dataset("bn-address-eh", Country.BruneiDarussalam, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.A);
        public static readonly Dataset BgAddressEd = new Dataset("bg-address-ed", Country.Bulgaria, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset BgAddressEh = new Dataset("bg-address-eh", Country.Bulgaria, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset BfAddressEd = new Dataset("bf-address-ed", Country.BurkinaFaso, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset BfAddressEh = new Dataset("bf-address-eh", Country.BurkinaFaso, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset BiAddressEh = new Dataset("bi-address-eh", Country.Burundi, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.AMinus);
        public static readonly Dataset KhAddressEd = new Dataset("kh-address-ed", Country.Cambodia, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.AMinus);
        public static readonly Dataset KhAddressEh = new Dataset("kh-address-eh", Country.Cambodia, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.AMinus);
        public static readonly Dataset CmAddressEd = new Dataset("cm-address-ed", Country.Cameroon, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.AMinus);
        public static readonly Dataset CmAddressEh = new Dataset("cm-address-eh", Country.Cameroon, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.AMinus);
        public static readonly Dataset CvAddressEd = new Dataset("cv-address-ed", Country.CapeVerde, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.AMinus);
        public static readonly Dataset CvAddressEh = new Dataset("cv-address-eh", Country.CapeVerde, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.AMinus);
        public static readonly Dataset KyAddressEd = new Dataset("ky-address-ed", Country.CaymanIslands, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.AMinus);
        public static readonly Dataset KyAddressEh = new Dataset("ky-address-eh", Country.CaymanIslands, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.AMinus);
        public static readonly Dataset CfAddressEd = new Dataset("cf-address-ed", Country.CentralAfricanRepublic, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset CfAddressEh = new Dataset("cf-address-eh", Country.CentralAfricanRepublic, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset TdAddressEd = new Dataset("td-address-ed", Country.Chad, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset TdAddressEh = new Dataset("td-address-eh", Country.Chad, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset ClAddressEd = new Dataset("cl-address-ed", Country.Chile, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset ClAddressEh = new Dataset("cl-address-eh", Country.Chile, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset CnAddressEd = new Dataset("cn-address-ed", Country.China, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset CnAddressEh = new Dataset("cn-address-eh", Country.China, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset CxAddressEd = new Dataset("cx-address-ed", Country.ChristmasIsland, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset CxAddressEh = new Dataset("cx-address-eh", Country.ChristmasIsland, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset CcAddressEd = new Dataset("cc-address-ed", Country.CocosIsland, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset CcAddressEh = new Dataset("cc-address-eh", Country.CocosIsland, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset CoAddressEd = new Dataset("co-address-ed", Country.Colombia, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset CoAddressEh = new Dataset("co-address-eh", Country.Colombia, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset KmAddressEd = new Dataset("km-address-ed", Country.Comoros, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset KmAddressEh = new Dataset("km-address-eh", Country.Comoros, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset CgAddressEd = new Dataset("cg-address-ed", Country.Congo, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.AMinus);
        public static readonly Dataset CgAddressEh = new Dataset("cg-address-eh", Country.Congo, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.AMinus);
        public static readonly Dataset CdAddressEd = new Dataset("cd-address-ed", Country.CongoDemocraticRepublic, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset CdAddressEh = new Dataset("cd-address-eh", Country.CongoDemocraticRepublic, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset CkAddressEd = new Dataset("ck-address-ed", Country.CookIslands, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset CkAddressEh = new Dataset("ck-address-eh", Country.CookIslands, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset CrAddressEd = new Dataset("cr-address-ed", Country.CostaRica, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset CrAddressEh = new Dataset("cr-address-eh", Country.CostaRica, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset HrAddressEd = new Dataset("hr-address-ed", Country.Croatia, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset HrAddressEh = new Dataset("hr-address-eh", Country.Croatia, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset CwAddressEd = new Dataset("cw-address-ed", Country.Curacao, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.AMinus);
        public static readonly Dataset CwAddressEh = new Dataset("cw-address-eh", Country.Curacao, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.AMinus);
        public static readonly Dataset CyAddressEd = new Dataset("cy-address-ed", Country.Cyprus, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset CyAddressEh = new Dataset("cy-address-eh", Country.Cyprus, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset CzAddressEd = new Dataset("cz-address-ed", Country.CzechRepublic, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset CzAddressEh = new Dataset("cz-address-eh", Country.CzechRepublic, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset DkAddressEd = new Dataset("dk-address-ed", Country.Denmark, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset DkAddressEh = new Dataset("dk-address-eh", Country.Denmark, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset DjAddressEd = new Dataset("dj-address-ed", Country.Djibouti, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset DjAddressEh = new Dataset("dj-address-eh", Country.Djibouti, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset DmAddressEd = new Dataset("dm-address-ed", Country.Dominica, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset DmAddressEh = new Dataset("dm-address-eh", Country.Dominica, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset DoAddressEd = new Dataset("do-address-ed", Country.DominicanRepublic, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset DoAddressEh = new Dataset("do-address-eh", Country.DominicanRepublic, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset EcAddressEd = new Dataset("ec-address-ed", Country.Ecuador, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset EcAddressEh = new Dataset("ec-address-eh", Country.Ecuador, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset EgAddressEd = new Dataset("eg-address-ed", Country.Egypt, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset EgAddressEh = new Dataset("eg-address-eh", Country.Egypt, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset SvAddressEd = new Dataset("sv-address-ed", Country.ElSalvador, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset SvAddressEh = new Dataset("sv-address-eh", Country.ElSalvador, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset GqAddressEd = new Dataset("gq-address-ed", Country.EquatorialGuinea, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset GqAddressEh = new Dataset("gq-address-eh", Country.EquatorialGuinea, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset ErAddressEd = new Dataset("er-address-ed", Country.Eritrea, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset ErAddressEh = new Dataset("er-address-eh", Country.Eritrea, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset EeAddressEd = new Dataset("ee-address-ed", Country.Estonia, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset EeAddressEh = new Dataset("ee-address-eh", Country.Estonia, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset EtAddressEd = new Dataset("et-address-ed", Country.Ethiopia, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset EtAddressEh = new Dataset("et-address-eh", Country.Ethiopia, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset FkAddressEd = new Dataset("fk-address-ed", Country.FalklandIslands, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset FkAddressEh = new Dataset("fk-address-eh", Country.FalklandIslands, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset FoAddressEd = new Dataset("fo-address-ed", Country.FaroeIslands, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset FoAddressEh = new Dataset("fo-address-eh", Country.FaroeIslands, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset FjAddressEd = new Dataset("fj-address-ed", Country.Fiji, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset FjAddressEh = new Dataset("fj-address-eh", Country.Fiji, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset FiAddressEd = new Dataset("fi-address-ed", Country.Finland, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset FiAddressEh = new Dataset("fi-address-eh", Country.Finland, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset FrAddressEd = new Dataset("fr-address-ed", Country.France, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset FrAddressEh = new Dataset("fr-address-eh", Country.France, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset GfAddressEd = new Dataset("gf-address-ed", Country.FrenchGuiana, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset GfAddressEh = new Dataset("gf-address-eh", Country.FrenchGuiana, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset PfAddressEd = new Dataset("pf-address-ed", Country.FrenchPolynesia, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset PfAddressEh = new Dataset("pf-address-eh", Country.FrenchPolynesia, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset GaAddressEd = new Dataset("ga-address-ed", Country.Gabon, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset GaAddressEh = new Dataset("ga-address-eh", Country.Gabon, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset GmAddressEd = new Dataset("gm-address-ed", Country.Gambia, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset GmAddressEh = new Dataset("gm-address-eh", Country.Gambia, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset GeAddressEd = new Dataset("ge-address-ed", Country.Georgia, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset GeAddressEh = new Dataset("ge-address-eh", Country.Georgia, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset DeAddress = new Dataset("de-address", Country.Germany, new List<SearchType> { SearchType.Singleline, SearchType.Typedown, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset DeAddressEd = new Dataset("de-address-ed", Country.Germany, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset DeAddressEh = new Dataset("de-address-eh", Country.Germany, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset GhAddressEd = new Dataset("gh-address-ed", Country.Ghana, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset GhAddressEh = new Dataset("gh-address-eh", Country.Ghana, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset GiAddressEd = new Dataset("gi-address-ed", Country.Gibraltar, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset GiAddressEh = new Dataset("gi-address-eh", Country.Gibraltar, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset GrAddressEd = new Dataset("gr-address-ed", Country.Greece, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset GrAddressEh = new Dataset("gr-address-eh", Country.Greece, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset GlAddressEd = new Dataset("gl-address-ed", Country.Greenland, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset GlAddressEh = new Dataset("gl-address-eh", Country.Greenland, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset GdAddressEd = new Dataset("gd-address-ed", Country.Grenada, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset GdAddressEh = new Dataset("gd-address-eh", Country.Grenada, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset GpAddressEd = new Dataset("gp-address-ed", Country.Guadeloupe, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset GpAddressEh = new Dataset("gp-address-eh", Country.Guadeloupe, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset GuAddressEd = new Dataset("gu-address-ed", Country.Guam, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset GuAddressEh = new Dataset("gu-address-eh", Country.Guam, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset GtAddressEd = new Dataset("gt-address-ed", Country.Guatemala, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset GtAddressEh = new Dataset("gt-address-eh", Country.Guatemala, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset GnAddressEd = new Dataset("gn-address-ed", Country.Guinea, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset GnAddressEh = new Dataset("gn-address-eh", Country.Guinea, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset GyAddressEd = new Dataset("gy-address-ed", Country.Guyana, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset GyAddressEh = new Dataset("gy-address-eh", Country.Guyana, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset HtAddressEd = new Dataset("ht-address-ed", Country.Haiti, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset HtAddressEh = new Dataset("ht-address-eh", Country.Haiti, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset HnAddressEd = new Dataset("hn-address-ed", Country.Honduras, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset HnAddressEh = new Dataset("hn-address-eh", Country.Honduras, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset HkAddressEd = new Dataset("hk-address-ed", Country.HongKong, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset HkAddressEh = new Dataset("hk-address-eh", Country.HongKong, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset HuAddressEd = new Dataset("hu-address-ed", Country.Hungary, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset HuAddressEh = new Dataset("hu-address-eh", Country.Hungary, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset IsAddressEd = new Dataset("is-address-ed", Country.Iceland, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset IsAddressEh = new Dataset("is-address-eh", Country.Iceland, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset InAddressEd = new Dataset("in-address-ed", Country.India, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset InAddressEh = new Dataset("in-address-eh", Country.India, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset IdAddressEd = new Dataset("id-address-ed", Country.Indonesia, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset IdAddressEh = new Dataset("id-address-eh", Country.Indonesia, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset IrAddressEd = new Dataset("ir-address-ed", Country.Iran, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset IrAddressEh = new Dataset("ir-address-eh", Country.Iran, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset IqAddressEd = new Dataset("iq-address-ed", Country.Iraq, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset IqAddressEh = new Dataset("iq-address-eh", Country.Iraq, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset IlAddressEd = new Dataset("il-address-ed", Country.Israel, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset IlAddressEh = new Dataset("il-address-eh", Country.Israel, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset ItAddressEd = new Dataset("it-address-ed", Country.Italy, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset ItAddressEh = new Dataset("it-address-eh", Country.Italy, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset JmAddressEd = new Dataset("jm-address-ed", Country.Jamaica, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset JmAddressEh = new Dataset("jm-address-eh", Country.Jamaica, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset JpAddressEd = new Dataset("jp-address-ed", Country.Japan, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset JpAddressEh = new Dataset("jp-address-eh", Country.Japan, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset JoAddressEd = new Dataset("jo-address-ed", Country.Jordan, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset JoAddressEh = new Dataset("jo-address-eh", Country.Jordan, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset KzAddressEd = new Dataset("kz-address-ed", Country.Kazakhstan, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset KzAddressEh = new Dataset("kz-address-eh", Country.Kazakhstan, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset KeAddressEd = new Dataset("ke-address-ed", Country.Kenya, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset KeAddressEh = new Dataset("ke-address-eh", Country.Kenya, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset KiAddressEd = new Dataset("ki-address-ed", Country.Kiribati, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset KiAddressEh = new Dataset("ki-address-eh", Country.Kiribati, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset KpAddressEd = new Dataset("kp-address-ed", Country.KoreaDemocraticPeoplesRepublic, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset KpAddressEh = new Dataset("kp-address-eh", Country.KoreaDemocraticPeoplesRepublic, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset KrAddressEd = new Dataset("kr-address-ed", Country.KoreaRepublic, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset KrAddressEh = new Dataset("kr-address-eh", Country.KoreaRepublic, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset XkAddressEd = new Dataset("xk-address-ed", Country.Kosovo, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset XkAddressEh = new Dataset("xk-address-eh", Country.Kosovo, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset KwAddressEd = new Dataset("kw-address-ed", Country.Kuwait, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset KwAddressEh = new Dataset("kw-address-eh", Country.Kuwait, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset KgAddressEd = new Dataset("kg-address-ed", Country.Kyrgyzstan, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.AMinus);
        public static readonly Dataset KgAddressEh = new Dataset("kg-address-eh", Country.Kyrgyzstan, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.AMinus);
        public static readonly Dataset LaAddressEd = new Dataset("la-address-ed", Country.Laos, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.AMinus);
        public static readonly Dataset LaAddressEh = new Dataset("la-address-eh", Country.Laos, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.AMinus);
        public static readonly Dataset LvAddressEd = new Dataset("lv-address-ed", Country.Latvia, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset LvAddressEh = new Dataset("lv-address-eh", Country.Latvia, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset LbAddressEd = new Dataset("lb-address-ed", Country.Lebanon, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset LbAddressEh = new Dataset("lb-address-eh", Country.Lebanon, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset LsAddressEd = new Dataset("ls-address-ed", Country.Lesotho, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset LsAddressEh = new Dataset("ls-address-eh", Country.Lesotho, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset LrAddressEd = new Dataset("lr-address-ed", Country.Liberia, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset LrAddressEh = new Dataset("lr-address-eh", Country.Liberia, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset LyAddressEd = new Dataset("ly-address-ed", Country.Libya, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset LyAddressEh = new Dataset("ly-address-eh", Country.Libya, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset LiAddressEd = new Dataset("li-address-ed", Country.Liechtenstein, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset LiAddressEh = new Dataset("li-address-eh", Country.Liechtenstein, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset LtAddressEd = new Dataset("lt-address-ed", Country.Lithuania, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset LtAddressEh = new Dataset("lt-address-eh", Country.Lithuania, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset LuAddressEd = new Dataset("lu-address-ed", Country.Luxembourg, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset LuAddressEh = new Dataset("lu-address-eh", Country.Luxembourg, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset MoAddressEd = new Dataset("mo-address-ed", Country.Macau, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset MoAddressEh = new Dataset("mo-address-eh", Country.Macau, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset MgAddressEd = new Dataset("mg-address-ed", Country.Madagascar, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset MgAddressEh = new Dataset("mg-address-eh", Country.Madagascar, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset MwAddressEd = new Dataset("mw-address-ed", Country.Malawi, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset MwAddressEh = new Dataset("mw-address-eh", Country.Malawi, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset MyAddressEd = new Dataset("my-address-ed", Country.Malaysia, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset MyAddressEh = new Dataset("my-address-eh", Country.Malaysia, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset MvAddressEd = new Dataset("mv-address-ed", Country.Maldives, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset MvAddressEh = new Dataset("mv-address-eh", Country.Maldives, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset MlAddressEd = new Dataset("ml-address-ed", Country.Mali, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset MlAddressEh = new Dataset("ml-address-eh", Country.Mali, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset MtAddressEd = new Dataset("mt-address-ed", Country.Malta, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset MtAddressEh = new Dataset("mt-address-eh", Country.Malta, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset MhAddressEd = new Dataset("mh-address-ed", Country.MarshallIslands, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset MhAddressEh = new Dataset("mh-address-eh", Country.MarshallIslands, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset MqAddressEd = new Dataset("mq-address-ed", Country.Martinique, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset MqAddressEh = new Dataset("mq-address-eh", Country.Martinique, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset MrAddressEd = new Dataset("mr-address-ed", Country.Mauritania, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset MrAddressEh = new Dataset("mr-address-eh", Country.Mauritania, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset MuAddressEd = new Dataset("mu-address-ed", Country.Mauritius, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset MuAddressEh = new Dataset("mu-address-eh", Country.Mauritius, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset YtAddressEd = new Dataset("yt-address-ed", Country.Mayotte, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset YtAddressEh = new Dataset("yt-address-eh", Country.Mayotte, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset MxAddressEd = new Dataset("mx-address-ed", Country.Mexico, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset MxAddressEh = new Dataset("mx-address-eh", Country.Mexico, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset FmAddressEd = new Dataset("fm-address-ed", Country.Micronesia, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset FmAddressEh = new Dataset("fm-address-eh", Country.Micronesia, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset MdAddressEd = new Dataset("md-address-ed", Country.Moldova, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset MdAddressEh = new Dataset("md-address-eh", Country.Moldova, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset McAddressEd = new Dataset("mc-address-ed", Country.Monaco, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset McAddressEh = new Dataset("mc-address-eh", Country.Monaco, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset MnAddressEd = new Dataset("mn-address-ed", Country.Mongolia, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset MnAddressEh = new Dataset("mn-address-eh", Country.Mongolia, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset MeAddressEd = new Dataset("me-address-ed", Country.Montenegro, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.AMinus);
        public static readonly Dataset MeAddressEh = new Dataset("me-address-eh", Country.Montenegro, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.AMinus);
        public static readonly Dataset MsAddressEd = new Dataset("ms-address-ed", Country.Montserrat, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset MsAddressEh = new Dataset("ms-address-eh", Country.Montserrat, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset MaAddressEd = new Dataset("ma-address-ed", Country.Morocco, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.AMinus);
        public static readonly Dataset MaAddressEh = new Dataset("ma-address-eh", Country.Morocco, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.AMinus);
        public static readonly Dataset MzAddressEd = new Dataset("mz-address-ed", Country.Mozambique, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset MzAddressEh = new Dataset("mz-address-eh", Country.Mozambique, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset MmAddressEd = new Dataset("mm-address-ed", Country.Myanmar, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset MmAddressEh = new Dataset("mm-address-eh", Country.Myanmar, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset NaAddressEd = new Dataset("na-address-ed", Country.Namibia, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset NaAddressEh = new Dataset("na-address-eh", Country.Namibia, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset NrAddressEd = new Dataset("nr-address-ed", Country.Nauru, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset NrAddressEh = new Dataset("nr-address-eh", Country.Nauru, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset NpAddressEd = new Dataset("np-address-ed", Country.Nepal, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset NpAddressEh = new Dataset("np-address-eh", Country.Nepal, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset NlAddressEd = new Dataset("nl-address-ed", Country.Netherlands, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset NlAddressEh = new Dataset("nl-address-eh", Country.Netherlands, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset NcAddressEd = new Dataset("nc-address-ed", Country.NewCaledonia, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset NcAddressEh = new Dataset("nc-address-eh", Country.NewCaledonia, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset NiAddressEd = new Dataset("ni-address-ed", Country.Nicaragua, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset NiAddressEh = new Dataset("ni-address-eh", Country.Nicaragua, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset NeAddressEd = new Dataset("ne-address-ed", Country.Niger, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset NeAddressEh = new Dataset("ne-address-eh", Country.Niger, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset NgAddressEd = new Dataset("ng-address-ed", Country.Nigeria, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset NgAddressEh = new Dataset("ng-address-eh", Country.Nigeria, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset NuAddressEd = new Dataset("nu-address-ed", Country.Niue, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset NuAddressEh = new Dataset("nu-address-eh", Country.Niue, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset NfAddressEd = new Dataset("nf-address-ed", Country.NorfolkIsland, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset NfAddressEh = new Dataset("nf-address-eh", Country.NorfolkIsland, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset MkAddressEd = new Dataset("mk-address-ed", Country.NorthMacedonia, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.AMinus);
        public static readonly Dataset MkAddressEh = new Dataset("mk-address-eh", Country.NorthMacedonia, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.AMinus);
        public static readonly Dataset MpAddressEd = new Dataset("mp-address-ed", Country.NorthernMarianaIslands, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset MpAddressEh = new Dataset("mp-address-eh", Country.NorthernMarianaIslands, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset NoAddressEd = new Dataset("no-address-ed", Country.Norway, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset NoAddressEh = new Dataset("no-address-eh", Country.Norway, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset OmAddressEd = new Dataset("om-address-ed", Country.Oman, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset OmAddressEh = new Dataset("om-address-eh", Country.Oman, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset PkAddressEd = new Dataset("pk-address-ed", Country.Pakistan, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.AMinus);
        public static readonly Dataset PkAddressEh = new Dataset("pk-address-eh", Country.Pakistan, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.AMinus);
        public static readonly Dataset PwAddressEd = new Dataset("pw-address-ed", Country.Palau, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset PwAddressEh = new Dataset("pw-address-eh", Country.Palau, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset PsAddressEd = new Dataset("ps-address-ed", Country.Palestine, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset PsAddressEh = new Dataset("ps-address-eh", Country.Palestine, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset PaAddressEd = new Dataset("pa-address-ed", Country.Panama, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset PaAddressEh = new Dataset("pa-address-eh", Country.Panama, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset PgAddressEd = new Dataset("pg-address-ed", Country.PapuaNewGuinea, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset PgAddressEh = new Dataset("pg-address-eh", Country.PapuaNewGuinea, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset PyAddressEd = new Dataset("py-address-ed", Country.Paraguay, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset PyAddressEh = new Dataset("py-address-eh", Country.Paraguay, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset PeAddressEd = new Dataset("pe-address-ed", Country.Peru, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset PeAddressEh = new Dataset("pe-address-eh", Country.Peru, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset PhAddressEd = new Dataset("ph-address-ed", Country.Philippines, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset PhAddressEh = new Dataset("ph-address-eh", Country.Philippines, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset PnAddressEd = new Dataset("pn-address-ed", Country.PitcairnIslands, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset PnAddressEh = new Dataset("pn-address-eh", Country.PitcairnIslands, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset PlAddressEd = new Dataset("pl-address-ed", Country.Poland, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset PlAddressEh = new Dataset("pl-address-eh", Country.Poland, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset PtAddressEd = new Dataset("pt-address-ed", Country.Portugal, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset PtAddressEh = new Dataset("pt-address-eh", Country.Portugal, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset QaAddressEd = new Dataset("qa-address-ed", Country.Qatar, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset QaAddressEh = new Dataset("qa-address-eh", Country.Qatar, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset RoAddressEd = new Dataset("ro-address-ed", Country.Romania, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset RoAddressEh = new Dataset("ro-address-eh", Country.Romania, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset RuAddressEd = new Dataset("ru-address-ed", Country.RussianFederation, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset RuAddressEh = new Dataset("ru-address-eh", Country.RussianFederation, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset RwAddressEd = new Dataset("rw-address-ed", Country.Rwanda, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset RwAddressEh = new Dataset("rw-address-eh", Country.Rwanda, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset ReAddressEd = new Dataset("re-address-ed", Country.Reunion, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset ReAddressEh = new Dataset("re-address-eh", Country.Reunion, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset BlAddressEd = new Dataset("bl-address-ed", Country.SaintBarthelemy, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset BlAddressEh = new Dataset("bl-address-eh", Country.SaintBarthelemy, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset ShAddressEd = new Dataset("sh-address-ed", Country.SaintHelena, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset ShAddressEh = new Dataset("sh-address-eh", Country.SaintHelena, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset KnAddressEd = new Dataset("kn-address-ed", Country.SaintKittsAndNevis, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset KnAddressEh = new Dataset("kn-address-eh", Country.SaintKittsAndNevis, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset LcAddressEd = new Dataset("lc-address-ed", Country.SaintLucia, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset LcAddressEh = new Dataset("lc-address-eh", Country.SaintLucia, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset MfAddressEd = new Dataset("mf-address-ed", Country.SaintMartin, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset MfAddressEh = new Dataset("mf-address-eh", Country.SaintMartin, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset PmAddressEd = new Dataset("pm-address-ed", Country.SaintPierreAndMiquelon, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset PmAddressEh = new Dataset("pm-address-eh", Country.SaintPierreAndMiquelon, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset VcAddressEd = new Dataset("vc-address-ed", Country.SaintVincentAndTheGrenadines, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset VcAddressEh = new Dataset("vc-address-eh", Country.SaintVincentAndTheGrenadines, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset WsAddressEd = new Dataset("ws-address-ed", Country.Samoa, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset WsAddressEh = new Dataset("ws-address-eh", Country.Samoa, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset SmAddressEd = new Dataset("sm-address-ed", Country.SanMarino, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset SmAddressEh = new Dataset("sm-address-eh", Country.SanMarino, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset StAddressEd = new Dataset("st-address-ed", Country.SaoTomeAndPrincipe, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset StAddressEh = new Dataset("st-address-eh", Country.SaoTomeAndPrincipe, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset SaAddressEd = new Dataset("sa-address-ed", Country.SaudiArabia, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset SaAddressEh = new Dataset("sa-address-eh", Country.SaudiArabia, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset SnAddressEd = new Dataset("sn-address-ed", Country.Senegal, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset SnAddressEh = new Dataset("sn-address-eh", Country.Senegal, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset RsAddressEd = new Dataset("rs-address-ed", Country.Serbia, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset RsAddressEh = new Dataset("rs-address-eh", Country.Serbia, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset ScAddressEd = new Dataset("sc-address-ed", Country.Seychelles, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset ScAddressEh = new Dataset("sc-address-eh", Country.Seychelles, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset SlAddressEd = new Dataset("sl-address-ed", Country.SierraLeone, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset SlAddressEh = new Dataset("sl-address-eh", Country.SierraLeone, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset SgAddressEd = new Dataset("sg-address-ed", Country.Singapore, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset SgAddressEh = new Dataset("sg-address-eh", Country.Singapore, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset SkAddressEd = new Dataset("sk-address-ed", Country.Slovakia, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset SkAddressEh = new Dataset("sk-address-eh", Country.Slovakia, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset SiAddressEd = new Dataset("si-address-ed", Country.Slovenia, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset SiAddressEh = new Dataset("si-address-eh", Country.Slovenia, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset SbAddressEd = new Dataset("sb-address-ed", Country.SolomonIslands, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset SbAddressEh = new Dataset("sb-address-eh", Country.SolomonIslands, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset SoAddressEd = new Dataset("so-address-ed", Country.Somalia, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset SoAddressEh = new Dataset("so-address-eh", Country.Somalia, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset ZaAddressEd = new Dataset("za-address-ed", Country.SouthAfrica, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset ZaAddressEh = new Dataset("za-address-eh", Country.SouthAfrica, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset GsAddressEd = new Dataset("gs-address-ed", Country.SouthGeorgiaAndTheSouthSandwichIslands, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset GsAddressEh = new Dataset("gs-address-eh", Country.SouthGeorgiaAndTheSouthSandwichIslands, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset SsAddressEd = new Dataset("ss-address-ed", Country.SouthSudan, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset SsAddressEh = new Dataset("ss-address-eh", Country.SouthSudan, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset EsAddressEd = new Dataset("es-address-ed", Country.Spain, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset EsAddressEh = new Dataset("es-address-eh", Country.Spain, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset LkAddressEd = new Dataset("lk-address-ed", Country.SriLanka, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset LkAddressEh = new Dataset("lk-address-eh", Country.SriLanka, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset SdAddressEd = new Dataset("sd-address-ed", Country.Sudan, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset SdAddressEh = new Dataset("sd-address-eh", Country.Sudan, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset SrAddressEd = new Dataset("sr-address-ed", Country.Suriname, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset SrAddressEh = new Dataset("sr-address-eh", Country.Suriname, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset SjAddressEd = new Dataset("sj-address-ed", Country.SvalbardAndJanMayenIslands, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset SjAddressEh = new Dataset("sj-address-eh", Country.SvalbardAndJanMayenIslands, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset SzAddressEd = new Dataset("sz-address-ed", Country.Swaziland, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset SzAddressEh = new Dataset("sz-address-eh", Country.Swaziland, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset SeAddressEd = new Dataset("se-address-ed", Country.Sweden, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset SeAddressEh = new Dataset("se-address-eh", Country.Sweden, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset ChAddressEd = new Dataset("ch-address-ed", Country.Switzerland, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset ChAddressEh = new Dataset("ch-address-eh", Country.Switzerland, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset SyAddressEd = new Dataset("sy-address-ed", Country.Syria, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset SyAddressEh = new Dataset("sy-address-eh", Country.Syria, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset TwAddressEd = new Dataset("tw-address-ed", Country.Taiwan, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset TwAddressEh = new Dataset("tw-address-eh", Country.Taiwan, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset TjAddressEd = new Dataset("tj-address-ed", Country.Tajikistan, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset TjAddressEh = new Dataset("tj-address-eh", Country.Tajikistan, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset TzAddressEd = new Dataset("tz-address-ed", Country.Tanzania, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset TzAddressEh = new Dataset("tz-address-eh", Country.Tanzania, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset ThAddressEd = new Dataset("th-address-ed", Country.Thailand, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset ThAddressEh = new Dataset("th-address-eh", Country.Thailand, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset TlAddressEd = new Dataset("tl-address-ed", Country.TimorLeste, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset TlAddressEh = new Dataset("tl-address-eh", Country.TimorLeste, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset TgAddressEd = new Dataset("tg-address-ed", Country.Togo, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset TgAddressEh = new Dataset("tg-address-eh", Country.Togo, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset TkAddressEd = new Dataset("tk-address-ed", Country.Tokelau, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset TkAddressEh = new Dataset("tk-address-eh", Country.Tokelau, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset ToAddressEd = new Dataset("to-address-ed", Country.Tonga, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset ToAddressEh = new Dataset("to-address-eh", Country.Tonga, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset TtAddressEd = new Dataset("tt-address-ed", Country.TrinidadAndTobago, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset TtAddressEh = new Dataset("tt-address-eh", Country.TrinidadAndTobago, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset TnAddressEd = new Dataset("tn-address-ed", Country.Tunisia, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset TnAddressEh = new Dataset("tn-address-eh", Country.Tunisia, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset TrAddressEd = new Dataset("tr-address-ed", Country.Turkey, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset TrAddressEh = new Dataset("tr-address-eh", Country.Turkey, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset TmAddressEd = new Dataset("tm-address-ed", Country.Turkmenistan, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset TmAddressEh = new Dataset("tm-address-eh", Country.Turkmenistan, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset TcAddressEd = new Dataset("tc-address-ed", Country.TurksAndCaicosIslands, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset TcAddressEh = new Dataset("tc-address-eh", Country.TurksAndCaicosIslands, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset TvAddressEd = new Dataset("tv-address-ed", Country.Tuvalu, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset TvAddressEh = new Dataset("tv-address-eh", Country.Tuvalu, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset UgAddressEd = new Dataset("ug-address-ed", Country.Uganda, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset UgAddressEh = new Dataset("ug-address-eh", Country.Uganda, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset UaAddressEd = new Dataset("ua-address-ed", Country.Ukraine, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset UaAddressEh = new Dataset("ua-address-eh", Country.Ukraine, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset AeAddressEd = new Dataset("ae-address-ed", Country.UnitedArabEmirates, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset AeAddressEh = new Dataset("ae-address-eh", Country.UnitedArabEmirates, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset UyAddressEd = new Dataset("uy-address-ed", Country.Uruguay, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset UyAddressEh = new Dataset("uy-address-eh", Country.Uruguay, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset UzAddressEd = new Dataset("uz-address-ed", Country.Uzbekistan, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.AMinus);
        public static readonly Dataset UzAddressEh = new Dataset("uz-address-eh", Country.Uzbekistan, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.AMinus);
        public static readonly Dataset VuAddressEd = new Dataset("vu-address-ed", Country.Vanuatu, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset VuAddressEh = new Dataset("vu-address-eh", Country.Vanuatu, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset VaAddressEd = new Dataset("va-address-ed", Country.VaticanCity, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset VaAddressEh = new Dataset("va-address-eh", Country.VaticanCity, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset VnAddressEd = new Dataset("vn-address-ed", Country.Vietnam, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset VnAddressEh = new Dataset("vn-address-eh", Country.Vietnam, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.A, Accuracy.APlus);
        public static readonly Dataset VgAddressEd = new Dataset("vg-address-ed", Country.VirginIslandsBritish, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset VgAddressEh = new Dataset("vg-address-eh", Country.VirginIslandsBritish, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset ViAddressEd = new Dataset("vi-address-ed", Country.VirginIslandsUS, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset ViAddressEh = new Dataset("vi-address-eh", Country.VirginIslandsUS, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset WfAddressEd = new Dataset("wf-address-ed", Country.WallisAndFutunaIslands, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset WfAddressEh = new Dataset("wf-address-eh", Country.WallisAndFutunaIslands, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset EhAddressEd = new Dataset("eh-address-ed", Country.WesternSahara, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset EhAddressEh = new Dataset("eh-address-eh", Country.WesternSahara, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset YeAddressEd = new Dataset("ye-address-ed", Country.Yemen, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset YeAddressEh = new Dataset("ye-address-eh", Country.Yemen, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset ZmAddressEd = new Dataset("zm-address-ed", Country.Zambia, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset ZmAddressEh = new Dataset("zm-address-eh", Country.Zambia, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);
        public static readonly Dataset ZwAddressEd = new Dataset("zw-address-ed", Country.Zimbabwe, new List<SearchType> { SearchType.Singleline, SearchType.Validate }, Accuracy.B, Accuracy.BMinus);
        public static readonly Dataset ZwAddressEh = new Dataset("zw-address-eh", Country.Zimbabwe, new List<SearchType> { SearchType.Autocomplete, SearchType.LookupV2 }, Accuracy.AMinus, Accuracy.BMinus);


        public string DatasetCode { get; }
        public Country Country { get; }
        public IEnumerable<SearchType> SearchTypes { get; }
        public Accuracy AddressAccuracy { get; }
        public Accuracy GeocodeAccuracy { get; }

        private static readonly Dictionary<string, Dataset> datasetMap;

        static Dataset()
        {
            datasetMap = new Dictionary<string, Dataset>
            {
                { AuAddress.DatasetCode, AuAddress },
                { AuAddressGnaf.DatasetCode, AuAddressGnaf },
                { AuAddressDatafusion.DatasetCode, AuAddressDatafusion },
                { CaAddress.DatasetCode, CaAddress },
                { IeAddress.DatasetCode, IeAddress },
                { IeAddressEh.DatasetCode, IeAddressEh },
                { IeAdditionalEircode.DatasetCode, IeAdditionalEircode },
                { IeAddressEcad.DatasetCode, IeAddressEcad },
                { NzAddress.DatasetCode, NzAddress },
                { NzAdditionalDatafusion.DatasetCode, NzAdditionalDatafusion },
                { GbAddress.DatasetCode, GbAddress },
                { GbAddressAddressbase.DatasetCode, GbAddressAddressbase },
                { GbAdditionalAddressbaseislands.DatasetCode, GbAdditionalAddressbaseislands },
                { GbAdditionalBusiness.DatasetCode, GbAdditionalBusiness },
                { GbAdditionalElectricity.DatasetCode, GbAdditionalElectricity },
                { GbAdditionalGas.DatasetCode, GbAdditionalGas },
                { GbAdditionalNames.DatasetCode, GbAdditionalNames },
                { GbAddressStreetlevel.DatasetCode, GbAddressStreetlevel },
                { GbAdditionalBusinessextended.DatasetCode, GbAdditionalBusinessextended },
                { GbAdditionalNotyetbuilt.DatasetCode, GbAdditionalNotyetbuilt },
                { GbAdditionalMultipleresidence.DatasetCode, GbAdditionalMultipleresidence },
                { GbAddressWales.DatasetCode, GbAddressWales },
                { UsAddress.DatasetCode, UsAddress },
                { VeAddressEd.DatasetCode, VeAddressEd },
                { VeAddressEh.DatasetCode, VeAddressEh },
                { CuAddressEd.DatasetCode, CuAddressEd },
                { CuAddressEh.DatasetCode, CuAddressEh },
                { AfAddressEd.DatasetCode, AfAddressEd },
                { AfAddressEh.DatasetCode, AfAddressEh },
                { AlAddressEd.DatasetCode, AlAddressEd },
                { AlAddressEh.DatasetCode, AlAddressEh },
                { DzAddressEd.DatasetCode, DzAddressEd },
                { DzAddressEh.DatasetCode, DzAddressEh },
                { AsAddressEh.DatasetCode, AsAddressEh },
                { AdAddressEd.DatasetCode, AdAddressEd },
                { AdAddressEh.DatasetCode, AdAddressEh },
                { AoAddressEd.DatasetCode, AoAddressEd },
                { AoAddressEh.DatasetCode, AoAddressEh },
                { AiAddressEd.DatasetCode, AiAddressEd },
                { AiAddressEh.DatasetCode, AiAddressEh },
                { BrAddressEd.DatasetCode, BrAddressEd },
                { BrAddressEh.DatasetCode, BrAddressEh },
                { IoAddressEd.DatasetCode, IoAddressEd },
                { BnAddressEd.DatasetCode, BnAddressEd },
                { BnAddressEh.DatasetCode, BnAddressEh },
                { BgAddressEd.DatasetCode, BgAddressEd },
                { BgAddressEh.DatasetCode, BgAddressEh },
                { BfAddressEd.DatasetCode, BfAddressEd },
                { BfAddressEh.DatasetCode, BfAddressEh },
                { BiAddressEh.DatasetCode, BiAddressEh },
                { KhAddressEd.DatasetCode, KhAddressEd },
                { KhAddressEh.DatasetCode, KhAddressEh },
                { CmAddressEd.DatasetCode, CmAddressEd },
                { CmAddressEh.DatasetCode, CmAddressEh },
                { CvAddressEd.DatasetCode, CvAddressEd },
                { CvAddressEh.DatasetCode, CvAddressEh },
                { KyAddressEd.DatasetCode, KyAddressEd },
                { KyAddressEh.DatasetCode, KyAddressEh },
                { CfAddressEd.DatasetCode, CfAddressEd },
                { CfAddressEh.DatasetCode, CfAddressEh },
                { TdAddressEd.DatasetCode, TdAddressEd },
                { TdAddressEh.DatasetCode, TdAddressEh },
                { ClAddressEd.DatasetCode, ClAddressEd },
                { ClAddressEh.DatasetCode, ClAddressEh },
                { CnAddressEd.DatasetCode, CnAddressEd },
                { CnAddressEh.DatasetCode, CnAddressEh },
                { CxAddressEd.DatasetCode, CxAddressEd },
                { CxAddressEh.DatasetCode, CxAddressEh },
                { CcAddressEd.DatasetCode, CcAddressEd },
                { CcAddressEh.DatasetCode, CcAddressEh },
                { CoAddressEd.DatasetCode, CoAddressEd },
                { CoAddressEh.DatasetCode, CoAddressEh },
                { KmAddressEd.DatasetCode, KmAddressEd },
                { KmAddressEh.DatasetCode, KmAddressEh },
                { CgAddressEd.DatasetCode, CgAddressEd },
                { CgAddressEh.DatasetCode, CgAddressEh },
                { CdAddressEd.DatasetCode, CdAddressEd },
                { CdAddressEh.DatasetCode, CdAddressEh },
                { CkAddressEd.DatasetCode, CkAddressEd },
                { CkAddressEh.DatasetCode, CkAddressEh },
                { CrAddressEd.DatasetCode, CrAddressEd },
                { CrAddressEh.DatasetCode, CrAddressEh },
                { HrAddressEd.DatasetCode, HrAddressEd },
                { HrAddressEh.DatasetCode, HrAddressEh },
                { CwAddressEd.DatasetCode, CwAddressEd },
                { CwAddressEh.DatasetCode, CwAddressEh },
                { CyAddressEd.DatasetCode, CyAddressEd },
                { CyAddressEh.DatasetCode, CyAddressEh },
                { CzAddressEd.DatasetCode, CzAddressEd },
                { CzAddressEh.DatasetCode, CzAddressEh },
                { DkAddressEd.DatasetCode, DkAddressEd },
                { DkAddressEh.DatasetCode, DkAddressEh },
                { DjAddressEd.DatasetCode, DjAddressEd },
                { DjAddressEh.DatasetCode, DjAddressEh },
                { DmAddressEd.DatasetCode, DmAddressEd },
                { DmAddressEh.DatasetCode, DmAddressEh },
                { DoAddressEd.DatasetCode, DoAddressEd },
                { DoAddressEh.DatasetCode, DoAddressEh },
                { EcAddressEd.DatasetCode, EcAddressEd },
                { EcAddressEh.DatasetCode, EcAddressEh },
                { EgAddressEd.DatasetCode, EgAddressEd },
                { EgAddressEh.DatasetCode, EgAddressEh },
                { SvAddressEd.DatasetCode, SvAddressEd },
                { SvAddressEh.DatasetCode, SvAddressEh },
                { GqAddressEd.DatasetCode, GqAddressEd },
                { GqAddressEh.DatasetCode, GqAddressEh },
                { ErAddressEd.DatasetCode, ErAddressEd },
                { ErAddressEh.DatasetCode, ErAddressEh },
                { EeAddressEd.DatasetCode, EeAddressEd },
                { EeAddressEh.DatasetCode, EeAddressEh },
                { EtAddressEd.DatasetCode, EtAddressEd },
                { EtAddressEh.DatasetCode, EtAddressEh },
                { FkAddressEd.DatasetCode, FkAddressEd },
                { FkAddressEh.DatasetCode, FkAddressEh },
                { FoAddressEd.DatasetCode, FoAddressEd },
                { FoAddressEh.DatasetCode, FoAddressEh },
                { FjAddressEd.DatasetCode, FjAddressEd },
                { FjAddressEh.DatasetCode, FjAddressEh },
                { FiAddressEd.DatasetCode, FiAddressEd },
                { FiAddressEh.DatasetCode, FiAddressEh },
                { FrAddressEd.DatasetCode, FrAddressEd },
                { FrAddressEh.DatasetCode, FrAddressEh },
                { GfAddressEd.DatasetCode, GfAddressEd },
                { GfAddressEh.DatasetCode, GfAddressEh },
                { PfAddressEd.DatasetCode, PfAddressEd },
                { PfAddressEh.DatasetCode, PfAddressEh },
                { GaAddressEd.DatasetCode, GaAddressEd },
                { GaAddressEh.DatasetCode, GaAddressEh },
                { GmAddressEd.DatasetCode, GmAddressEd },
                { GmAddressEh.DatasetCode, GmAddressEh },
                { GeAddressEd.DatasetCode, GeAddressEd },
                { GeAddressEh.DatasetCode, GeAddressEh },
                { DeAddressEd.DatasetCode, DeAddressEd },
                { DeAddressEh.DatasetCode, DeAddressEh },
                { GhAddressEd.DatasetCode, GhAddressEd },
                { GhAddressEh.DatasetCode, GhAddressEh },
                { GiAddressEd.DatasetCode, GiAddressEd },
                { GiAddressEh.DatasetCode, GiAddressEh },
                { GrAddressEd.DatasetCode, GrAddressEd },
                { GrAddressEh.DatasetCode, GrAddressEh },
                { GlAddressEd.DatasetCode, GlAddressEd },
                { GlAddressEh.DatasetCode, GlAddressEh },
                { GdAddressEd.DatasetCode, GdAddressEd },
                { GdAddressEh.DatasetCode, GdAddressEh },
                { GpAddressEd.DatasetCode, GpAddressEd },
                { GpAddressEh.DatasetCode, GpAddressEh },
                { GuAddressEd.DatasetCode, GuAddressEd },
                { GuAddressEh.DatasetCode, GuAddressEh },
                { GtAddressEd.DatasetCode, GtAddressEd },
                { GtAddressEh.DatasetCode, GtAddressEh },
                { GnAddressEd.DatasetCode, GnAddressEd },
                { GnAddressEh.DatasetCode, GnAddressEh },
                { GyAddressEd.DatasetCode, GyAddressEd },
                { GyAddressEh.DatasetCode, GyAddressEh },
                { HtAddressEd.DatasetCode, HtAddressEd },
                { HtAddressEh.DatasetCode, HtAddressEh },
                { HnAddressEd.DatasetCode, HnAddressEd },
                { HnAddressEh.DatasetCode, HnAddressEh },
                { HkAddressEd.DatasetCode, HkAddressEd },
                { HkAddressEh.DatasetCode, HkAddressEh },
                { HuAddressEd.DatasetCode, HuAddressEd },
                { HuAddressEh.DatasetCode, HuAddressEh },
                { IsAddressEd.DatasetCode, IsAddressEd },
                { IsAddressEh.DatasetCode, IsAddressEh },
                { InAddressEd.DatasetCode, InAddressEd },
                { InAddressEh.DatasetCode, InAddressEh },
                { IdAddressEd.DatasetCode, IdAddressEd },
                { IdAddressEh.DatasetCode, IdAddressEh },
                { IrAddressEd.DatasetCode, IrAddressEd },
                { IrAddressEh.DatasetCode, IrAddressEh },
                { IqAddressEd.DatasetCode, IqAddressEd },
                { IqAddressEh.DatasetCode, IqAddressEh },
                { IlAddressEd.DatasetCode, IlAddressEd },
                { IlAddressEh.DatasetCode, IlAddressEh },
                { ItAddressEd.DatasetCode, ItAddressEd },
                { ItAddressEh.DatasetCode, ItAddressEh },
                { JmAddressEd.DatasetCode, JmAddressEd },
                { JmAddressEh.DatasetCode, JmAddressEh },
                { JpAddressEd.DatasetCode, JpAddressEd },
                { JpAddressEh.DatasetCode, JpAddressEh },
                { JoAddressEd.DatasetCode, JoAddressEd },
                { JoAddressEh.DatasetCode, JoAddressEh },
                { KzAddressEd.DatasetCode, KzAddressEd },
                { KzAddressEh.DatasetCode, KzAddressEh },
                { KeAddressEd.DatasetCode, KeAddressEd },
                { KeAddressEh.DatasetCode, KeAddressEh },
                { KiAddressEd.DatasetCode, KiAddressEd },
                { KiAddressEh.DatasetCode, KiAddressEh },
                { KpAddressEd.DatasetCode, KpAddressEd },
                { KpAddressEh.DatasetCode, KpAddressEh },
                { KrAddressEd.DatasetCode, KrAddressEd },
                { KrAddressEh.DatasetCode, KrAddressEh },
                { XkAddressEd.DatasetCode, XkAddressEd },
                { XkAddressEh.DatasetCode, XkAddressEh },
                { KwAddressEd.DatasetCode, KwAddressEd },
                { KwAddressEh.DatasetCode, KwAddressEh },
                { KgAddressEd.DatasetCode, KgAddressEd },
                { KgAddressEh.DatasetCode, KgAddressEh },
                { LaAddressEd.DatasetCode, LaAddressEd },
                { LaAddressEh.DatasetCode, LaAddressEh },
                { LvAddressEd.DatasetCode, LvAddressEd },
                { LvAddressEh.DatasetCode, LvAddressEh },
                { LbAddressEd.DatasetCode, LbAddressEd },
                { LbAddressEh.DatasetCode, LbAddressEh },
                { LsAddressEd.DatasetCode, LsAddressEd },
                { LsAddressEh.DatasetCode, LsAddressEh },
                { LrAddressEd.DatasetCode, LrAddressEd },
                { LrAddressEh.DatasetCode, LrAddressEh },
                { LyAddressEd.DatasetCode, LyAddressEd },
                { LyAddressEh.DatasetCode, LyAddressEh },
                { LiAddressEd.DatasetCode, LiAddressEd },
                { LiAddressEh.DatasetCode, LiAddressEh },
                { LtAddressEd.DatasetCode, LtAddressEd },
                { LtAddressEh.DatasetCode, LtAddressEh },
                { LuAddressEd.DatasetCode, LuAddressEd },
                { LuAddressEh.DatasetCode, LuAddressEh },
                { MoAddressEd.DatasetCode, MoAddressEd },
                { MoAddressEh.DatasetCode, MoAddressEh },
                { MgAddressEd.DatasetCode, MgAddressEd },
                { MgAddressEh.DatasetCode, MgAddressEh },
                { MwAddressEd.DatasetCode, MwAddressEd },
                { MwAddressEh.DatasetCode, MwAddressEh },
                { MyAddressEd.DatasetCode, MyAddressEd },
                { MyAddressEh.DatasetCode, MyAddressEh },
                { MvAddressEd.DatasetCode, MvAddressEd },
                { MvAddressEh.DatasetCode, MvAddressEh },
                { MlAddressEd.DatasetCode, MlAddressEd },
                { MlAddressEh.DatasetCode, MlAddressEh },
                { MtAddressEd.DatasetCode, MtAddressEd },
                { MtAddressEh.DatasetCode, MtAddressEh },
                { MhAddressEd.DatasetCode, MhAddressEd },
                { MhAddressEh.DatasetCode, MhAddressEh },
                { MqAddressEd.DatasetCode, MqAddressEd },
                { MqAddressEh.DatasetCode, MqAddressEh },
                { MrAddressEd.DatasetCode, MrAddressEd },
                { MrAddressEh.DatasetCode, MrAddressEh },
                { MuAddressEd.DatasetCode, MuAddressEd },
                { MuAddressEh.DatasetCode, MuAddressEh },
                { YtAddressEd.DatasetCode, YtAddressEd },
                { YtAddressEh.DatasetCode, YtAddressEh },
                { MxAddressEd.DatasetCode, MxAddressEd },
                { MxAddressEh.DatasetCode, MxAddressEh },
                { FmAddressEd.DatasetCode, FmAddressEd },
                { FmAddressEh.DatasetCode, FmAddressEh },
                { MdAddressEd.DatasetCode, MdAddressEd },
                { MdAddressEh.DatasetCode, MdAddressEh },
                { McAddressEd.DatasetCode, McAddressEd },
                { McAddressEh.DatasetCode, McAddressEh },
                { MnAddressEd.DatasetCode, MnAddressEd },
                { MnAddressEh.DatasetCode, MnAddressEh },
                { MeAddressEd.DatasetCode, MeAddressEd },
                { MeAddressEh.DatasetCode, MeAddressEh },
                { MsAddressEd.DatasetCode, MsAddressEd },
                { MsAddressEh.DatasetCode, MsAddressEh },
                { MaAddressEd.DatasetCode, MaAddressEd },
                { MaAddressEh.DatasetCode, MaAddressEh },
                { MzAddressEd.DatasetCode, MzAddressEd },
                { MzAddressEh.DatasetCode, MzAddressEh },
                { MmAddressEd.DatasetCode, MmAddressEd },
                { MmAddressEh.DatasetCode, MmAddressEh },
                { NaAddressEd.DatasetCode, NaAddressEd },
                { NaAddressEh.DatasetCode, NaAddressEh },
                { NrAddressEd.DatasetCode, NrAddressEd },
                { NrAddressEh.DatasetCode, NrAddressEh },
                { NpAddressEd.DatasetCode, NpAddressEd },
                { NpAddressEh.DatasetCode, NpAddressEh },
                { NlAddressEd.DatasetCode, NlAddressEd },
                { NlAddressEh.DatasetCode, NlAddressEh },
                { NcAddressEd.DatasetCode, NcAddressEd },
                { NcAddressEh.DatasetCode, NcAddressEh },
                { NiAddressEd.DatasetCode, NiAddressEd },
                { NiAddressEh.DatasetCode, NiAddressEh },
                { NeAddressEd.DatasetCode, NeAddressEd },
                { NeAddressEh.DatasetCode, NeAddressEh },
                { NgAddressEd.DatasetCode, NgAddressEd },
                { NgAddressEh.DatasetCode, NgAddressEh },
                { NuAddressEd.DatasetCode, NuAddressEd },
                { NuAddressEh.DatasetCode, NuAddressEh },
                { NfAddressEd.DatasetCode, NfAddressEd },
                { NfAddressEh.DatasetCode, NfAddressEh },
                { MkAddressEd.DatasetCode, MkAddressEd },
                { MkAddressEh.DatasetCode, MkAddressEh },
                { MpAddressEd.DatasetCode, MpAddressEd },
                { MpAddressEh.DatasetCode, MpAddressEh },
                { NoAddressEd.DatasetCode, NoAddressEd },
                { NoAddressEh.DatasetCode, NoAddressEh },
                { OmAddressEd.DatasetCode, OmAddressEd },
                { OmAddressEh.DatasetCode, OmAddressEh },
                { PkAddressEd.DatasetCode, PkAddressEd },
                { PkAddressEh.DatasetCode, PkAddressEh },
                { PwAddressEd.DatasetCode, PwAddressEd },
                { PwAddressEh.DatasetCode, PwAddressEh },
                { PsAddressEd.DatasetCode, PsAddressEd },
                { PsAddressEh.DatasetCode, PsAddressEh },
                { PaAddressEd.DatasetCode, PaAddressEd },
                { PaAddressEh.DatasetCode, PaAddressEh },
                { PgAddressEd.DatasetCode, PgAddressEd },
                { PgAddressEh.DatasetCode, PgAddressEh },
                { PyAddressEd.DatasetCode, PyAddressEd },
                { PyAddressEh.DatasetCode, PyAddressEh },
                { PeAddressEd.DatasetCode, PeAddressEd },
                { PeAddressEh.DatasetCode, PeAddressEh },
                { PhAddressEd.DatasetCode, PhAddressEd },
                { PhAddressEh.DatasetCode, PhAddressEh },
                { PnAddressEd.DatasetCode, PnAddressEd },
                { PnAddressEh.DatasetCode, PnAddressEh },
                { PlAddressEd.DatasetCode, PlAddressEd },
                { PlAddressEh.DatasetCode, PlAddressEh },
                { PtAddressEd.DatasetCode, PtAddressEd },
                { PtAddressEh.DatasetCode, PtAddressEh },
                { QaAddressEd.DatasetCode, QaAddressEd },
                { QaAddressEh.DatasetCode, QaAddressEh },
                { RoAddressEd.DatasetCode, RoAddressEd },
                { RoAddressEh.DatasetCode, RoAddressEh },
                { RuAddressEd.DatasetCode, RuAddressEd },
                { RuAddressEh.DatasetCode, RuAddressEh },
                { RwAddressEd.DatasetCode, RwAddressEd },
                { RwAddressEh.DatasetCode, RwAddressEh },
                { ReAddressEd.DatasetCode, ReAddressEd },
                { ReAddressEh.DatasetCode, ReAddressEh },
                { BlAddressEd.DatasetCode, BlAddressEd },
                { BlAddressEh.DatasetCode, BlAddressEh },
                { ShAddressEd.DatasetCode, ShAddressEd },
                { ShAddressEh.DatasetCode, ShAddressEh },
                { KnAddressEd.DatasetCode, KnAddressEd },
                { KnAddressEh.DatasetCode, KnAddressEh },
                { LcAddressEd.DatasetCode, LcAddressEd },
                { LcAddressEh.DatasetCode, LcAddressEh },
                { MfAddressEd.DatasetCode, MfAddressEd },
                { MfAddressEh.DatasetCode, MfAddressEh },
                { PmAddressEd.DatasetCode, PmAddressEd },
                { PmAddressEh.DatasetCode, PmAddressEh },
                { VcAddressEd.DatasetCode, VcAddressEd },
                { VcAddressEh.DatasetCode, VcAddressEh },
                { WsAddressEd.DatasetCode, WsAddressEd },
                { WsAddressEh.DatasetCode, WsAddressEh },
                { SmAddressEd.DatasetCode, SmAddressEd },
                { SmAddressEh.DatasetCode, SmAddressEh },
                { StAddressEd.DatasetCode, StAddressEd },
                { StAddressEh.DatasetCode, StAddressEh },
{ SaAddressEd.DatasetCode, SaAddressEd },
                { SaAddressEh.DatasetCode, SaAddressEh },
                { SnAddressEd.DatasetCode, SnAddressEd },
                { SnAddressEh.DatasetCode, SnAddressEh },
                { RsAddressEd.DatasetCode, RsAddressEd },
                { RsAddressEh.DatasetCode, RsAddressEh },
                { ScAddressEd.DatasetCode, ScAddressEd },
                { ScAddressEh.DatasetCode, ScAddressEh },
                { SlAddressEd.DatasetCode, SlAddressEd },
                { SlAddressEh.DatasetCode, SlAddressEh },
                { SgAddressEd.DatasetCode, SgAddressEd },
                { SgAddressEh.DatasetCode, SgAddressEh },
                { SkAddressEd.DatasetCode, SkAddressEd },
                { SkAddressEh.DatasetCode, SkAddressEh },
                { SiAddressEd.DatasetCode, SiAddressEd },
                { SiAddressEh.DatasetCode, SiAddressEh },
                { SbAddressEd.DatasetCode, SbAddressEd },
                { SbAddressEh.DatasetCode, SbAddressEh },
                { SoAddressEd.DatasetCode, SoAddressEd },
                { SoAddressEh.DatasetCode, SoAddressEh },
                { ZaAddressEd.DatasetCode, ZaAddressEd },
                { ZaAddressEh.DatasetCode, ZaAddressEh },
                { GsAddressEd.DatasetCode, GsAddressEd },
                { GsAddressEh.DatasetCode, GsAddressEh },
                { SsAddressEd.DatasetCode, SsAddressEd },
                { SsAddressEh.DatasetCode, SsAddressEh },
                { EsAddressEd.DatasetCode, EsAddressEd },
                { EsAddressEh.DatasetCode, EsAddressEh },
                { LkAddressEd.DatasetCode, LkAddressEd },
                { LkAddressEh.DatasetCode, LkAddressEh },
                { SdAddressEd.DatasetCode, SdAddressEd },
                { SdAddressEh.DatasetCode, SdAddressEh },
                { SrAddressEd.DatasetCode, SrAddressEd },
                { SrAddressEh.DatasetCode, SrAddressEh },
                { SjAddressEd.DatasetCode, SjAddressEd },
                { SjAddressEh.DatasetCode, SjAddressEh },
                { SzAddressEd.DatasetCode, SzAddressEd },
                { SzAddressEh.DatasetCode, SzAddressEh },
                { SeAddressEd.DatasetCode, SeAddressEd },
                { SeAddressEh.DatasetCode, SeAddressEh },
                { ChAddressEd.DatasetCode, ChAddressEd },
                { ChAddressEh.DatasetCode, ChAddressEh },
                { SyAddressEd.DatasetCode, SyAddressEd },
                { SyAddressEh.DatasetCode, SyAddressEh },
                { TwAddressEd.DatasetCode, TwAddressEd },
                { TwAddressEh.DatasetCode, TwAddressEh },
                { TjAddressEd.DatasetCode, TjAddressEd },
                { TjAddressEh.DatasetCode, TjAddressEh },
                { TzAddressEd.DatasetCode, TzAddressEd },
                { TzAddressEh.DatasetCode, TzAddressEh },
                { ThAddressEd.DatasetCode, ThAddressEd },
                { ThAddressEh.DatasetCode, ThAddressEh },
                { TlAddressEd.DatasetCode, TlAddressEd },
                { TlAddressEh.DatasetCode, TlAddressEh },
                { TgAddressEd.DatasetCode, TgAddressEd },
                { TgAddressEh.DatasetCode, TgAddressEh },
                { TkAddressEd.DatasetCode, TkAddressEd },
                { TkAddressEh.DatasetCode, TkAddressEh },
                { ToAddressEd.DatasetCode, ToAddressEd },
                { ToAddressEh.DatasetCode, ToAddressEh },
                { TtAddressEd.DatasetCode, TtAddressEd },
                { TtAddressEh.DatasetCode, TtAddressEh },
                { TnAddressEd.DatasetCode, TnAddressEd },
                { TnAddressEh.DatasetCode, TnAddressEh },
                { TrAddressEd.DatasetCode, TrAddressEd },
                { TrAddressEh.DatasetCode, TrAddressEh },
                { TmAddressEd.DatasetCode, TmAddressEd },
                { TmAddressEh.DatasetCode, TmAddressEh },
                { TcAddressEd.DatasetCode, TcAddressEd },
                { TcAddressEh.DatasetCode, TcAddressEh },
                { TvAddressEd.DatasetCode, TvAddressEd },
                { TvAddressEh.DatasetCode, TvAddressEh },
                { UgAddressEd.DatasetCode, UgAddressEd },
                { UgAddressEh.DatasetCode, UgAddressEh },
                { UaAddressEd.DatasetCode, UaAddressEd },
                { UaAddressEh.DatasetCode, UaAddressEh },
                { AeAddressEd.DatasetCode, AeAddressEd },
                { AeAddressEh.DatasetCode, AeAddressEh },
                { UyAddressEd.DatasetCode, UyAddressEd },
                { UyAddressEh.DatasetCode, UyAddressEh },
                { UzAddressEd.DatasetCode, UzAddressEd },
                { UzAddressEh.DatasetCode, UzAddressEh },
                { VuAddressEd.DatasetCode, VuAddressEd },
                { VuAddressEh.DatasetCode, VuAddressEh },
                { VaAddressEd.DatasetCode, VaAddressEd },
                { VaAddressEh.DatasetCode, VaAddressEh },
                { VnAddressEd.DatasetCode, VnAddressEd },
                { VnAddressEh.DatasetCode, VnAddressEh },
                { VgAddressEd.DatasetCode, VgAddressEd },
                { VgAddressEh.DatasetCode, VgAddressEh },
                { ViAddressEd.DatasetCode, ViAddressEd },
                { ViAddressEh.DatasetCode, ViAddressEh },
                { WfAddressEd.DatasetCode, WfAddressEd },
                { WfAddressEh.DatasetCode, WfAddressEh },
                { EhAddressEd.DatasetCode, EhAddressEd },
                { EhAddressEh.DatasetCode, EhAddressEh },
                { YeAddressEd.DatasetCode, YeAddressEd },
                { YeAddressEh.DatasetCode, YeAddressEh },
                { ZmAddressEd.DatasetCode, ZmAddressEd },
                { ZmAddressEh.DatasetCode, ZmAddressEh },
                { ZwAddressEd.DatasetCode, ZwAddressEd },
                { ZwAddressEh.DatasetCode, ZwAddressEh }
            };
        }

        private Dataset(string datasetCode, Country country, List<SearchType> searchTypes, Accuracy addressAccuracy, Accuracy geocodeAccuracy)
        {
            DatasetCode = datasetCode;
            Country = country;
            SearchTypes = searchTypes;
            AddressAccuracy = addressAccuracy;
            GeocodeAccuracy = geocodeAccuracy;
        }

        public static Dataset FromCode(string? datasetCode)
        {
            if (!string.IsNullOrWhiteSpace(datasetCode))
            {
                return datasetMap.TryGetValue(datasetCode, out var dataset) ? dataset : throw new KeyNotFoundException($"Dataset code '{datasetCode}' not found.");
            }

            throw new KeyNotFoundException($"Dataset code '{datasetCode}' not found.");
        }
    }
}