# xampp-apache-rightclick-cd
A right-click context-menu item helper that'll swap XAMPP's Apache's directory with a newly desired directory,
and then restart Apache to update its configuration.

# Installation

1.  Extract the release `.zip` file somewhere (maybe `C:\xampp-apache-rightclick-cd\` will suffice)
2.  Open the Windows Registry (you can do so by hitting `Win`+`R`, then typing `regedit`)
3.  Navigate to `\HKEY_CLASSES_ROOT\Directory\Background\shell`.
4.  Right-click on `shell`, then click to make a New -> Key.
5.  Name this new key `xampp-apache-rightclick-cd`.
6.  Double click `Default`.
7.  Type in the box that comes up the desired name of the right-click shortcut. An easy one is:
    `Set XAMPP's Apache root here`.
8.  Right click on that new key, and make another new key within that called `command`.
9.  Double click `Default`.
10. Type in, in quotes, where the executable for `xampp-apache-rightclick-cd` lies. For example,
    if you used `C:\xampp-apache-rightclick-cd\`, you would make that:

```
"C:\xampp-apache-rightclick-cd\xampp-apache-rightclick-cd.exe"
```

11. Enjoy a bit of faster switching between projects when debugging with XAMPP on localhost.

Unfortunately, this installation guide is complicated and probably could be automated in the future.

# Usage

It's meant to simply be ran in the folder that you wish to be the new document root.
For example: Say your document root used to be `C:\a` and you want it to be `C:\b`.
Run the program from within `C:\b` (using a right-click helper would do this automatically).

# `httpd.conf` location

The program depends on `httpd.conf` to be in `C:\xampp\apache\httpd.conf`.
If you'd like to change where this is, simply change the required variable in `Program.cs`
and recompile.

# `httpd.exe` location

The program depends on `httpd.exe` (the Apache host process) to be in `C:\xampp\apache\bin\httpd.exe`.
If you'd like to change where this is, simply change the required variable in `Program.cs`
and recompile.

# Dependencies

XAMPP is required (as it's meant to change XAMPP settings). For easier use, use XAMPP's default location
on your C drive (`C:\xampp`).

Due to being in C#, the .NET environment (specifically, version 2.1) is required.
The DLLs necessary for it to run are attached in the release zip files.

The Hardware Requirements aren't any more strict than the ones for .NET Core,
besides the fact that it must be running on Windows (at the time being).

For a full list, see [https://docs.microsoft.com/en-us/dotnet/core/windows-prerequisites?tabs=netcore2x](this list from Microsoft).
