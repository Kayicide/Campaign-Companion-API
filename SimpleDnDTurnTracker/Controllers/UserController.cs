using System;
using Microsoft.AspNetCore.Mvc;
using SimpleDnDTurnTracker.Controllers.HttpRequests;
using SimpleDnDTurnTracker.Data.Entities;
using SimpleDnDTurnTracker.Features;
using SimpleDnDTurnTracker.Features.Encounters;
using SimpleDnDTurnTracker.Features.Users;

namespace SimpleDnDTurnTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IRequestHandler<FindUserRequest, User> _findUserRequestHandler;
        private readonly IRequestHandler<CreateUserRequest, User> _createUserRequestHandler;

        //I don't want this to stay in this api, it would be nice to to move it to a user microservice
        public UserController(IRequestHandler<FindUserRequest, User> findUserRequestHandler,
                              IRequestHandler<CreateUserRequest, User> createUserRequestHandler)
        {
            _findUserRequestHandler = findUserRequestHandler;
            _createUserRequestHandler = createUserRequestHandler;
        }

        [HttpGet("{discordId}")]
        public async Task<IActionResult> Get([FromRoute] string discordId)
        {
            var user = await _findUserRequestHandler.HandleRequest(new FindUserRequest { DiscordId = discordId });
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserHttpRequest createUserHttpRequest)
        {
            var user = await _createUserRequestHandler.HandleRequest(new CreateUserRequest { DiscordId = createUserHttpRequest.DiscordId });
            return Ok(user);
        }
    }
}

