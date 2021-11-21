# TourLogger

## Current stable version:
6.3.0

## Current experimental version:
7.0.0-beta4

## Next minor version:
None planned

## Next hotfix:
None planned

## About TourLogger:

[![Codacy Security Scan](https://github.com/EnKdev/TourLogger/actions/workflows/codacy-analysis.yml/badge.svg)](https://github.com/EnKdev/TourLogger/actions/workflows/codacy-analysis.yml)

TourLogger is a small companion tool for players of ETS2 & ATS, allowing them to log their tours into a central database.

Current features of TourLogger include:

-	Displaying all tours into a single table
-	Viewing a single tour inside a special window to have information packed into one package
-	Logging tours to a database, Refreshing the table directly afterwards
-	Saving an already on-going tour so drivers can pick up where they left in case they needed to take a break.

## Changelogs (Stable Channel)

Release 6.0.0 (Initial Github Release):

-	Overhauled the entire UI to make it more unified
-	Added security features to prohibit unallowed access
-	Added [EnKdev.SessionPass](https://github.com/EnKdev/EnKdev.SessionPass), a pseudo-authentication library to (somewhat) ensure session authenticy.


Release 6.0.1

-	Fixed [Issue #1](https://github.com/EnKdev/TourLogger/issues/1) - Saving progressing tours now has a better behaviour and works if some fields in the UI are left blank.

Release 6.0.2

-	Fixed some general bugs

Release 6.1.0

-	Migrated from Windows Forms to WPF
-	This Release is still in testing for performance issues to be sighted, expect hotfixes coming around whenever something surfaces

Release 6.1.1

-	UI Cleanup, removed confusing placeholders

Release 6.1.2
-	Various code improvements and fixes. Compatibility remains across Versions 6.1.0 and 6.1.1.

Release 6.2.0
-	Added AutoUpdater.NET to the app
-		This means that updates will now be automatically downloaded if there is one available.
-	Updates are downloaded into the Update directory of the app.

-	Cleaned up some forgotten leftover placeholders after sending in a new tour

Release 6.3.0
-	Added the ability to switch onto an experimental channel of the App whenever one is open.
### NOTE:
-	Older Versions (6.1.0 - 6.2.0) are not supported with this change anymore due to changes to the server backend!

## Changelog (Experimental Channel)

Beta-Build 7.0.0-beta1

-	Added a Refueling Interface, Datatable and what-not related to this.
-	Lots and lots of Code Tweaks and shit.
-	Cache file is now split into two:
-		tourCache.dat and refuelCache.dat

Beta-Build 7.0.0-beta2

-	Various code fixes

Beta-Build 7.0.0-beta3

-	Code reinforcements
-	App now throws you an error if something went wrong on the backend side.

Beta-Build 7.0.0-beta4

-	Added an account system
-	Accounts are synchronized whenever you access your personal account window, send a tour to the server or make a new refuel
-	You can also check others accounts (but not update their truck!)
-	Again, lots and lots of code tweaks
-		truck.dat-File (The old profile) is now moved into the Legacy Folder of the App upon startup.
