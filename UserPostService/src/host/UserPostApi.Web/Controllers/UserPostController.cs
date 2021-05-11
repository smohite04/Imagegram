using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using UserPostApi.GraphQL.Service;

namespace UserPostService.Controllers
{
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
            var data = HttpContext.Request.Query;
                if (query == null) { throw new ArgumentNullException(nameof(query)); }
                var inputs = query.Variables.ToInputs();
            foreach (var pair in data)
            {
                inputs.Add(pair.Key,pair.Value);
            }
                var executionOptions = new ExecutionOptions
                {
                    Schema = _schema,
                    Query = query.Query,
                    Inputs = inputs
                };

                var result = await _documentExecuter.ExecuteAsync(executionOptions);

                if (result.Errors?.Count > 0)
                {
                   // ErrorExtension.HandleErrors(result);
                    return BadRequest(result);
                }
                return Ok(result);            
        }
    }
}
