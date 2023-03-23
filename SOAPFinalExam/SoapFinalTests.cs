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
       

    }

}