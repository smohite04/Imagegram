using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using UserPostApi.Common;
using UserPostApi.GraphQL.Service;

namespace UserPostApi.Web
{
    [TypeFilter(typeof(AccountAuthenticationFilter))]
    [Route("api/v1.0/")]
    public class UserPostController : Controller
    {
        private readonly IDocumentExecuter _documentExecuter;
        private readonly ISchema _schema;
        public UserPostController(ISchema schema, IDocumentExecuter documentExecuter)
        {
            _schema = schema;
            _documentExecuter = documentExecuter;
        }

        [HttpPost]
        [Route("postDetails")]
        public async Task<IActionResult> UserPostDetailsAsync([FromBody] GraphQLQuery query)
        {
            if (query == null || string.IsNullOrWhiteSpace(query.Query) == true)
            {
                throw Errors.MissingField(nameof(query));
            }
            var inputs = query.Variables.ToInputs();

            var executionOptions = new ExecutionOptions
            {
                Schema = _schema,
                Query = query.Query,
                Inputs = inputs
            };

            var result = await _documentExecuter.ExecuteAsync(executionOptions);
            if (result.Errors?.Count > 0)
            {
                result.Errors.ToException();
            }
            return Ok(result);
        }
        [HttpPost]
        [Route("DeleteUser/init")]
        public async Task<IActionResult> DeleteUserPostDetailsAsync([FromBody] GraphQLQuery query)
        {
            if (query == null || string.IsNullOrWhiteSpace(query.Query) == true)
            {
                throw Errors.MissingField(nameof(query));
            }
            var inputs = query.Variables.ToInputs();

            var executionOptions = new ExecutionOptions
            {
                Schema = _schema,
                Query = query.Query,
                Inputs = inputs
            };

            var result = await _documentExecuter.ExecuteAsync(executionOptions);
            if (result.Errors?.Count > 0)
            {
                result.Errors.ToException();
            }
            return Ok(result);
        }
    }
}
