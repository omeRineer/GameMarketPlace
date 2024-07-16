using GameStore.Cms.Model.Enum;

namespace GameStore.Cms.Model.Setting
{
    public class SettingProperty
    {
        public InputType Type { get; set; } = InputType.Text;
        public string Key { get; set; }
        public object Value { get; set; }
        public bool ReadOnly { get; set; }
    }
}
