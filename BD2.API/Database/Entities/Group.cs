﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BD2.API.Database.Entities
{
    public class Group
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        
        public DateTime CreatedDate { get; set; }
        public DateTime? LastPostDate { get; set; }
        [JsonIgnore]
        public ICollection<GroupAccount> Members { get; set; }
        [JsonIgnore]
        public ICollection<Post> Posts { get; set; }
        [JsonIgnore]
        public PacketSubscription Subscription { get; set; }
        public Guid? SubscriptionId { get; set; }
        [JsonIgnore]
        public GroupTopic GroupTopicObject { get; set; }
        public string GroupTopic { get; set; }
    }

    public class GroupConfig : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("NEWSEQUENTIALID ()");

            builder.Property(x => x.Name).HasMaxLength(200);

            builder.Property(x => x.CreatedDate)
                .HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.GroupTopic).HasMaxLength(100);
            builder.HasOne(x => x.GroupTopicObject)
                .WithMany()
                .HasForeignKey(x => x.GroupTopic)
                .OnDelete(DeleteBehavior.SetNull);

        }
    }
}
