using Microsoft.AspNetCore.Mvc;
using PatelHiren_Assignment3.Models.ViewModels;
using PatelHiren_Assignment3.Services;
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	File Name:         MemberClassController.cs
//  Date:              March 31, 2022
//	Course:            CSCI 3110
//	Author:            Hiren Patel, East Tennessee State University
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
namespace PatelHiren_Assignment3.Controllers
{
    /// <summary>
    /// This class is the member class controller that executes all the actions required
    /// </summary>
    public class MemberClassController : Controller
    {
        private readonly IMemberRepository _memberRepo;                 //Private read only Member repository variable
        private readonly IClassRepository _classRepo;                   //Private read only Class repository variable
        private readonly IMemberClassRepository _memberClassRepo;       //Private read only MemberClass repository variable

        /// <summary>
        /// Parameterized contructor for MemberClassController
        /// </summary>
        /// <param name="memberRepo"></param>
        /// <param name="classRepo"></param>
        /// <param name="memberClassRepo"></param>
        public MemberClassController( IMemberRepository memberRepo, IClassRepository classRepo, IMemberClassRepository memberClassRepo)
        {
            _memberRepo = memberRepo;
            _classRepo = classRepo;
            _memberClassRepo = memberClassRepo;
        }

        /// <summary>
        /// View Index
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// This action demonstrates the create action
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="classId"></param>
        /// <returns></returns>
        public IActionResult Create([Bind(Prefix = "id")] string memberId, int classId)
        {
            var member = _memberRepo.Read(memberId);
            if (member == null)
            {
                return RedirectToAction("Index", "Member");
            }
            var @class = _classRepo.Read(classId);
            if (@class == null)
            {
                return RedirectToAction("Details", "Member", new { id = memberId });
            }
            var memberClass = member.ClassCompletion
                .SingleOrDefault(scg => scg.ClassId == classId);
            if (memberClass != null)
            {
                return RedirectToAction("Details", "Member", new { id = memberId });
            }
            var memberClassVM = new MemberClassVM
            {
                Member = member,
                GymClass = @class
            };
            return View(memberClassVM);
        }

        [HttpPost, ValidateAntiForgeryToken, ActionName("Create")]
        public IActionResult CreateConfirmed(string memberId, int classId)
        {
            _memberClassRepo.Create(memberId, classId);
            return RedirectToAction("Details", "Member", new { id = memberId });
        }

        /// <summary>
        /// This action demonstrates the update action
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="classId"></param>
        /// <returns></returns>
        public IActionResult AssignSessions([Bind(Prefix = "id")] string memberId, int classId)
        {
            var member = _memberRepo.Read(memberId);
            if (member == null)
            {
                return RedirectToAction("Index", "Member");
            }
            var memberClass = member.ClassCompletion
                .FirstOrDefault(scg => scg.ClassId == classId);
            if (memberClass == null)
            {
                return RedirectToAction("Details", "Member", new { id = memberId });
            }
            return View(memberClass);
        }

        [HttpPost, ValidateAntiForgeryToken, ActionName("AssignSessions")]
        public IActionResult AssignSessionsConfirmed( string memberId, int memberClassId, string sessions)
        {
            _memberClassRepo.UpdateMemberSessions(memberClassId, sessions);
            return RedirectToAction("Details", "Member", new { id = memberId });
        }

        /// <summary>
        /// This action demonstrates the delete action
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="classId"></param>
        /// <returns></returns>
        public IActionResult Delete([Bind(Prefix = "id")] string memberId, int classId)
        {
            var member = _memberRepo.Read(memberId);
            if (member == null)
            {
                return RedirectToAction("Index", "Member");
            }
            var memberClass = member.ClassCompletion
                .FirstOrDefault(scg => scg.ClassId == classId);
            if (memberClass == null)
            {
                return RedirectToAction("Details", "Member", new { id = memberId });
            }
            return View(memberClass);
        }

        [HttpPost, ValidateAntiForgeryToken, ActionName("Delete")]
        public IActionResult DeleteConfirmed(string memberId, int memberClassId)
        {
            _memberClassRepo.Delete(memberId, memberClassId);
            return RedirectToAction("Details", "Member", new { id = memberId });
        }

        /// <summary>
        /// This action demonstrates the additional action 
        /// </summary>
        /// <returns></returns>
        public IActionResult MemberSessionsPerClass()
        {
            ViewData["Message"] = "Members sessions signed up for per class";
            var classes = _classRepo.ReadAll();
            var memberClassCompletions = _memberClassRepo.ReadAll();
            var query =
            from c in classes
            join scg in memberClassCompletions
            on new { c.ClassName }
            equals new { scg.Class!.ClassName}
            into scSessions
            select new ClassGroupVM
            {
                ClassName = c.ClassName,
                MemberClassCompletions = scSessions
            };
            var model = query.ToList();
            return View(model);
        }

    }

}
