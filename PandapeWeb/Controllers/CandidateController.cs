using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Pandape.Application;
using Pandape.Domain.Dto;
using PandapeWeb.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PandapeWeb.Controllers
{
    public class CandidateController : Controller
    {
        public ICandidateManager _candidateManager;

        public CandidateController(ICandidateManager candidateManager) 
        {
            _candidateManager = candidateManager; 
        }

        public IActionResult Index()
        {
            var canidates = _candidateManager.GetCandidates().Select(x =>
            {
                return new CandidateViewModel
                {
                    IdCandidate = x.IdCandidate,
                    Name = x.Name,
                    Surname = x.Surname,
                    Birthdate = x.Birthdate,
                    Email = x.Email,
                };
            });
            return View(canidates);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateCanditeViewModel create)
        {
            if (ModelState.IsValid)
            {
                var newCandidate = new CreateCandidateVO
                {
                    Name = create.Name,
                    Surname = create.Surname,
                    Birthdate = create.Birthdate,
                    Email = create.Email,
                };
                _candidateManager.CreateCandidate(newCandidate);
                return RedirectToAction(nameof(Index));
            }
            return View(create);
        }

        [HttpGet]
        public IActionResult Update(int idCandidate)
        {
            var candidate = _candidateManager.GetCandidateById(idCandidate);
            return View(new UpdateCandidateViewModel 
            {
                IdCandidate = candidate.IdCandidate,
                Email = candidate.Email,
                Birthdate = candidate.Birthdate,
            });
        }

        [HttpPost]
        public IActionResult Update(UpdateCandidateViewModel update)
        {
            if (ModelState.IsValid)
            {
                var updateCandidate = new UpdateCandidateVO
                {
                    Birthdate = update.Birthdate,
                    Email = update.Email,
                };
                _candidateManager.UpdateCandidate(update.IdCandidate, updateCandidate);
                return RedirectToAction(nameof(Index));
            }
            return View(update);
        }

        [HttpDelete]
        public IActionResult Delete(int idCandidate)
        {
            _candidateManager.DeleteCandidate(idCandidate);
            return RedirectToAction(nameof(Index));
        }

        
        
        public IActionResult ExperiencesByCandidate(int idCandidate) 
        {
            var experience = _candidateManager.GetExpereincesByCandidate(idCandidate);
            return View(new CandidateExperienceViewModel
            {
                FullName = experience.FullName,
                IdCandidate = experience.IdCandidate,
                Experiences = !experience.Experiences.IsNullOrEmpty() ? experience.Experiences
                    .Select(x =>
                    {
                        return new ExperienceViewModel
                        {
                            Company = x.Company,
                            BeginDate = x.BeginDate,
                            Description = x.Description,
                            EndDate = x.EndDate,
                            IdCandidateExperience = x.IdCandidateExperience,
                            Job = x.Job,
                            Salary = x.Salary,
                        };
                    }) : Array.Empty<ExperienceViewModel>()
            });
        }
    }
}
