﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Migrations
{
    [DbContext(typeof(MeetingContext))]
    [Migration("20181213153725_BishopricForeignKey")]
    partial class BishopricForeignKey
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SacramentMeetingPlanner.Models.Bishopric", b =>
                {
                    b.Property<int>("BishopricId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("BishopricName");

                    b.Property<int?>("PlannerId");

                    b.HasKey("BishopricId");

                    b.HasIndex("PlannerId");

                    b.ToTable("Bishopric");
                });

            modelBuilder.Entity("SacramentMeetingPlanner.Models.Planner", b =>
                {
                    b.Property<int>("PlannerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BishopricId");

                    b.Property<string>("ClosePrayer");

                    b.Property<DateTime>("MeetingDate");

                    b.Property<string>("OpenPrayer");

                    b.HasKey("PlannerId");

                    b.ToTable("Planner");
                });

            modelBuilder.Entity("SacramentMeetingPlanner.Models.Song", b =>
                {
                    b.Property<int>("SongId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CloseSongNum");

                    b.Property<string>("CloseSongTitle");

                    b.Property<int?>("InterSongNum");

                    b.Property<string>("InterSongTitle");

                    b.Property<int>("OpenSongNum");

                    b.Property<string>("OpenSongTitle");

                    b.Property<int>("PlannerId");

                    b.Property<int>("SacramentSongNum");

                    b.Property<string>("SacramentSongTitle");

                    b.HasKey("SongId");

                    b.HasIndex("PlannerId");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("SacramentMeetingPlanner.Models.Speaker", b =>
                {
                    b.Property<int>("SpeakerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PlannerId");

                    b.Property<string>("SpeakerName");

                    b.Property<string>("SpeakerTopic");

                    b.HasKey("SpeakerId");

                    b.HasIndex("PlannerId");

                    b.ToTable("Speakers");
                });

            modelBuilder.Entity("SacramentMeetingPlanner.Models.Bishopric", b =>
                {
                    b.HasOne("SacramentMeetingPlanner.Models.Planner")
                        .WithMany("Bishoprics")
                        .HasForeignKey("PlannerId");
                });

            modelBuilder.Entity("SacramentMeetingPlanner.Models.Song", b =>
                {
                    b.HasOne("SacramentMeetingPlanner.Models.Planner")
                        .WithMany("Songs")
                        .HasForeignKey("PlannerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SacramentMeetingPlanner.Models.Speaker", b =>
                {
                    b.HasOne("SacramentMeetingPlanner.Models.Planner")
                        .WithMany("Speakers")
                        .HasForeignKey("PlannerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
