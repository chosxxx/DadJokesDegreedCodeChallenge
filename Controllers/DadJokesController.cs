using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DadJokesDegreedCodeChallenge.Helpers;
using DadJokesDegreedCodeChallenge.Models;
using DadJokesDegreedCodeChallenge.Providers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DadJokesDegreedCodeChallenge.Controllers
{

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class DadJokesController : ControllerBase
    {
        #region Private fields
        private readonly IICanHazDadJokesProvider _dadJokesProvider;
        #endregion

        #region Constructors
        public DadJokesController(IICanHazDadJokesProvider dadJokesProvider)
        {
            _dadJokesProvider = dadJokesProvider;
        }
        #endregion

        #region Actions
        [HttpGet()]
        public async Task<ActionResult> GetRandomJoke()
        {
            try
            {
                var joke = await _dadJokesProvider.GetRandomJoke();
                return Ok(new { TotalJokes = 1, Results = new List<DadJokeResponseModel> { joke } });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpGet("{term}")]
        public async Task<ActionResult> SearchJoke(string term)
        {
            try
            {
                var jokes = await _dadJokesProvider.SearchJoke(term);
                
                return Ok(jokes);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        #endregion
    }
}