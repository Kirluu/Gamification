using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GamificationApi;
using GamificationApi.Dtos;
using GamificationApi.GameLogic;
using GamificationApi.ModelRepositories;
using GamificationApi.Models;

namespace GamificationApi.Controllers
{
    public class PlayerController : ApiController // Maybe just need to use AccountController for this? Confirm with Isabella eventually
    {
        private IUnitOfWork _unitOfWork;
        private IGameLogicApplier _gameLogic;
        private IDtoFactory _dtoFactory;

        public PlayerController()
        {
            _unitOfWork = new UnitOfWork();
            _gameLogic = new GameLogicApplier(_unitOfWork, new AchievementChecker(), new StatApplier(), new LevelUpChecker());
            _dtoFactory = new DtoFactory(_unitOfWork);
        }

        //public IHttpActionResult Player()
        //{

        //}

        // GET: api/Player
        public IEnumerable<string> Get() // Get all players
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPut]
        public IHttpActionResult CompleteTask(string playerName, string taskNameOrCode)
        {
            // Get player and assignment completed
            var player = _unitOfWork.PlayerRepository.Get(p => p.Name == playerName, null, "").FirstOrDefault();
            if (player == null) return Conflict();
            var assignmentTypeCompleted = _unitOfWork.AssignmentTypeRepository.Get(a => a.NameOrCode == taskNameOrCode, null, "").FirstOrDefault();
            if (assignmentTypeCompleted == null) return Conflict();

            return Ok(_gameLogic.CompleteTask(player, assignmentTypeCompleted));
        }

        [HttpGet]
        [Route("state")]
        public IHttpActionResult GetState(string playerName)
        {
            var player = _unitOfWork.PlayerRepository.Get(p => p.Name == playerName, null, "").FirstOrDefault();
            if (player != null)
            {
                try
                {
                    return Ok(_dtoFactory.CreatePlayerDto(player));
                }
                catch
                {
                    return Conflict(); // Code for "I fucked up"
                }
            }
            else
            {
                return NotFound();
            }
        }

        // ---------------------------------------------------------------------------------------------
        // Standard CRUD

        // GET: api/Player/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Player
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Player/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Player/5
        public void Delete(int id)
        {
        }
    }
}
