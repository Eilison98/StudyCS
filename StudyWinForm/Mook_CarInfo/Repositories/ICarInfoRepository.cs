using Model;
using System.Collections;
using System.Data;

namespace Repositories
{
    public interface ICarInfoRepository
    { 
        //등록, 수정, 삭제, 전체검색, 조건검색
        int Add(CarInfoModel model, IDbConnection connection = null);
        int Update(CarInfoModel model, IDbConnection connection = null);
        int Delete(int carNo, IDbConnection connection = null);
        ArrayList GetAllCarInfo(IDbConnection connection = null);
        ArrayList GetCarInfoByCondition(CarInfoModel model, IDbConnection connection = null);
    }
}
