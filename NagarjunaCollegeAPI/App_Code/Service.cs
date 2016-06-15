using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.Services;

public struct CommonResponse
{
    public String CODE;
    public String MSG;
}

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]

public class Service : System.Web.Services.WebService
{
    public Service () {
        
    }
    
    [WebMethod]
    public CommonResponse UserAuthentication(String USERNAME, String PASSWORD, String SALT, String TRANSACTION_ID, String APP_ID)
    {
        CommonResponse obj_res = new CommonResponse();
        String _sqlConn = String.Empty;

        if (USERNAME == null || USERNAME == "")
        {
            obj_res.CODE = "1001";
            obj_res.MSG = "USERNAME IS EMPTY";
            return obj_res;
        }

        if (PASSWORD == null || PASSWORD == "")
        {
            obj_res.CODE = "1002";
            obj_res.MSG = "PASSWORD IS EMPTY";
            return obj_res;
        }

        if (SALT == null || SALT == "")
        {
            obj_res.CODE = "1003";
            obj_res.MSG = "SALT IS EMPTY";
            return obj_res;
        }

        if (TRANSACTION_ID == null || TRANSACTION_ID == "")
        {
            obj_res.CODE = "1004";
            obj_res.MSG = "TRANSACTION_ID IS EMPTY";
            return obj_res;
        }

        if (APP_ID == null || APP_ID == "")
        {
            obj_res.CODE = "1005";
            obj_res.MSG = "APP_ID IS EMPTY";
            return obj_res;
        }

        try
        {
            if (APP_ID == "9876543210A")
            {
                _sqlConn = ConfigurationManager.AppSettings["_db_NagarjunaCollege"].ToString();
            }
            else 
            {
                obj_res.CODE = "1006";
                obj_res.MSG = "INVALID APP_ID";
                return obj_res;
            }

            SqlConnection conn = new SqlConnection(_sqlConn);

            obj_res.CODE = "0";
            obj_res.MSG = "User Validated";

            conn.Close();            
        }
        catch (Exception ex) 
        {
            obj_res.CODE = "1000";
            obj_res.MSG = ex.Message;
        }

        return obj_res;
    }
    
}