using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BefolkPostGres.Models
{
    public partial class egedalContext : DbContext
    {
        public egedalContext()
        {
        }

        public egedalContext(DbContextOptions<egedalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CprBefolkningSamlet> CprBefolkningSamlet { get; set; }
        public virtual DbSet<CprPrognoseSamlet> CprPrognoseSamlet { get; set; }
        public virtual DbSet<CprPrognoseSamlet1> CprPrognoseSamlet1 { get; set; }
        public virtual DbSet<CprPrognoseSamlet2> CprPrognoseSamlet2 { get; set; }
        public virtual DbSet<CprPrognoseSamlet3> CprPrognoseSamlet3 { get; set; }
        public virtual DbSet<CprPrognoseSamlet4> CprPrognoseSamlet4 { get; set; }
        public virtual DbSet<CprPrognoseSamletTest> CprPrognoseSamletTest { get; set; }
        public virtual DbSet<PrognoseHardcodet> PrognoseHardcodet { get; set; }
        public virtual DbSet<Skolestoerrelse> Skolestoerrelse { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=10.192.144.48;Port=5432;Database=egedal; User Id=egedal;Password=GsYrICM4nA9j;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("adminpack")
                .HasPostgresExtension("pg_stat_statements")
                .HasPostgresExtension("pgrouting")
                .HasPostgresExtension("postgis")
                .HasPostgresExtension("postgres_fdw")
                .HasPostgresExtension("uuid-ossp");

            modelBuilder.Entity<CprBefolkningSamlet>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CPR_Befolkning_Samlet", "flis");

                entity.Property(e => e.Alder).HasColumnName("alder");

                entity.Property(e => e.Befolkdisttext)
                    .HasColumnName("befolkdisttext")
                    .HasMaxLength(30);

                entity.Property(e => e.Befolkkod)
                    .HasColumnName("befolkkod")
                    .HasColumnType("numeric(8,0)");

                entity.Property(e => e.Civilstand)
                    .HasColumnName("civilstand")
                    .HasMaxLength(1);

                entity.Property(e => e.Cpr)
                    .HasColumnName("cpr")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Foedestedstekst)
                    .HasColumnName("foedestedstekst")
                    .HasMaxLength(20);

                entity.Property(e => e.HusNr)
                    .HasColumnName("hus_nr")
                    .HasMaxLength(4);

                entity.Property(e => e.HusNr1)
                    .HasColumnName("hus_nr1")
                    .HasMaxLength(4);

                entity.Property(e => e.KommuneNr).HasColumnName("kommune_nr");

                entity.Property(e => e.Koornord).HasColumnName("koornord");

                entity.Property(e => e.Kooroest).HasColumnName("kooroest");

                entity.Property(e => e.Pnr)
                    .HasColumnName("pnr")
                    .HasColumnType("numeric(11,0)");

                entity.Property(e => e.Skoledisttext)
                    .HasColumnName("skoledisttext")
                    .HasMaxLength(30);

                entity.Property(e => e.Skolekod)
                    .HasColumnName("skolekod")
                    .HasColumnType("numeric(8,0)");

                entity.Property(e => e.Tidligerekommune)
                    .HasColumnName("tidligerekommune")
                    .HasMaxLength(20);

                entity.Property(e => e.Tilflytningsdatomarkering)
                    .HasColumnName("tilflytningsdatomarkering")
                    .HasMaxLength(1);

                entity.Property(e => e.VejKode).HasColumnName("vej_kode");

                entity.Property(e => e.VejKode1).HasColumnName("vej_kode1");
            });

            modelBuilder.Entity<CprPrognoseSamlet>(entity =>
            {
                entity.HasKey(e => e.AarMaaned)
                    .HasName("CPR_Prognose_Samlet_pkey");

                entity.ToTable("CPR_Prognose_Samlet", "flis");

                entity.Property(e => e.AarMaaned)
                    .HasColumnName("aar_maaned")
                    .ValueGeneratedNever();

                entity.Property(e => e.Aarstal).HasColumnName("aarstal");

                entity.Property(e => e.Maaned).HasColumnName("maaned");

                entity.Property(e => e._0).HasColumnName("0");

                entity.Property(e => e._02).HasColumnName("0_2");

                entity.Property(e => e._1).HasColumnName("1");

                entity.Property(e => e._1724).HasColumnName("17_24");

                entity.Property(e => e._2564).HasColumnName("25_64");

                entity.Property(e => e._35).HasColumnName("3_5");

                entity.Property(e => e._616).HasColumnName("6_16");

                entity.Property(e => e._6574).HasColumnName("65_74");

                entity.Property(e => e._7584).HasColumnName("75_84");

                entity.Property(e => e._85).HasColumnName("85_");
                entity.Property(e => e.Sum).HasColumnName("sum");
            });

            modelBuilder.Entity<CprPrognoseSamlet1>(entity =>
            {
                entity.HasKey(e => e.AarMaaned)
                    .HasName("CPR_Prognose_Samlet_1_pkey");

                entity.ToTable("CPR_Prognose_Samlet_1", "flis");

                entity.Property(e => e.AarMaaned)
                    .HasColumnName("aar_maaned")
                    .ValueGeneratedNever();

                entity.Property(e => e.Aarstal).HasColumnName("aarstal");

                entity.Property(e => e.Maaned).HasColumnName("maaned");

                entity.Property(e => e._0).HasColumnName("0");

                entity.Property(e => e._02).HasColumnName("0_2");

                entity.Property(e => e._1).HasColumnName("1");

                entity.Property(e => e._1724).HasColumnName("17_24");

                entity.Property(e => e._2564).HasColumnName("25_64");

                entity.Property(e => e._35).HasColumnName("3_5");

                entity.Property(e => e._616).HasColumnName("6_16");

                entity.Property(e => e._6574).HasColumnName("65_74");

                entity.Property(e => e._7584).HasColumnName("75_84");

                entity.Property(e => e._85).HasColumnName("85_");
                entity.Property(e => e.Sum).HasColumnName("sum");
            });

            modelBuilder.Entity<CprPrognoseSamlet2>(entity =>
            {
                entity.HasKey(e => e.AarMaaned)
                    .HasName("CPR_Prognose_Samlet_2_pkey");

                entity.ToTable("CPR_Prognose_Samlet_2", "flis");

                entity.Property(e => e.AarMaaned)
                    .HasColumnName("aar_maaned")
                    .ValueGeneratedNever();

                entity.Property(e => e.Aarstal).HasColumnName("aarstal");

                entity.Property(e => e.Maaned).HasColumnName("maaned");

                entity.Property(e => e._0).HasColumnName("0");

                entity.Property(e => e._02).HasColumnName("0_2");

                entity.Property(e => e._1).HasColumnName("1");

                entity.Property(e => e._1724).HasColumnName("17_24");

                entity.Property(e => e._2564).HasColumnName("25_64");

                entity.Property(e => e._35).HasColumnName("3_5");

                entity.Property(e => e._616).HasColumnName("6_16");

                entity.Property(e => e._6574).HasColumnName("65_74");

                entity.Property(e => e._7584).HasColumnName("75_84");

                entity.Property(e => e._85).HasColumnName("85_");
                entity.Property(e => e.Sum).HasColumnName("sum");
            });

            modelBuilder.Entity<CprPrognoseSamlet3>(entity =>
            {
                entity.HasKey(e => e.AarMaaned)
                    .HasName("CPR_Prognose_Samlet_3_pkey");

                entity.ToTable("CPR_Prognose_Samlet_3", "flis");

                entity.Property(e => e.AarMaaned)
                    .HasColumnName("aar_maaned")
                    .ValueGeneratedNever();

                entity.Property(e => e.Aarstal).HasColumnName("aarstal");

                entity.Property(e => e.Maaned).HasColumnName("maaned");

                entity.Property(e => e._0).HasColumnName("0");

                entity.Property(e => e._02).HasColumnName("0_2");

                entity.Property(e => e._1).HasColumnName("1");

                entity.Property(e => e._1724).HasColumnName("17_24");

                entity.Property(e => e._2564).HasColumnName("25_64");

                entity.Property(e => e._35).HasColumnName("3_5");

                entity.Property(e => e._616).HasColumnName("6_16");

                entity.Property(e => e._6574).HasColumnName("65_74");

                entity.Property(e => e._7584).HasColumnName("75_84");

                entity.Property(e => e._85).HasColumnName("85_");
                entity.Property(e => e.Sum).HasColumnName("sum");
            });

            modelBuilder.Entity<CprPrognoseSamlet4>(entity =>
            {
                entity.HasKey(e => e.AarMaaned)
                    .HasName("CPR_Prognose_Samlet_4_pkey");

                entity.ToTable("CPR_Prognose_Samlet_4", "flis");

                entity.Property(e => e.AarMaaned)
                    .HasColumnName("aar_maaned")
                    .ValueGeneratedNever();

                entity.Property(e => e.Aarstal).HasColumnName("aarstal");

                entity.Property(e => e.Maaned).HasColumnName("maaned");

                entity.Property(e => e._0).HasColumnName("0");

                entity.Property(e => e._02).HasColumnName("0_2");

                entity.Property(e => e._1).HasColumnName("1");

                entity.Property(e => e._1724).HasColumnName("17_24");

                entity.Property(e => e._2564).HasColumnName("25_64");

                entity.Property(e => e._35).HasColumnName("3_5");

                entity.Property(e => e._616).HasColumnName("6_16");

                entity.Property(e => e._6574).HasColumnName("65_74");

                entity.Property(e => e._7584).HasColumnName("75_84");

                entity.Property(e => e._85).HasColumnName("85_");
                entity.Property(e => e.Sum).HasColumnName("sum");
            });

            modelBuilder.Entity<CprPrognoseSamletTest>(entity =>
            {
                entity.HasKey(e => e.AarMaaned)
                    .HasName("CPR_Prognose_Samlet_Test_pkey");

                entity.ToTable("CPR_PROGNOSE_SAMLET_TEST", "flis");

                entity.Property(e => e.AarMaaned)
                    .HasColumnName("aar_maaned")
                    .ValueGeneratedNever();

                entity.Property(e => e.Aarstal).HasColumnName("aarstal");

                entity.Property(e => e.Maaned).HasColumnName("maaned");

                entity.Property(e => e._02).HasColumnName("_0_2");

                entity.Property(e => e._1724).HasColumnName("_17_24");

                entity.Property(e => e._2564).HasColumnName("_25_64");

                entity.Property(e => e._35).HasColumnName("_3_5");

                entity.Property(e => e._616).HasColumnName("_6_16");

                entity.Property(e => e._6574).HasColumnName("_65_74");

                entity.Property(e => e._7584).HasColumnName("_75_84");

                entity.Property(e => e._85).HasColumnName("_85_");
            });

            modelBuilder.Entity<PrognoseHardcodet>(entity =>
            {
                entity.ToTable("PROGNOSE_hardcodet", "flis");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Aarstal).HasColumnName("aarstal");

                entity.Property(e => e.Alder0).HasColumnName("alder_0");

                entity.Property(e => e.Alder02).HasColumnName("alder_0_2");

                entity.Property(e => e.Alder1).HasColumnName("alder_1");

                entity.Property(e => e.Alder1724).HasColumnName("alder_17_24");

                entity.Property(e => e.Alder2564).HasColumnName("alder_25_64");

                entity.Property(e => e.Alder35).HasColumnName("alder_3_5");

                entity.Property(e => e.Alder616).HasColumnName("alder_6_16");

                entity.Property(e => e.Alder6574).HasColumnName("alder_65_74");

                entity.Property(e => e.Alder7584).HasColumnName("alder_75_84");

                entity.Property(e => e.Alder85).HasColumnName("alder_85");

                entity.Property(e => e.Maaned)
                    .HasColumnName("maaned")
                    .HasMaxLength(10);

                entity.Property(e => e.Omraade)
                    .HasColumnName("omraade")
                    .HasMaxLength(10);

                entity.Property(e => e.Sum).HasColumnName("sum");
            });

            modelBuilder.Entity<Skolestoerrelse>(entity =>
            {
                entity.HasKey(e => e.OgcFid)
                    .HasName("skolestoerrelse_pkey");

                entity.ToTable("skolestoerrelse", "flis");

                entity.Property(e => e.OgcFid).HasColumnName("ogc_fid");

                entity.Property(e => e.FlisGnsSkolestoerrelse).HasColumnName("flis_gns_skolestoerrelse");

                entity.Property(e => e.FlisKommune)
                    .HasColumnName("flis_kommune")
                    .HasMaxLength(200)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
