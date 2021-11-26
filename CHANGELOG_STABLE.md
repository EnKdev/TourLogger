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

Release 7.0.0
-	Added a refueling interface, datatable and what-not related to this.
-	Lots and lots of code tweaks, code reinforcements, code fixes and shit.
-	The old cache file is now split into two caches. One for tours, the other for refuels.
-	Errors are now being thrown if something happens on the backend.
-	Added an account system
-	Accounts are synchronized whenever you access your personal account, save a tour or make a new refuel.
-	You can check others accounts by searching for their driver name. (No, you can't change their truck!)
-	Your old, local profile is now being moved into a legacy folder once you start the app. (Unless you've been on the experimental branch before)

Release 7.0.1
-	Hotfixed a bug where exceptions wouldn't be thrown on the tour side of the backend
-	Hotfixed a bug where saving tours didn't work correctly.
-	Hotfixed a bug where fetching a single refuel wouldn't work correctly.
### NOTE:
-	Version 7.0.0 won't work with this hotfix anymore.