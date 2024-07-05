using Microsoft.AspNetCore.Mvc;
using Pandape.Application;
using Pandape.Domain.Dto;
using PandapeWeb.Models;

namespace PandapeWeb.Controllers
{
    public class ExperienceController : Controller
    {
        private readonly IExperiencesManager _experiencesManager;

        public ExperienceController(IExperiencesManager experiencesManager) 
        {
            _experiencesManager = experiencesManager;
        }

        [HttpGet]
        public IActionResult Create(int IdCandidate)
        {
            var newExperience = new CreateExperienceViewModel
            {
                IdCandidate = IdCandidate
            };
            return View(newExperience);
        }

        [HttpPost]
        public IActionResult Create(CreateExperienceViewModel createExperience)
        {
            /*if (ModelState.IsValid)
            {
                var newExperience = new CreateCandidateExperienceVO
                {
                    Company = createExperience.Company,
                    Job = createExperience.Job,
                    BeginDate = DateTime.Now,
                    Description = createExperience.Description,
                    EndDate = DateTime.Now,
                    Salary = createExperience.Salary,
                };
                _experiencesManager.CreateExperience(createExperience.IdCandidate, newExperience);*/
                return RedirectToAction("ExperiencesByCandidate", "Candidate", new { idCandidate = createExperience.IdCandidate });
            //}
            //return View(createExperience);
        }

        [HttpGet]
        public IActionResult Update(int idCandidate)
        {
            var experience = _experiencesManager.GetExperienceById(idCandidate);
            return View(new UpdateExperienceViewModel
            {
                IdExperience = experience.IdCandidateExperience,
                IdCandidate = experience.IdCandidate,
                Description = experience.Description,
                Salary = experience.Salary,
                BeginDate = experience.BeginDate,
                EndDate = experience.EndDate,
            });
        }

        [HttpPost]
        public IActionResult Update(int idCanidate, UpdateExperienceViewModel updateExperience)
        {
            if (ModelState.IsValid)
            {
                var experience = new UpdateCandidateExperienceVO
                {
                    BeginDate = DateTime.Now,
                    Description = updateExperience.Description,
                    EndDate = DateTime.Now,
                    Salary = updateExperience.Salary,
                };
                _experiencesManager.UpdateExperience(idCanidate, updateExperience.IdExperience, experience);
                return RedirectToAction("Candidate", "ExperiencesByCandidate", new { idCandidate = idCanidate });
            }
            return View(updateExperience);
        }

        [HttpDelete]
        public IActionResult Delete(int idCandidate, int idExperience)
        {
            _experiencesManager.DeleteExperience(idExperience);
            return RedirectToAction("ExperiencesByCandidate", "Candidate", new { idCandidate = idCandidate });
        }
    }
}
