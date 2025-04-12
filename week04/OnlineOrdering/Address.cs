using System;

class Address {

    private string _street;
    private string _city;
    private string _stateProvince;
    private string _country;


    public Address(string streetAddress, string city, string stateProvince, string country) 
    {
        _street = streetAddress;
        _city = city;
        _stateProvince = stateProvince;
        _country = country;
    }
        public Address(string streetAddress, string city, string country) 
    {
        _street = streetAddress;
        _city = city;
        _country = country;
    }

    public string GetFormattedAddress() {

        return $"{_street}\n{_city},\n{_stateProvince}\n{_country}";
    }

    public bool IsInUSA()
    {
        return _country.ToUpper() == "USA" || _country.ToUpper() == "UNITED STATES" || _country.ToUpper() == "US";
    }

}