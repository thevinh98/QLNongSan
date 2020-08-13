namespace QLNS.Models.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QLNSDbContext : DbContext
    {
        public QLNSDbContext()
            : base("name=QLNSDbContext")
        {
        }

        public virtual DbSet<account> accounts { get; set; }
        public virtual DbSet<BinhLuan> BinhLuans { get; set; }
        public virtual DbSet<ChatLuong> ChatLuongs { get; set; }
        public virtual DbSet<ChiTietOrder> ChiTietOrders { get; set; }
        public virtual DbSet<DiaLy> DiaLies { get; set; }
        public virtual DbSet<Footer> Footers { get; set; }
        public virtual DbSet<LoaiMenu> LoaiMenus { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Nhap_Xuat_ThuHoach> Nhap_Xuat_ThuHoach { get; set; }
        public virtual DbSet<NhomN> NhomNS { get; set; }
        public virtual DbSet<NongSan> NongSans { get; set; }
        public virtual DbSet<slide_anh> slide_anh { get; set; }
        public virtual DbSet<tblOrder> tblOrders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<account>()
                .Property(e => e.PassWord)
                .IsUnicode(false);

            modelBuilder.Entity<account>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<account>()
                .HasMany(e => e.BinhLuans)
                .WithRequired(e => e.account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BinhLuan>()
                .Property(e => e.ma_ns)
                .IsUnicode(false);

            modelBuilder.Entity<ChatLuong>()
                .Property(e => e.ma_chat_luong)
                .IsUnicode(false);

            modelBuilder.Entity<ChatLuong>()
                .HasMany(e => e.NongSans)
                .WithOptional(e => e.ChatLuong)
                .WillCascadeOnDelete();

            modelBuilder.Entity<ChiTietOrder>()
                .Property(e => e.ma_ns)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietOrder>()
                .Property(e => e.gia)
                .HasPrecision(18, 3);

            modelBuilder.Entity<DiaLy>()
                .Property(e => e.ma_vi_tri)
                .IsUnicode(false);

            modelBuilder.Entity<DiaLy>()
                .HasMany(e => e.NongSans)
                .WithOptional(e => e.DiaLy)
                .WillCascadeOnDelete();

            modelBuilder.Entity<LoaiMenu>()
                .HasMany(e => e.Menus)
                .WithOptional(e => e.LoaiMenu)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Menu>()
                .Property(e => e.link)
                .IsUnicode(false);

            modelBuilder.Entity<Nhap_Xuat_ThuHoach>()
                .Property(e => e.ma_nx_th)
                .IsUnicode(false);

            modelBuilder.Entity<Nhap_Xuat_ThuHoach>()
                .Property(e => e.ma_ns)
                .IsUnicode(false);

            modelBuilder.Entity<Nhap_Xuat_ThuHoach>()
                .Property(e => e.don_gia_nhap)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Nhap_Xuat_ThuHoach>()
                .Property(e => e.don_gia_xuat)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NhomN>()
                .Property(e => e.ma_nhom_ns)
                .IsUnicode(false);

            modelBuilder.Entity<NhomN>()
                .Property(e => e.tieu_de_url)
                .IsUnicode(false);

            modelBuilder.Entity<NhomN>()
                .Property(e => e.ID_cha)
                .IsUnicode(false);

            modelBuilder.Entity<NhomN>()
                .Property(e => e.tieu_de_tk)
                .IsUnicode(false);

            modelBuilder.Entity<NhomN>()
                .HasMany(e => e.NongSans)
                .WithOptional(e => e.NhomN)
                .WillCascadeOnDelete();

            modelBuilder.Entity<NongSan>()
                .Property(e => e.ma_ns)
                .IsUnicode(false);

            modelBuilder.Entity<NongSan>()
                .Property(e => e.hinh_anh)
                .IsUnicode(false);

            modelBuilder.Entity<NongSan>()
                .Property(e => e.gia_goc)
                .HasPrecision(18, 3);

            modelBuilder.Entity<NongSan>()
                .Property(e => e.gia_km)
                .HasPrecision(18, 3);

            modelBuilder.Entity<NongSan>()
                .Property(e => e.ma_nhom_ns)
                .IsUnicode(false);

            modelBuilder.Entity<NongSan>()
                .Property(e => e.ma_chat_luong)
                .IsUnicode(false);

            modelBuilder.Entity<NongSan>()
                .Property(e => e.ma_vi_tri)
                .IsUnicode(false);

            modelBuilder.Entity<NongSan>()
                .HasMany(e => e.BinhLuans)
                .WithRequired(e => e.NongSan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblOrder>()
                .Property(e => e.sdt_kh)
                .IsUnicode(false);

            modelBuilder.Entity<tblOrder>()
                .Property(e => e.email_kh)
                .IsUnicode(false);

            modelBuilder.Entity<tblOrder>()
                .HasMany(e => e.ChiTietOrders)
                .WithRequired(e => e.tblOrder)
                .HasForeignKey(e => e.order_id);
        }
    }
}
