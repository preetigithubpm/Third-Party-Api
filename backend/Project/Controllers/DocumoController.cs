using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;

namespace task29August.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumoController : ControllerBase
    {
        private readonly HttpClient _client;

        public DocumoController()
        {
            // Initialize HttpClient with authorization header
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("Authorization", "Basic eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VySWQiOiI2ZTVmMmYxYS04NmMyLTQ4NjUtYTcxNC05Zjg3MWY1YzQ5YzgiLCJhY2NvdW50SWQiOiIyOWJhMjM5Zi00NDgzLTRkNDEtYThlMC1jZjMyNWU2MDEwNWQiLCJpYXQiOjE2OTU4NzMwNDJ9.cFrYLuVknQ3E1DrJsPWZv01g7s6PPRDbEiKm4QM9NSI");
        }
        public class PayLoad
        {
            public string value { get; set; }


        }
 

        [HttpPost]
        [Route("webhooknormal")]
        public async Task<IActionResult> webhooknormal()
        {
            string requestBody;
            using (var reader = new StreamReader(Request.Body))
            {
                requestBody = await reader.ReadToEndAsync();
            }

            FaxResponse faxResponse = JsonConvert.DeserializeObject<FaxResponse>(requestBody);


            return Ok();

        }
        [HttpPost]
        [Route("webhook")]
        public async Task<IActionResult> webhook(FaxResponse webhookData)
        {
            Console.WriteLine($"Received webhook: {webhookData.ApiResponse}");

            return Ok("Webhook received successfully");

        }


        public class Content
        {
            public string value { get; set; }
            public string attachments { get; set; }

        }

        [HttpPost]
        [Route("sendAttachment")]
        public async Task<IActionResult> send([FromBody] Content model)
        {
            try { 
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.sandbox.documo.com");
            request.Headers.Add("Authorization", "Basic eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VySWQiOiI2ZTVmMmYxYS04NmMyLTQ4NjUtYTcxNC05Zjg3MWY1YzQ5YzgiLCJhY2NvdW50SWQiOiIyOWJhMjM5Zi00NDgzLTRkNDEtYThlMC1jZjMyNWU2MDEwNWQiLCJpYXQiOjE2OTU4NzMwNDJ9.cFrYLuVknQ3E1DrJsPWZv01g7s6PPRDbEiKm4QM9NSI");
            var content = new MultipartFormDataContent();
            content.Add(new StringContent("+14052955384"), "faxNumber");
                    //var file1Path = "D:\\Users\\File1.pdf";  
                    //var file1Bytes = await System.IO.File.ReadAllBytesAsync(file1Path);
                    //content.Add(new ByteArrayContent(file1Bytes), "attachments", "File1.pdf");

                    //var file2Path = "D:\\Users\\File2.pdf";
                    //var file2Bytes = await System.IO.File.ReadAllBytesAsync(file2Path);
                    //content.Add(new ByteArrayContent(file2Bytes), "attachments", "File2.pdf");


            content.Add(new StringContent("true"), "coverPage");
            content.Add(new StringContent("c71ea74a-9c1b-4911-8aa6-58b71d497a3a"), "coverPageId");
            content.Add(new StringContent("example"), "tags");
            content.Add(new StringContent("example"), "recipientName");
            content.Add(new StringContent("example"), "senderName");
            content.Add(new StringContent("example"), "subject");
            content.Add(new StringContent("18889851595"), "callerId");
            content.Add(new StringContent("example"), "notes");
            content.Add(new StringContent("{\"example\":"+model.value+" \"value\"}"), "cf");
            content.Add(new StringContent("2020-01-01T00:00:00.000Z"), "scheduledDate");
            content.Add(new StringContent("d1077489-5ea1-4db1-9760-853f175e8288"), "webhookId");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();

            Console.WriteLine(responseContent);

            return Ok(new { ResponseContent = responseContent });
        }
              catch (Exception ex)
            {
               return BadRequest(ex.Message);
            }

}
        [HttpPost]
        [Route("sendFaxFront")]
        public async Task<IActionResult> sendFaxBy([FromBody] PayLoad model)
        {
            try
            {
                // Create the fax request
                var request = new HttpRequestMessage(HttpMethod.Post, "https://api.sandbox.documo.com");
                var content = new MultipartFormDataContent();
                content.Add(new StringContent("+14052955384"), "faxNumber");
             
                //content.Add(new StringContent("D:\\Users\\File1.pdf.pdf"), "attachments", "File1.pdf.pdf");
                //content.Add(new StringContent("D:\\Users\\File2.pdf.pdf"), "attachments", "File2.pdf.pdf");
                content.Add(new StringContent("true"), "coverPage");
                content.Add(new StringContent("c71ea74a-9c1b-4911-8aa6-58b71d497a3a"), "coverPageId");
                content.Add(new StringContent("example"), "tags");
                content.Add(new StringContent("example"), "recipientName");
                content.Add(new StringContent("example"), "senderName");
                content.Add(new StringContent("example"), "subject");
                content.Add(new StringContent("18889851595"), "callerId");
                content.Add(new StringContent("example"), "notes");
                content.Add(new StringContent("{\"example\": \"value\"}"), "cf"); // Include model.value in "cf"
                content.Add(new StringContent("2020-01-01T00:00:00.000Z"), "scheduledDate");
                content.Add(new StringContent("d1077489-5ea1-4db1-9760-853f175e8288"), "webhookId");
                request.Content = content;

                // Send the fax request to Documo
                var response = await _client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var apiResponse = await response.Content.ReadAsStringAsync();

                // Prepare webhook data
                var webhookData = new FaxResponse
                {
                    RequestBodyValue = model.value,
                    ApiResponse = apiResponse
                };

                // Trigger the webhook
                var webhookUrl = "https://9de2-203-129-247-226.ngrok-free.app/api/Documo/webhook"; // Replace with your actual webhook URL
                var webhookContent = new StringContent(JsonConvert.SerializeObject(webhookData), Encoding.UTF8, "application/json");
                var webhookResponse = await _client.PostAsync(webhookUrl, webhookContent);

                // Check if the webhook request was successful
                if (webhookResponse.IsSuccessStatusCode)
                {
                    var combinedResponse = new FaxResponse
                    {
                        RequestBodyValue = model.value,
                        ApiResponse = apiResponse
                    };

                    return Ok(combinedResponse);
                }
                else
                {
                    // Handle the case where the webhook request failed
                    // You can log an error, return an error response, or take appropriate action
                    return StatusCode((int)webhookResponse.StatusCode, "Webhook request failed");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the process
                // You can log the exception details or return an error response
                return StatusCode(500, "An error occurred: " + ex.Message);
            }

        }
        public class FaxResponse
        {
            public string RequestBodyValue { get; set; }
            public string ApiResponse { get; set; }
        }

        [HttpPost]
        [Route("SendFaxRes")]
        public async Task<IActionResult> SendFaxRes(PayLoad model)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.sandbox.documo.com");

            // Set the Authorization header correctly with your token
            request.Headers.Add("Authorization", "Basic eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VySWQiOiI2ZTVmMmYxYS04NmMyLTQ4NjUtYTcxNC05Zjg3MWY1YzQ5YzgiLCJhY2NvdW50SWQiOiIyOWJhMjM5Zi00NDgzLTRkNDEtYThlMC1jZjMyNWU2MDEwNWQiLCJpYXQiOjE2OTU4NzMwNDJ9.cFrYLuVknQ3E1DrJsPWZv01g7s6PPRDbEiKm4QM9NSI");

            var content = new MultipartFormDataContent();
            content.Add(new StringContent("+14052955384"), "faxNumber");
            content.Add(new StringContent("true"), "coverPage");
            content.Add(new StringContent("c71ea74a-9c1b-4911-8aa6-58b71d497a3a"), "coverPageId");
            content.Add(new StringContent("example"), "tags");
            content.Add(new StringContent("example"), "recipientName");
            content.Add(new StringContent("example"), "senderName");
            content.Add(new StringContent("example"), "subject");
            content.Add(new StringContent("8889851595"), "callerId");
            content.Add(new StringContent("example"), "notes");
            content.Add(new StringContent("{\"example\": \"value\"}"), "cf");
            content.Add(new StringContent("2020-01-01T00:00:00.000Z"), "scheduledDate");
            content.Add(new StringContent("d1077489-5ea1-4db1-9760-853f175e8288"), "webhookId");

            request.Content = content;

            try
            {
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var apiResponse = await response.Content.ReadAsStringAsync();

                var combinedResponse = new FaxResponse
                {
                    RequestBodyValue = model.value,
                    ApiResponse = apiResponse
                };

                return Ok(combinedResponse);
            }
            catch (HttpRequestException ex)
            {
                // Handle exceptions or log the error message
                return StatusCode(500, "Error: " + ex.Message);
            }
        }


        [HttpGet]
        [Route("dowloadFax")]
        public async Task<IActionResult> dowloadFax()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.documo.com/v1/fax/c71ea74a-9c1b-4911-8aa6-58b71d497a3a/download");
            request.Headers.Add("Authorization", "Basic eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VySWQiOiI2ZTVmMmYxYS04NmMyLTQ4NjUtYTcxNC05Zjg3MWY1YzQ5YzgiLCJhY2NvdW50SWQiOiIyOWJhMjM5Zi00NDgzLTRkNDEtYThlMC1jZjMyNWU2MDEwNWQiLCJpYXQiOjE2OTU4NzMwNDJ9.cFrYLuVknQ3E1DrJsPWZv01g7s6PPRDbEiKm4QM9NSI");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(await response.Content.ReadAsStringAsync());
            return Ok(response.Content.ReadAsStringAsync());

        }







    }
}
