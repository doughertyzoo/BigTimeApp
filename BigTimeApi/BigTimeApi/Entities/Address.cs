namespace BigTimeApi
{
    public class Address
    {
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zip { get; set; }
        public string AddressBlock
        {
            get
            {
                bool hasStreet = !string.IsNullOrWhiteSpace(Street);
                bool hasCity = !string.IsNullOrWhiteSpace(City);
                bool hasState = !string.IsNullOrWhiteSpace(State);
                bool hasZip = !string.IsNullOrWhiteSpace(Zip);

                if (!hasStreet && !hasCity && !hasState && !hasZip)
                {
                    return string.Empty;
                }

                string street = hasStreet ? $"{Street}<br />" : string.Empty;
                string city = hasCity ? $"{City}" : string.Empty;
                if (!string.IsNullOrWhiteSpace(city) && (hasState || hasZip)) {
                    city += ", ";
                }
                string state = hasState ? $"{State} " : string.Empty;

                return $"{street}{city}{state}{Zip}";
            }
        }
    }
}
