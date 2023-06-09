using ServiceReference1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;



namespace SOAPFinalExam
{
    [TestClass]
    public class SoapFinalTests
    {
        private readonly CountryInfoServiceSoapTypeClient countryTest =
            new CountryInfoServiceSoapTypeClient(CountryInfoServiceSoapTypeClient.EndpointConfiguration.CountryInfoServiceSoap);

        private List<tCountryCodeAndName> CountryList()
        {
            var countryList = countryTest.ListOfCountryNamesByCode();
            return countryList;
        }

        private static tCountryCodeAndName RandomCountryCode(List<tCountryCodeAndName> countryList)
        {
            Random rd = new Random();
            int countryCount = countryList.Count - 1;
            int randomNum = rd.Next(0, countryCount);
            var randomCountryCode = countryList[randomNum];

            return randomCountryCode;
        }

        [TestMethod]
        public void CountryDetails()
        {
            var countryList = CountryList();
            var countryListCode = RandomCountryCode(countryList);
            var countryDetails = countryTest.FullCountryInfo(countryListCode.sISOCode);


            Assert.AreEqual(countryListCode.sISOCode, countryDetails.sISOCode, "Country code doesn't match.");
            Assert.AreEqual(countryListCode.sName, countryDetails.sName, "Country name doesn't match.");
        }
        [TestMethod]
        public void RandomFiveCountry()
        {
            var countryList = CountryList();

            List<tCountryCodeAndName> RanCountry = new List<tCountryCodeAndName>();

      

            for (int x = 0; x < 5; x++)
            {
                RanCountry.Add(RandomCountryCode(countryList));
            }
            foreach (var country in RanCountry)
            {
                var countryISOCode = countryTest.CountryISOCode(country.sName);
                Assert.AreEqual(country.sISOCode, countryISOCode, "Country code doesn't match.");
            }

        }

    }

}