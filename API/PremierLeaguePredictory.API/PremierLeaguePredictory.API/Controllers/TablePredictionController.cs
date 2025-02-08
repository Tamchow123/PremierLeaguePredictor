using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PremierLeaguePredictory.API.Data;
using PremierLeaguePredictory.API.Models.Domain;
using PremierLeaguePredictory.API.Models.DTO;
using PremierLeaguePredictory.API.Services.Interfaces;

namespace PremierLeaguePredictory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablePredictionController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly ITeamsRepository teamsRepository;
        private readonly ITablePredictionRepository tablePredictionRepository;

        public TablePredictionController(IUserRepository userRepository, ITeamsRepository teamsRepository, ITablePredictionRepository tablePredictionRepository)
        {
            this.userRepository = userRepository;
            this.teamsRepository = teamsRepository;
            this.tablePredictionRepository = tablePredictionRepository;
        }

        // POST: {apibaseurl}/api/TablePredictions
        [HttpPost]
        public async Task<IActionResult> AddTablePrediction(CreateTablePredictionRequestDto request)
        {
            var user = await userRepository.GetByEmailAsync(request.Username);

            //Convert dto to domain model

            foreach (var predictionRequest in request.Predictions)
            {
                var team = await teamsRepository.GetByNameAsync(predictionRequest.Team);
                var prediction = new EndOfSeasonPredictions
                {

                    UserId = user.Id,
                    Position = predictionRequest.Position,
                    TeamId = team.TeamId,
                    Season = "2024"
                };

                await tablePredictionRepository.CreateAsync(prediction);
            }



            return Ok();
        }

        // GET: {apibaseurl}/api/TablePredictions/{email}
        [HttpGet("{email}")]
        public async Task<IActionResult> GetTablePredictionByEmail(string email)
        {
            var user = await userRepository.GetByEmailAsync(email);
            if (user == null)
            {
                return NotFound("User does not exist");
            }

            var predictions = await tablePredictionRepository.GetByEmailAsync(user.Id);

            if (predictions.Count() == 0)
            {
                return Ok(Array.Empty<TablePredictionResponseDto>());
            }
            return Ok(predictions);
        }



    }
}
