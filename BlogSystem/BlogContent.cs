namespace BlogSystem
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;

    public class BlogContent : DbContext
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“BlogContent”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“BlogSystem.BlogContent”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“BlogContent”
        //连接字符串。
        public BlogContent()
            : base("name=con")
        {
            Database.SetInitializer<BlogContent>(null);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<BlogCategory> BlogCategories { set; get; }
        public DbSet<Artcile> Artciles { set; get; }
        public DbSet<ArtcleToCategory> ArtcleToCategories { set; get; }
        public DbSet<Comment> comments { set; get; }
        public DbSet<Fans> fans { set; get; }
    }

}

