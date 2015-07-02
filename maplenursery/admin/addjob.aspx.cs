using JustTest1.DataModel;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Parse;
using maplenursery.DataModel;
using Newtonsoft.Json;
namespace maplenursery.admin
{
    public partial class addjob : System.Web.UI.Page
    {
        ParseObject job = new ParseObject("Job");
        content c = new content();
        List<content> allcontent = new List<content>();

        List<string> selected = new List<string>();

        static List<Plant> listToShow = new List<Plant>();
        //var user = ParseUser.LogInAsync(userName.Trim(), password.Trim());
        //private MobileServiceCollection<User, User> items;
        //private IMobileServiceTable<User> userTable = Global.MobileService.GetTable<User>();

        //private IMobileServiceTable<Job> jobTable = Global.MobileService.GetTable<Job>(); 
        protected async void Page_Load(object sender, EventArgs e)
        {

            selectplant.Visible = false;
            //Session["pid"] = "_addjob";
            //if (Session["adminusername"] == null)
            //{
                
            //    Response.Redirect("~/login.aspx",false);
            //}
            //items = await userTable
            //    .Where(con => con.Availability != false)
            //    .ToCollectionAsync();

            //DropDownList1.DataSource = items;
            //DropDownList1.DataTextField = "Name";
            //DropDownList1.DataValueField = "Name";
            //DropDownList1.DataBind();
            if(!IsPostBack)
            {
                await RefreshTodoItems();
                //this.Button2.Attributes.Add("onclick", "javascript:return OpenPopup()");
            }
            

        }

        //protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}
        private async Task  RefreshTodoItems()
        {
           
                // This code refreshes the entries in the list view by querying the TodoItems table.
                // The query excludes completed TodoItems
            //var query = from item in ParseObject.GetQuery(User)
            //            orderby item.ObjectId.
            //            select item;
            //ParseQuery<ParseObject> query = ParseObject.GetQuery("User");
            //query.WhereEqualTo("Availablity", "true");

            //var query = ParseObject.GetQuery("User").WhereEqualTo("Availablity", "true");
            //query.FindAsync().ContinueWith(t =>
            //{
            //    IEnumerable<ParseObject> results = t.Result;
            //    foreach (var obj in results)
            //    {
            //        var name = obj.Get<ParseObject>("Name");
            //        Lblerror.Text = name.ToString();
            //        //Debug.Log("Score: " + score);
            //    }
            //});
            IEnumerable<ParseUser> users = await ParseUser.Query
                .WhereNotEqualTo("username", "admin").WhereEqualTo("status","idle").FindAsync();
            List<User> all=new List<User>();
          //  var query = from all in ParseObject.GetQuery("user")
          //              where all.Get<string>("availability") != "false"
          //              select all;
          //  var final = await query.FindAsync();
          //      //items = await userTable
          //      //    .Where(todoItem => todoItem.Availability != false)
          //      //    .ToCollectionAsync();

            foreach (ParseObject obj in users)
            {
                all.Add( new User()  {Id= obj.ObjectId,Name=obj.Get<string>("username")
                } );
            }
               
                LiEmployee.DataSource = all;
                LiEmployee.DataTextField = "Name";
                LiEmployee.DataValueField = "Id";
                LiEmployee.DataBind();

                LiEmployee.EnableViewState = true;
            
        }

        protected async void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedValue = LiEmployee.SelectedItem;
                //User userObject = items[selectedValue];
                //Response.Write((selectedValue.Value));


