using PatelHiren_Assignment3.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	File Name:         MemberClassAPIController.cs
//  Date:              April 2, 2022
//	Course:            CSCI 3110
//	Author:            Hiren Patel, East Tennessee State University
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
namespace PatelHiren_Assignment3.Controllers
{
    /// <summary>
    /// This is the API class that creates, updates, deletes, and displays 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MemberClassAPIController : ControllerBase
    {
        private readonly IMemberRepository _memberRepo;                 //Private read only Member repository variable
        private readonly IClassRepository _classRepo;                   //Private read only Class repository variable
        private readonly IMemberClassRepository _memberClassRepo;       //Private read only MemberClass repository variable

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="memberRepo"></param>
        /// <param name="classRepo"></param>
        /// <param name="memberClassRepo"></param>
        public MemberClassAPIController(IMemberRepository memberRepo, IClassRepository classRepo, IMemberClassRepository memberClassRepo)
        {
            _memberRepo = memberRepo;
            _classRepo = classRepo;
            _memberClassRepo = memberClassRepo;
        }

        /// <summary>
        /// Creates the API
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="classId"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public IActionResult Post([FromForm] string memberId, [FromForm] int classId)
        {
            var memberClassCompleted = _memberClassRepo.Create(memberId, classId);

            memberClassCompleted?.Member?.ClassCompletion.Clear();
            memberClassCompleted?.Class?.MemberCompletion.Clear();
            return CreatedAtAction("Get", new { id = memberClassCompleted?.Id }, memberClassCompleted);
        }

        /// <summary>
        /// Puts the assigned sessions to the memberId and updates it
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="memberClassId"></param>
        /// <param name="sessions"></param>
        /// <returns></returns>
        [HttpPut("assignsessions")]
        public IActionResult Put( 
            [FromForm] string memberId,  
            [FromForm] int memberClassId,
            [FromForm] string sessions)
        {
            _memberClassRepo.UpdateMemberSessions(memberClassId, sessions);
            return NoContent(); 
        }

        /// <summary>
        /// Deletes the memberId a
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="memberClassId"></param>
        /// <returns></returns>
        [HttpDelete("delete")]
        public IActionResult Delete(
            [FromForm] string memberId,
            [FromForm] int memberClassId)
        {
            _memberClassRepo.Delete(memberId, memberClassId);
            return NoContent(); 
        }

        /// <summary>
        /// Gets the members id, first, and last name for the additional function
        /// </summary>
        /// <returns></returns>
        [HttpGet("membersessionsreport")]
        public IActionResult Get()
        {
            var members = _memberRepo.ReadAll();
            var memberClassSessions = _memberClassRepo.ReadAll();

            var model = from m in members
                        join mcs in memberClassSessions
                            on m.MemberId equals mcs.MemberId
                        orderby m.LastName, m.FirstName
                        select new
                        {
                            MemberName = m.FirstName + " " + m.LastName,
                            ClassName = mcs.Class!.ClassName,
                            mcs.Sessions
                        };

            return Ok(model);
        }
    }
}
