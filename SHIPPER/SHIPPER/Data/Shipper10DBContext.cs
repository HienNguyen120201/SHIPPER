using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SHIPPER.Data.Entities;

namespace SHIPPER.Data
{
    public partial class Shipper10DBContext : DbContext
    {
        public Shipper10DBContext()
        {
        }

        public Shipper10DBContext(DbContextOptions<Shipper10DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChiNhanh> ChiNhanh { get; set; }
        public virtual DbSet<ChiTietDonMonAn> ChiTietDonMonAn { get; set; }
        public virtual DbSet<DanhGiaNhaHang> DanhGiaNhaHang { get; set; }
        public virtual DbSet<DanhGiaShipper> DanhGiaShipper { get; set; }
        public virtual DbSet<DonGiaoHangGiup> DonGiaoHangGiup { get; set; }
        public virtual DbSet<DonKhieuNai> DonKhieuNai { get; set; }
        public virtual DbSet<DonKhuyenMai> DonKhuyenMai { get; set; }
        public virtual DbSet<DonMonAn> DonMonAn { get; set; }
        public virtual DbSet<DonVanChuyen> DonVanChuyen { get; set; }
        public virtual DbSet<HangVanChuyen> HangVanChuyen { get; set; }
        public virtual DbSet<KhachHang> KhachHang { get; set; }
        public virtual DbSet<KhieuNai> KhieuNai { get; set; }
        public virtual DbSet<MaKhuyenMai> MaKhuyenMai { get; set; }
        public virtual DbSet<MonAn> MonAn { get; set; }
        public virtual DbSet<NhaHang> NhaHang { get; set; }
        public virtual DbSet<NhanGiaoHangDvcPtSp> NhanGiaoHangDvcPtSp { get; set; }
        public virtual DbSet<NhanVien> NhanVien { get; set; }
        public virtual DbSet<NhanVienChiNhanh> NhanVienChiNhanh { get; set; }
        public virtual DbSet<PhuongThucThanhToan> PhuongThucThanhToan { get; set; }
        public virtual DbSet<PhuongTien> PhuongTien { get; set; }
        public virtual DbSet<QuanLi> QuanLi { get; set; }
        public virtual DbSet<QuyTrachNhiem> QuyTrachNhiem { get; set; }
        public virtual DbSet<SdtKhachHang> SdtKhachHang { get; set; }
        public virtual DbSet<SdtnhaHang> SdtnhaHang { get; set; }
        public virtual DbSet<Shipper> Shipper { get; set; }
        public virtual DbSet<TongDaiVien> TongDaiVien { get; set; }
        public virtual DbSet<TrangThaiDon> TrangThaiDon { get; set; }
        public virtual DbSet<TuVanGiaiDap> TuVanGiaiDap { get; set; }
        public virtual DbSet<UuDai> UuDai { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiNhanh>(entity =>
            {
                entity.HasKey(e => e.MaDonVi)
                    .HasName("PK__ChiNhanh__B103E26C9E4DDDC6");

                entity.HasOne(d => d.MaChiNhanhChaNavigation)
                    .WithMany(p => p.InverseMaChiNhanhChaNavigation)
                    .HasForeignKey(d => d.MaChiNhanhCha)
                    .HasConstraintName("FK_ChiNhanhChiNhanh");

                entity.HasOne(d => d.MaNvquanLyNavigation)
                    .WithMany(p => p.ChiNhanh)
                    .HasForeignKey(d => d.MaNvquanLy)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ChiNhanhQuanLi");
            });

            modelBuilder.Entity<ChiTietDonMonAn>(entity =>
            {
                entity.HasKey(e => new { e.MaDonMonAn, e.MaMonAn })
                    .HasName("PK__ChiTietD__3FC302289571B000");

                entity.Property(e => e.ApDungUuDai).HasDefaultValueSql("((0))");

                entity.Property(e => e.SoLuong).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.MaDonMonAnNavigation)
                    .WithMany(p => p.ChiTietDonMonAn)
                    .HasForeignKey(d => d.MaDonMonAn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ChiTietDo__maDon__06CD04F7");

                entity.HasOne(d => d.MaMonAnNavigation)
                    .WithMany(p => p.ChiTietDonMonAn)
                    .HasForeignKey(d => d.MaMonAn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ChiTietDo__maMon__07C12930");
            });

            modelBuilder.Entity<DanhGiaNhaHang>(entity =>
            {
                entity.HasKey(e => new { e.MaNhaHang, e.MaKhachHang, e.NgayDanhGia })
                    .HasName("PK__DanhGiaN__A426E549D90F3B60");

                entity.Property(e => e.NgayDanhGia).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.MaKhachHangNavigation)
                    .WithMany(p => p.DanhGiaNhaHang)
                    .HasForeignKey(d => d.MaKhachHang)
                    .HasConstraintName("fk_maKhachHangN");

                entity.HasOne(d => d.MaNhaHangNavigation)
                    .WithMany(p => p.DanhGiaNhaHang)
                    .HasForeignKey(d => d.MaNhaHang)
                    .HasConstraintName("fk_maNhaHang");
            });

            modelBuilder.Entity<DanhGiaShipper>(entity =>
            {
                entity.HasKey(e => new { e.MaShipper, e.MaKhachHang, e.NgayDanhGia })
                    .HasName("PK__DanhGiaS__98C7B7BE57A7A386");

                entity.Property(e => e.NgayDanhGia).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.MaKhachHangNavigation)
                    .WithMany(p => p.DanhGiaShipper)
                    .HasForeignKey(d => d.MaKhachHang)
                    .HasConstraintName("fk_maKhachHang");

                entity.HasOne(d => d.MaShipperNavigation)
                    .WithMany(p => p.DanhGiaShipper)
                    .HasForeignKey(d => d.MaShipper)
                    .HasConstraintName("fk_maShipperD");
            });

            modelBuilder.Entity<DonGiaoHangGiup>(entity =>
            {
                entity.HasKey(e => e.MaDon)
                    .HasName("PK__DonGiaoH__2431086D077E06D5");

                entity.Property(e => e.MaDon).ValueGeneratedNever();

                entity.HasOne(d => d.MaDonNavigation)
                    .WithOne(p => p.DonGiaoHangGiup)
                    .HasForeignKey<DonGiaoHangGiup>(d => d.MaDon)
                    .HasConstraintName("fk_idDonGiaoHangGiup");
            });

            modelBuilder.Entity<DonKhieuNai>(entity =>
            {
                entity.HasKey(e => e.MaDonKhieuNai)
                    .HasName("PK__DonKhieu__CB9803BE4F82B593");

                entity.HasOne(d => d.MaQuanLyKiemDuyetNavigation)
                    .WithMany(p => p.DonKhieuNai)
                    .HasForeignKey(d => d.MaQuanLyKiemDuyet)
                    .HasConstraintName("FK_DonKhieuNaiQuanLi");
            });

            modelBuilder.Entity<DonKhuyenMai>(entity =>
            {
                entity.HasKey(e => e.MaKhuyenMai)
                    .HasName("PK__DonKhuye__87BEDDE9C3BA40C3");

                entity.Property(e => e.MaKhuyenMai).ValueGeneratedNever();

                entity.HasOne(d => d.MaDonNavigation)
                    .WithMany(p => p.DonKhuyenMai)
                    .HasForeignKey(d => d.MaDon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DonKhuyen__maDon__09A971A2");

                entity.HasOne(d => d.MaKhuyenMaiNavigation)
                    .WithOne(p => p.DonKhuyenMai)
                    .HasForeignKey<DonKhuyenMai>(d => d.MaKhuyenMai)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DonKhuyen__maKhu__08B54D69");
            });

            modelBuilder.Entity<DonMonAn>(entity =>
            {
                entity.HasKey(e => e.MaDon)
                    .HasName("PK__DonMonAn__2431086D1123651F");

                entity.Property(e => e.MaDon).ValueGeneratedNever();

                entity.HasOne(d => d.MaDonNavigation)
                    .WithOne(p => p.DonMonAn)
                    .HasForeignKey<DonMonAn>(d => d.MaDon)
                    .HasConstraintName("fk_idDonMonAn");
            });

            modelBuilder.Entity<DonVanChuyen>(entity =>
            {
                entity.HasKey(e => e.MaDon)
                    .HasName("PK__DonVanCh__2431086D1BDB5F73");

                entity.Property(e => e.TienShip).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.MaKhachHangNavigation)
                    .WithMany(p => p.DonVanChuyen)
                    .HasForeignKey(d => d.MaKhachHang)
                    .HasConstraintName("FK__DonVanChu__maKha__3864608B");

                entity.HasOne(d => d.MaPhuongThucThanhToanNavigation)
                    .WithMany(p => p.DonVanChuyen)
                    .HasForeignKey(d => d.MaPhuongThucThanhToan)
                    .HasConstraintName("FK__DonVanChu__phuon__1CBC4616");

                entity.HasOne(d => d.MaTrangThaiDonHangNavigation)
                    .WithMany(p => p.DonVanChuyen)
                    .HasForeignKey(d => d.MaTrangThaiDonHang)
                    .HasConstraintName("FK__DonVanChu__trang__1DB06A4F");
            });

            modelBuilder.Entity<HangVanChuyen>(entity =>
            {
                entity.HasKey(e => new { e.MaHang, e.MaDonGiaoGiup })
                    .HasName("pk_HangVanChuyen");

                entity.HasOne(d => d.MaDonGiaoGiupNavigation)
                    .WithMany(p => p.HangVanChuyen)
                    .HasForeignKey(d => d.MaDonGiaoGiup)
                    .HasConstraintName("FK_HangVanChuyenidDonGiaoGiup");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.HasKey(e => e.MaKhachHang)
                    .HasName("PK__KhachHan__0CCB3D497E306EA7");

                entity.HasIndex(e => e.CccdorVisa)
                    .HasName("UQ__KhachHan__7B681C85EC1C5EFB")
                    .IsUnique();

                entity.HasIndex(e => e.TaiKhoan)
                    .HasName("UQ__KhachHan__B4C453184AE673B6")
                    .IsUnique();

                entity.Property(e => e.MaKhachHang).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DiaChi).IsUnicode(false);

                entity.Property(e => e.GioiTinh).HasDefaultValueSql("('Nam')");

                entity.Property(e => e.LoaiKhachHang).IsUnicode(false);

                entity.Property(e => e.MatKhau).IsUnicode(false);

                entity.Property(e => e.NgayThamGia).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SoDonBiHuyDoKhachHang).HasDefaultValueSql("((0))");

                entity.Property(e => e.SoDonDaDat).HasDefaultValueSql("((0))");

                entity.Property(e => e.TaiKhoan).IsUnicode(false);

                entity.Property(e => e.TenLot).HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<KhieuNai>(entity =>
            {
                entity.HasKey(e => e.MaDonKhieuNai)
                    .HasName("PK__KhieuNai__CB9803BEFF1E0F4A");

                entity.Property(e => e.MaDonKhieuNai).ValueGeneratedNever();

                entity.HasOne(d => d.MaDonKhieuNaiNavigation)
                    .WithOne(p => p.KhieuNai)
                    .HasForeignKey<KhieuNai>(d => d.MaDonKhieuNai)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KhieuNai__maDonK__03F0984C");

                entity.HasOne(d => d.MaKhachHangNavigation)
                    .WithMany(p => p.KhieuNai)
                    .HasForeignKey(d => d.MaKhachHang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KhieuNai__maKhac__05D8E0BE");

                entity.HasOne(d => d.MaTongDaiVienNavigation)
                    .WithMany(p => p.KhieuNai)
                    .HasForeignKey(d => d.MaTongDaiVien)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KhieuNai__maTong__04E4BC85");
            });

            modelBuilder.Entity<MaKhuyenMai>(entity =>
            {
                entity.HasKey(e => e.MaKhuyenMai1)
                    .HasName("PK__MaKhuyen__87BEDDE97C74635E");

                entity.Property(e => e.DaDungChua).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.MaKhachHangSoHuuNavigation)
                    .WithMany(p => p.MaKhuyenMai)
                    .HasForeignKey(d => d.MaKhachHangSoHuu)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_MaKhuyenMaiKhachHang");
            });

            modelBuilder.Entity<MonAn>(entity =>
            {
                entity.HasKey(e => e.MaMonAn)
                    .HasName("PK__MonAn__2D20DD22A634A4A5");

                entity.HasOne(d => d.MaNhaHangOfferNavigation)
                    .WithMany(p => p.MonAn)
                    .HasForeignKey(d => d.MaNhaHangOffer)
                    .HasConstraintName("FK_MonAnidNhaHangOffer");
            });

            modelBuilder.Entity<NhaHang>(entity =>
            {
                entity.HasKey(e => e.MaNhaHang)
                    .HasName("PK__NhaHang__CF55DE335BF728B8");

                entity.HasIndex(e => e.TaiKhoan)
                    .HasName("UQ__NhaHang__B4C453182B70C111")
                    .IsUnique();

                entity.Property(e => e.TrangThaiNhaHang).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<NhanGiaoHangDvcPtSp>(entity =>
            {
                entity.HasKey(e => e.MaDon)
                    .HasName("PK__NhanGiao__2431086D2A9911FF");

                entity.Property(e => e.MaDon).ValueGeneratedNever();

                entity.HasOne(d => d.BienKiemSoatXeGiaoNavigation)
                    .WithMany(p => p.NhanGiaoHangDvcPtSp)
                    .HasForeignKey(d => d.BienKiemSoatXeGiao)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_bienKiemSoatt");

                entity.HasOne(d => d.MaDonNavigation)
                    .WithOne(p => p.NhanGiaoHangDvcPtSp)
                    .HasForeignKey<NhanGiaoHangDvcPtSp>(d => d.MaDon)
                    .HasConstraintName("fk_idDon");

                entity.HasOne(d => d.MaShipperNavigation)
                    .WithMany(p => p.NhanGiaoHangDvcPtSp)
                    .HasForeignKey(d => d.MaShipper)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_maShipperr");
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.MaNhanVien)
                    .HasName("PK__NhanVien__BDDEF20DD48377C2");

                entity.HasIndex(e => e.TaiKhoan)
                    .HasName("UQ__NhanVien__B4C4531852D8BA51")
                    .IsUnique();

                entity.Property(e => e.MaNhanVien).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ChiSoUyTin).HasDefaultValueSql("((5))");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Luong).HasDefaultValueSql("((0))");

                entity.Property(e => e.NgayVaoLam).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TenLot).HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<NhanVienChiNhanh>(entity =>
            {
                entity.HasKey(e => e.MaNhanVien)
                    .HasName("PK__NhanVien__BDDEF20D03CAE229");

                entity.Property(e => e.MaNhanVien).ValueGeneratedNever();

                entity.HasOne(d => d.MaDonViNavigation)
                    .WithMany(p => p.NhanVienChiNhanh)
                    .HasForeignKey(d => d.MaDonVi)
                    .HasConstraintName("fk_maDonVi");

                entity.HasOne(d => d.MaNhanVienNavigation)
                    .WithOne(p => p.NhanVienChiNhanh)
                    .HasForeignKey<NhanVienChiNhanh>(d => d.MaNhanVien)
                    .HasConstraintName("fk_maNhanVienChiNhanh");
            });

            modelBuilder.Entity<PhuongThucThanhToan>(entity =>
            {
                entity.HasKey(e => e.MaPhuongThuc)
                    .HasName("PK__PhuongTh__072D2D3F90B11353");

                entity.HasIndex(e => e.PhuongThucThanhToan1)
                    .HasName("UQ__PhuongTh__A8CCC13B39591402")
                    .IsUnique();
            });

            modelBuilder.Entity<PhuongTien>(entity =>
            {
                entity.HasKey(e => e.BienKiemSoat)
                    .HasName("PK__PhuongTi__E8A61C3D39F5EC5E");

                entity.Property(e => e.GiayPhepSoHuuXe).IsUnicode(false);

                entity.Property(e => e.HinhAnhXe).IsUnicode(false);
            });

            modelBuilder.Entity<QuanLi>(entity =>
            {
                entity.HasKey(e => e.MaNhanVien)
                    .HasName("PK__QuanLi__BDDEF20DADA4BC27");

                entity.Property(e => e.MaNhanVien).ValueGeneratedNever();

                entity.HasOne(d => d.MaNhanVienNavigation)
                    .WithOne(p => p.QuanLi)
                    .HasForeignKey<QuanLi>(d => d.MaNhanVien)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_maQuanLi");
            });

            modelBuilder.Entity<QuyTrachNhiem>(entity =>
            {
                entity.HasKey(e => new { e.MaNhanVien, e.MaDonKhieuNai })
                    .HasName("PK__QuyTrach__416772361D49C368");

                entity.HasOne(d => d.MaDonKhieuNaiNavigation)
                    .WithMany(p => p.QuyTrachNhiem)
                    .HasForeignKey(d => d.MaDonKhieuNai)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__QuyTrachN__maDon__0B91BA14");

                entity.HasOne(d => d.MaNhanVienNavigation)
                    .WithMany(p => p.QuyTrachNhiem)
                    .HasForeignKey(d => d.MaNhanVien)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__QuyTrachN__maNha__0A9D95DB");

                entity.HasOne(d => d.MaQuanLyNavigation)
                    .WithMany(p => p.QuyTrachNhiem)
                    .HasForeignKey(d => d.MaQuanLy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__QuyTrachN__maQua__0C85DE4D");
            });

            modelBuilder.Entity<SdtKhachHang>(entity =>
            {
                entity.HasKey(e => new { e.Sdt, e.MaKhachHang })
                    .HasName("PK__SdtKhach__4AD58370DDCFB770");

                entity.Property(e => e.Sdt)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.MaKhachHangNavigation)
                    .WithMany(p => p.SdtKhachHang)
                    .HasForeignKey(d => d.MaKhachHang)
                    .HasConstraintName("FK_SdtKhachHangKhachHang");
            });

            modelBuilder.Entity<SdtnhaHang>(entity =>
            {
                entity.HasKey(e => new { e.MaNhaHang, e.SoDienThoai })
                    .HasName("PK__SDTNhaHa__EF3F15A91E40E279");

                entity.Property(e => e.SoDienThoai)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.MaNhaHangNavigation)
                    .WithMany(p => p.SdtnhaHang)
                    .HasForeignKey(d => d.MaNhaHang)
                    .HasConstraintName("fk_maNhaHangN");
            });

