﻿using BD2.API.Database.Entities;
using BD2.API.Database.ViewEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BD2.API.Database
{
    public class AppDbContext : IdentityDbContext<Account, Role, Guid>
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<AccountImage> AccountImages { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<ChatAccount> ChatAccounts { get; set; }
        public DbSet<ChatEntry> ChatEntries { get; set; }
        public DbSet<Friendship> Friendships { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupAccount> GroupAccounts { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Invitation> Invitations { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostComment> PostComments { get; set; }
        public DbSet<PostImage> PostImages { get; set; }
        public DbSet<PostReaction> PostReactions { get; set; }
        public DbSet<PostView> PostViews { get; set; }
        public DbSet<PacketSubscription> PacketSubscriptions { get; set; }
        public DbSet<Packet> Packets { get; set; }
        public DbSet<PacketGroupsLimit> PacketGroupsLimits { get; set; }
        public DbSet<PacketPeopleLimit> PacketPeopleLimits { get; set; }
        public DbSet<PacketPeriod> PacketPeriods { get; set; }
        public DbSet<GroupTopic> GroupTopics { get; set; }
        public DbSet<PostAbusement> PostAbusements { get; set; }
        
        // Stored pocedures entities
        public DbSet<PostCommentNotification> PostCommentNotifications { get; set; }
        public DbSet<PostReactionNotification> PostReactionNotifications { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            // modelBuilder.Ignore<BaseEntity>();
        }
    }
}
