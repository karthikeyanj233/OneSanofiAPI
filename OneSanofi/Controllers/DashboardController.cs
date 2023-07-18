using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Model;
using ServiceLayer.IDashboardServices;
using ServiceLayer.Model;

namespace OneSanofi.Controllers
{
    [Authorize(Roles = "CustomRole")]
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly ILogger<DashboardController> _logger;
        private readonly IDashboardService<DashboardBoxModel> _dashboardboxService;
        private readonly IDashboardService<DashboardModel> _dashboardService;
        private readonly IDashboardService<DashboardDetailModel> _dashboarddetailsService;
        private readonly IDashboardHeaderService<DashboardHeader> _dashboardheadrService;
        public DashboardController(ILogger<DashboardController> logger, IDashboardService<DashboardBoxModel> dashboardboxService,
            IDashboardService<DashboardModel> dashboardService, IDashboardService<DashboardDetailModel> dashboarddetailsService, IDashboardHeaderService<DashboardHeader> dashboardheadrService)
        {
            _logger = logger;
            _dashboardboxService = dashboardboxService;
            _dashboardService = dashboardService;
            _dashboarddetailsService = dashboarddetailsService;
            _dashboardheadrService = dashboardheadrService;
        }
        [AllowAnonymous]
        [HttpGet(nameof(GetDashboard))]
        public IActionResult GetDashboard()
        {
            try
            {
                var obj = _dashboardheadrService.GetAllDashboard();
                if (obj == null)
                {
                    _logger.LogWarning("Record not found");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation("Successfullly got DashboardBoxes list");
                    return Ok(obj);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("GetDashboardBoxesById error: " + ex.Message);
                throw ex;
            }

        }

        #region DashboardBoxes
        [HttpGet(nameof(GetDashboardBoxesById))]
        public IActionResult GetDashboardBoxesById(int Id)
        {
            try
            {
                var obj = _dashboardboxService.Get(Id);
                if (obj == null)
                {
                    _logger.LogWarning("Record not found");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation("Successfullly got DashboardBoxes list");
                    return Ok(obj);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("GetDashboardBoxesById error: " + ex.Message);
                throw ex;
            }

        }

        [HttpGet(nameof(GetAllDashboardBoxes))]
        public IActionResult GetAllDashboardBoxes()
        {
            try
            {
                var obj = _dashboardboxService.GetAll();
                if (obj == null)
                {
                    _logger.LogWarning("Record not found");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation("GetAllDashboardBoxes Information");
                    return Ok(obj);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("GetAllDashboardBoxes error: " + ex.Message);
                throw ex;
            }

        }

        [HttpPost(nameof(CreateDashboardBoxes))]
        public IActionResult CreateDashboardBoxes(DashboardBoxModel dashboardboxes)
        {
            try
            {
                if (dashboardboxes != null)
                {
                    _dashboardboxService.Insert(dashboardboxes);
                    _logger.LogInformation("Created Successfully");
                    return Ok("Created Successfully");
                }
                else
                {
                    _logger.LogWarning("Somethingwent wrong");
                    return BadRequest("Somethingwent wrong");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("CreateUser error: " + ex.Message);
                throw ex;
            }

        }

        [HttpPost(nameof(UpdateDashboardBoxes))]
        public IActionResult UpdateDashboardBoxes(DashboardBoxModel dashboardboxes)
        {
            try
            {
                if (dashboardboxes != null)
                {
                    _dashboardboxService.Update(dashboardboxes);
                    _logger.LogInformation("Updated Successfully");
                    return Ok("Updated SuccessFully");
                }
                else
                {
                    _logger.LogWarning("Somethingwent wrong");
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("UpdateDashboardBoxes error: " + ex.Message);
                throw ex;
            }


        }

        [HttpDelete(nameof(DeleteDashboardBoxes))]
        public IActionResult DeleteDashboardBoxes(DashboardBoxModel dashboardboxes)
        {
            try
            {
                if (dashboardboxes != null)
                {
                    _dashboardboxService.Delete(dashboardboxes);
                    _logger.LogInformation("Deleted Successfully");
                    return Ok("Deleted Successfully");
                }
                else
                {
                    _logger.LogWarning("DeleteUser Something went wrong");
                    return BadRequest("Something went wrong");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("DeleteUser error: " + ex.Message);
                throw ex;
            }

        }
        #endregion
        #region Dashboard
        [HttpGet(nameof(GetDashboardById))]
        public IActionResult GetDashboardById(int Id)
        {
            try
            {
                var obj = _dashboardService.Get(Id);
                if (obj == null)
                {
                    _logger.LogWarning("Record not found");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation("Successfullly got Dashboard list");
                    return Ok(obj);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("GetDashboardById error: " + ex.Message);
                throw ex;
            }

        }

        [HttpGet(nameof(GetAllDashboard))]
        public IActionResult GetAllDashboard()
        {
            try
            {
                var obj = _dashboardService.GetAll();
                if (obj == null)
                {
                    _logger.LogWarning("Record not found");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation("GetAllDashboard Information");
                    return Ok(obj);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("GetAllDashboard error: " + ex.Message);
                throw ex;
            }

        }

        [HttpPost(nameof(CreateDashboard))]
        public IActionResult CreateDashboard(DashboardModel dashboard)
        {
            try
            {
                if (dashboard != null)
                {
                    _dashboardService.Insert(dashboard);
                    _logger.LogInformation("Created Successfully");
                    return Ok("Created Successfully");
                }
                else
                {
                    _logger.LogWarning("Somethingwent wrong");
                    return BadRequest("Somethingwent wrong");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("CreateDashboard error: " + ex.Message);
                throw ex;
            }

        }

        [HttpPost(nameof(UpdateDashboard))]
        public IActionResult UpdateDashboard(DashboardModel dashboard)
        {
            try
            {
                if (dashboard != null)
                {
                    _dashboardService.Update(dashboard);
                    _logger.LogInformation("Updated Successfully");
                    return Ok("Updated SuccessFully");
                }
                else
                {
                    _logger.LogWarning("Somethingwent wrong");
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("UpdateDashboard error: " + ex.Message);
                throw ex;
            }


        }

        [HttpDelete(nameof(DeleteDashboard))]
        public IActionResult DeleteDashboard(DashboardModel dashboard)
        {
            try
            {
                if (dashboard != null)
                {
                    _dashboardService.Delete(dashboard);
                    _logger.LogInformation("Deleted Successfully");
                    return Ok("Deleted Successfully");
                }
                else
                {
                    _logger.LogWarning("DeleteDashboard Something went wrong");
                    return BadRequest("Something went wrong");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("DeleteDashboard error: " + ex.Message);
                throw ex;
            }

        }
        #endregion
        #region DashboardDetails
        [HttpGet(nameof(GetDashboardDetailsById))]
        public IActionResult GetDashboardDetailsById(int Id)
        {
            try
            {
                var obj = _dashboarddetailsService.Get(Id);
                if (obj == null)
                {
                    _logger.LogWarning("Record not found");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation("Successfullly got DashboardDetails list");
                    return Ok(obj);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("GetDashboardDetailsById error: " + ex.Message);
                throw ex;
            }

        }

        [HttpGet(nameof(GetAllDashboardDetails))]
        public IActionResult GetAllDashboardDetails()
        {
            try
            {
                var obj = _dashboarddetailsService.GetAll();
                if (obj == null)
                {
                    _logger.LogWarning("Record not found");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation("GetAllDashboardDetails Information");
                    return Ok(obj);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("GetAllDashboardDetails error: " + ex.Message);
                throw ex;
            }

        }

        [HttpPost(nameof(CreateDashboardDetails))]
        public IActionResult CreateDashboardDetails(DashboardDetailModel dashboarddetails)
        {
            try
            {
                if (dashboarddetails != null)
                {
                    _dashboarddetailsService.Insert(dashboarddetails);
                    _logger.LogInformation("Created Successfully");
                    return Ok("Created Successfully");
                }
                else
                {
                    _logger.LogWarning("Somethingwent wrong");
                    return BadRequest("Somethingwent wrong");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("CreateDashboardDetails error: " + ex.Message);
                throw ex;
            }

        }

        [HttpPost(nameof(UpdateDashboardDetails))]
        public IActionResult UpdateDashboardDetails(DashboardDetailModel dashboarddetails)
        {
            try
            {
                if (dashboarddetails != null)
                {
                    _dashboarddetailsService.Update(dashboarddetails);
                    _logger.LogInformation("Updated Successfully");
                    return Ok("Updated SuccessFully");
                }
                else
                {
                    _logger.LogWarning("Somethingwent wrong");
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("UpdateDashboardBoxes error: " + ex.Message);
                throw ex;
            }


        }

        [HttpDelete(nameof(DeleteDashboardDetails))]
        public IActionResult DeleteDashboardDetails(DashboardDetailModel dashboarddetails)
        {
            try
            {
                if (dashboarddetails != null)
                {
                    _dashboarddetailsService.Delete(dashboarddetails);
                    _logger.LogInformation("Deleted Successfully");
                    return Ok("Deleted Successfully");
                }
                else
                {
                    _logger.LogWarning("DeleteDashboardBoxes Something went wrong");
                    return BadRequest("Something went wrong");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("DeleteUser error: " + ex.Message);
                throw ex;
            }

        }
        #endregion
    }
}
