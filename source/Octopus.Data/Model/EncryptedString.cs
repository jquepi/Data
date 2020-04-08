namespace Octopus.Data.Model
{
    public class EncryptedString
    {
        public EncryptedString()
        {}
        
        public EncryptedString(string value)
        {
            Value = value;
        }

        public string Value { get; set; }
    }
}