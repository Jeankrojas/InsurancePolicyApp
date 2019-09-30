using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using InsurancePolicyApp.API.Data;
using InsurancePolicyApp.API.Dtos;
using InsurancePolicyApp.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InsurancePolicyApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyEventTypesController : ControllerBase
    {
        private readonly IPolicyEventTypeRepository _repo;
        private readonly IMapper _mapper;
        public PolicyEventTypesController(IPolicyEventTypeRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpPost("")]
        public async Task<IActionResult> CreatePolicyEventType(PolicyEventType policyEventTypeForCreate)
        {
            //Verify rule Percent-Risk
            if (!await _repo.VerifyRisk(policyEventTypeForCreate.RiskTypeId, policyEventTypeForCreate.Percent)) {
                return BadRequest("The percentage can't be greater than fifty if the risk is high");
            }
            _repo.Add(policyEventTypeForCreate);

            if (await _repo.SaveAll()) {
                return Ok();
            }

            throw new Exception($"Creating event type failed on save");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePolicyEventType(int id, PolicyEventTypeForUpdateDto policyEventTypeForUpdateDto)
        {
            if (!await _repo.VerifyRisk(policyEventTypeForUpdateDto.RiskTypeId, policyEventTypeForUpdateDto.Percent)) {
                return BadRequest("The percentage can't be greater than fifty if the risk is high");
            }
            
            var policyEventTypeFromRepo = await _repo.GetPolicyEventType(id);
            _mapper.Map(policyEventTypeForUpdateDto, policyEventTypeFromRepo);

            if (await _repo.SaveAll()) {
                return Ok();
            }

            throw new Exception($"updating policy {id} failed on save");
        }

        //Get all the policy event types
        [HttpGet]
        public async Task<IActionResult> GetPolicyEventTypes()
        {
            var policyEventTypes = await _repo.GetPolicyEventTypes();

            var policiesToReturn = _mapper.Map<IEnumerable<PolicyEventTypeForDetailedDto>>(policyEventTypes);

            return Ok(policiesToReturn);
        }

        //Get a list of policy event types by policy ID
        [HttpGet("policy/{policyId}")]
        public async Task<IActionResult> GetPolicyEventTypes(int policyId)
        {
            var policyEventTypes = await _repo.GetPolicyEventTypes(policyId);

            var policyToReturn =  _mapper.Map<IEnumerable<PolicyEventTypeForDetailedDto>>(policyEventTypes);

            return Ok(policyToReturn);
        }

        //Get an especific policy event type by ID        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPolicyEventType(int id)
        {
            var policyEventType = await _repo.GetPolicyEventType(id);

            var policyToReturn =  _mapper.Map<PolicyEventTypeForDetailedDto>(policyEventType);

            return Ok(policyToReturn);
        }
    }
}