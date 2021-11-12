# TourLogger | Current Version: 6.2.0 | Next major release: 7.0.0 | Next minor release: None planned | Next Hotfix: None planned

[![Codacy Security Scan](https://github.com/EnKdev/TourLogger/actions/workflows/codacy-analysis.yml/badge.svg)](https://github.com/EnKdev/TourLogger/actions/workflows/codacy-analysis.yml)

TourLogger is a small companion tool for players of ETS2 & ATS, allowing them to log their tours into a central database.

Current features of TourLogger include:

-  Displaying all tours into a single table
-  Viewing a single tour inside a special window to have information packed into one package
-  Logging tours to a database, Refreshing the table directly afterwards
-  Saving an already on-going tour so drivers can pick up where they left in case they needed to take a break.

## Changelogs

Release 6.0.0 (Initial Github Release):

-  Overhauled the entire UI to make it more unified
-  Added security features to prohibit unallowed access
-  Added [EnKdev.SessionPass](https://github.com/EnKdev/EnKdev.SessionPass), a pseudo-authentication library to (somewhat) ensure session authenticy.

----

Release 6.0.1

-  Fixed [Issue #1](https://github.com/EnKdev/TourLogger/issues/1) - Saving progressing tours now has a better behaviour and works if some fields in the UI are left blank.

Release 6.0.2

-  Fixed some general bugs

Release 6.1.0

-  Migrated from Windows Forms to WPF
-  This Release is still in testing for performance issues to be sighted, expect hotfixes coming around whenever something surfaces

Release 6.1.1

-  UI Cleanup, removed confusing placeholders

Release 6.1.2
-  Various code improvements and fixes. Compatibility remains across Versions 6.1.0 and 6.1.1.

### Related projects:

-  [TourLogger-Backend](https://github.com/enkdev/TourLogger-Backend) - The server-backend of TourLogger, where the behind-the-scenes magic takes place.
