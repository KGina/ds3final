using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Text;
using AbantwanaWebMaster.Data;

namespace AbantwanaWebMaster.Data
{
    public class DataContext : IdentityDbContext, IDbContext
    {
        public DataContext()
            : base("Gconnection2019")
        {

        }

        //#region Properties
       
        public DbSet<Category> Categories { get; set; }
        public DbSet<Payment> payments { get; set; }
        public DbSet<Fees> fees { get; set; }
        public DbSet<Attendance> attendances { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Announcement> announcements { get; set; }
        //public DbSet<DeliveredItems> deliveredItems { get; set; }
        public DbSet<ThemeColor> colors { get; set; }
        public DbSet<Item> items { get; set; }       
        public DbSet<LeaveRequest> leaveRequests { get; set; }
        public DbSet<LeaveType> leaveTypes { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Parent> parents { get; set; }
        public DbSet<StaffMember> staffMembers { get; set; }
        public DbSet<WorkSchedule> workSchedules { get; set; }
        //mark relevant
        public DbSet<LearnerProfile> learnerProfiles { get; set; }
        public DbSet<ClassRoom> classRooms { get; set; }
       public DbSet<Subject> Subjects { get; set; }
        public DbSet<Assessment> Assessments { get; set; }
        public DbSet<Term> terms { get; set; }
        public DbSet<ParentLearner> ParentLearners { get; set; }
        public DbSet<ParentAnnouncement> ParentAnnouncements { get; set; }
        public DbSet<Connection> Connections { get; set; }
        public DbSet<YearLearnerClassRoom> yearLearnerClassRooms { get; set; }
        public DbSet<Grade> grades { get; set; }
        public DbSet<GradeSubject> gradeSubjects { get; set; }
        public DbSet<YearLearnerGradeSubject> yearLearnerGradeSubjects { get; set; }
        public DbSet<YearLearnerGradeSubjectAssessment> yearLearnerGradeSubjectAssessments { get; set; }
        //public DbSet<YearLearnerClassRoom> yearLearnerClassRooms { get; set; }
        //#endregion

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<IdentityUser>().ToTable("AspNetUsers");

            EntityTypeConfiguration<ApplicationUser> table =
                modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers");

            table.Property((ApplicationUser u) => u.UserName).IsRequired();

            modelBuilder.Entity<ApplicationUser>().HasMany<IdentityUserRole>((ApplicationUser u) => u.Roles);
            modelBuilder.Entity<IdentityUserRole>().HasKey((IdentityUserRole r) =>
                new { UserId = r.UserId, RoleId = r.RoleId }).ToTable("AspNetUserRoles");

            EntityTypeConfiguration<IdentityUserLogin> entityTypeConfiguration =
                modelBuilder.Entity<IdentityUserLogin>().HasKey((IdentityUserLogin l) =>
                    new
                    {
                        UserId = l.UserId,
                        LoginProvider = l.LoginProvider,
                        ProviderKey
                            = l.ProviderKey
                    }).ToTable("AspNetUserLogins");

            modelBuilder.Entity<IdentityRole>().ToTable("AspNetRoles");

            EntityTypeConfiguration<ApplicationRole> entityTypeConfiguration1 = modelBuilder.Entity<ApplicationRole>().ToTable("AspNetRoles");

            entityTypeConfiguration1.Property((ApplicationRole r) => r.Name).IsRequired();
            // Configure primary Keys

            //Attendance
            modelBuilder.Entity<Attendance>().HasKey(k =>k.attendId );

            //Announcements
            modelBuilder.Entity<Announcement>().HasKey(k => k.announcementid);
            modelBuilder.Entity<ParentAnnouncement>().HasKey(m => new { m.ParentAnnouncementId, m.ReceiverId });


            //Registration
            modelBuilder.Entity<ParentLearner>().HasKey(m => new { m.parentid, m.learnerId });
            modelBuilder.Entity<Parent>().HasKey(k => k.parentId);
            modelBuilder.Entity<LearnerProfile>().HasKey(k => k.learnerId);

            //Chat

            modelBuilder.Entity<Connection>().HasKey(x => x.Id);

            //Payment

            modelBuilder.Entity<Payment>().HasKey(x => x.pymentId);
            modelBuilder.Entity<Fees>().HasKey(x => x.FeeId);

            //Marks

            modelBuilder.Entity<YearLearnerClassRoom>().HasKey(m => new { m.classRoomId,m.learnerId,m.yearId });
            modelBuilder.Entity<Grade>().HasKey(m => new { m.gradeId });
            modelBuilder.Entity<GradeSubject>().HasKey(m => new { m.gradeId,m.subjectId });
            modelBuilder.Entity<YearLearnerGradeSubject>().HasKey(m => new {m.subjectId,m.gradeId,m.yearId,m.learnerId });
            modelBuilder.Entity<YearLearnerGradeSubjectAssessment>().HasKey(m => new { m.assessmentId,m.subjectId,m.gradeId,m.yearId,m.learnerId });
            modelBuilder.Entity<Year>().HasKey(m => new { m.yearId });
            modelBuilder.Entity<Assessment>().HasKey(m => new { m.assessmentId });
            modelBuilder.Entity<Subject>().HasKey(m => new { m.subjectId });
            modelBuilder.Entity<Term>().HasKey(m => new { m.termId });
            
            //Schedule
            //modelBuilder.Entity<ClassRoom>().HasMany(k => k.WorkSchedules).WithRequired(k => k.ClassRoom).HasForeignKey(o=>o.classRoomId);
            modelBuilder.Entity<StaffMember>().HasMany(k => k.WorkSchedules).WithRequired(k => k.StaffMember).HasForeignKey(o=>o.staffMemberId);
            modelBuilder.Entity<StaffMember>().HasMany(k => k.LeaveRequests).WithRequired(k => k.StaffMember).HasForeignKey(o=>o.staffmemberId);
            modelBuilder.Entity<ThemeColor>().HasKey(k=>k.colorID);
            modelBuilder.Entity<ClassRoom>().HasKey(k => k.classRoomId);
            modelBuilder.Entity<WorkSchedule>().HasKey(k => k.scheduleId);
            modelBuilder.Entity<StaffMember>().HasKey(k => k.staffMemberId);
            modelBuilder.Entity<LeaveRequest>().HasKey(k => k.requestid);
            modelBuilder.Entity<LeaveType>().HasKey(k => k.leaveTypeID);

            //Order
            modelBuilder.Entity<Item>().HasRequired(v => v.Category).WithMany(v => v.Items).HasForeignKey(o => o.CategoryId);
            modelBuilder.Entity<Cart>().HasRequired(v => v.Item).WithMany(v => v.Carts).HasForeignKey(o => o.ItemId);
            modelBuilder.Entity<Order>().HasKey(k => k.OrderId);
            modelBuilder.Entity<Supplier>().HasKey(k => k.SupplierId);
            modelBuilder.Entity<Item>().HasKey(k => k.ItemId);

           
        }


    }
}
