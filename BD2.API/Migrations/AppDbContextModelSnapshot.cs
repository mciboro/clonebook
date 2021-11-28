﻿// <auto-generated />
using System;
using BD2.API.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BD2.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BD2.API.Database.Entities.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.AccountImage", b =>
                {
                    b.Property<Guid>("ImageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ImageId", "AccountId");

                    b.HasIndex("AccountId");

                    b.ToTable("AccountImages");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID ()");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID ()");

                    b.Property<Guid>("AuthoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthoId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.Chat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID ()");

                    b.Property<DateTime?>("LastPostDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Name")
                        .HasMaxLength(200)
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.ChatAccount", b =>
                {
                    b.Property<Guid>("ChatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ChatId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsAdmin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("LastViewDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ChatId", "AccountId");

                    b.HasIndex("AccountId");

                    b.HasIndex("ChatId1");

                    b.ToTable("ChatAccounts");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.ChatEntry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID ()");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ChatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ChatId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("PostDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("ChatId");

                    b.HasIndex("ChatId1");

                    b.ToTable("ChatEntries");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.Friendship", b =>
                {
                    b.Property<Guid>("FirstFriendId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SecondFriendId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("FriendshipBeginDate")
                        .HasColumnType("datetime2");

                    b.HasKey("FirstFriendId", "SecondFriendId");

                    b.HasIndex("SecondFriendId");

                    b.ToTable("Friendships");

                    b.HasCheckConstraint("NotSelfFriends_Friendship_constraint", "FirstFriendId <> SecondFriendId");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.Group", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID ()");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("LastPostDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<Guid?>("SubscriptionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SubscriptionId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.GroupAccount", b =>
                {
                    b.Property<Guid>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("GroupId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsAdmin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("LastViewDate")
                        .HasColumnType("datetime2");

                    b.HasKey("GroupId", "AccountId");

                    b.HasIndex("AccountId");

                    b.HasIndex("GroupId1");

                    b.ToTable("GroupAccounts");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<byte[]>("Binary")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("MimeType")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("PostDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.Invitation", b =>
                {
                    b.Property<Guid>("InvitingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("InvitedId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("InvitationSendAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("InvitingId", "InvitedId");

                    b.HasIndex("InvitedId");

                    b.ToTable("Invitations");

                    b.HasCheckConstraint("NotSelfInvited_Friendship_constraint", "InvitingId <> InvitedId");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.Packet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID ()");

                    b.Property<int>("GroupsLimit")
                        .HasColumnType("int");

                    b.Property<bool>("IsValid")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("PacketPeriod")
                        .HasColumnType("int");

                    b.Property<int>("PeopleLimit")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("Id");

                    b.HasIndex("GroupsLimit");

                    b.HasIndex("PacketPeriod");

                    b.HasIndex("PeopleLimit");

                    b.ToTable("Packets");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.PacketGroupsLimit", b =>
                {
                    b.Property<int>("GroupsLimit")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("GroupsLimit");

                    b.ToTable("PacketGroupsLimits");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.PacketPeopleLimit", b =>
                {
                    b.Property<int>("PeopleLimit")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("PeopleLimit");

                    b.ToTable("PacketPeopleLimits");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.PacketPeriod", b =>
                {
                    b.Property<int>("MonthsPeriod")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("MonthsPeriod");

                    b.ToTable("PacketPeriods");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.PacketSubscription", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID ()");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("date");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PacketId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("PacketId");

                    b.ToTable("PacketSubscriptions");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID ()");

                    b.Property<int>("CommentsCount")
                        .HasColumnType("int");

                    b.Property<Guid?>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("LastCommentDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastOwnerViewDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastReactionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("NegativeReactionCount")
                        .HasColumnType("int");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PositiveReactionsCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("PostDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("ViewsCounts")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.PostComment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID ()");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CommentDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("PostId");

                    b.ToTable("PostComments");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.PostImage", b =>
                {
                    b.Property<Guid>("ImageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ImageId", "PostId");

                    b.HasIndex("PostId");

                    b.ToTable("PostImages");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.PostReaction", b =>
                {
                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ReactionDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("AccountId", "PostId");

                    b.HasIndex("PostId");

                    b.ToTable("PostReactions");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.PostView", b =>
                {
                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ViewDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("AccountId", "PostId");

                    b.HasIndex("PostId");

                    b.ToTable("PostViews");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.AccountImage", b =>
                {
                    b.HasOne("BD2.API.Database.Entities.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BD2.API.Database.Entities.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.Book", b =>
                {
                    b.HasOne("BD2.API.Database.Entities.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.ChatAccount", b =>
                {
                    b.HasOne("BD2.API.Database.Entities.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .IsRequired();

                    b.HasOne("BD2.API.Database.Entities.Chat", "Chat")
                        .WithMany()
                        .HasForeignKey("ChatId")
                        .IsRequired();

                    b.HasOne("BD2.API.Database.Entities.Chat", null)
                        .WithMany("Members")
                        .HasForeignKey("ChatId1");

                    b.Navigation("Account");

                    b.Navigation("Chat");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.ChatEntry", b =>
                {
                    b.HasOne("BD2.API.Database.Entities.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .IsRequired();

                    b.HasOne("BD2.API.Database.Entities.Chat", "Chat")
                        .WithMany()
                        .HasForeignKey("ChatId")
                        .IsRequired();

                    b.HasOne("BD2.API.Database.Entities.Chat", null)
                        .WithMany("Entries")
                        .HasForeignKey("ChatId1");

                    b.Navigation("Account");

                    b.Navigation("Chat");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.Friendship", b =>
                {
                    b.HasOne("BD2.API.Database.Entities.Account", "FirstFriend")
                        .WithMany("Friendships")
                        .HasForeignKey("FirstFriendId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("BD2.API.Database.Entities.Account", "SecondFriend")
                        .WithMany()
                        .HasForeignKey("SecondFriendId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("FirstFriend");

                    b.Navigation("SecondFriend");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.Group", b =>
                {
                    b.HasOne("BD2.API.Database.Entities.PacketSubscription", "Subscription")
                        .WithMany("Groups")
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Subscription");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.GroupAccount", b =>
                {
                    b.HasOne("BD2.API.Database.Entities.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .IsRequired();

                    b.HasOne("BD2.API.Database.Entities.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .IsRequired();

                    b.HasOne("BD2.API.Database.Entities.Group", null)
                        .WithMany("Members")
                        .HasForeignKey("GroupId1");

                    b.Navigation("Account");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.Invitation", b =>
                {
                    b.HasOne("BD2.API.Database.Entities.Account", "Invited")
                        .WithMany("Invitations")
                        .HasForeignKey("InvitedId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("BD2.API.Database.Entities.Account", "Inviting")
                        .WithMany()
                        .HasForeignKey("InvitingId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Invited");

                    b.Navigation("Inviting");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.Packet", b =>
                {
                    b.HasOne("BD2.API.Database.Entities.PacketGroupsLimit", "GroupsLimitObject")
                        .WithMany()
                        .HasForeignKey("GroupsLimit")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BD2.API.Database.Entities.PacketPeriod", "PacketPeriodObject")
                        .WithMany()
                        .HasForeignKey("PacketPeriod")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BD2.API.Database.Entities.PacketPeopleLimit", "PeopleLimitObject")
                        .WithMany()
                        .HasForeignKey("PeopleLimit")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("GroupsLimitObject");

                    b.Navigation("PacketPeriodObject");

                    b.Navigation("PeopleLimitObject");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.PacketSubscription", b =>
                {
                    b.HasOne("BD2.API.Database.Entities.Account", "Owner")
                        .WithMany("Subscriptions")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BD2.API.Database.Entities.Packet", "Packet")
                        .WithMany()
                        .HasForeignKey("PacketId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Owner");

                    b.Navigation("Packet");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.Post", b =>
                {
                    b.HasOne("BD2.API.Database.Entities.Group", "Group")
                        .WithMany("Posts")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BD2.API.Database.Entities.Account", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.PostComment", b =>
                {
                    b.HasOne("BD2.API.Database.Entities.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .IsRequired();

                    b.HasOne("BD2.API.Database.Entities.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.PostImage", b =>
                {
                    b.HasOne("BD2.API.Database.Entities.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId")
                        .IsRequired();

                    b.HasOne("BD2.API.Database.Entities.Post", "Post")
                        .WithMany("Images")
                        .HasForeignKey("PostId")
                        .IsRequired();

                    b.Navigation("Image");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.PostReaction", b =>
                {
                    b.HasOne("BD2.API.Database.Entities.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .IsRequired();

                    b.HasOne("BD2.API.Database.Entities.Post", "Post")
                        .WithMany("Reactions")
                        .HasForeignKey("PostId")
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.PostView", b =>
                {
                    b.HasOne("BD2.API.Database.Entities.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .IsRequired();

                    b.HasOne("BD2.API.Database.Entities.Post", "Post")
                        .WithMany("Views")
                        .HasForeignKey("PostId")
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("BD2.API.Database.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("BD2.API.Database.Entities.Account", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("BD2.API.Database.Entities.Account", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("BD2.API.Database.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BD2.API.Database.Entities.Account", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("BD2.API.Database.Entities.Account", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BD2.API.Database.Entities.Account", b =>
                {
                    b.Navigation("Friendships");

                    b.Navigation("Invitations");

                    b.Navigation("Subscriptions");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.Chat", b =>
                {
                    b.Navigation("Entries");

                    b.Navigation("Members");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.Group", b =>
                {
                    b.Navigation("Members");

                    b.Navigation("Posts");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.PacketSubscription", b =>
                {
                    b.Navigation("Groups");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.Post", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Images");

                    b.Navigation("Reactions");

                    b.Navigation("Views");
                });
#pragma warning restore 612, 618
        }
    }
}
