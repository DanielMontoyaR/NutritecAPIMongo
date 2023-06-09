using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDbAPI.Models;
using MongoDbAPI.Repositories;

namespace MongoDbAPI.Controllers
{
    
    [ApiController]
    [Route("api/")]

    public class MongoFeedbackController : Controller
    {
        private IFeedback db = new FeedbackCollection();

        [HttpGet("all_feedback")]
        public async Task<IActionResult> GetAllFeedback() {

            return Ok(await db.GetAllFeedbacks());
        }

        [HttpPost("feedback_details")]
        public async Task<IActionResult> GetFeedbackDetails(string id)
        {

            return Ok(await db.GetFeedbackById(id));
        }


        [HttpPost("insert_feedback")]
        public async Task<IActionResult> CreateFeedback(MongoFeedback feedback)
        {
            if (feedback == null)
                return BadRequest();

            if (string.IsNullOrEmpty(feedback.client_id))
            {
                ModelState.AddModelError("Name", "The client id shouldn't be empty");
                return BadRequest(ModelState);
            }

            feedback.Id = ObjectId.Empty; // Remove the Id property to generate a new unique _id

            await db.InsertFeedback(feedback);

            return Created("Created", true);
        }

    }
}
