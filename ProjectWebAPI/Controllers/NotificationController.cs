using Microsoft.AspNetCore.Mvc;
using ProjectLibrary.DataAccess;
using ProjectLibrary.Repository;
using ProjectWebAPI.Application;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private INotificationRepository _reponse = new NotificationRepository();    
        // GET: api/<NotificationController>
        [HttpGet]
        public ActionResult<IEnumerable<Notification>> GetNotifications() => _reponse.GetNotifications();
        
        

        // GET api/<NotificationController>/5
        [HttpGet("{id}")]
        public ActionResult<Notification> GetNotificationById(int id)
        {
            var notification = _reponse.GetNotificationById(id);
            if (notification == null)
            {
                return NotFound();
            }
            return notification;
        }

        // POST api/<NotificationController>
        [HttpPost]
        public IActionResult PostNotification( NotificationDTO nDTO)
        {
            
                var newNotification = new Notification
                {
                    NotificationID = nDTO.NotificationID,
                    Title = nDTO.Title,
                    Content = nDTO.Content,
                    Date = nDTO.Date,
                    UserId = nDTO.UserId,
                };
                _reponse.SaveNotification(newNotification);
            
                 return StatusCode(StatusCodes.Status500InternalServerError, "Error creating employee record");

        }

        // PUT api/<NotificationController>/5
        [HttpPut("{id}")]
        public IActionResult PutNotification(int id, NotificationDTO nDTO)
        {
            var temp = _reponse.GetNotificationById(id);
            if (temp == null)
            {
                return NotFound();
            }
            temp.NotificationID = nDTO.NotificationID;
            temp.Title = nDTO.Title;
            temp.Content = nDTO.Content;
            temp.Date = nDTO.Date;
            temp.UserId = nDTO.UserId;
            _reponse.UpdateNotification(temp);
            return NoContent();

            
        }

        // DELETE api/<NotificationController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id)
        {
            var temp = _reponse.GetNotificationById(id);
            if (temp == null)
            {
                return NotFound();
            }
            _reponse.DeleteNotification(temp);
            return NoContent();
        }
    }
}
