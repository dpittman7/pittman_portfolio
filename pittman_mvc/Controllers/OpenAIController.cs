using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.Extensions.DependencyInjection;
using OpenAI.GPT3.Interfaces;
using System;
using System.Runtime.CompilerServices;
using OpenAI.GPT3.Managers;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3;

namespace pittman_mvc.Controllers
{
    [ApiController]
    [Route("/api/openAI")]
    //https://localhost:7274/api/openAI/
    public class OpenAIController : ControllerBase

    {
        //Update to leverage dependency injection before posting to production.
        // https://github.com/betalgo/openai
        // "

        public OpenAIController()
        {
            
        }



        [HttpPost]
        public String GetGPTResponse()
        {

           string response = HandleGPTRequest().Result;
           return response;
        }
        async public Task<String> HandleGPTRequest()
        {
            string requestBody = await new StreamReader(Request.Body).ReadToEndAsync();
            Console.WriteLine(requestBody);
            string apikey = Environment.GetEnvironmentVariable("OPENAPI_KEY");
            var openAiService = new OpenAIService(new OpenAiOptions()
            {
                ApiKey = apikey
            }); 
            
            var completionResult = await openAiService.Completions.CreateCompletion(new CompletionCreateRequest()
            {
                Prompt = requestBody,
                MaxTokens = 300,
                Temperature = 0.9f,
            }, "davinci-instruct-beta"); // Submit Pull Request to add ADA and Davinci Intrust Models accessable in Model Class

            if (completionResult.Successful)
            {
                string response = completionResult.Choices[0].Text;
                Console.WriteLine(response);
                return response;
            }
            else
            {
                if (completionResult.Error == null)
                {
                    throw new Exception("Unknown Error");
                }
                return $"{completionResult.Error.Code}: {completionResult.Error.Message}";
                
            }
        }
    }
}
