using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using TransApi.Models;

namespace TransApi.Controllers
{
    public class ValuesController : ApiController
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["trans_conn"].ConnectionString);
        transaction trans = new transaction();
        // GET api/values
        public List<transaction> Get()
        {
            SqlDataAdapter da = new SqlDataAdapter("sp_GetTransaction", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<transaction> lst_trans = new List<transaction>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    transaction trans = new transaction();
                    trans.client_id = Convert.ToInt32(dt.Rows[i]["client_id"]);
                    trans.acc_no = Convert.ToInt32(dt.Rows[i]["acc_no"]);
                    trans.trans_amount = Convert.ToDecimal(dt.Rows[i]["trans_amount"]);
                    trans.trans_description = (dt.Rows[i]["trans_description"]).ToString();
                    trans.trans_type = (dt.Rows[i]["trans_type"]).ToString();
                    trans.dr_cr = (dt.Rows[i]["dr_cr"]).ToString();
                    trans.trans_date = Convert.ToDateTime(dt.Rows[i]["trans_date"]);
                    lst_trans.Add(trans);
                }

            }
            if (lst_trans.Count > 0)
                return lst_trans;
            else return null;
        }
 

        // POST api/values
        public string Post(transaction trans)
        {
            string msg = "";
            if (trans != null)
            {
                SqlCommand cmd = new SqlCommand("sp_AddTransaction", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@client_id", trans.client_id);
                cmd.Parameters.AddWithValue("@acc_no", trans.acc_no);
                cmd.Parameters.AddWithValue("@trans_amount", trans.trans_amount);
                cmd.Parameters.AddWithValue("@trans_description", trans.trans_description);
                cmd.Parameters.AddWithValue("@trans_type", trans.trans_type);
                cmd.Parameters.AddWithValue("@dr_cr", trans.dr_cr);
                cmd.Parameters.AddWithValue("@trans_date", trans.trans_date);
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                conn.Close();

                if (i > 0)
                    msg = "Transaction Created Successfully.";
                else
                    msg = "Errro";

            }
            return msg;
        }

        // PUT api/values/5
        public string Put(int id, transaction trans)
        {
            string msg = "";
            if (trans != null)
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateTransaction", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@trans_id", id);
                cmd.Parameters.AddWithValue("@client_id", trans.client_id);
                cmd.Parameters.AddWithValue("@acc_no", trans.acc_no);
                cmd.Parameters.AddWithValue("@trans_amount", trans.trans_amount);
                cmd.Parameters.AddWithValue("@trans_description", trans.trans_description);
                cmd.Parameters.AddWithValue("@trans_type", trans.trans_type);
                cmd.Parameters.AddWithValue("@dr_cr", trans.dr_cr);
                cmd.Parameters.AddWithValue("@trans_date", trans.trans_date);
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                conn.Close();

                if (i > 0)
                    msg = "Transaction Updated Successfully.";
                else
                    msg = "Errro";

            }
            return msg;
        }

        // DELETE api/values/5
        public string Delete(int id)
        {
            string msg = "";
            if (trans != null)
            {
                SqlCommand cmd = new SqlCommand("sp_DeleteTransaction", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@trans_id", id);
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                conn.Close();

                if (i > 0)
                    msg = "Transaction Deleted Successfully.";
                else
                    msg = "Errro";

            }
            return msg;
        }
    }
}
