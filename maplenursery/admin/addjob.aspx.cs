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
using GoogleMaps.LocationServices;
using JustTest1.Controller;
namespace maplenursery.admin
{
    public partial class addjob : System.Web.UI.Page
    {


       static List<content> allcontent = new List<content>();
        List<EmpJobRelation> empjobrel=new List<EmpJobRelation>();
        List<string> selected = new List<string>();

       // static List<Plant> listToShow = new List<Plant>();
        //var user = ParseUser.LogInAsync(userName.Trim(), password.Trim());
        //private MobileServiceCollection<User, User> items;
        //private IMobileServiceTable<User> userTable = Global.MobileService.GetTable<User>();

        //private IMobileServiceTable<Job> jobTable = Global.MobileService.GetTable<Job>(); 
        protected async void Page_Load(object sender, EventArgs e)
        {

            //selectplant.Visible = false;
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
                .WhereNotEqualTo(MemberInfoGetting.GetMemberName(() => new User().username), "admin").WhereEqualTo(MemberInfoGetting.GetMemberName(() => new User().status),UserControlls.statusCode[0]).FindAsync();
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
                all.Add(new User()
                {
                    Id = obj.ObjectId,
                    username = obj.Get<string>(MemberInfoGetting.GetMemberName(() => new User().username))
                } );
            }
               
                LiEmployee.DataSource = all;
                LiEmployee.DataTextField = MemberInfoGetting.GetMemberName(() => new User().username);
                LiEmployee.DataValueField = MemberInfoGetting.GetMemberName(() => new User().Id);
                LiEmployee.DataBind();

                LiEmployee.EnableViewState = true;
            
        }

