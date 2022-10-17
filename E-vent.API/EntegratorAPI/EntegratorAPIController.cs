using E_vent.Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Serialization;
using System.Xml;
using E_vent.Entities.Concrete;
using System.Text.Encodings.Web;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text.Unicode;
using E_vent.API.Helpers.ViewModel;

namespace E_vent.API.EntegratorAPI
{
	[Route("entegrator/api")]
	[ApiController]
	public class EntegratorAPIController : ControllerBase
	{
        private readonly IEntegratorService _entegratorService;
        private readonly IEventService _eventService;
        private readonly IEventTicketService _eventTicketService;
        public EntegratorAPIController(IEntegratorService entegratorService, IEventService eventService, IEventTicketService eventTicketService)
        {
            _entegratorService = entegratorService;
            _eventService = eventService;
            _eventTicketService = eventTicketService;
        }
        private string GetApiKey(HttpRequest request)
        {
            var headers = request.Headers;
            var token = headers["apikey"];
            return token;
        }
        private Entegrator GetEntegrator(string apiKey)
        {
            return _entegratorService.Get(e => e.IsActive == true && e.SecretKey.Equals(apiKey));
        }
        [HttpGet]
        public string GetAll(string? type)
        {
            string apiKey = GetApiKey(Request);
            var entegrator = GetEntegrator(apiKey);
            if (entegrator == null)
                return "Api-Key is not found";
            List<Event> events = _eventService.GetAll(e => e.IsActive == true && e.WithTicket == true && e.StatusId==2,true);
            var models = events
                .Select(e => new EventViewModel
                {
                    Adress=e.Adress,
                    Name=e.Name,
                    BegginigTime=e.BegginigTime.Value,
                    CategoryName=e.Category.Name,
                    CityName=e.City.Name,
                    Description=e.Description,
                    Id=e.Id,
                    LastAttendance=e.LastAttendance.Value,
                    Price=e.Price.Value,
                    Quato=e.Quato.Value
                }).ToList();
            if(type != null)
            {
                if (type.ToLower().Equals("xml"))
                {
                    XmlSerializer xsSubmit = new XmlSerializer(models.GetType());
                    var xml = "";
                    using (var sww = new StringWriter())
                    {
                        using (XmlWriter writer = XmlWriter.Create(sww))
                        {
                            xsSubmit.Serialize(writer, models);
                            xml = sww.ToString();
                        }
                    }
                    return xml;
                }
                else if (type.ToLower().Equals("json"))
                {
                    var json = "";
                    json = JsonSerializer.Serialize(models,
                     new JsonSerializerOptions
                     {
                         Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                         DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                         WriteIndented = true,
                     });
                    return json;
                }
            }

            return "Please enter valid data type [json/xml]";
        }

        [HttpPost("{eventId}")]
        public IActionResult Add(int eventId)
        {
            string apiKey = GetApiKey(Request);
            var entegrator = GetEntegrator(apiKey);
            if(entegrator is not null)
            {
                var selectedEvent = _eventService.Get(e => e.Id == eventId);
                if(selectedEvent is not null)
                {
                    if (selectedEvent.IsActive == true && selectedEvent.StatusId == 2 && selectedEvent.WithTicket == true)
                    {
                        var entegration = _eventTicketService.Get(e => e.EventId == eventId && e.Id == entegrator.Id);
                        if (entegration is not null)
                            return BadRequest("The event is already entegrated.");
                        var entegrationModel = new EventTicket { EntegratorId = entegrator.Id, EventId = eventId, IsActive = true };
                        _eventTicketService.Add(entegrationModel);
                        return Ok("Entegration is done.");
                    }
                    else
                        return BadRequest("Event is not allowed for entegration.");
                }
                else
                {
                    return BadRequest("Event is not found.");
                }
            }
            return BadRequest("Api key is not found.");
        }
    }
}
