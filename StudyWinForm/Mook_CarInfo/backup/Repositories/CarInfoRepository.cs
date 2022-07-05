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

        int ICarInfoRepository.Add(CarInfoModel model, IDbConnection connection)
        {
            throw new NotImplementedException();
        }

        int ICarInfoRepository.Delete(CarInfoModel model, IDbConnection connection)
        {
            throw new NotImplementedException();
        }

        ArrayList ICarInfoRepository.GetAllCarInfo(IDbConnection connection)
        {
            try
            {
                Conn.Open();

                var Comm = new SqlCommand("Select * From TB_CAR_INFO", Conn);
                var myRead = Comm.ExecuteReader(CommandBehavior.CloseConnection);

                ArrayList list = new ArrayList();

                while(myRead.Read())
                {
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


        ArrayList ICarInfoRepository.GetCarInfoByCondition(CarInfoModel model, IDbConnection connection)
        {
            throw new NotImplementedException();
        }

        int ICarInfoRepository.Update(CarInfoModel model, IDbConnection connection)
        {
            throw new NotImplementedException();
        }
    }
}
