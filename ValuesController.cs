using Microsoft.AspNetCore.Cors;
using Product.Data;
using Product.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
// using System.Web.Http.Cors;

namespace Product.Controllers
{
   //  [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
        DAL dataAccessLayer = new DAL();

        #region Get Default Data
        [HttpGet]
        [Route("API/DefaultFields")]
        public object DefaultFields()
        {
            var response = dataAccessLayer.DefaultField();
            return response;
        }
        #endregion

        #region Get Custom Data
        [HttpGet]
        [Route("API/CustomFields")]
        public object CustomFields()
        {
            var response = dataAccessLayer.CustomField();
            return response;
        }
        #endregion


        #region Merge output
        [HttpGet]
        [Route("API/Merge")]
        public object MergeOutput()
        {
            var response = dataAccessLayer.MergeOutput();
            return response;
        }

        #endregion

        #region BulkInsert
        [HttpPost]
        [Route("API/BulkInsert")]
        public object BulkInsert(Products product)
        {
            var response = dataAccessLayer.BulkInsert(product);
            return response;
        }

        #endregion
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
