using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudAPI.Migrations
{
    public partial class Updatedanime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Animes",
                columns: new[] { "Id", "CategoryId", "Description", "Istreaming", "Name", "Producer", "ReleaseDate", "Thumbnail" },
                values: new object[] { 2, 2, "Shinichi Kudou, a high school student of astounding talent in detective work, is well known for having solved several challenging cases. One day, when Shinichi spots two suspicious men and decides to follow them, he inadvertently becomes witness to a disturbing illegal activity. Unfortunately, he is caught in the act, so the men dose him with an experimental drug formulated by their criminal organization, leaving him to his death. However, to his own astonishment, Shinichi lives to see another day, but now in the body of a seven-year-old child. Perfectly preserving his original intelligence, he hides his real identity from everyone, including his childhood friend Ran Mouri and her father, private detective Kogorou Mouri. To this end, he takes on the alias of Conan Edogawa, inspired by the mystery writers Arthur Conan Doyle and Ranpo Edogawa.Detective Conan follows Shinichi who, as Conan, starts secretly solving the senior Mouri's cases from behind the scenes with his still exceptional sleuthing skills, while covertly investigating the organization responsible for his current state, hoping to reverse the drug's effects someday", true, "Case Closed; Detective Conan", "TMS Entertainment", new DateTime(1996, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://ytvcontents.com/ytv/open/open-tv-program!image?tid=64&imageNumber=1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Animes",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
