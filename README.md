# xampp-apache-rightclick-cd
A right-click context-menu item helper that'll swap XAMPP's Apache's directory with a newly desired directory.

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

