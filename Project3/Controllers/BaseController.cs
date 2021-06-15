using Microsoft.AspNetCore.Mvc;
using Project3.Common.Models;
using Project3.Common.Properties;
using Project3.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Project3.Api.Controllers
{

    /// <summary>
    /// Base controler chung 
    /// </summary>
    /// <typeparam name="Entity">Thực thể truyền vào </typeparam>
    /// Created by: TQAnh(16/03/2021)
    [Route("api/v1/[controller]")]
    [ApiController]


    public class BaseController<Entity> : ControllerBase
    {
        #region DECLARE
        /// <summary>
        /// khai báo interface đến service
        /// </summary>
        protected IBaseService<Entity> _baseService;
        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="baseService">interface của service</param>
        public BaseController(IBaseService<Entity> baseService)
        {
            _baseService = baseService;
        }
        #endregion

        #region Method

        /// <summary>
        /// Lấy tất cả dữ liệu của thực thể 
        /// </summary>
        /// <returns> IActionResult  </returns>
        /// Created by: TQAnh(16/03/2021)
        [HttpGet]
        public IActionResult GetData()
        {

            return StatusCode(200, 1);

            //try
            //{
            //    // gọi tới service lấy dữ liệu 
            //    var serviceResult = _baseService.GetData();
            //    var entity = serviceResult.Data as List<Entity>;
            //    if (entity.Count == 0)
            //        return StatusCode(204, serviceResult.Data);
            //    else return StatusCode(200, serviceResult.Data);
            //}
            //catch (Exception ex)
            //{
            //    var serviceResult = new ServiceResult();
            //    var erroMsg = new ErroMsg();
            //    erroMsg.UserMsg.Add(Project3.Common.Properties.Resource.UserMsg_Exception);
            //    erroMsg.DevMsg = ex.ToString();
            //    serviceResult.Data = erroMsg;
            //    return StatusCode(500, serviceResult.Data);
            //}
        }

        /// <summary>
        /// Lấy thực thể phân trang, search 
        /// </summary>
        /// <param name="payload">trường dữ liệu cần check</param>
        /// <returns></returns>
        /// Created by: TQAnh(16/03/2021)
        [HttpPost("paging")]
        public IActionResult GetData([FromBody] Payload payload)
        {

            try
            {
                var serviceResult = _baseService.GetData(payload);
                return StatusCode(200, serviceResult.Data);
            }
            catch (Exception ex)
            {
                var serviceResult = new ServiceResult();
                var erroMsg = new ErroMsg();
                erroMsg.UserMsg.Add(Project3.Common.Properties.Resource.UserMsg_Exception);
                erroMsg.DevMsg = ex.ToString();
                serviceResult.Data = erroMsg;
                return StatusCode(500, serviceResult.Data);
            }
        }

        /// <summary>
        /// Lấy 1 thực thể theo khóa chính
        /// </summary>
        /// <param name="id">Khóa chính thực thể</param>
        /// <returns></returns>
        /// Created by: TQAnh(16/03/2021)
        [HttpGet("{id}")]
        public IActionResult GetbyID(string id)
        {

            try
            {
                var serviceResult = _baseService.GetByID(id);

                return StatusCode(200, serviceResult.Data);
            }
            catch (Exception ex)
            {
                var serviceResult = new ServiceResult();
                var erroMsg = new ErroMsg();
                erroMsg.UserMsg.Add(Project3.Common.Properties.Resource.UserMsg_Exception);
                erroMsg.DevMsg = ex.ToString();
                serviceResult.Data = erroMsg;
                return StatusCode(500, serviceResult.Data);
            }
        }


        /// <summary>
        /// Thêm mới 1 thực thể 
        /// </summary>
        /// <param name="entity"> Thực thể mới </param>
        /// <returns></returns>
        /// Created by: TQAnh(16/03/2021)
        [HttpPost]
        public IActionResult Post(Entity entity)
        {

            try
            {
                var res = _baseService.Insert(entity);
                if (res.Success == false)
                    return StatusCode(400, res.Data);
             
                else return StatusCode(200, res.Data);
            }
            catch (Exception ex)
            {
                var serviceResult = new ServiceResult();
                var erroMsg = new ErroMsg();
                erroMsg.UserMsg.Add(Project3.Common.Properties.Resource.UserMsg_Exception);
                erroMsg.DevMsg = ex.ToString();
                serviceResult.Data = erroMsg;
                return StatusCode(500, serviceResult.Data);
            }
        }

        /// <summary>
        /// Chỉnh sửa một thực thể 
        /// </summary>
        /// <param name="id">khóa chính thực thể </param>
        /// <param name="entity">dữ liệu thực thể </param>
        /// <returns></returns>
        /// Created by: TQAnh(16/03/2021)
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Entity entity)
        {

            try
            {

                var res = _baseService.Update(entity);
                if (res.Success == false)
                    return StatusCode(400, res.Data);

                else return StatusCode(200, res.Data);


            }
            catch (Exception ex)
            {
                var serviceResult = new ServiceResult();
                var erroMsg = new ErroMsg();
                erroMsg.UserMsg.Add(Project3.Common.Properties.Resource.UserMsg_Exception);
                erroMsg.DevMsg = ex.ToString();
                serviceResult.Data = erroMsg;
                return StatusCode(500, serviceResult.Data);
            }
        }


        /// <summary>
        /// Xóa nhiều thực thể 
        /// </summary>
        /// <param name="id">Danh sách khóa chính </param>
        /// <returns></returns>
        /// Created by: TQAnh(16/03/2021)

        [HttpPost("multiple-delete")]
        public IActionResult MultipleDelete([FromBody] String id)
        {

            try
            {

                var res = _baseService.Delete(id);


                if (res.Success == false)
                    return StatusCode(400, res.Data);

                else return StatusCode(200, res.Data);
            }
            catch (Exception ex)
            {
                var serviceResult = new ServiceResult();
                var erroMsg = new ErroMsg();
                erroMsg.UserMsg.Add(Project3.Common.Properties.Resource.UserMsg_Exception);
                erroMsg.DevMsg = ex.ToString();
                serviceResult.Data = erroMsg;

                return StatusCode(500, serviceResult.Data);
            }
        }

        /// <summary>
        /// Xóa một thực thể 
        /// </summary>
        /// <param name="IDs"> khóa chính thực thể </param>
        /// <returns></returns>
        /// Created by: TQAnh(16/03/2021)
        [HttpDelete("{IDs}")]
        public IActionResult Delete(String IDs)
        {
            try
            {

                var res = _baseService.Delete(IDs);


                if (res.Success == false)
                    return StatusCode(400, res.Data);

                else return StatusCode(200, res.Data);
            }
            catch (Exception ex)
            {
                var serviceResult = new ServiceResult();
                var erroMsg = new ErroMsg();
                erroMsg.UserMsg.Add(Project3.Common.Properties.Resource.UserMsg_Exception);
                erroMsg.DevMsg = ex.ToString();
                serviceResult.Data = erroMsg;

                return StatusCode(500, serviceResult.Data);
            }
        }
        #endregion
    }
}
