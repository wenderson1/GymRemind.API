using GymRemid.API.Connection;
using GymRemid.API.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

using MongoDB.Driver;

namespace GymRemind.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RemindController : ControllerBase
    {
        IMongoCollection<InputRemind> _remind;

        public RemindController(MongoConnection mongo)
        {
            _remind = mongo.DB.GetCollection<InputRemind>("reminds");
        }

        [HttpGet]
        public IActionResult Get()
        {
            var reminds = _remind.AsQueryable().ToList();
            return Ok(reminds);
        }

        [HttpPost]
        public IActionResult Post(InputRemind remind)
        {
            _remind.InsertOne(remind);
            return Ok();
        }

        [HttpPut("{exercise}")]
        public IActionResult Put(string exercise, InputRemind remind)
        {
            var update = _remind.FindOneAndReplaceAsync(x => x.Exercise == exercise, remind);
            if (update == null)
                return NotFound($"Unable to found {exercise}.");
            return Ok(remind);
        }

        [HttpDelete("{exercise}")]
        public IActionResult Delete(string exercise)
        {
            var delete = _remind.DeleteOne(x => x.Exercise == exercise);

            if(delete.DeletedCount <= 0)
                return NotFound($"Unable to found {exercise}.");

            return Ok();
        }
    }
}
