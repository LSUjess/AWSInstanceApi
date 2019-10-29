using Amazon;
using Amazon.EC2;
using Amazon.EC2.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace AWSInstanceByIdApi.Controllers
{
    public class InstanceInfoController : ApiController
    {
        public class ReturnValues
        {
            public string instancetype { get; set; }
            public string instancestate { get; set; }
            public string instancename { get; set; }
        }

        [Route("api/instanceinfo")]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] {"Please add an Instance Id."};
        }

        // GET api/instanceinfo/5
        [Route("api/instanceinfo/{id}")]
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            try
            {
                var ec2Client = new AmazonEC2Client(RegionEndpoint.USEast1);

                var request = ec2Client.DescribeInstances(new DescribeInstancesRequest
                {
                    InstanceIds = new List<string> {id}
                });

                if (request.Reservations != null)
                    foreach (var reservation in request.Reservations)
                    {
                        foreach (var item in reservation.Instances)
                        {
                            var returnJson = new List<ReturnValues>
                            {
                                new ReturnValues
                                {
                                    instancetype = item.InstanceType,
                                    instancestate = item.State.Name,
                                    instancename = item.InstanceId + "." + RegionEndpoint.USEast1.SystemName
                                }
                            };

                            return Ok(returnJson);
                        }
                    }
                return ResponseMessage(
                    Request.CreateResponse(
                        HttpStatusCode.NotFound,
                        "Instance Id does not exist."
                    )
                );
            }
            catch (AmazonEC2Exception ex)
            {
                string errorMessage = "An error has occurred.";

                // Check the ErrorCode to see if the instance does not exist.
                if ("InvalidInstanceID.NotFound" == ex.ErrorCode)
                {
                    errorMessage = "Instance Id does not exist.";
                }
                else if ("InvalidInstanceID.Malformed" == ex.ErrorCode)
                {
                    errorMessage = "Instance Id is malformed.";
                }
                else
                {

                }

                return ResponseMessage(
                    Request.CreateResponse(
                        HttpStatusCode.NotFound,
                        errorMessage
                    )
                );
            }

            return null;
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
