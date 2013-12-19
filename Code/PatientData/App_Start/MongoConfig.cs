using PatientData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver.Linq;

namespace PatientData.App_Start
{
    public static class MongoConfig
    {
        public static void Seed()
        {
            var patients = PatientDb.Open();
            if (!patients.AsQueryable().Any(p => p.Name == "Andy"))
            {
                var data = new List<Patient>()
                {
                new Patient {
                    Name = "Andy",
                    Ailments = new List<Ailment>() {new Ailment() {Name = "Ailment1"}, new Ailment() {Name = "Ailment2"}},
                    Midications = new List<Medication>() {new Medication() { Name="Medi1", Doses=2}, new Medication() { Name="Medi2", Doses=3}}
                },
                new Patient {
                    Name = "Scott",
                    Ailments = new List<Ailment>() {new Ailment() {Name = "Ailment3"}},
                    Midications = new List<Medication>() {new Medication() { Name="Medi5", Doses=5}, new Medication() { Name="Medi6", Doses=1}}
                }
                };
                patients.InsertBatch(data);
            }
        }
    }
}