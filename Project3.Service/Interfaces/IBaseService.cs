using Project3.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.Service.Interfaces
{
    /// <summary>
    /// giao diện cho service chung 
    /// </summary>
    /// <typeparam name="Entity"></typeparam>
    public interface IBaseService<Entity>
    {

        /// <summary>
        /// lấy danh sách 
        /// </summary>
        /// <returns> trả về một ServiceResult  </returns>
        ServiceResult GetData(Payload payload);


        /// <summary>
        /// lấy danh sách 
        /// </summary>
        /// <returns> trả về một ServiceResult  </returns>
        ServiceResult GetData();

        /// <summary>
        /// lấy dữ liệu theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ServiceResult GetByID(string id);


        /// <summary>
        /// thêm mới một bản ghi 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ServiceResult Insert(Entity entity);

        /// <summary>
        /// Chỉnh sửa một bản ghi 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns
        ServiceResult Update(Entity entity);

        /// <summary>
        /// xóa đối tượng
        /// </summary>
        /// <param name="id">khóa chính đối tượng cần xóa</param>
        ServiceResult Delete(String IDs);

        /// <summary>
        /// lấy dữ liệu theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ServiceResult GetByIDs(string IDs);
    }
}
