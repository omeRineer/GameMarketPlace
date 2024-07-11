namespace GameStore.Cms.Model.Setting
{
    public class CreateSettingModel
    {
        public int SettingTypeId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public bool IsCached { get; set; }
        public int? CacheDuration { get; set; }
    }
}
