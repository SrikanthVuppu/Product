using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Product.Models;

namespace Product.Data
{
    public class DAL
    {
        string connection = System.Configuration.ConfigurationManager.ConnectionStrings["Assignment"].ConnectionString;

        public List<Products> lstproduct = new List<Products>();
        public List<Fields> lstfields = new List<Fields>();
        public List<Fields> lstcustomfields = new List<Fields>();
        public List<Entity> lstentity = new List<Entity>();
        public List<Entity> lstCustomentity = new List<Entity>();
        Result objResult = new Result();

        public object DefaultField()
        {
            for (int i = 1; i < 4; i++)
            {
                Fields fields = new Fields();
                fields.Field = "Field" + i;
                fields.IsRequired = true;
                fields.MaxLength = 10;
                fields.Source = "Source1";

                lstfields.Add(fields);
            }

            Entity objEntity = new Entity();
            objEntity.EntityName = "Product";
            objEntity.Fields = lstfields;


            // Products products = new Products();
            lstentity.Add(objEntity);
            // products.Entities = lstentity;


            return lstentity;

        }
        public object CustomField()
        {
            for (int i = 1; i < 4; i++)
            {
                Fields fields = new Fields();
                fields.Field = "CField" + i;
                fields.IsRequired = true;
                fields.MaxLength = 10;
                fields.Source = "Source2";

                lstfields.Add(fields);
            }

            Entity objEntity = new Entity();
            objEntity.EntityName = "Product";
            objEntity.Fields = lstfields;


            // Products products = new Products();
            lstentity.Add(objEntity);
            // products.Entities = lstentity;




            return lstentity;
        }

        public object MergeOutput()
        {
            for (int i = 1; i < 4; i++)
            {
                Fields fields = new Fields();
                fields.Field = "CField" + i;
                fields.IsRequired = true;
                fields.MaxLength = 10;
                fields.Source = "Source2";

                lstfields.Add(fields);
            }



            Entity objEntity = new Entity();
            objEntity.EntityName = "Product";
            objEntity.Fields = lstfields;

            lstentity.Add(objEntity);

            //Products product = new Products();
            //product.Entities = lstentity;


            for (int i = 1; i < 4; i++)
            {
                Fields fieldss = new Fields();
                fieldss.Field = "Field" + i;
                fieldss.IsRequired = true;
                fieldss.MaxLength = 10;
                fieldss.Source = "Source1";

                lstcustomfields.Add(fieldss);
            }

            Entity objEntities = new Entity();
            objEntities.EntityName = "Product";
            objEntities.Fields = lstcustomfields;

            lstCustomentity.Add(objEntities);

            //Products productt = new Products();
            //productt.Entities = lstentity;

            //lstproduct.Add(productt);
            return lstCustomentity.Concat(lstentity);

        }

        public object BulkInsert(Products product)
        {
            object response = "";
            for (int i = 0; i < product.Entities.Count; i++)
            {
                response = BulkInsertUpdate(product.Entities[i].Fields[i]);
            }
            return "";
        }

        public object BulkInsertUpdate(Fields Field)
        {
            SqlConnection con = new SqlConnection(connection);

            if (con.State == ConnectionState.Fetching || con.State == ConnectionState.Executing || con.State == ConnectionState.Open)
                con.Close();
            if (con.State == ConnectionState.Closed)
                con.Open();

            try
            {
                using (SqlCommand cmd = new SqlCommand("usp_InsertProduct", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Field", Field.Field);
                    cmd.Parameters.AddWithValue("@IsRequired", Field.IsRequired);
                    cmd.Parameters.AddWithValue("@MaxLength", Field.MaxLength);
                    cmd.Parameters.AddWithValue("@Source", Field.Source);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        objResult.statusCode = "200";
                        objResult.statusMessage = "Success";
                        objResult.data = dt;

                    }
                    else
                    {
                        objResult.statusCode = "200";
                        objResult.statusMessage = "Success";
                        objResult.data = dt;
                    }

                }
            }

            catch (SqlException ex)
            {
              
                objResult.statusCode = ex.ErrorCode.ToString();
                objResult.statusMessage = ex.Message;
                objResult.data = "";
            }

            catch (Exception ex)
            {
               
                objResult.statusCode = "500";
                objResult.statusMessage = "Exception";
                objResult.data = null;
            }


            finally
            {
                con.Close();
            }

            return objResult;
        }


    }
}