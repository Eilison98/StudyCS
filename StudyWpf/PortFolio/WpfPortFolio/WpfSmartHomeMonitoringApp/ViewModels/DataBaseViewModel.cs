using Caliburn.Micro;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using WpfSmartHomeMonitoringApp.Helpers;
using WpfSmartHomeMonitoringApp.Models;

namespace WpfSmartHomeMonitoringApp.ViewModels
{
    public class DataBaseViewModel : Screen
    {

        private string brokerUrl;
        public string BrokerUrl
        {
            get { return brokerUrl; }
            set
            {
                brokerUrl = value;
                NotifyOfPropertyChange(() => BrokerUrl);
            }
        }

        private string topic;
        public string Topic
        {
            get { return topic; }
            set
            {
                topic = value;
                NotifyOfPropertyChange(() => Topic);
            }
        }

        private string connString;
        public string ConnString
        {
            get { return connString; }
            set
            {
                connString = value;
                NotifyOfPropertyChange(() => ConnString);
            }
        }

        private string dbLog;
        public string DBLog
        {
            get { return dbLog; }
            set
            {
                dbLog = value;
                NotifyOfPropertyChange(() => DBLog);
            }
        }

        private bool isConnected;
        public bool IsConnected
        {
            get => isConnected; set  //  람다식
            {
                isConnected = value;
                NotifyOfPropertyChange(() => IsConnected);
            }
        }

        public DataBaseViewModel()
        {
            BrokerUrl = Commons.BROKERHOST = "127.0.0.1";  //  MQTT Broker IP 설정
            Topic = Commons.PUB_TOPIC = "home/device/#";  //  MQTT Program Topic 문자가 틀리면 데이터가 안들어옴  // #은 모든데이더가 다 들어옴
            ConnString = Commons.CONNSTRING = "Data Source=PC01;Initial Catalog=OpenApiLab;Integrated Security=True";  //  DB 연결문자열
            
            if (Commons.IS_CONNECT)
            {
                IsConnected = true;
                ConnectDB();
            }
        }

        /// <summary>
        /// DB연결 + MQTT Broker 접속
        /// </summary>
        public void ConnectDB()
        {
            if (IsConnected)
            {
                Commons.MQTT_CLIENT = new MqttClient(BrokerUrl);

                try
                {
                    if(Commons.MQTT_CLIENT.IsConnected != true)
                    {
                        Commons.MQTT_CLIENT.MqttMsgPublishReceived += MQTT_CLIENT_MqttMsgPublishReceived;
                        Commons.MQTT_CLIENT.Connect("MONITOR");  // 클라이언트 이름
                        Commons.MQTT_CLIENT.Subscribe(new string[] { Commons.PUB_TOPIC },
                            new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
                        UpdateText(">>> MQTT Broker Connected");
                        IsConnected = Commons.IS_CONNECT = true;
                    }
                }
                catch (Exception ex)
                {
                    //  PASS...
                }
            }
            else  //  접속종료 
            {
                try
                {
                    if (Commons.MQTT_CLIENT.IsConnected)
                    {
                        Commons.MQTT_CLIENT.MqttMsgPublishReceived -= MQTT_CLIENT_MqttMsgPublishReceived;  //  이벤트 연결 삭제
                        Commons.MQTT_CLIENT.Disconnect();
                        UpdateText(">>> MQTT Broker Disconnected...");

                        IsConnected = Commons.IS_CONNECT = false;
                    }
                }
                catch (Exception)
                {
                    //  PASS...
                }
            }
        }

        private void UpdateText(string message)
        {
            DBLog += $"{message}\n";
        }

        /// <summary>
        /// Subscribe한 메시지 처리해주는 이벤트핸들러
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MQTT_CLIENT_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            var message = Encoding.UTF8.GetString(e.Message);  //  String 중요
            UpdateText(message);  //  센서데이터 출력
            SetDataBase(message, e.Topic); //  DB에 저장
        }

        /// <summary>
        /// 메세지를 받아서 처리함
        /// </summary>
        /// <param name="message"></param>
        private void SetDataBase(string message, string topic)
        {
            var cuurDatas = JsonConvert.DeserializeObject<Dictionary<string, string>>(message);
            var Model = new SmartHomeModel();  // DB 모델사용
            

            Debug.WriteLine(cuurDatas);

            Model.DevId = cuurDatas["DevId"];
            Model.CurrTime = DateTime.Parse(cuurDatas["CurrTime"]);
            Model.Temp = double.Parse(cuurDatas["Temp"]);
            Model.Humid = double.Parse(cuurDatas["Humid"]);

            using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
            {
                conn.Open();  //  DB Open
                //  Verbatim string C# = @
                string strInQuery = @"INSERT INTO TblSmartHome
                                                 (DevId
                                                 , CurrTime
                                                 , Temp
                                                 , Humid)
                                           VALUES
                                                 (@DevId
                                                 , @CurrTime
                                                 , @Temp
                                                 , @Humid)";

                try
                {
                    SqlCommand cmd = new SqlCommand(strInQuery, conn);

                    SqlParameter parmDevId = new SqlParameter("@DevId", Model.DevId);
                    cmd.Parameters.Add(parmDevId);
                    SqlParameter parmCurrTime = new SqlParameter("@CurrTime", Model.CurrTime);  //  날짜형으로 변환필요
                    cmd.Parameters.Add(parmCurrTime);
                    SqlParameter parmTemp = new SqlParameter("@Temp", Model.Temp);
                    cmd.Parameters.Add(parmTemp);
                    SqlParameter parmHumid = new SqlParameter("@Humid", Model.Humid);
                    cmd.Parameters.Add(parmHumid);

                    if (cmd.ExecuteNonQuery() == 1)
                        UpdateText(">>> DB Inserted.");    //  저장성공
                    else
                        UpdateText(">>> DB Failed!!!!!");  //  저장실패
                }
                catch (Exception ex)
                {
                    UpdateText($">>> DB Error! {ex.Message}");  //  예외
                }
                                          
            }  //  using 사용시 conn.Close() 불필요
        }
    }
}
