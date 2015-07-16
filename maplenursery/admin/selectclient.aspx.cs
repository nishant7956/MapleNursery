using JustTest1.Controller;
using maplenursery.DataModel;
using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace maplenursery.admin
{
    
    public partial class selectclient : System.Web.UI.Page
    {
        public static string count = "0";
        public static List<Client> all = new List<Client>();
        public static string id;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if(!IsPostBack)
            {
                clientcontrols.Visible = false;
                search.Visible = false;
            }
        }
        protected void RadioButton_CheckedChanged(object sender, System.EventArgs e)
        {
            if (radioexist.Checked)
            {
                search.Visible = true;
                clientcontrols.Visible = false;
            }
            else
            {
                clientcontrols.Visible = true;
                
               
                search.Visible = false;
            }
        }
        
        protected async void searchclient_Click(object sender, EventArgs e)
        {
            
           
            try
            {
                IEnumerable<ParseObject> query = await ParseObject.GetQuery(typeof(Client).Name)
                     .WhereEqualTo(MemberInfoGetting.GetMemberName(() => new Client().name), txtsearchclient.Text).FindAsync();
                count = query.Count().ToString();
               
                
                if (query.Count() != 0)
                {
                    
                    foreach (ParseObject obj in query)
                    {
                        id = obj.ObjectId;
                        
                        clientcontrols.Visible = true;
                        clientname.Text = obj.Get<string>(MemberInfoGetting.GetMemberName(() => new Client().name));
                        clientname.Enabled = false;
                        clientaddress.Text = obj.Get<string>(MemberInfoGetting.GetMemberName(() => new Client().address));
                        clientaddress.Enabled = false;
                        clientcontact.Text = obj.Get<string>(MemberInfoGetting.GetMemberName(() => new Client().contactnumber));
                        clientcontact.Enabled = false;
                        clientemail.Text = obj.Get<string>(MemberInfoGetting.GetMemberName(() => new Client().email));
                        clientemail.Enabled = false;
                    }
                }
                else
                {
                    Lblerror.Text = "Client Does Not Exist";
                }

            }
            catch (Exception en)
            {
                Lblerror.Text = en.Message;
            }
        }
        public async void savedata()
        {
            ParseObject query = new ParseObject(typeof(Client).Name);
            query[MemberInfoGetting.GetMemberName(() => new Client().name)] = clientname.Text;
            query[MemberInfoGetting.GetMemberName(() => new Client().address)] = clientaddress.Text;
            query[MemberInfoGetting.GetMemberName(() => new Client().contactnumber)] = clientcontact.Text;
            query[MemberInfoGetting.GetMemberName(() => new Client().email)] = clientemail.Text;
            await query.SaveAsync();
        }
        protected async void next_Click(object sender, EventArgs e)
        {
            if (count == "0")
            {
                savedata();
                IEnumerable<ParseObject> clientid = await ParseObject.GetQuery(typeof(Client).Name)
                     .WhereEqualTo(MemberInfoGetting.GetMemberName(() => new Client().name),clientname.Text).FindAsync();
                foreach (ParseObject obj in clientid)
                {
                    id = obj.ObjectId;
                }
                Session["clientid"] = id;
                Response.Redirect("addjob.aspx",false);
            }
            else
            {
                Session["clientid"] = id;
                Response.Redirect("addjob.aspx",false);
            }
        }
        //clear the values of the textboxes and enable them when new client is selected.
        public void cleartext()
        {
            clientname.Text = "";
            clientname.Enabled = true;
            clientaddress.Text = "";
            clientaddress.Enabled = true;
            clientcontact.Text = "";
            clientcontact.Enabled = true;
            clientemail.Text = "";
            clientemail.Enabled = true;
        }
    }
}