        protected async void Button1_Click(object sender, EventArgs e)
        {
            ParseObject job = new ParseObject(typeof(Job).Name);
            ParseObject empjob = new ParseObject(typeof(EmpJobRelation).Name);
            var locationService = new GoogleLocationService();
            var point = locationService.GetLatLongFromAddress(txtlocation.Text);
            DateTime selected=Calendar1.SelectedDate;

            DateTime dt = new DateTime(selected.Year, selected.Month, selected.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            //var latitude = point.Latitude;
            //var longitude = point.Longitude;
            //Response.Write(latitude + "" + longitude);
            var addpoint = new ParseGeoPoint(point.Latitude, point.Longitude);
            try
            {
                var selectedValue = LiEmployee.SelectedItem;
                //User userObject = items[selectedValue];
                //Response.Write((selectedValue.Value));


                job[MemberInfoGetting.GetMemberName(() => new Job().name)] = JobTitle.Text;
                job[MemberInfoGetting.GetMemberName(() => new Job().description)] = JobDescription.Text;
                //job[MemberInfoGetting.GetMemberName(() => new Job().EmployeeId)] = selectedValue.Value;
                job[MemberInfoGetting.GetMemberName(() => new Job().content)] = JsonConvert.SerializeObject(allcontent);
                job[MemberInfoGetting.GetMemberName(() => new Job().Status)] = JobControlls.JobStatusCode[8];
                job[MemberInfoGetting.GetMemberName(() => new Job().jobDate)] = dt;
                job[MemberInfoGetting.GetMemberName(() => new Job().location)]=txtlocation.Text;
                job[MemberInfoGetting.GetMemberName(() => new Job().locCoordinate)]=addpoint;
                empjob[MemberInfoGetting.GetMemberName(() => new Job().EmployeeId)]=selectedValue.Value;
                
                await job.SaveAsync();
                await empjob.SaveAsync();
                IEnumerable<ParseObject> query  =await ParseObject.GetQuery(typeof(EmpJobRelation).Name)
                    .WhereEqualTo(MemberInfoGetting.GetMemberName(() => new Job().EmployeeId), selectedValue.Value).FindAsync();
                foreach (ParseObject obj in query)
                {
                    empjobrel.Add(new EmpJobRelation()
                    {
                        Id=obj.ObjectId
                    }
                        );
 
                }
                //ParseObject p;
                //var relaiton = p.GetRelation<ParseObject>("UserRelation");
                foreach(var a in empjobrel)
                {

                    job[MemberInfoGetting.GetMemberName(() => new Job().UserRelation)] = a.Id;
                }
                
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
        public async void bindlist()
        {

            List<content> all = new List<content>();
            IEnumerable<ParseObject> users = await ParseObject.GetQuery(typeof(Plant).Name).FindAsync();

            foreach (ParseObject obj in users)
            {
                ParseFile img = obj.Get<ParseFile>(MemberInfoGetting.GetMemberName(() => new Plant().image));
                //Console.Write("" + img.Url); 
                all.Add(new content()
                {
                    Id = obj.ObjectId,

                    name = obj.Get<string>(MemberInfoGetting.GetMemberName(() => new Plant().name)),
                    description = obj.Get<string>(MemberInfoGetting.GetMemberName(() => new Plant().description)),
                    image = img.Url,
                    price = obj.Get<double>(MemberInfoGetting.GetMemberName(() => new Plant().price)),
                    Quantity = 1
                });
            }
            ListView1.DataSource = all;
            ListView1.DataBind();
            //DataList1.DataSource = all;
            //DataList1.DataBind();
        }
         protected  void addplant_Click(object sender, EventArgs e)
        {
            try
            {
                ListView1.Visible = true;
                //ParseQuery<ParseObject> query = ParseObject.GetQuery("Plant");

                //var queryTask = query.FirstAsync();
                //ParseObject obj = queryTask.Result;
                //ParseFile applicantResumeFile = obj.Get<ParseFile>("image");

                //string assd = applicantResumeFile.Url + "";
                 bindlist();
                //selectplant.Visible = true;

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

     

        //protected async void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        //{
           
        //}

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

            LinkButton btn = (LinkButton)sender;
            DataListItem item = (DataListItem)btn.NamingContainer;
            Label lblId = (Label)item.FindControl("LblID");
            
            string ID = lblId.Text;

            List<content> ids = new List<content>();
            
            
            ids.Add(new content(){ Id=ID}
                );
            selectedplant.DataSource = ids;
            selectedplant.DataBind();
        }

        protected void selectplant_Click(object sender, EventArgs e)
        {
            //Button btn=(Button)sender; 
            select_plant();
            ListView1.Visible = false;
        }
        public void select_plant()
        {
            foreach (ListViewItem selecteditem in selectedplant.Items)
            {
                Label selectedid = (Label)selecteditem.FindControl("Label5");
               
                selected.Add(selectedid.Text);
            }
            
            //foreach (DataListItem items in DataList1.Items)
            //{
               
            //    TextBox quantity = (TextBox)items.FindControl("lblquantity");
            //    Label price = (Label)items.FindControl("lblprice1");
            //    CheckBox cb = (CheckBox)items.FindControl("CheckBox1");
            //    Label lblId = (Label)items.FindControl("LblID"); 
            //    Image i = (Image)items.FindControl("Image1");
            //    Label desc = (Label)items.FindControl("description");
            //    List<string> ids=new List<string>();
            //    ids.Add(lblId.Text);
            //    int q = Convert.ToInt16(quantity.Text);
            //    double p = Convert.ToDouble(price.Text);

            //    double totol = q * p;
            //    if ((items.FindControl("CheckBox1") as CheckBox).Checked)
            //    {
            //        bool result = ids.Intersect(selected).Count() == ids.Count;
                    
            //        if (!result)
            //        {
            //            allcontent.Add(new content()
            //            {
            //                Id = lblId.Text,
            //                name = cb.Text,
            //                image = new Uri(i.ImageUrl),
            //                price = Convert.ToDouble(price.Text),
            //                description=desc.Text,
            //                Quantity = Convert.ToInt16(quantity.Text),
            //                Total=totol
            //            });
            //        }
            //        else
            //        {
            //            Lblerror.Text = "already selected";
            //        }
            //    }
                 
            //}
            foreach(ListViewItem items in ListView1.Items)
            {

                TextBox quantity = (TextBox)items.FindControl("lblquantity");
                Label price = (Label)items.FindControl("lblprice1");
                CheckBox cb = (CheckBox)items.FindControl("CheckBox1");
                Label lblId = (Label)items.FindControl("LblID");
                Image i = (Image)items.FindControl("Image1");
                Label desc = (Label)items.FindControl("description");
                List<string> ids = new List<string>();
                ids.Add(lblId.Text);
                int q = Convert.ToInt16(quantity.Text);
                double p = Convert.ToDouble(price.Text);

                double totol = q * p;
                if ((items.FindControl("CheckBox1") as CheckBox).Checked)
                {
                    bool result = ids.Intersect(selected).Count() == ids.Count;

                    if (!result)
                    {
                        allcontent.Add(new content()
                        {
                            Id = lblId.Text,
                            name = cb.Text,
                            image = new Uri(i.ImageUrl),
                            price = Convert.ToDouble(price.Text),
                            description = desc.Text,
                            Quantity = Convert.ToInt16(quantity.Text),
                            Total = totol
                        });
                    }
                    else
                    {
                        Lblerror.Text = "already selected";
                    }
                }

            }
            selectedplant.DataSource = allcontent;
            selectedplant.DataBind();
            
            //selectplant.Visible = false;
        }

        

        protected void ListView1_PagePropertiesChanged(object sender, EventArgs e)
        {
            bindlist();
        }

        protected async void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {

            if (e.CommandArgument == "search")
            {
                TextBox searchitem = (TextBox)ListView1.FindControl("txtsearch");
                //Button search = (Button)e.Item.FindControl("btnsearch");
                IEnumerable<ParseObject> query = await ParseObject.GetQuery(typeof(Plant).Name).WhereContains
                    (MemberInfoGetting.GetMemberName(() => new Plant().name), searchitem.Text).FindAsync();
                List<content> all = new List<content>();
                //IEnumerable<ParseObject> users = await ParseObject.GetQuery(typeof(Plant).Name).FindAsync();

                foreach (ParseObject obj in query)
                {
                    ParseFile img = obj.Get<ParseFile>(MemberInfoGetting.GetMemberName(() => new Plant().image));
                    //Console.Write("" + img.Url); 
                    all.Add(new content()
                    {
                        Id = obj.ObjectId,

                        name = obj.Get<string>(MemberInfoGetting.GetMemberName(() => new Plant().name)),
                        description = obj.Get<string>(MemberInfoGetting.GetMemberName(() => new Plant().description)),
                        image = img.Url,
                        price = obj.Get<double>(MemberInfoGetting.GetMemberName(() => new Plant().price)),
                        Quantity = 1
                    });
                }

                ListView1.DataSource = all;
                ListView1.DataBind();
            }
        }

        protected void selectedplant_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandArgument == "Delete")
            {
                //ListViewDataItem dataItem = (ListViewDataItem)e.Item;
                //ListView1.Items.Remove(dataItem);
                allcontent.RemoveAt(e.Item.DataItemIndex);
                selectedplant.DataSource = allcontent;
                selectedplant.DataBind();

            }
            
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