using Dapper;
using Project3.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.DataLayer
{
    public class MariaDbContext<Entity> : IDbContext<Entity>
    {

        #region DECLARE

        protected string className = typeof(Entity).Name;
        // khai báo thông tin kết nối 
        String _connectionString = "Host=localhost;" +
        "Database =project3 ;" +
        "Port=3307;User Id=root;" +
        " Password =123456 ;" +
        "Character Set=utf8";

        // khởi tạo kết nối 
        protected IDbConnection _dbConnection;
        #endregion

        #region Constructor
        /// <summary>
        /// hàm khởi tạo 
        /// </summary>
        public MariaDbContext()
        {
            _dbConnection = new MySqlConnector.MySqlConnection(_connectionString);
        }

        #endregion

        #region Method
        /// <summary>
        /// Xóa một đối tượng
        /// </summary>
        /// <param name="id"> danh sách  khóa chính đối tượng cần xóa</param>
        /// <returns>trả về số dòng được thay đổi </returns>
        public virtual int Delete(string IDs)
        {

            var sqlQuery = $" UPDATE {className} e SET e.isDelete = 1 WHERE id IN({IDs});";
            // thực thi truy vấn

            var efectRows = _dbConnection.Execute(sqlQuery, commandType: CommandType.Text);
            return efectRows;
        }

        public IEnumerable<Entity> GetAll(string sqlQuery, DynamicParameters Parameters)
        {


            // thực thi truy vấn
            var entities = _dbConnection.Query<Entity>(sqlQuery, Parameters, commandType: CommandType.Text);

            // trả về cho client
            return entities;
        }

        /// <summary>
        /// lấy tất cả danh sách đối tượng
        /// </summary>
        /// <returns>trả về danh sách đối tượng</returns>
        public IEnumerable<Entity> GetAll()
        {

            var sqlQuery = $"Proc_GetAll{className}";
            // thực thi truy vấn
            var entities = _dbConnection.Query<Entity>(sqlQuery, commandType: CommandType.StoredProcedure);

            // trả về cho client
            return entities;
        }


        /// <summary>
        /// lấy đối tượng theo id
        /// </summary>
        /// <param name="value">giá trị id</param>

        /// <returns>trả về đối tượng </returns>
        public Entity GetByID(string id)
        {

            var sqlQuery = $"Get{className}ByID";
            // thực thi truy vấn
            var entities = _dbConnection.Query<Entity>(sqlQuery, new { ID = id }, commandType: CommandType.StoredProcedure).FirstOrDefault();

            // trả về cho client
            return entities;
        }


        /// <summary>
        /// thêm mới đối tượng 
        /// </summary>
        /// <param name="entity">đối tượng cần thêm mới</param>
        /// <returns> trả về số dòng được thay đổi</returns>
        public int Insert(Entity entity)
        {
            var sqlQuery = $"Insert{className}";
            var res = _dbConnection.Execute(sqlQuery, entity, commandType: CommandType.StoredProcedure);
            return res;
        }


        /// <summary>
        /// chỉnh sửa 1 đối tượng
        /// </summary>
        /// <param name="id">khóa chính đối tượng được thay đổi </param>
        /// <param name="entity"> đối tượng được thay đổi </param>
        /// <returns> trả về số dòng được thay đổi </returns>
        ///   Created by: TQAnh(16/03/2021)
        public int Update(Entity entity)
        {
            var sqlQuery = $"Update{className}";
            var res = _dbConnection.Execute(sqlQuery, entity, commandType: CommandType.StoredProcedure);
            return res;
        }

        /// <summary>
        /// lấy thực thể theo phân trang 
        /// </summary>
        /// <param name="pageSize">số bản ghi cần lấy</param>
        /// <param name="offset">vị trí bắt đầu lấy</param>
        /// <param name="status">trạng thái</param>
        /// <param name="sqlCondition"> điều kiện</param>
        /// <returns></returns>
        /// Created by: TQAnh(16/03/2021)
        public int GetTotalEleMent(string sqlQuery, DynamicParameters Parameters)
        {

            // thực thi truy vấn
            int numberOfRecord = _dbConnection.Query<int>(sqlQuery, Parameters, commandType: CommandType.Text).FirstOrDefault(); ;

            return numberOfRecord;
        }

        public string GetCode()
        {
            var sql = $"SELECT {className}Code FROM {className}  ORDER BY createDate DESC ";
            string entityCode = _dbConnection.Query<string>(sql, commandType: CommandType.Text).FirstOrDefault(); ;

            return entityCode;
        }

        public int ExecuteQuery(string sqlString)
        {

            var efectRows = _dbConnection.Execute(sqlString, commandType: CommandType.Text);
            return efectRows;
        }

        public IEnumerable<Entity> GetByIDs(string IDs)
        {
            var sqlQuery = $"SELECT * FROM {className} e WHERE e.id IN({IDs});";
            // thực thi truy vấn

            var entities = _dbConnection.Query<Entity>(sqlQuery, commandType: CommandType.Text);

            // trả về cho client
            return entities;
        }


        #endregion
    }
}
