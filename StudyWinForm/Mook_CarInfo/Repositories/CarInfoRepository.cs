using Libs;
using Model;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
  
namespace Repositories
{
    public class CarInfoRepository : ClassForDBInstance, ICarInfoRepository
    {
        private SqlConnection Conn;

        public CarInfoRepository()
        {
            Conn = (SqlConnection)configurationMgr.Connection;
        }

        // 차량정보 신규등록
        int ICarInfoRepository.Add(CarInfoModel model, IDbConnection connection)
        {
            try
            {
                Conn.Open();

                string Sql = "insert into TB_CAR_INFO(carName, carYear, carPrice, carDoor) "
                                + "values( @carName, @carYear, @carPrice, @carDoor )";
                var Comm = new SqlCommand(Sql, Conn);
                Comm.Parameters.Add("@carName", SqlDbType.NVarChar, 30);
                Comm.Parameters.Add("@carYear", SqlDbType.VarChar, 4);
                Comm.Parameters.Add("@carPrice", SqlDbType.Int);
                Comm.Parameters.Add("@carDoor", SqlDbType.Int);

                Comm.Parameters["@carName"].Value = model.carName;
                Comm.Parameters["@carYear"].Value = model.carYear;
                Comm.Parameters["@carPrice"].Value = Convert.ToInt32(model.carPrice);
                Comm.Parameters["@carDoor"].Value = Convert.ToInt32(model.carDoor);

                // 등록 후 영향 받은 row 수를 화면단으로 반환.
                int i = Comm.ExecuteNonQuery();
                Conn.Close();

                return i;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // 차량정보 삭제
        int ICarInfoRepository.Delete(int carNo, IDbConnection connection)
        {
            try
            {
                Conn.Open();

                string Sql = "delete from TB_CAR_INFO "
                    + "where id = @id ";

                var Comm = new SqlCommand(Sql, Conn);

                Comm.Parameters.Add("@id", SqlDbType.Int);

                Comm.Parameters["@id"].Value = carNo;

                // 삭제 후 영향 받은 row 수를 화면단으로 반환.
                int i = Comm.ExecuteNonQuery();

                Conn.Close();

                return i;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // 차량정보 전체조회
        ArrayList ICarInfoRepository.GetAllCarInfo(IDbConnection connection)
        {
            try
            {
                Conn.Open();

                var Comm = new SqlCommand("Select * From TB_CAR_INFO", Conn);
                var myRead = Comm.ExecuteReader(CommandBehavior.CloseConnection);

                // 조회된 결과를 컬렉션 형태로 저장 후 반환하면,
                // 화면단의 리스트 뷰의 뷰 아이템으로 초기화하기 편리함.
                ArrayList list = new ArrayList();

                while(myRead.Read())
                {
                    // GetCarInfoModel() 을 사용하면, 조회된 결과의 각 row를 string[] 로 변환할 수 있어,
                    // 화면단에서 조회된 결과를 리스트 뷰에 출력하기가 편리해짐.
                    list.Add(GetCarInfoModel(myRead).ToStringList());
                }
                myRead.Close();

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // 차량정보 전체조회 후 화면단에 조회된 결과를 Model 형태로 반환하기 위함.
        private CarInfoModel GetCarInfoModel(SqlDataReader myRead)
        {
            CarInfoModel model = new CarInfoModel();

            model.id = myRead["id"].ToString();
            model.carName = myRead["carName"].ToString();
            model.carYear = myRead["carYear"].ToString();
            model.carPrice = myRead["carPrice"].ToString();
            model.carDoor = myRead["carDoor"].ToString();

            return model;
        }

        // 차량정보 조건검색
        ArrayList ICarInfoRepository.GetCarInfoByCondition(CarInfoModel model, IDbConnection connection)
        {
            try
            {
                Conn.Open();

                string Sql = "Select * From TB_CAR_INFO "
                            + "where carName = @carName or carYear = @carYear "
                            + "or carPrice = @carPrice or carDoor = @carDoor ";

                var Comm = new SqlCommand(Sql, Conn);

                Comm.Parameters.Add("@carName", SqlDbType.NVarChar, 30);
                Comm.Parameters.Add("@carYear", SqlDbType.VarChar, 4);
                Comm.Parameters.Add("@carPrice", SqlDbType.Int);
                Comm.Parameters.Add("@carDoor", SqlDbType.Int);

                Comm.Parameters["@carName"].Value = model.carName;
                Comm.Parameters["@carYear"].Value = model.carYear;
                Comm.Parameters["@carPrice"].Value =
                    Convert.ToInt32((model.carPrice == "") ? 0 : Convert.ToInt32(model.carPrice));
                Comm.Parameters["@carDoor"].Value =
                    Convert.ToInt32((model.carDoor == "") ? 0 : Convert.ToInt32(model.carDoor));

                var myRead = Comm.ExecuteReader(CommandBehavior.CloseConnection);

                // 조회된 결과를 컬렉션 형태로 저장 후 반환하면,
                // 화면단의 리스트 뷰의 뷰 아이템으로 초기화하기 편리함.
                ArrayList list = new ArrayList();

                while (myRead.Read())
                {
                    // GetCarInfoModel() 을 사용하면, 조회된 결과의 각 row를 string[] 로 변환할 수 있어,
                    // 화면단에서 조회된 결과를 리스트 뷰에 출력하기가 편리해짐.
                    list.Add(GetCarInfoModel(myRead).ToStringList());
                }
                myRead.Close();

                return list;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // 차량정보 수정
        int ICarInfoRepository.Update(CarInfoModel model, IDbConnection connection)
        {
            try
            {
                Conn.Open();

                string Sql = "update TB_CAR_INFO "
                        + "set carName = @carName, carYear = @carYear, "
                        + "carPrice = @carPrice, carDoor = @carDoor "
                        + "where id = @id ";

                var Comm = new SqlCommand(Sql, Conn);
                Comm.Parameters.Add("@id", SqlDbType.Int);
                Comm.Parameters.Add("@carName", SqlDbType.NVarChar, 30);
                Comm.Parameters.Add("@carYear", SqlDbType.VarChar, 4);
                Comm.Parameters.Add("@carPrice", SqlDbType.Int);
                Comm.Parameters.Add("@carDoor", SqlDbType.Int);

                Comm.Parameters["@id"].Value = Convert.ToInt32(model.id);
                Comm.Parameters["@carName"].Value = model.carName;
                Comm.Parameters["@carYear"].Value = model.carYear;
                Comm.Parameters["@carPrice"].Value = Convert.ToInt32(model.carPrice);
                Comm.Parameters["@carDoor"].Value = Convert.ToInt32(model.carDoor);

                // 수정 후 영향 받은 row 수를 화면단으로 반환.
                int i = Comm.ExecuteNonQuery();

                Conn.Close();

                return i;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
