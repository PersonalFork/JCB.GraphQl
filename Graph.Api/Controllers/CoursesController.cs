using Graph.Interfaces.Services;
using Graph.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Graph.Api.Controllers
{
    [ApiController]
    [Route("api/courses")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseManagementService _courseManagementService;
        private readonly ILogger<CoursesController> _logger;

        public CoursesController(ICourseManagementService courseManagementService, ILogger<CoursesController> logger)
        {
            _courseManagementService = courseManagementService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_courseManagementService.GetAll());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Some error occurred.");
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                if (!Guid.TryParse(id, out Guid courseId))
                {
                    return BadRequest("Invalid ID");
                }

                var course = _courseManagementService.GetById(courseId);
                return Ok(course);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Some error occurred.");
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Course course)
        {
            try
            {
                var courseId = _courseManagementService.Add(course);
                return Ok($"Course Created with ID : {courseId}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Some error occurred.");
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] Course course)
        {
            try
            {
                if (course == null || !Guid.TryParse(course.Id, out Guid id))
                {
                    return StatusCode((int)HttpStatusCode.BadRequest, "Missing Course/Id.");
                }

                var success = _courseManagementService.Update(course) > 0;
                return Ok($"Total Records Updated : {success}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Some error occurred.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                if (!Guid.TryParse(id, out Guid courseId))
                {
                    return BadRequest("Invalid ID");
                }

                var totalRecordsDeleted = _courseManagementService.Remove(id);
                return Ok($"Total Records Deleted : {totalRecordsDeleted}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Some error occurred.");
            }
        }
    }
}