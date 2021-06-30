using LanguageInstitute.model;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;

namespace LanguageInstitute.handler
{
    class OraHandler
    {
        const string ORADB =
            "Data Source=(DESCRIPTION=(ADDRESS_LIST=" +
            "(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)" +
            "(PORT=1521)))" +
            "(CONNECT_DATA=(SERVER=DEDICATED)" +
            "(SERVICE_NAME=xe)));" +
            "User Id=SQLDB;Password=1234;";
        OracleConnection conn;
        OracleCommand cmd;

        public OraHandler()
        {
            Console.WriteLine("객체 생성");
            conn = new OracleConnection(ORADB);
            cmd = new OracleCommand();
            dbConnect();
        }

        ~OraHandler()//소멸자
        {
            Console.WriteLine("객체 소멸");
            dbClose();
        }

        public void dbConnect()
        {
            try
            {
                conn.Open();
                Console.WriteLine("오라클 접속 성공!");
            }
            catch (OracleException e)
            {
                errMsg(e);
            }
        }

        public void errMsg(OracleException e)
        {
            Console.WriteLine("에러번호: " + e.Number);
            Console.WriteLine(e.StackTrace);
        }

        public void dbClose()
        {
            try
            {
                conn.Close();
                Console.WriteLine("오라클 접속 해제!");
            }
            catch (OracleException e)
            {
                errMsg(e);
            }
        }
        //수강과목 테이블 입력
        public void insertDb()
        {
            string crs_name = "ENGLISH";
            string crs_level = "INTERMEDIATE";
            string semester = "Summer'21";

            string query = string.Format("INSERT INTO COURSE_T VALUES"
                + "(COURSE_T_SEQ.NEXTVAL, '{0}', '{1}', '{2}')",
                crs_name, crs_level, semester);

            cmd.Connection = conn;
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
        }
        public void insertDb(Register register)
        {
            try
            {
                string query = string.Format("INSERT ALL INTO STUDENT_T VALUES(STUDENT_T_SEQ.NEXTVAL, '{0}', "
                   + "'{1}', '{2}', '{3}', COURSE_T_SEQ.CURRVAL)",
                   register.Stu.Name, register.Stu.Tel, register.Stu.Birth, register.Stu.Email);

                query += string.Format("INTO COURSE_T VALUES"
                    + "(COURSE_T_SEQ.NEXTVAL, '{0}', '{1}', '{2}')",
                    register.Crs.Crs_name, register.Crs.Crs_level, register.Crs.Semester);            

                query += "SELECT * FROM DUAL";
                cmd.Connection = conn;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                List<CrsItem> itemList = register.ItemList;
                for (int i = 0; i < itemList.Count; i++)
                {
                    CrsItem item = itemList[i];
                    string queryItem = string.Format("INSERT INTO CRSITEM_T VALUES "
                        + "(CRSITEM_T_SEQ.NEXTVAL, '{0}', '{1}', {2}', COURSE_T_SEQ.CURRVAL)",
                            item.Idx, item.CrsName, item.Price);
                    cmd.CommandText = queryItem;
                    cmd.ExecuteNonQuery();
                }

                string queryRegister = string.Format("INSERT INTO REG_T VALUES (REG_T_SEQ.NEXTVAL, "
                    + "STUDENT_T_SEQ.CURRVAL, '{0}', "
                    + "(SELECT STAFF_T.STAFF_ID FROM STAFF_T WHERE STAFF_T.STAFF_NAME = '{1}'), "
                    + "COURSE_T_SEQ.CURRVAL, '{2}')", register.InDate, register.StaffName, register.TotalPrice);
                cmd.CommandText = queryRegister;
                cmd.ExecuteNonQuery();

            }
            catch (OracleException e)
            {
                errMsg(e);
            }
        }
        
        public void showDb()
        {
            string query = "SELECT INDATE AS 접수일, TOTAL_PRICE AS 총결제금액, "
                + "(SELECT STUDENT_T.NAME FROM STUDENT_T WHERE "
                            + "STUDENT_T.STU_ID = REG_T.STU_ID) AS 학생이름, "
                            + "(SELECT STAFF_T.NAME FROM STAFF_T WHERE "
                            + "STAFF_T.STAFF_ID = REG_T.STAFF_ID) AS 강사 FROM REG_T";
            cmd.Connection = conn;
            cmd.CommandText = query;
            cmd.CommandType = System.Data.CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            int count = 1;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Console.WriteLine("번호: " + count);
                    Console.WriteLine("접수날짜: " + dr["접수일"]);//Alias명 혹은 컬럼명 둘 다 가능
                    Console.WriteLine("결제금액: " + dr["총결제금액"]);
                    Console.WriteLine("학생이름: " + dr["고객명"]);
                    Console.WriteLine("담당자: " + dr["담당자"]);
                    Console.WriteLine("-----------------------------");
                    count++;
                }
            }
            else
            {
                Console.WriteLine("데이터가 존재하지 않습니다.");
            }

            string query2 = "SELECT CRSNAME AS 강좌형태, PRICE AS 수강료 CRSITEM_T "
                            + "WHERE CRS_ID = (SELECT STUDENT_T.STU_ID FROM STUDENT_T "
                            + "WHERE STUDENT_T.NAME = '김말동')";
            cmd.CommandText = query2;
            cmd.CommandType = System.Data.CommandType.Text;
            dr = cmd.ExecuteReader();
            count = 1;

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Console.WriteLine("번호: " + count);
                    Console.WriteLine("강좌형태: " + dr["강좌형태"]);//Alias명 혹은 컬럼명 둘 다 가능
                    Console.WriteLine("수강료: " + dr["수강료"]);
                    Console.WriteLine("-----------------------------");
                    count++;
                }
            }
            else
            {
                Console.WriteLine("데이터가 존재하지 않습니다.");
            }
            dr.Close();
        }
    }
       

    

} 
