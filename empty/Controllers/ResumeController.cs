using Microsoft.AspNetCore.Mvc;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using empty.Models;

namespace empty.Controllers
{
    public class ResumeController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public ResumeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
                
        public IActionResult Details(Guid? id)
        {
            return View(Map(_unitOfWork.Resume.Get(id)));
        }

        private ResumeViewModel Map(Resume resume)
        {
            return new ResumeViewModel
            {
                Id = resume.Id,
                Biography = resume.Biography,
                Positions = resume.Positions.Select(p => Map(p)).ToList()
            };
        }

        private ResumePositionViewModel Map(ResumePosition position)
        {
            return new ResumePositionViewModel
            {
                Id = position.Id,
                DateRange = position.DateRange,
                Description = position.Description
            };
        }        
    }
}
