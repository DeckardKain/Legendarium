using OpenAI.GPT3;
using OpenAI.GPT3.Managers;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.SharedModels;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.Interfaces;
using LegendariumWorld;
using Microsoft.Identity.Client;

namespace LegendariumUI.Services
{
    public class AIService : IAIService
    {
        private readonly IOpenAIService _openAIService;
        private readonly ILocationService _locationService;

        public AIService(IOpenAIService openAIService, ILocationService locationService)
        {
            _openAIService = openAIService;
            _locationService = locationService;
        }

        public async Task GetPicture(Location location)
        {
            try
            {
                var imageResult = await _openAIService.Image.CreateImage(new ImageCreateRequest
                {
                    Prompt = "landscape vista photography by Carr Clifton & Galen Rowell, 16K resolution, Landscape veduta photo by Dustin Lefevre & tdraw, 8k resolution, detailed landscape painting by Ivan Shishkin, DeviantArt, Flickr, rendered in Enscape, a " + location.Biome + " landscape",
                    N = 1,
                    Size = "256x256",
                    ResponseFormat = StaticValues.ImageStatics.ResponseFormat.Base64,
                    User = "Phil Mullins"
                });

                
                if (imageResult.Successful)
                
                {
                    var image = imageResult.Results.Select(x => x.B64).First();
                    _locationService.SaveImage(location, image);                   
                }
            }
            catch(Exception e)
            {
            
            }
        }
    }
}
