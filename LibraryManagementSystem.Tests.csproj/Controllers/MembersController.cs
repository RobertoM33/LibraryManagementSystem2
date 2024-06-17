using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    
        [ApiController]
        [Route("api/[controller]")]
        public class MembersController : ControllerBase
        {
            private readonly IMemberService _memberService;

            public MembersController(IMemberService memberService)
            {
                _memberService = memberService;
            }

            [HttpPost]
            public async Task<IActionResult> AddMember([FromBody] Member member)
            {
                try
                {
                    await _memberService.AddMemberAsync(member);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetMemberById(int id)
            {
                var member = await _memberService.GetMemberByIdAsync(id);
                if (member == null)
                {
                    return NotFound();
                }
                return Ok(member);
            }

            [HttpGet]
            public async Task<IActionResult> GetAllMembers()
            {
                var members = await _memberService.GetAllMembersAsync();
                return Ok(members);
            }

            [HttpPut]
            public async Task<IActionResult> UpdateMember([FromBody] Member member)
            {
                try
                {
                   await _memberService.UpdateMemberAsync(member);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteMember(int id)
            {
                try
                {
                    await _memberService.DeleteMemberAsync(id);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
        }
    }