                job["name"] = JobTitle.Text;
                job["description"] = JobDescription.Text;
                job["assignedUser"] = selectedValue.Value;
                job["content"] = JsonConvert.SerializeObject(listToShow);
                job["Status"] = "sent";
                job["userResponse"] = "waiting";
                await job.SaveAsync();
                Lblerror.Text = "Saved Successfully";
                

            }
            catch(Exception en)
            {
                Lblerror.Text = en.Message;
            }
            //var newJob = new Job { JobName = JobTitle.Text, JobDesc = JobDescription.Text, AssignedUser = selectedValue.Value };
            ////Debug.WriteLine("" + selectedValue.Id);
            // await InsertnewJob(newJob);
        }
         protected async void addplant_Click(object sender, EventArgs e)
        {
            try
            {
                DataList1.Visible = true;
                //ParseQuery<ParseObject> query = ParseObject.GetQuery("Plant");

                //var queryTask = query.FirstAsync();
                //ParseObject obj = queryTask.Result;
                //ParseFile applicantResumeFile = obj.Get<ParseFile>("image");

                //string assd = applicantResumeFile.Url + "";
                List<Plant> all = new List<Plant>();
                IEnumerable<ParseObject> users = await ParseObject.GetQuery("Plant").FindAsync();

                foreach (ParseObject obj in users)
                {
                    ParseFile img = obj.Get<ParseFile>("image"); 
                    //Console.Write("" + img.Url); 
                    all.Add(new Plant()
                {
                    Id = obj.ObjectId,
                    Name = obj.Get<string>("name"),
                    imagePath = img.Url,
                    Price=obj.Get<double>("price"),
                    Quantity= 1
                });
                }

                DataList1.DataSource = all;
                DataList1.DataBind();
                selectplant.Visible = true;

            }
            catch (Exception err)
            {
                Lblerror.Text = err.Message;
            }
            //lblerror.Text = assd;

            //string resumeText = await new HttpClient().GetStringAsync(image.Url);
            //IEnumerable<ParseObject> users = await ParseObject.GetQuery("Plant")
            //   .FindAsync();
            //List<Plant> all = new List<Plant>();
            //  var query = from all in ParseObject.GetQuery("user")
            //              where all.Get<string>("availability") != "false"
            //              select all;
            //  var final = await query.FindAsync();
            //      //items = await userTable
            //      //    .Where(todoItem => todoItem.Availability != false)
            //      //    .ToCollectionAsync();

            //foreach (ParseObject obj in users)
            //{
            //    all.Add(new Plant()
            //    {
            //        Id = obj.ObjectId,
            //        Name = obj.Get<string>("username"),
            //        image=obj.Get<File>("image")
            //    });
            ////}
            //GridView1.DataSource = all;


            //GridView1.DataBind();
        }

     

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

            LinkButton btn = (LinkButton)sender;
            DataListItem item = (DataListItem)btn.NamingContainer;
            Label lblId = (Label)item.FindControl("LblID");
            
            string ID = lblId.Text;

            List<Plant> ids = new List<Plant>();
            
            
            ids.Add(new Plant(){ Id=ID}
                );
            DLselectedplant.DataSource = ids;
            DLselectedplant.DataBind();
        }

        protected void selectplant_Click(object sender, EventArgs e)
        {
            //Button btn=(Button)sender; 
            select_plant();
            DataList1.Visible = false;
        }
        public void select_plant()
        {
            foreach (DataListItem selecteditem in DLselectedplant.Items)
            {
                Label selectedid = (Label)selecteditem.FindControl("Label5");
               
                selected.Add(selectedid.Text);
            }
            
            foreach (DataListItem items in DataList1.Items)
            {
                TextBox quantity = (TextBox)items.FindControl("lblquantity");
                Label price = (Label)items.FindControl("lblprice1");
                CheckBox cb = (CheckBox)items.FindControl("CheckBox1");
                Label lblId = (Label)items.FindControl("LblID"); 
                Image i = (Image)items.FindControl("Image1");

                List<string> ids=new List<string>();
                ids.Add(lblId.Text);
                if ((items.FindControl("CheckBox1") as CheckBox).Checked)
                {
                    bool result = ids.Intersect(selected).Count() == ids.Count;
                    
                    if (!result)
                    {
                        listToShow.Add(new Plant()
                        {
                            Id = lblId.Text,
                            Name = cb.Text,
                            imagePath = new Uri(i.ImageUrl),
                            Price = Convert.ToDouble(price.Text),
                            Quantity = Convert.ToInt16(quantity.Text)
                        });
                    }
                    else
                    {
                        Lblerror.Text = "already selected";
                    }
                }
                 
            }
            DLselectedplant.DataSource = listToShow;
            DLselectedplant.DataBind();
            
            selectplant.Visible = false;
        }

        protected void DLselectedplant_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            //int id = (int)DLselectedplant.DataKeys[e.Item.ItemIndex];
            listToShow.RemoveAt(e.Item.ItemIndex);
            DLselectedplant.DataSource = listToShow;
            DLselectedplant.DataBind();
            
        }

        //protected void DLselectedplant_EditCommand(object source, DataListCommandEventArgs e)
        //{
        //    //if(e.CommandName=="Edit")
        //    DLselectedplant.EditItemIndex = e.Item.ItemIndex;
        //    select_plant();
        //    //DLselectedplant.DataBind();
        //}

        //protected void DLselectedplant_CancelCommand(object source, DataListCommandEventArgs e)
        //{
        //    DLselectedplant.EditItemIndex = -1;
        //    select_plant();
        //}

