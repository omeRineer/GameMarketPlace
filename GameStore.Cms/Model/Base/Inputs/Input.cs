namespace GameStore.Cms.Model.Base.Inputs
{
    public class Input<TValue>
    {
        public Type Type => typeof(TValue);

        public string Id { get; set; } = Guid.NewGuid().ToString();
        public bool ReadOnly { get; set; } = false;
        public TValue Value { get; set; }
    }
}
