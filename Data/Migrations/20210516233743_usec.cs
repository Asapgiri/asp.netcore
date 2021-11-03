using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class usec : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Posts_PostId",
                table: "Likes");

            migrationBuilder.DropIndex(
                name: "IX_Likes_PostId",
                table: "Likes");

            migrationBuilder.RenameColumn(
                name: "LikeCnt",
                table: "Posts",
                newName: "Likes");

            migrationBuilder.RenameColumn(
                name: "ContentLocation",
                table: "Posts",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "LastModified",
                table: "AspNetUsers",
                newName: "Modified");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7d2f5d30-3ec3-4ae1-93f3-efecf20906bf", "AQAAAAEAACcQAAAAEGyMchJlyqWNgbnFdag0hhT7Ns8Dsn3gUrUb26ZNnkbeIJODwgpBBUSIGbwYx8MVAA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbs-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "118b28b1-d770-408d-b656-ca59421f0666", "AQAAAAEAACcQAAAAECjGY+XkMrtcX0W9ue3yI55+yer8jdlrqLEAold92HYJT9qSeWfQ5XXWH5lp1iY7gw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Posts",
                newName: "ContentLocation");

            migrationBuilder.RenameColumn(
                name: "Likes",
                table: "Posts",
                newName: "LikeCnt");

            migrationBuilder.RenameColumn(
                name: "Modified",
                table: "AspNetUsers",
                newName: "LastModified");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0d849c91-b1d7-4b55-b173-8d487de05f21", "AQAAAAEAACcQAAAAEFBazgGDKKbu7xbJv6m1ZpsVNW57ZugwaLg2eyEpxxNRdiAnRZ6GQOkiXeIXA4whAA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbs-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c62101d7-d6cd-4f75-a195-7fcea16925e1", "AQAAAAEAACcQAAAAEMxYzUx44B+l1IHgCraT4XNxIet6Y+G5IYAy7dv22RGIlSgM8cOOi2FAqefdXW5CLw==" });

            migrationBuilder.CreateIndex(
                name: "IX_Likes_PostId",
                table: "Likes",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Posts_PostId",
                table: "Likes",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