            modelBuilder.Entity<Shipper>(entity =>
            {
                entity.HasKey(e => e.MaNhanVien)
                    .HasName("PK__Shipper__BDDEF20DEDBE1BFA");

                entity.Property(e => e.MaNhanVien).ValueGeneratedNever();

                entity.Property(e => e.Rating).HasDefaultValueSql("((5))");

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.BienKiemSoatNavigation)
                    .WithMany(p => p.Shipper)
                    .HasForeignKey(d => d.BienKiemSoat)
                    .HasConstraintName("fk_bienKiemSoat");

                entity.HasOne(d => d.MaNhanVienNavigation)
                    .WithOne(p => p.Shipper)
                    .HasForeignKey<Shipper>(d => d.MaNhanVien)
                    .HasConstraintName("fk_maShipper");
            });

            modelBuilder.Entity<TongDaiVien>(entity =>
            {
                entity.HasKey(e => e.MaNhanVien)
                    .HasName("PK__TongDaiV__BDDEF20D370775C1");

                entity.Property(e => e.MaNhanVien).ValueGeneratedNever();

                entity.HasOne(d => d.MaNhanVienNavigation)
                    .WithOne(p => p.TongDaiVien)
                    .HasForeignKey<TongDaiVien>(d => d.MaNhanVien)
                    .HasConstraintName("fk_maTongDai");
            });

