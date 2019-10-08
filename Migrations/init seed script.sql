CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

CREATE TABLE "BrewerType" (
    "BrewerTypeId" INTEGER NOT NULL CONSTRAINT "PK_BrewerType" PRIMARY KEY AUTOINCREMENT,
    "Description" TEXT NULL,
    "Recipe_WaterTemperatureF" INTEGER NOT NULL,
    "Recipe_GrindSize" INTEGER NOT NULL,
    "Recipe_GrindOunces" INTEGER NOT NULL,
    "Recipe_WaterOunces" INTEGER NOT NULL,
    "Recipe_BrewTime" INTEGER NOT NULL,
    "Recipe_Description" TEXT NULL
);

CREATE TABLE "Locations" (
    "LocationId" INTEGER NOT NULL CONSTRAINT "PK_Locations" PRIMARY KEY AUTOINCREMENT,
    "StreetAddress" TEXT NULL,
    "OpenTime" TEXT NULL,
    "CloseTime" TEXT NULL
);

CREATE TABLE "Unit" (
    "UnitId" INTEGER NOT NULL CONSTRAINT "PK_Unit" PRIMARY KEY AUTOINCREMENT,
    "LocationId" INTEGER NOT NULL,
    "BrewerTypeId" INTEGER NOT NULL,
    "Acquired" TEXT NOT NULL,
    CONSTRAINT "FK_Unit_Locations_LocationId" FOREIGN KEY ("LocationId") REFERENCES "Locations" ("LocationId") ON DELETE CASCADE
);

INSERT INTO "Locations" ("LocationId", "CloseTime", "OpenTime", "StreetAddress")
VALUES (1, '4PM', '6AM', NULL);

INSERT INTO "Unit" ("UnitId", "Acquired", "BrewerTypeId", "LocationId")
VALUES (1, '2018-06-07 20:01:46.066', 1, 1);

CREATE INDEX "IX_Unit_LocationId" ON "Unit" ("LocationId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20180608000146_init', '2.1.1-rtm-30846');

