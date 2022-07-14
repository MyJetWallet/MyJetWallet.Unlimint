using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Payments
{

    public class Flights
    {
        [JsonProperty("computerized_res_system")]
        public string ComputerizedResSystem { get; set; }

        [JsonProperty("credit_reason_indicator")]
        public string CreditReasonIndicator { get; set; }

        [JsonProperty("departure_date")] public string DepartureDate { get; set; }
        [JsonProperty("flight")] public List<Flight> Flight { get; set; }
        [JsonProperty("is_restricted")] public Boolean IsRestricted { get; set; }
        [JsonProperty("origination_code")] public string OriginationCode { get; set; }
        [JsonProperty("passenger_name")] public string PassengerName { get; set; }

        [JsonProperty("ticket_change_indicator")]
        public string TicketChangeIndicator { get; set; }

        [JsonProperty("ticket_number")] public string TicketNumber { get; set; }
        [JsonProperty("travel_agency_code")] public string travelAgencyCode { get; set; }
        [JsonProperty("travel_agency_name")] public string TravelAgencyName { get; set; }
    }
}