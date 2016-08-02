#region using directives

using System;
using System.Threading.Tasks;
using PokemonGo.RocketAPI.Enums;
using PokemonGo.RocketAPI.Exceptions;
using PokemonGo.RocketAPI.Extensions;

#endregion

namespace PokemonGo.Haxton.Bot.ApiProvider
{
    public class ApiFailureStrategy : IApiFailureStrategy
    {
        private int _retryCount;

        public ApiFailureStrategy()
        {
        }

        public async Task<ApiOperation> HandleApiFailure()
        {
            if (_retryCount == 11)
                return ApiOperation.Abort;

            await Task.Delay(500);
            _retryCount++;

            return ApiOperation.Retry;
        }

        public void HandleApiSuccess()
        {
            _retryCount = 0;
        }
    }
}