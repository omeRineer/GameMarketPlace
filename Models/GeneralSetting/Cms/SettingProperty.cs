using Models.Base.Cms.Enums;

namespace Models.GeneralSetting.Cms
{
    public class SettingProperty
    {
        public InputType Type { get; set; } = InputType.Text;
        public string Key { get; set; }
        public object Value { get; set; }
        public bool ReadOnly { get; set; }
    }
}
