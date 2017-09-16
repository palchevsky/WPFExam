using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;

namespace ERP.Helpers
{
    public class RandomNames
    {
        //Information loading from randomuser.me
        public class Randomuser
        {
            public List<Results> ResultsList { get; set; }
        }

        public class Results
        {
            public string gender { get; set; }
            public Name name { get; set; }
            public Location location { get; set; }
            public string email { get; set; }
            public Login login { get; set; }
            public string dob { get; set; }
            public string registered { get; set; }
            public string phone { get; set; }
            public string cell { get; set; }
            public Id id { get; set; }
            public Picture picture { get; set; }
            public string nat { get; set; }
        }

        public partial class Name
        {
            public string title { get; set; }
            public string first { get; set; }
            public string last { get; set; }
        }

        public partial class Location
        {
            public string street { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string postcode { get; set; }
        }

        public partial class Login
        {
            public string username { get; set; }
            public string password { get; set; }
            public string salt { get; set; }
            public string md5 { get; set; }
            public string sha1 { get; set; }
            public string sha256 { get; set; }
        }

        public partial class Id
        {
            public string name { get; set; }
            public string value { get; set; }
        }

        public partial class Picture
        {
            public string large { get; set; }
            public string medium { get; set; }
            public string thumbnail { get; set; }
        }

        /// <summary>
        /// Get one user
        /// </summary>
        /// <returns></returns>
        public static Results GetSingleDummyUser()
        {
            var user = new Results();
            var url = @"https://randomuser.me/api/1.1/?nat=us";
            var data = Fetch(url);
            if (data != null)
                user = data.FirstOrDefault();
            return user;
        }

        /// <summary>
        /// Get list of users
        /// </summary>
        /// <param name="take"></param>
        /// <returns></returns>
        public static List<Results> GetManyDummyUser(int take)
        {
            var users = new List<Results>();
            var url = @"https://randomuser.me/api/1.1/?nat=us&results=" + take;
            var data = Fetch(url);
            if (data == null) return users;
            users.AddRange(data);
            return users;
        }

        /// <summary>
        /// Deserialization from the url
        /// </summary>
        /// <param name="url">URL from randomuser.me</param>
        /// <returns></returns>
        private static List<Results> Fetch(string url)
        {
            var lresults = new List<Results>();
            try
            {
                using (var wc = new WebClient())
                {
                    var downloaded = wc.DownloadString(url);
                    var joresult = JObject.Parse(downloaded);
                    IList<JToken> results = joresult["results"].Children().ToList();
                    lresults.AddRange(results.Select(result => JsonConvert.DeserializeObject<Results>(result.ToString())));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return lresults;
        }
    }
}