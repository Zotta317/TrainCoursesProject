using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace trainTicketApp.Migrations
{
    public partial class AddSeatData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Seat",
                columns: new[] { "SeatID", "CarrigeId", "SeatName", "TrainId" },
                values: new object[,]
                {
                    { new Guid("002be73c-0c94-4f61-9776-3350e27453c8"), new Guid("525ce5a0-644e-49cb-bc08-e12c5266b8a7"), "A3", new Guid("21e9557f-99d2-40b2-b0e1-2bcf97b226d5") },
                    { new Guid("0b882cd9-c7f6-4e46-853f-05e966d644ba"), new Guid("150f25f7-6e91-4880-b6db-c7b60ff6a801"), "B2", new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5") },
                    { new Guid("17d3dd2e-63f1-47dd-9e59-f3e489894954"), new Guid("6aa81f80-1a04-47ab-ac46-150b893526a8"), "A5", new Guid("21e9557f-99d2-40b2-b0e1-2bcf97b226d5") },
                    { new Guid("1b155670-a5ab-44cd-a2a0-bf265453e663"), new Guid("33a987e8-5767-486a-92ba-d0269009763e"), "C8", new Guid("d5fc5911-b45e-4134-acc0-8a35531faee8") },
                    { new Guid("24caf5d7-e2db-44b1-b145-e2eab29a22a3"), new Guid("389e75ce-284b-49bb-b093-688fb1983465"), "B13", new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5") },
                    { new Guid("2c922ec6-c82a-4fd5-afd1-e379e7b63b80"), new Guid("993a0e29-9326-402f-9134-cd153e3df275"), "C6", new Guid("d5fc5911-b45e-4134-acc0-8a35531faee8") },
                    { new Guid("43165ed7-4812-4659-8901-0f6f70cd5856"), new Guid("6aa81f80-1a04-47ab-ac46-150b893526a8"), "A4", new Guid("21e9557f-99d2-40b2-b0e1-2bcf97b226d5") },
                    { new Guid("454333dd-d175-47dc-acb1-9312f6e7376a"), new Guid("e61c724e-942a-4b85-8e74-d165d64f01ee"), "C3", new Guid("d5fc5911-b45e-4134-acc0-8a35531faee8") },
                    { new Guid("4bc6fa95-7b90-44fb-a758-696176db4109"), new Guid("7bf45095-fba6-47b7-b380-996233626448"), "B12", new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5") },
                    { new Guid("520de61f-dc9e-4747-8b1c-42aa70979bff"), new Guid("993a0e29-9326-402f-9134-cd153e3df275"), "C4", new Guid("d5fc5911-b45e-4134-acc0-8a35531faee8") },
                    { new Guid("525cf6a0-644e-33cb-bc08-e12c5266b8a7"), new Guid("525ce5a0-644e-49cb-bc08-e12c5266b8a7"), "A1", new Guid("21e9557f-99d2-40b2-b0e1-2bcf97b226d5") },
                    { new Guid("554321fc-9d5c-47f6-9f79-b3fa70cf08ea"), new Guid("150f25f7-6e91-4880-b6db-c7b60ff6a801"), "B3", new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5") },
                    { new Guid("6dbe5a17-dd43-4299-bd09-0f89b40326d0"), new Guid("0bfdf344-31ff-4e75-a389-70315c001833"), "A7", new Guid("21e9557f-99d2-40b2-b0e1-2bcf97b226d5") },
                    { new Guid("7915717f-20a2-4f03-ac6c-21d3cd326a04"), new Guid("e61c724e-942a-4b85-8e74-d165d64f01ee"), "C2", new Guid("d5fc5911-b45e-4134-acc0-8a35531faee8") },
                    { new Guid("7bee3ef2-6033-4e25-89bf-fdc8e9494e2c"), new Guid("fed20eac-3aa0-4a9f-a9b7-b5af494471d7"), "B8", new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5") },
                    { new Guid("813a3db7-f01a-4482-914a-bce5a4d638bb"), new Guid("525ce5a0-644e-49cb-bc08-e12c5266b8a7"), "A2", new Guid("21e9557f-99d2-40b2-b0e1-2bcf97b226d5") },
                    { new Guid("88fb29e9-53ad-490f-bf06-66bf0e7e9a19"), new Guid("6aa81f80-1a04-47ab-ac46-150b893526a8"), "A6", new Guid("21e9557f-99d2-40b2-b0e1-2bcf97b226d5") },
                    { new Guid("9a4b7f11-6e29-4ed2-939c-b5c44c47ce33"), new Guid("993a0e29-9326-402f-9134-cd153e3df275"), "C5", new Guid("d5fc5911-b45e-4134-acc0-8a35531faee8") },
                    { new Guid("9d0f9f2f-3840-4329-93ce-693329bb0bc1"), new Guid("0bfdf344-31ff-4e75-a389-70315c001833"), "A9", new Guid("21e9557f-99d2-40b2-b0e1-2bcf97b226d5") },
                    { new Guid("a9d3b0d4-2594-4949-acae-b542413600aa"), new Guid("7bf45095-fba6-47b7-b380-996233626448"), "B11", new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5") },
                    { new Guid("ad9aa746-05df-40d4-8880-677d4f026b81"), new Guid("0bfdf344-31ff-4e75-a389-70315c001833"), "A8", new Guid("21e9557f-99d2-40b2-b0e1-2bcf97b226d5") },
                    { new Guid("afc39e45-e4d6-4666-9159-1494c1a18a39"), new Guid("33a987e8-5767-486a-92ba-d0269009763e"), "C7", new Guid("d5fc5911-b45e-4134-acc0-8a35531faee8") },
                    { new Guid("b2e10c30-8e6c-40fd-89a7-9627bf5fe541"), new Guid("fed20eac-3aa0-4a9f-a9b7-b5af494471d7"), "B7", new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5") },
                    { new Guid("b51224ff-b75c-4e04-9a12-0e8bf96a43d5"), new Guid("fed20eac-3aa0-4a9f-a9b7-b5af494471d7"), "B6", new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5") },
                    { new Guid("b53a0c7d-1405-4a68-a6a6-a9cf7af6a3a7"), new Guid("389e75ce-284b-49bb-b093-688fb1983465"), "B15", new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5") },
                    { new Guid("c5a40b9a-5d93-4223-95cf-0090bd3bd0fb"), new Guid("389e75ce-284b-49bb-b093-688fb1983465"), "B16", new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5") },
                    { new Guid("cdb585b4-55ba-4aea-b5a5-9a47d8ef68f7"), new Guid("fed20eac-3aa0-4a9f-a9b7-b5af494471d7"), "B5", new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5") },
                    { new Guid("d9ebadde-29e9-4121-aa55-d22817c601e9"), new Guid("7bf45095-fba6-47b7-b380-996233626448"), "B10", new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5") },
                    { new Guid("daa7eb6d-6e8e-4ae7-a342-2884861275d0"), new Guid("150f25f7-6e91-4880-b6db-c7b60ff6a801"), "B4", new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5") },
                    { new Guid("e71f128b-5aa1-49b3-af04-618808d0a6af"), new Guid("389e75ce-284b-49bb-b093-688fb1983465"), "B14", new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5") },
                    { new Guid("ea803373-4bd7-4f6d-9511-0c2ca0e2239f"), new Guid("150f25f7-6e91-4880-b6db-c7b60ff6a801"), "B1", new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5") },
                    { new Guid("eed81cd4-5958-4872-8e0a-da1ca0ac368a"), new Guid("7bf45095-fba6-47b7-b380-996233626448"), "B9", new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5") },
                    { new Guid("ff6370b6-c194-4acc-8ef9-70339fb5fa13"), new Guid("e61c724e-942a-4b85-8e74-d165d64f01ee"), "C1", new Guid("d5fc5911-b45e-4134-acc0-8a35531faee8") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "SeatID",
                keyValue: new Guid("002be73c-0c94-4f61-9776-3350e27453c8"));

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "SeatID",
                keyValue: new Guid("0b882cd9-c7f6-4e46-853f-05e966d644ba"));

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "SeatID",
                keyValue: new Guid("17d3dd2e-63f1-47dd-9e59-f3e489894954"));

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "SeatID",
                keyValue: new Guid("1b155670-a5ab-44cd-a2a0-bf265453e663"));

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "SeatID",
                keyValue: new Guid("24caf5d7-e2db-44b1-b145-e2eab29a22a3"));

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "SeatID",
                keyValue: new Guid("2c922ec6-c82a-4fd5-afd1-e379e7b63b80"));

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "SeatID",
                keyValue: new Guid("43165ed7-4812-4659-8901-0f6f70cd5856"));

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "SeatID",
                keyValue: new Guid("454333dd-d175-47dc-acb1-9312f6e7376a"));

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "SeatID",
                keyValue: new Guid("4bc6fa95-7b90-44fb-a758-696176db4109"));

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "SeatID",
                keyValue: new Guid("520de61f-dc9e-4747-8b1c-42aa70979bff"));

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "SeatID",
                keyValue: new Guid("525cf6a0-644e-33cb-bc08-e12c5266b8a7"));

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "SeatID",
                keyValue: new Guid("554321fc-9d5c-47f6-9f79-b3fa70cf08ea"));

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "SeatID",
                keyValue: new Guid("6dbe5a17-dd43-4299-bd09-0f89b40326d0"));

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "SeatID",
                keyValue: new Guid("7915717f-20a2-4f03-ac6c-21d3cd326a04"));

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "SeatID",
                keyValue: new Guid("7bee3ef2-6033-4e25-89bf-fdc8e9494e2c"));

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "SeatID",
                keyValue: new Guid("813a3db7-f01a-4482-914a-bce5a4d638bb"));

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "SeatID",
                keyValue: new Guid("88fb29e9-53ad-490f-bf06-66bf0e7e9a19"));

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "SeatID",
                keyValue: new Guid("9a4b7f11-6e29-4ed2-939c-b5c44c47ce33"));

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "SeatID",
                keyValue: new Guid("9d0f9f2f-3840-4329-93ce-693329bb0bc1"));

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "SeatID",
                keyValue: new Guid("a9d3b0d4-2594-4949-acae-b542413600aa"));

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "SeatID",
                keyValue: new Guid("ad9aa746-05df-40d4-8880-677d4f026b81"));

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "SeatID",
                keyValue: new Guid("afc39e45-e4d6-4666-9159-1494c1a18a39"));

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "SeatID",
                keyValue: new Guid("b2e10c30-8e6c-40fd-89a7-9627bf5fe541"));

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "SeatID",
                keyValue: new Guid("b51224ff-b75c-4e04-9a12-0e8bf96a43d5"));

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "SeatID",
                keyValue: new Guid("b53a0c7d-1405-4a68-a6a6-a9cf7af6a3a7"));

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "SeatID",
                keyValue: new Guid("c5a40b9a-5d93-4223-95cf-0090bd3bd0fb"));

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "SeatID",
                keyValue: new Guid("cdb585b4-55ba-4aea-b5a5-9a47d8ef68f7"));

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "SeatID",
                keyValue: new Guid("d9ebadde-29e9-4121-aa55-d22817c601e9"));

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "SeatID",
                keyValue: new Guid("daa7eb6d-6e8e-4ae7-a342-2884861275d0"));

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "SeatID",
                keyValue: new Guid("e71f128b-5aa1-49b3-af04-618808d0a6af"));

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "SeatID",
                keyValue: new Guid("ea803373-4bd7-4f6d-9511-0c2ca0e2239f"));

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "SeatID",
                keyValue: new Guid("eed81cd4-5958-4872-8e0a-da1ca0ac368a"));

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "SeatID",
                keyValue: new Guid("ff6370b6-c194-4acc-8ef9-70339fb5fa13"));
        }
    }
}
