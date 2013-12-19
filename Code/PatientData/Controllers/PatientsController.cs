using MongoDB.Bson;
using MongoDB.Driver;
using PatientData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PatientData.Controllers
{
    [EnableCors("http://localhost","*","GET")]
    public class PatientsController : ApiController
    {
        MongoCollection<Patient> _patients;

        public PatientsController()
        {
            _patients = PatientDb.Open();
        }
         
        public IEnumerable<Patient> Get()
        {
            return _patients.FindAll();
        }

        public HttpResponseMessage Get(string id)
        {
            var patient = _patients.FindOneById(ObjectId.Parse(id));
            if (patient == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Patient not found");
            }
            return Request.CreateResponse(patient);
        }

        [Route("api/patients/{id:length(24)}/medications")]
        public HttpResponseMessage GetetMedications(string id)
        {
            var patient = _patients.FindOneById(ObjectId.Parse(id));
            if (patient == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Patient not found");
            }
            return Request.CreateResponse(patient.Midications);
        }
    }
}
