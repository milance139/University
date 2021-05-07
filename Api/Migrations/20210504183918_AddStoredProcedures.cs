using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class AddStoredProcedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Create procedure spGetStudentById
                @Id int
                as
                Begin
                    Select * from Student
                    where StudentID = @Id
                End";
            migrationBuilder.Sql(procedure);

            procedure = @"Create procedure spGetCourseById
                @Id int
                as
                Begin
                    Select * from Course
                    where CourseID = @Id
                End";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop procedure spGetCourseById";
            migrationBuilder.Sql(procedure);

            procedure = @"Drop procedure spGetStudentById";
            migrationBuilder.Sql(procedure);
        }
    }
}
