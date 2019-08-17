# Remove-Diacritics
Console app, that can remove text diacritics from stdin, inside files and file/dir names

[![Build Status](https://jakubsuchybio.visualstudio.com/Github%20CI%20CD/_apis/build/status/Remove-Diacritics?branchName=master&jobName=Build)](https://jakubsuchybio.visualstudio.com/Github%20CI%20CD/_build/latest?definitionId=1&branchName=master)

## **Help content:**
```cmd
> .\remove-diacritics.exe help
remove-diacritics 1.0.16+Branch.master.Sha.301c567a42c94a9b8e8f824d9470b07975623407
Copyright (C) 2019 remove-diacritics

  stdin         Removes diacritics from stdin and outputs it to stdout

  file-names    Removes diacritics from all files and directories

  content       Removes diacritics inside files

  help          Display more information on a specific command.

  version       Display version information.
```
```cmd
> .\remove-diacritics.exe help stdin
remove-diacritics 1.0.16+Branch.master.Sha.301c567a42c94a9b8e8f824d9470b07975623407
Copyright (C) 2019 remove-diacritics

  --debug      Forces program to run in debug mode

  --help       Display this help screen.

  --version    Display version information.
```
```cmd
> .\remove-diacritics.exe help file-names
remove-diacritics 1.0.16+Branch.master.Sha.301c567a42c94a9b8e8f824d9470b07975623407
Copyright (C) 2019 remove-diacritics

  -d, --directories    Required. Input directories where will diacritics be recursively removed in file/dir names

  --debug              Forces program to run in debug mode

  --help               Display this help screen.

  --version            Display version information.
```
```cmd
> .\remove-diacritics.exe help content
remove-diacritics 1.0.16+Branch.master.Sha.301c567a42c94a9b8e8f824d9470b07975623407
Copyright (C) 2019 remove-diacritics

  -f, --files    Required. Input files where the diacritics be removed inside the file's content

  --debug        Forces program to run in debug mode

  --help         Display this help screen.

  --version      Display version information.
```
## **Examples:**
----
### **stdin** example
**input:**
```cmd
echo ÁČĎÉĚÍŇÓŘŠŤÚŮÝŽáčďéěíňóřšťúůýž | remove-diacritics.exe stdin
```
**output:**
```cmd
ACDEEINORSTUUYZacdeeinorstuuyz
```
----
### **file-names** example
**input:**
```cmd
echo > ÁČĎÉĚÍŇÓŘŠŤÚŮÝŽáčďéěíňóřšťúůýž.txt
remove-diacritics.exe file-names --directories .
```
**output:** (Console doesn't correctly logs diacritics...)
```cmd
13:13:38.9467384 +02:00 [INF] [1] Renaming .\ACDÉEINORSTUUYZácdéeínórstúuyz.txt -> .\ACDEEINORSTUUYZacdeeinorstuuyz.txt
```
----
### **content** example
**input:**
```cmd
echo ÁČĎÉĚÍŇÓŘŠŤÚŮÝŽáčďéěíňóřšťúůýž > test.txt
remove-diacritics.exe content --files test.txt
```
**test.txt** file content:
```
ÁČĎÉĚÍŇÓŘŠŤÚŮÝŽáčďéěíňóřšťúůýž
```
**output:**
```cmd
13:32:45.5279019 +02:00 [INF] [1] Processed file test.txt
```
**nodiacritics_test.txt** file content:
```
ACDEEINORSTUUYZacdeeinorstuuyz
```
