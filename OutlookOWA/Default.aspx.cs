using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OutlookOWA
{
    public partial class _Default : System.Web.UI.Page
    {
        private string userName;

        private string passWord;

        protected void Page_Load(object sender, EventArgs e)
        {
            passWord = "R8ll%23qqO2";

            userName = "corp%5Cbkwang";

            Response.Write(CreateOWAFrom());

            Response.Write(LoadOWAPostJS("logonForm"));
        }

        private string LoadOWAPostJS(string strFormId)
        {

            //Constructs the JS needed to post the data to Realex and returns it

            StringBuilder strScript = new StringBuilder();

            strScript.Append("<script language='javascript'>");

            strScript.Append("var ctlForm = document.forms.namedItem('{0}');");

            strScript.Append("ctlForm.username.value=\"" + userName + "\";");

            strScript.Append("ctlForm.password.value=\"" + passWord + "\";");

            strScript.Append("ctlForm.submit();");

            strScript.Append("</script>");

            return String.Format(strScript.ToString(), strFormId);
        }



        private string CreateOWAFrom()
        {

            //Constructs the Realex HTML form and returns it

            StringBuilder strForm = new StringBuilder();

            //https://your_Owa_Adress/exchweb/bin/auth/owaauth.dll\
            //https://your_Owa_Adress/exchange/\
            //https://legacymail.taylorcorp.com/exchweb/bin/auth/owaauth.dll
            //string url=
            strForm.AppendLine("<form id=\"logonForm\" ENCTYPE=\"application/x-www-form-urlencoded\" autocomplete=\"off\" name=\"logonForm\" target=\"_self\" action=\"https://webmail.taylorcorp.com/owa/auth.owa\" method=\"post\">");

            strForm.AppendLine("<input type=\"hidden\" name=\"destination\" value=\"https%3A%2F%2Fwebmail.taylorcorp.com%2Fowa%2F\"/>");

            strForm.AppendLine("<input type=\"hidden\" name=\"flags\" value=\"0\"/>");

            strForm.AppendLine("<input type=\"hidden\" name=\"username\" id=\"username\" value=\""+userName+"\" />");

            strForm.AppendLine("<input type=\"hidden\" name=\"password\" id=\"password\" value=\""+passWord+"\"/>");

            strForm.AppendLine("<input type=\"hidden\" id=\"SubmitCreds\" name=\"SubmitCreds\" value=\"Connection\"/>");

            strForm.AppendLine("<input type=\"hidden\" id=\"rdoRich\" name=\"forcedownlevel\" value=\"0\"/>");

            strForm.AppendLine("<input type=\"hidden\" id=\"rdoPublic\" name=\"trusted\" value=\"0\"/>");

            strForm.AppendLine("</form>");

            return strForm.ToString();
        }

    }
}
