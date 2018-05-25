﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using Tournaments.Data.Core.Context;

namespace Tournaments.Data.Core.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20180525133150_Add_Team_Series_Match_Tournament_Entities")]
    partial class Add_Team_Series_Match_Tournament_Entities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Tournaments.Data.Entities.HelperTables.TeamTournament", b =>
                {
                    b.Property<int>("TeamId");

                    b.Property<int>("TournamentId");

                    b.HasKey("TeamId", "TournamentId");

                    b.HasIndex("TournamentId");

                    b.ToTable("TeamTournament");
                });

            modelBuilder.Entity("Tournaments.Data.Entities.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DireTeamId");

                    b.Property<bool>("IsRadiantWin");

                    b.Property<int>("RadiantTeamId");

                    b.Property<int>("SeriesId");

                    b.Property<int?>("TeamId");

                    b.HasKey("Id");

                    b.HasIndex("DireTeamId");

                    b.HasIndex("RadiantTeamId");

                    b.HasIndex("SeriesId");

                    b.HasIndex("TeamId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("Tournaments.Data.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Country");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("PhotoUrl");

                    b.Property<int>("Points");

                    b.Property<int?>("PositionId");

                    b.Property<int?>("TeamId");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Tournaments.Data.Entities.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("Tournaments.Data.Entities.Series", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("SeriesTypeId");

                    b.Property<int>("TournamentId");

                    b.HasKey("Id");

                    b.HasIndex("SeriesTypeId");

                    b.HasIndex("TournamentId");

                    b.ToTable("Series");
                });

            modelBuilder.Entity("Tournaments.Data.Entities.SeriesType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("SeriesTypes");
                });

            modelBuilder.Entity("Tournaments.Data.Entities.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("PhotoUrl");

                    b.Property<decimal>("Revenue");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Tournaments.Data.Entities.Tournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Name");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("Tournaments.Data.Entities.HelperTables.TeamTournament", b =>
                {
                    b.HasOne("Tournaments.Data.Entities.Team", "Team")
                        .WithMany("TeamTournament")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Tournaments.Data.Entities.Tournament", "Tournament")
                        .WithMany("TeamTournament")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Tournaments.Data.Entities.Match", b =>
                {
                    b.HasOne("Tournaments.Data.Entities.Team", "DireTeam")
                        .WithMany()
                        .HasForeignKey("DireTeamId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Tournaments.Data.Entities.Team", "RadiantTeam")
                        .WithMany()
                        .HasForeignKey("RadiantTeamId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Tournaments.Data.Entities.Series", "Series")
                        .WithMany("Matches")
                        .HasForeignKey("SeriesId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Tournaments.Data.Entities.Team")
                        .WithMany("Matches")
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("Tournaments.Data.Entities.Player", b =>
                {
                    b.HasOne("Tournaments.Data.Entities.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId");

                    b.HasOne("Tournaments.Data.Entities.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("Tournaments.Data.Entities.Series", b =>
                {
                    b.HasOne("Tournaments.Data.Entities.SeriesType", "SeriesType")
                        .WithMany()
                        .HasForeignKey("SeriesTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Tournaments.Data.Entities.Tournament", "Tournament")
                        .WithMany("Series")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