//        protected void DLselectedplant_UpdateCommand(object source, DataListCommandEventArgs e)
//        {
//            TextBox quantity = (TextBox)e.Item.FindControl("txtquantity");
//            Label price = (Label)e.Item.FindControl("lblprice2");
//            Label id = (Label)e.Item.FindControl("lblID");
//            int q = Convert.ToInt16(quantity.Text);
//            double p = Convert.ToDouble(price.Text);
            
//            double totol = q * p;
            
//            allcontent.Add(new content
//                {
//                    Id=id.Text,
//                    Quantity = q,
//                    Price = p,
//                    Total = totol
//                });
//            DLselectedplant.EditItemIndex = -1;
           
//                select_plant();
           
           
////            List<Plant> rows = new List<Plant>();
////            //Label quantity = (Label)items.FindControl("lblquantity");

////            Label name = (Label)e.Item.FindControl("lblname");
////            Label lblId = (Label)e.Item.FindControl("lblID");
////            Image i = (Image)e.Item.FindControl("Image3");
////            Uri convertedUri = new Uri(i.ImageUrl);
            
//////            var query =
//////    from ord in ParseObject.GetQuery("Job")
//////    where ord.ObjectId ==lblId.Text
//////    select ord;

//////// Execute the query, and change the column values 
//////// you want to change. 
//////foreach (ParseObject ord in query)
//////{
//////    ord.Get<double>("total") = "Mariner";
    
//////    // Insert any additional changes to column values.
//////}

////            foreach (DataListItem items in DLselectedplant.Items)
////            {
////                rows.Add(new Plant()
////                {
////                    Id = lblId.Text,
////                    Name = name.Text,
////                    imagePath = convertedUri,
////                    Price = c.Price,
////                    Total = c.Total,
////                    Quantity = c.Quantity
////                });

////            }
////            DLselectedplant.DataSource = rows;
////            DLselectedplant.DataBind();
//            //IEnumerable<ParseObject> users = await ParseObject.GetQuery("Plant").FindAsync();
//            //try
//            //{
//            //    ParseObject job = new ParseObject("Job");
//            //    job["quantity"] = Convert.ToInt32( quantity.Text);
//            //    await job.SaveAsync();
//            //    DLselectedplant.EditItemIndex = -1;
//            //    select_plant();
//            //}
//            //catch (Exception en)
//            //{
//            //    Lblerror.Text = en.Message;
//            //}




//            //private async void SaveaJob(object sender, EventArgs e)
//            //{


//            //}


//            //private async Task InsertnewJob(Job newJob)
//            //{
//            //    await jobTable.InsertAsync(newJob);
//            //    Lblerror.Text = "saved";
//            //    //items.Add(newJob); 
//            //}
//        }
       
         
    }
}