            modelBuilder.Entity<TrangThaiDon>(entity =>
            {
                entity.HasKey(e => e.MaTrangThai)
                    .HasName("PK__TrangTha__AD42D179F7D389D9");

                entity.HasIndex(e => e.TrangThai)
                    .HasName("UQ__TrangTha__A8CCC13B07B96DF5")
                    .IsUnique();
            });

            modelBuilder.Entity<TuVanGiaiDap>(entity =>
            {
                entity.HasKey(e => new { e.MaTongDaiVien, e.MaKhachHang, e.Record })
                    .HasName("pk_TuVanGiaiDap");

                entity.HasOne(d => d.MaKhachHangNavigation)
                    .WithMany(p => p.TuVanGiaiDap)
                    .HasForeignKey(d => d.MaKhachHang)
                    .HasConstraintName("FK_TuVanGiaiDapmaKhachHang");

                entity.HasOne(d => d.MaTongDaiVienNavigation)
                    .WithMany(p => p.TuVanGiaiDap)
                    .HasForeignKey(d => d.MaTongDaiVien)
                    .HasConstraintName("FK_TuVanGiaiDapmaTongDaiVien");
            });

            modelBuilder.Entity<UuDai>(entity =>
            {
                entity.HasKey(e => new { e.MaMonAn, e.TenUuDai })
                    .HasName("pk_UuDai");

                entity.HasOne(d => d.MaMonAnNavigation)
                    .WithMany(p => p.UuDai)
                    .HasForeignKey(d => d.MaMonAn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UuDaiidMonAn");

                entity.HasOne(d => d.MaNhaHangNavigation)
                    .WithMany(p => p.UuDai)
                    .HasForeignKey(d => d.MaNhaHang)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_UuDaiidNhaHang");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
