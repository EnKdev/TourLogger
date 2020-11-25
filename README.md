# TourLogger | Current Version: 6.0.1 | Next release: 7.0.0

TourLogger is a small companion tool for players of ETS2 & ATS, allowing them to log their tours into a central database.

Current features of TourLogger include:

- Displaying all tours into a single table
- Viewing a single tour inside a special window to have information packed into one package
- Logging tours to a database, Refreshing the table directly afterwards
- Saving an already on-going tour so drivers can pick up where they left in case they needed to take a break.

## Changelogs

Release 6.0.0 (Initial Github Release):

- Overhauled the entire UI to make it more unified
- Added security features to prohibit unallowed access
- Added [EnKdev.SessionPass](https://github.com/EnKdev/EnKdev.SessionPass), a pseudo-authentication library to (somewhat) ensure session authenticy.

----

Release 6.0.1

- Fixed [Issue #1](https://github.com/EnKdev/TourLogger/issues/1) - Saving progressing tours now has a better behaviour and works if some fields in the UI are left blank.

### Related projects:

- [TourLogger-Backend](https://github.com/enkdev/TourLogger-Backend) - The server-backend of TourLogger, where the behind-the-scenes magic takes place.
