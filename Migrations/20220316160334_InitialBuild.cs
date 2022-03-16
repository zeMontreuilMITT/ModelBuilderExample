using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModelBuilderDemo.Migrations
{
    public partial class InitialBuild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CourseTitle = table.Column<string>(name: "Course Title", type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseNumber);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttendingCourseNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AuditingCourseNumber = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Student_Course_AttendingCourseNumber",
                        column: x => x.AttendingCourseNumber,
                        principalTable: "Course",
                        principalColumn: "CourseNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_Course_AuditingCourseNumber",
                        column: x => x.AuditingCourseNumber,
                        principalTable: "Course",
                        principalColumn: "CourseNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "CourseNumber", "Course Title" },
                values: new object[] { "ef3fc486-c8c2-41d8-bc68-2b528439d03a", "ModelBuilder Introduction" });

            migrationBuilder.CreateIndex(
                name: "IX_Student_AttendingCourseNumber",
                table: "Student",
                column: "AttendingCourseNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Student_AuditingCourseNumber",
                table: "Student",
                column: "AuditingCourseNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Course");
        }
    }
}
