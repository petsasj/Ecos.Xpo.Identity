# Ecos XPO Identity

This library helps you configure Microsoft Identity to work with DevExpress XPO ORM. 

## Installation

You can either clone the project and use it as a project dependency, or download it from nuget package manager. Package is listed as [Ecos.DX.Data.Xpo.Identity](https://www.nuget.org/packages/Ecos.DX.Data.Xpo.Identity/ "View Package").

## Usage
Start by adding a reference to the library. Then, define your ApplicationUser and XpoApplicationUser. In the following example, properties FirstName, LastName, ProfilePicture and a list of Posts have been added to extend the basic functionality of the ApplicationUser. Be carefull with the **Association Tag**. This tag must be added to both sides of the SQL relation. In this example, we would add it to the Post model.

### ApplicationUser

    public class ApplicationUser : XPIdentityUser<XpoApplicationUser>
    {
        public ApplicationUser(XpoApplicationUser source) : base(source)
        { }

        public ApplicationUser(XpoApplicationUser source, int loadingFlags) : base(source, loadingFlags)
        { }

        public ApplicationUser()
        { }
		
		// custom properties extending the default user 
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public byte[] ProfilePicture { get; set; }

        public IList<Post> Posts { get; set; }

        public override void Assign(object source, int loadingFlags)
        {
            base.Assign(source, loadingFlags);
            if (source is XpoApplicationUser src)
            {
                // additional properties here
                this.FirstName = src.FirstName;
                this.LastName = src.LastName;
                this.ProfilePicture = src.ProfilePicture;
                this.Posts= src.Posts.ToList();
                // etc.             
            }
        }
    }
### XpoApplicationUser

    // This class will be persisted in the database by XPO
    // It should have the same properties as the ApplicationUser
    [MapInheritance(MapInheritanceType.ParentTable)]
    public class XpoApplicationUser : XpoDxUser
    {
        public XpoApplicationUser(Session session) : base(session) { }

        private string fFirstName;
        public string FirstName
        {
            get => fFirstName;
            set => SetPropertyValue<string>(nameof(FirstName), ref fFirstName, value);
        }

        private string fLastName;
        public string LastName
        {
            get => fLastName;
            set => SetPropertyValue<string>(nameof(LastName), ref fLastName, value);
        }

        private byte[] fProfilePicture;
        public byte[] ProfilePicture
        {
            get => fProfilePicture;
            set => SetPropertyValue<byte[]>(nameof(ProfilePicture), ref fProfilePicture, value);
        }

        [Association(@"PostsReferencesApplicationUser")]
        public XPCollection<Post> Posts => GetCollection<Post>(nameof(Posts));

        public override void Assign(object source, int loadingFlags)
        {
            base.Assign(source, loadingFlags);
            if (source is ApplicationUser src)
            {
                // additional properties here
                this.FirstName = src.FirstName;
                this.LastName = src.LastName;
                this.ProfilePicture = src.ProfilePicture;
                // etc.             
            }
        }
    }
Do the same with ApplicationRole and XpoApplicationRole classes:
### ApplicationRole

    public class ApplicationRole : XPIdentityRole<XpoApplicationRole>
    {
        public ApplicationRole(XpoApplicationRole source, int loadingFlags) : base(source, loadingFlags)
        { }

        public ApplicationRole(XpoApplicationRole source) : base(source)
        { }

        public ApplicationRole()
        { }
        public override void Assign(object source, int loadingFlags)
        {
            base.Assign(source, loadingFlags);
        }
    }

### XpoApplicationRole

    [MapInheritance(MapInheritanceType.ParentTable)]
    public class XpoApplicationRole : XpoDxRole
    {
        public XpoApplicationRole(Session session) : base(session)
        {
        }
        public override void Assign(object source, int loadingFlags)
        {
            base.Assign(source, loadingFlags);
        }
    }

## Connect to your database

Edit your startup class, adding the following to configureServices method:

	   //Initialize XPODataLayer / Database. XPOConnection is the connection string defined in appsettings.json
	   services.AddXpoDatabase("XPOConnection", Configuration.GetConnectionString("XPOConnection"));
	   
		//Add UnitOfWork as a scoped dependency
	   services.AddXpoUnitOfWork("XPOConnection");

## Configure Authentication

Configure identity to use Xpo

    services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
             {
                 options.Lockout.AllowedForNewUsers = true;
                 options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                 options.Lockout.MaxFailedAccessAttempts = 3;
             })
             .AddXpoIdentityStores<XpoApplicationUser, XpoApplicationRole>()
             .AddDefaultTokenProviders();
Don't forget to 

    app.useAuthentication();