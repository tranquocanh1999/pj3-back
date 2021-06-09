using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.DataLayer.Interfaces
{
    /// <summary>
    /// interface cho base chung database
    /// </summary>
    /// <typeparam name="Entity"></typeparam>
    /// Created by: TQAnh(16/03/2021)
    public interface IDbContext<Entity>
    {

        /// <summary>
        /// lấy tất cả danh sách đối tượng
        /// </summary>
        /// <returns>trả về danh sách đối tượng</returns>
        /// Created by: TQAnh(16/03/2021)
        IEnumerable<Entity> GetAll();

        /// <summary>
        /// lấy tất cả danh sách đối tượng
        /// </summary>
        /// <returns>trả về danh sách đối tượng</returns>
        IEnumerable<Entity> GetAll(string sqlQuery, DynamicParameters Parameters);

        /// <summary>
        /// lấy thực thể theo phân trang 
        /// </summary>
        /// <param name="pageSize">số bản ghi cần lấy</param>
        /// <param name="offset">vị trí bắt đầu lấy</param>
        /// <param name="status">trạng thái</param>
        /// <param name="sqlCondition"> điều kiện</param>
        /// <returns></returns>
        int GetTotalEleMent(string sqlQuery, DynamicParameters Parameters);

        /// <summary>
        /// lấy đối tượng theo id
        /// </summary>
        /// <param name="value">giá trị id</param>

        /// <returns>trả về đối tượng </returns>
        ///  Created by: TQAnh(16/03/2021)
        Entity GetByID(string value);



        /// <summary>
        /// thêm mới đối tượng 
        /// </summary>
        /// <param name="entity">đối tượng cần thêm mới</param>
        /// <returns> trả về số dòng được thay đổi</returns>
        ///   Created by: TQAnh(16/03/2021)
        int Insert(Entity entity);

        /// <summary>
        /// chỉnh sửa 1 đối tượng
        /// </summary>
        /// <param name="id">khóa chính đối tượng được thay đổi </param>
        /// <param name="entity"> đối tượng được thay đổi </param>
        /// <returns> trả về số dòng được thay đổi </returns>
        int Update(Entity entity);

        /// <summary>
        /// Xóa một đối tượng
        /// </summary>
        /// <param name="id"> danh sách  khóa chính đối tượng cần xóa</param>
        /// <returns>trả về số dòng được thay đổi </returns>
        int Delete(string IDs);


        string GetCode();
    }
}
