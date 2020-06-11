using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Amazon.CostExplorer.Model;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using AutoMapper;

namespace CloudUsagePOC
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([TimerTrigger("0 */5 * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            CanonicalCostandUsage costandUsage =  createCanonicalData(buildResponse());

        }

        private static GetCostAndUsageResponse buildResponse()
        {

            GetCostAndUsageResponse  costAndUsageResponse = new GetCostAndUsageResponse();
            string jsonString = File.ReadAllText(@"..\TestData\costandusageresponse.json");
            costAndUsageResponse =   JsonSerializer.Deserialize<GetCostAndUsageResponse>(jsonString);
            return costAndUsageResponse;



        }

        private static CanonicalCostandUsage createCanonicalData(GetCostAndUsageResponse awsResponse)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<GetCostAndUsageResponse, CanonicalCostandUsage>(); });
            IMapper mapper = config.CreateMapper();
            CanonicalCostandUsage genericUsage = mapper.Map<GetCostAndUsageResponse, CanonicalCostandUsage>(awsResponse);
            return genericUsage;
        }


            
        
    }
}
