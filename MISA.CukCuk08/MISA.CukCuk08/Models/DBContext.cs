using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace MISA.CukCuk08.Models
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=35.194.166.58;port=3306;user=nvmanh;password=12345678@Abc;database=MISADemo_NQTrung", x => x.ServerVersion("10.3.22-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasComment("Bảng thông tin khách hàng");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("CustomerID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Address)
                    .HasColumnType("varchar(255)")
                    .HasComment("Địa chỉ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Birthday)
                    .HasColumnType("date")
                    .HasComment("Ngày sinh");

                entity.Property(e => e.CompanyName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên Công Ty")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CustomerCode)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasDefaultValueSql("''")
                    .HasComment("Tên khách hàng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DebitAmount)
                    .HasColumnType("decimal(18,2)")
                    .HasComment("Số tiền nợ");

                entity.Property(e => e.Email)
                    .HasColumnType("varchar(50)")
                    .HasComment("Email")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.GroupCustomer)
                    .HasColumnType("varchar(255)")
                    .HasComment("Nhóm khách hàng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Is5FoodMember).HasComment("Là Thành viên 5Food(1-có 0-không)");

                entity.Property(e => e.MemberCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã thành viên")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Note)
                    .HasColumnType("text")
                    .HasComment("ghi chú")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasComment("Số điện thoại")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Taxcode)
                    .HasColumnType("varchar(50)")
                    .HasComment("Mã số thuế")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
                entity.Property(e => e.Image)
                    
                    .HasColumnType("varchar(255)")
                    .HasComment("avatar người dùng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });
             modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasComment("Bảng nhân viên ");

                entity.Property(e => e.EmployeeId)
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasComment("Ngày sinh");

                entity.Property(e => e.Department)
                    .HasColumnType("varchar(255)")
                    .HasComment("Phòng ban")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasDefaultValueSql("''")
                    .HasComment("chứng minh thư")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EmployeeCode)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasDefaultValueSql("''")
                    .HasComment("Mã nhân viên")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EmployeeName)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasDefaultValueSql("''")
                    .HasComment("họ và tên")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Gender)
                    .HasColumnType("int(11)")
                    .HasComment("giới tính (0- nữ, 1- nam, 2 khác");

                entity.Property(e => e.IssuedBy)
                    .HasColumnType("varchar(100)")
                    .HasComment("Nơi cấp")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IssuedDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày cấp");

                entity.Property(e => e.JoinDate)
                    .HasColumnType("date")
                    .HasComment("Ngày gia nhập");

                entity.Property(e => e.Passport)
                    .HasColumnType("varchar(20)")
                    .HasComment("Hộ chiếu")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasComment("số điện thoại")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Position)
                    .HasColumnType("varchar(100)")
                    .HasComment("Vị trí")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Salary)
                    .HasColumnType("decimal(18,0)")
                    .HasComment("Mức lương");

                entity.Property(e => e.State)
                    .HasColumnType("varchar(255)")
                    .HasComment("trạng thái")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TaxCode)
                    .HasColumnType("varchar(50)")
                    .HasComment("Mã số thuế")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
                entity.Property(e => e.ImageUrl)
                   .HasColumnType("varchar(255)")
                   .HasComment("đường dẫn ảnh")
                   .HasCharSet("utf8")
                   .HasCollation("utf8_general_ci");
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày Tạo");
                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày Cấp");
            });
           

            OnModelCreatingPartial(modelBuilder);
        }

        //internal Task SaveChangesAsync()
        //{
        //    throw new NotImplementedException();
        //}

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        //internal Task SaveChangesAsync()
        //{
        //    throw new NotImplementedException();
        //}

       
    }
}
