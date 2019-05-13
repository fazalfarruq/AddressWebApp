using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AddressWebApp.Controllers
{
    public class CanadaPostController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Index2(string postCode)
        {
            //Build the url
            try
            {
                var key = "mc82-bz64-rw92-xr71";
                //var url = "http://ws1.postescanada-canadapost.ca/AddressComplete/Interactive/AutoComplete/v1.00/dataset.ws?";
                //var url = "http://ws1.postescanada-canadapost.ca/js/addresscomplete-2.30.min.js?";
                var url = "https://ws1.postescanada-canadapost.ca/AddressComplete/Interactive/Find/v2.10/json3ex.ws?";
                url += "&Key=" + System.Web.HttpUtility.UrlEncode(key);
                url += "&SearchTerm=" + System.Web.HttpUtility.UrlEncode(postCode);
                //url += "&Location=" + System.Web.HttpUtility.UrlEncode(location);
                //url += "&LocationAccuracy=" + System.Web.HttpUtility.UrlEncode(locationaccuracy.ToString(CultureInfo.InvariantCulture));
                //url += "&Country=" + System.Web.HttpUtility.UrlEncode(country);
                //url += "&LanguagePreference=" + System.Web.HttpUtility.UrlEncode(languagepreference);

                //Create the dataset
                var dataSet = new System.Data.DataSet();
                dataSet.ReadXml(url);

                //Check for an error
                if (dataSet.Tables.Count == 1 && dataSet.Tables[0].Columns.Count == 4 && dataSet.Tables[0].Columns[0].ColumnName == "Error")
                    throw new Exception(dataSet.Tables[0].Rows[0].ItemArray[1].ToString());
                var x = dataSet;
                //Return the dataset
                //return dataSet;

            }
            catch (Exception e) {

            }

            //FYI: The dataset contains the following columns:
            //Id
            //Text
            //Highlight
            //Description
            //IsRetrievable


            return View();
        }
    }
}