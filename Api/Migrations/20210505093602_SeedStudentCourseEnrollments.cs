using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class SeedStudentCourseEnrollments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
              table: "CourseStudent",
              columns: new[] { "CoursesCourseID", "StudentsStudentID" },
              values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
              table: "CourseStudent",
              columns: new[] { "CoursesCourseID", "StudentsStudentID" },
              values: new object[] { 1, 5 });

            migrationBuilder.InsertData(
              table: "CourseStudent",
              columns: new[] { "CoursesCourseID", "StudentsStudentID" },
             values: new object[] { 1, 4 });

            migrationBuilder.InsertData(
              table: "CourseStudent",
              columns: new[] { "CoursesCourseID", "StudentsStudentID" },
              values: new object[] { 3, 5 });

            migrationBuilder.InsertData(
              table: "CourseStudent",
              columns: new[] { "CoursesCourseID", "StudentsStudentID" },
              values: new object[] { 2, 4 });

            migrationBuilder.InsertData(
              table: "CourseStudent",
              columns: new[] { "CoursesCourseID", "StudentsStudentID" },
              values: new object[] { 4, 4 });

            migrationBuilder.InsertData(
              table: "CourseStudent",
              columns: new[] { "CoursesCourseID", "StudentsStudentID" },
              values: new object[] { 5, 1 });

            migrationBuilder.InsertData(
              table: "CourseStudent",
              columns: new[] { "CoursesCourseID", "StudentsStudentID" },
              values: new object[] { 3, 3 });

            migrationBuilder.InsertData(
              table: "CourseStudent",
              columns: new[] { "CoursesCourseID", "StudentsStudentID" },
              values: new object[] { 3, 1 });

            migrationBuilder.InsertData(
              table: "CourseStudent",
              columns: new[] { "CoursesCourseID", "StudentsStudentID" },
              values: new object[] { 5, 5 });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
