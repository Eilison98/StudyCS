using AppConfiguration;

namespace Libs
{ 
    public class ClassForDBInstance
    {
        // 상속받아서 쓸거기 때문에 protected로 선언
        protected ConfigurationMgr configurationMgr;

        public ClassForDBInstance()
        {
            // ConfigurationMgr의 객체 생성을 하지 않아도, 사용가능
            // Instance() 메소드가 public static이므로
            configurationMgr = ConfigurationMgr.Instance(); // => 객체가 없으면 객체를 생성해주는 메소드

        }
    }
}
