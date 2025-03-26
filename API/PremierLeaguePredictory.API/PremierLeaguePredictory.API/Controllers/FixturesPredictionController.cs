using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PremierLeaguePredictory.API.Models.Domain;
using PremierLeaguePredictory.API.Models.DTO;
using PremierLeaguePredictory.API.Services.Interfaces;

namespace PremierLeaguePredictory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FixturesPredictionController(IFixturePredictionRepository fixturePredictionRepository, 
        IUserRepository userRepository, 
        IFixturesRepository fixturesRepository) : ControllerBase
    {
        private readonly IFixturePredictionRepository fixturePredictionRepository = fixturePredictionRepository;
        private readonly IUserRepository userRepository = userRepository;
        private readonly IFixturesRepository fixturesRepository = fixturesRepository;



        // POST: {apibaseurl}/api/FixturesPredictions
        [HttpPost]
        public async Task<IActionResult> AddFixturePrediction(CreateFixturePredictionRequestDto request)
        {
            
            var user = await userRepository.GetByEmailAsync(request.Username);

            var fixture = await fixturesRepository.GetFixtureAsync(request);

            string predictedWinner;

            if(request.PredictedHomeTeamScore > request.PredictedAwayTeamScore)
            {
                 predictedWinner = "HOME_TEAM";
            }
            else if (request.PredictedAwayTeamScore > request.PredictedHomeTeamScore)
            {
                 predictedWinner = "AWAY_TEAM";
            }
            else
            {
                 predictedWinner = "DRAW";
            }

            // Convert dto to domain model

            if (fixture == null)
            {
                return NotFound("Fixture doesn't exist");

            }


            var prediction = new FixturesPredictions
            {
                UserId = user.Id,
                FixtureId = fixture.FixtureId,
                PredictedHomeScore = request.PredictedHomeTeamScore,
                PredictedAwayScore = request.PredictedAwayTeamScore,
                PredictionDate = DateTime.Now,
                PredictedWinner = predictedWinner,
            };

            await fixturePredictionRepository.CreateAsync(prediction);

            return Ok();
        }

        // GET: {apibaseurl}/api/FixturesPredictions
        [HttpGet("{email}")]
        public async Task<IActionResult> GetFixturePredictionByEmail(string email)
        {
            var user = await userRepository.GetByEmailAsync(email);
            if (user == null)
            {
                return NotFound("User does not exist");
            }

            var predictions = await fixturePredictionRepository.GetByEmailAsync(user.Id);

            if (predictions.Count() == 0)
            {
                return Ok(Array.Empty<FixturePredictionResponseDto>());
            }
            return Ok(predictions);

        }
    }
}
