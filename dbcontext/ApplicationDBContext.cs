using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SMApi.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SMApi.dbcontext
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options) { }

        public DbSet<SMUser> SMUser { get; set; }
        public DbSet<Posts> Post { get; set; }
        public DbSet<Comments> Comment { get; set; }
        public DbSet<LikeComments> LikeComments { get; set; }
        public DbSet<LikePosts> LikePosts { get; set; } 
        public DbSet<UserSecurity> UserSecurity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // smuser - user security : one to one
            modelBuilder.Entity<UserSecurity>()
                .HasOne(us=>us.sMUser)
                .WithOne(u=>u.userSecurity)
                .HasForeignKey<UserSecurity>(us=>us.userId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SMUser>()
                .HasIndex(u => u.email)
                .IsUnique();

            // user - post (one to many) 2 way navigation
            modelBuilder.Entity<Posts>()
             .HasOne(p => p.sMUsers)  
             .WithMany(u => u.posts)   
             .HasForeignKey(p => p.userId)
             .OnDelete(DeleteBehavior.Restrict);

            //user - comment : one to many
            modelBuilder.Entity<Comments>()
                .HasOne(c => c.smusers)
                .WithMany(u => u.comments)
                .HasForeignKey(c => c.userId)
                .OnDelete(DeleteBehavior.Restrict);

            //post - comment : one to many
            modelBuilder.Entity<Comments>()
                .HasOne(c=>c.post)
                .WithMany(p=>p.comments)
                .HasForeignKey(c => c.postId)
                .OnDelete(DeleteBehavior.Restrict);

            

            //one user can have many likes 
            modelBuilder.Entity<LikePosts>()
                .HasOne(lp=>lp.sMUsers)
                .WithMany(u=>u.likePosts)
                .HasForeignKey(lp=> lp.userId)
                .OnDelete(DeleteBehavior.Restrict);
            
            // one post can have many likes
            modelBuilder.Entity<LikePosts>()
                .HasOne(lp => lp.posts)
                .WithMany(p => p.likePosts)
                .HasForeignKey(lp => lp.postId)
                .OnDelete(DeleteBehavior.Cascade);

            

            //one user has many comments
            modelBuilder.Entity<LikeComments>()
                .HasOne(lc => lc.sMUsers)
                .WithMany(u => u.likeComments)
                .HasForeignKey(lc => lc.userId)
                .OnDelete(DeleteBehavior.Restrict);
            
            //one comment has many likes
            modelBuilder.Entity<LikeComments>()
            .HasOne(lc => lc.comments)
            .WithMany(c => c.likeComments)
            .HasForeignKey(lc => lc.commentId)
            .OnDelete(DeleteBehavior.Cascade);

            //So before deleting a user, you must manually:
                //1. Delete all the user’s comments.
                //2. Delete all the user’s posts.
                //3. Then delete the user itself.

            //Deleting a post will delete all its likes
            //Deleting a comment will delete all its likes
            //Deleting a user will delete all its user security

        }


    }
}
