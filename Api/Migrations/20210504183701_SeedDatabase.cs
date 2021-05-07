using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
              table: "Status",
              columns: new[] { "StatusID", "Name" },
              values: new object[] { 1, "Full-time" });

            migrationBuilder.InsertData(
             table: "Status",
             columns: new[] { "StatusID", "Name" },
             values: new object[] { 2, "Part-time" });

            migrationBuilder.InsertData(
               table: "Student",
               columns: new[] { "StudentID", "StatusID", "FirstName", "LastName", "Index", "Year" },
               values: new object[] { 1, 1, "Marko", "Markovic", "1000", "1" });

            migrationBuilder.InsertData(
               table: "Student",
               columns: new[] { "StudentID", "StatusID", "FirstName", "LastName", "Index", "Year" },
               values: new object[] { 2, 1, "Janko", "Jankovic", "1001", "1" });

            migrationBuilder.InsertData(
               table: "Student",
               columns: new[] { "StudentID", "StatusID", "FirstName", "LastName", "Index", "Year" },
               values: new object[] { 3, 1, "Nikola", "Nikolic", "1002", "2" });

            migrationBuilder.InsertData(
               table: "Student",
               columns: new[] { "StudentID", "StatusID", "FirstName", "LastName", "Index", "Year" },
               values: new object[] { 4, 2, "Stojan", "Stojanovic", "1003", "3" });

            migrationBuilder.InsertData(
               table: "Student",
               columns: new[] { "StudentID", "StatusID", "FirstName", "LastName", "Index", "Year" },
               values: new object[] { 5, 2, "Pero", "Perovic", "1004", "4" });

            migrationBuilder.InsertData(
               table: "Student",
               columns: new[] { "StudentID", "StatusID", "FirstName", "LastName", "Index", "Year" },
               values: new object[] { 6, 1, "Stojan", "Stojanovic", "1005", "1" });

            migrationBuilder.InsertData(
               table: "Course",
               columns: new[] { "CourseID", "Name" },
               values: new object[] { 1, "Matematika" });

            migrationBuilder.InsertData(
               table: "Course",
               columns: new[] { "CourseID", "Name" },
               values: new object[] { 2, "Fizika" });

            migrationBuilder.InsertData(
               table: "Course",
               columns: new[] { "CourseID", "Name" },
               values: new object[] { 3, "Biologija" });

            migrationBuilder.InsertData(
               table: "Course",
               columns: new[] { "CourseID", "Name" },
               values: new object[] { 4, "Geografija" });

            migrationBuilder.InsertData(
               table: "Course",
               columns: new[] { "CourseID", "Name" },
               values: new object[] { 5, "Srpski jezik" });           

            migrationBuilder.InsertData(
               table: "User",
               columns: new[] { "UserID", "FullName", "Email", "Username", "Password" },
               values: new object[] { 1, "Admin", "admin@gmail.com", "admin", "123456" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
               table: "Course",
               keyColumn: "CourseID",
               keyValue: 1);

            migrationBuilder.DeleteData(
               table: "Course",
               keyColumn: "CourseID",
               keyValue: 2);

            migrationBuilder.DeleteData(
               table: "Course",
               keyColumn: "CourseID",
               keyValue: 3);

            migrationBuilder.DeleteData(
               table: "Course",
               keyColumn: "CourseID",
               keyValue: 4);

            migrationBuilder.DeleteData(
               table: "Course",
               keyColumn: "CourseID",
               keyValue: 5);

            migrationBuilder.DeleteData(
               table: "Student",
               keyColumn: "StudentID",
               keyValue: 1);

            migrationBuilder.DeleteData(
               table: "Student",
               keyColumn: "StudentID",
               keyValue: 2);

            migrationBuilder.DeleteData(
               table: "Student",
               keyColumn: "StudentID",
               keyValue: 3);

            migrationBuilder.DeleteData(
               table: "Student",
               keyColumn: "StudentID",
               keyValue: 4);

            migrationBuilder.DeleteData(
               table: "Student",
               keyColumn: "StudentID",
               keyValue: 5);

            migrationBuilder.DeleteData(
               table: "Status",
               keyColumn: "StatusID",
               keyValue: 1);

            migrationBuilder.DeleteData(
               table: "Status",
               keyColumn: "StatusID",
               keyValue: 2);

            migrationBuilder.DeleteData(
               table: "User",
               keyColumn: "UserID",
               keyValue: 1);
        }
    }
}
