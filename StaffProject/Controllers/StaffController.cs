using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StaffProject.Data.Domain;
using StaffProject.Data.Repositories;
using StaffProject.Schema;
using StaffProject.Service.Validators;

namespace StaffProject.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private IStaffRepository repository;
        private IMapper mapper;
        private IValidator<StaffRequest> validator;

        public StaffController(IStaffRepository repository, IMapper mapper,IValidator<StaffRequest> validator)
        {
            this.validator = validator;
            this.repository = repository;
            this.mapper = mapper;
        }


        [HttpGet]
        public List<StaffResponse> GetAll()
        {

            var list = repository.GetAll();
            var mapped = mapper.Map<List<StaffResponse>>(list);
            return mapped;
        }

        [HttpGet("{id}")]
        public StaffResponse GetById(int id)
        {

            var row = repository.GetById(id);
            var mapped = mapper.Map<StaffResponse>(row);
            return mapped;
        }

        [HttpGet("filterByFirstNameAndCity")]
        public IActionResult GetFilteredStaff(string firstName, string city)
        {
            var staffResult = repository.GetFilteredStaff(firstName, city);
            return Ok(staffResult);
        }



        [HttpPost]
        public IActionResult Post([FromBody] StaffRequest request)
        {
            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var existingStaff = repository.ControlUniqueEmail(request.Email);
            if (existingStaff != true)
            {
                return BadRequest("Email is already in use.");
            }


            var entity = mapper.Map<Staff>(request);
            repository.Insert(entity);
            repository.Complete();
            return Ok();
            
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] StaffRequest request)
        {
            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var existingStaff = repository.ControlUniqueEmail(request.Email);
            if (existingStaff != true)
            {
                return BadRequest("Email is already in use.");
            }

            var entity = mapper.Map<Staff>(request);
            entity.Id = id;
            repository.Update(entity);
            repository.Complete();
            return Ok();
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repository.DeleteById(id);
            repository.Complete();
        }
    }
}
