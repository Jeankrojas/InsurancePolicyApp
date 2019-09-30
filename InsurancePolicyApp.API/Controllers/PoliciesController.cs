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
    public class PoliciesController : ControllerBase
    {
        private readonly IPolicyRepository _repo;
        private readonly IMapper _mapper;
        public PoliciesController(IPolicyRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpPost("")]
        public async Task<IActionResult> CreatePolicy(PolicyDto policyForCreateDto)
        {
            var policyToCreate = new Policy();
            _mapper.Map(policyForCreateDto, policyToCreate);
            _repo.Add(policyToCreate);

            if (await _repo.SaveAll()) {
                return Ok();
            }

            throw new Exception($"Creating policy {policyForCreateDto.Name} failed on save");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePolicy(int id, PolicyDto policyForUpdateDto)
        {
            var policyFromRepo = await _repo.GetPolicy(id);
            _mapper.Map(policyForUpdateDto, policyFromRepo);

            if (await _repo.SaveAll()) {
                return Ok();
            }

            throw new Exception($"updating policy {id} failed on save");
        }

        [HttpGet]
        public async Task<IActionResult> GetPolicies()
        {
            var policies = await _repo.GetPolicies();

            var policiesToReturn = _mapper.Map<IEnumerable<PolicyForListDto>>(policies);

            return Ok(policiesToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPolicy(int id)
        {
            var policy = await _repo.GetPolicy(id);

            var policyToReturn = _mapper.Map<PolicyForListDto>(policy);

            return Ok(policyToReturn);
        }

        [HttpPost("assing")]
        public async Task<IActionResult> AssingPolicy(int policyId, int clientId)
        {
            var policyClient = new PolicyClient();
            policyClient.PolicyId = policyId;
            policyClient.ClientId = clientId;
            policyClient.ValidityStarted = DateTime.Now;

            _repo.Add(policyClient);

            if (await _repo.SaveAll()) {
                return Ok();
            }

            throw new Exception($"Assing failed on save");
        }
    }
}