using Microsoft.EntityFrameworkCore.Migrations;

namespace PersistenceLayer.Migrations
{
    public partial class AddedMembers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Member_MemberId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_ChallengeRegistrations_Member_MemberId",
                table: "ChallengeRegistrations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Member_MemberId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Skill_Member_MemberId",
                table: "Skill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Member",
                table: "Member");

            migrationBuilder.RenameTable(
                name: "Member",
                newName: "Members");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Members",
                table: "Members",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Members_MemberId",
                table: "Address",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChallengeRegistrations_Members_MemberId",
                table: "ChallengeRegistrations",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Members_MemberId",
                table: "Reservations",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_Members_MemberId",
                table: "Skill",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Members_MemberId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_ChallengeRegistrations_Members_MemberId",
                table: "ChallengeRegistrations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Members_MemberId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Skill_Members_MemberId",
                table: "Skill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Members",
                table: "Members");

            migrationBuilder.RenameTable(
                name: "Members",
                newName: "Member");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Member",
                table: "Member",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Member_MemberId",
                table: "Address",
                column: "MemberId",
                principalTable: "Member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChallengeRegistrations_Member_MemberId",
                table: "ChallengeRegistrations",
                column: "MemberId",
                principalTable: "Member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Member_MemberId",
                table: "Reservations",
                column: "MemberId",
                principalTable: "Member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_Member_MemberId",
                table: "Skill",
                column: "MemberId",
                principalTable: "Member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
