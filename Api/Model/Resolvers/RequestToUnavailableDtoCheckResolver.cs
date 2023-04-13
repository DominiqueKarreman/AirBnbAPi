using Api.Model.DTO;
using Api.Repositories;
using Api.Services;
using AutoMapper;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Api.Model.Resolvers
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    namespace Api.Model.Resolvers
    {
        public class ReservationRequestToDatesListResolver
        {
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public List<DateTime> Dates { get; set; }

            public ReservationRequestToDatesListResolver(DateTime startDate, DateTime endDate)
            {
                StartDate = startDate;
                EndDate = endDate;
                Dates = Map();
            }

            public List<DateTime> Map()
            {
                var dates = new List<DateTime>();
                for (
                    var date = this.StartDate.AddDays(1);
                    date <= this.EndDate.AddDays(1);
                    date = date.AddDays(1)
                )
                {
                    dates.Add(date);
                }
                return dates;
            }
        }
    }
}
