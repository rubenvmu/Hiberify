using Microsoft.AspNetCore.Mvc;

namespace webmusic_solved.Services.BadRequest
{
    public class BadRequestService
    {
        public IActionResult CreateBadRequestResponse(string message)
        {
            return new BadRequestObjectResult(new { error = message });
        }
    }
}