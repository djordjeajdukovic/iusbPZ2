namespace NetworkService.Model
{
    public class NetworkEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EntityType Type { get; set; }
        public double Value { get; set; }

        public string TypeName
        {
            get { return Type == null ? string.Empty : Type.Name; }
        }

        public bool IsValid
        {
            get { return Value >= 5 && Value <= 16; }
        }

        public string StatusText
        {
            get { return IsValid ? "Validno" : "Nevalidno"; }
        }

        public string ValueText
        {
            get { return Value.ToString("0.0") + " MP"; }
        }
    }
}
