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
    //https://localhost:7274/api/openAI
    public class OpenAIController : ControllerBase

    {
        //Update to leverage dependency injection before posting to production.
        // https://github.com/betalgo/openai

        public OpenAIController()
        {
           
        }



        [HttpGet("{prompt}")]
        public String GetGPTResponse(string prompt)
        {
           Console.WriteLine(prompt);
           string response = HandleGPTRequest(prompt).Result;
           return response;
        }
        async public Task<String> HandleGPTRequest(String prompt)
        {

            var openAiService = new OpenAIService(new OpenAiOptions()
            {
                ApiKey = ""
            });
            
            var completionResult = await openAiService.Completions.CreateCompletion(new CompletionCreateRequest()
            {
                Prompt = prompt,
                MaxTokens = 300,
                Temperature = 0.9f,
            }, OpenAI.GPT3.ObjectModels.Models.Davinci);

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
                Console.WriteLine($"{completionResult.Error.Code}: {completionResult.Error.Message}");
                return null;
            }
        }
    }
}