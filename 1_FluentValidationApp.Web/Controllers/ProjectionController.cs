using _1_FluentValidationApp.Web.DTOs;
using _1_FluentValidationApp.Web.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace _1_FluentValidationApp.Web.Controllers
{
    public class ProjectionController : Controller
    {
        private readonly IMapper _mapper;
        public ProjectionController(IMapper mapper)
        {
           _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(EventDateDTO eventDateDTO)
        {
            EventDate eventDate = _mapper.Map<EventDate>(eventDateDTO);

            ViewBag.date = eventDate.Date.ToShortDateString();

            return View();
        }
    }
}
